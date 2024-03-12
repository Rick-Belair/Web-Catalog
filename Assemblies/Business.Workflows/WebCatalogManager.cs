using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Data;
using CallBaseCRM.Business.Entities;
using CallBaseCRM.DataAccess.Logic;
using CallBaseCRM.WebLang;

namespace CallBaseCRM.Business.Workflows
{
    public class WebCatalogManager
    {
        /// <summary>
        /// Instance variables
        /// </summary>
        private WebCatalogManagerDataService dataService;
        private string remoteIP;
        private string sessionID;
        private decimal decSessionID;

        /// <summary>
        /// 
        /// </summary>
        public WebCatalogManager(
            string remoteIP,
            string sessionID)
        {

            // Initialize the instance variables
            dataService = new WebCatalogManagerDataService();
            this.remoteIP = remoteIP;
            this.sessionID = sessionID;
            

            // Convert the session ID to a number so that it can be stored in a numeric field in the database

            string myChar;
            string allChars = "0123456789abcdefghijklmnopqrstuvwxyz";
            int pos;
            int c;
            decimal max;
            decimal i = 0;
            //max = decimal.MaxValue / (allChars.Length * 3) - 1;
            max = 30000000;

            for (c = 0; c < 24; c++)
            {
                myChar = this.sessionID.Substring(c, 1);
                pos = allChars.IndexOf(myChar);

                if (i < max)
                {
                    i = i * allChars.Length;
                    i = i + pos ;
                }
            }
            decSessionID = i;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lang"></param>
        /// <returns></returns>
        public DataSet GetCatalogCategories(
            string lang)
        {
            return dataService.GetCatalogCategories(lang);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="pubLang"></param>
        /// <param name="lang"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        public DataSet GetPublicationList(
            string pubLang,
            string lang,
            string category)
        {
            return dataService.GetPublicationList(pubLang, lang, category);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public DataSet GetPublicationList(
            Dictionary<string, string> values)
        {
            return dataService.GetPublicationList(values);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public T_Client GetClientByEmail(
            string email)
        {
            T_Client client = new T_Client();
            client.MapData(dataService.GetClientByEmail(email));

            return client;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public T_Client GetClientByName(
            string firstName,
            string lastName)
        {
            T_Client client = new T_Client();
            client.MapData(dataService.GetClientByName(firstName, lastName));

            return client;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lang"></param>
        /// <returns></returns>
        public DataSet GetProvinceList(
            string lang)
        {
            return dataService.GetProvinceList(lang);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lang"></param>
        /// <returns></returns>
        public DataSet GetAffiliationList(
            string lang)
        {
            return dataService.GetAffiliationList(lang);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="values"></param>
        /// <param name="basket"></param>
        /// <param name="oLang"></param>
        public string SaveData(
            Dictionary<string, string> values,
            Collection<BasketItem> basket,
            Language oLang)
        {
            int email_port;
            bool default_cred;
            string smtp_cred;
            bool ssl_flag;

            // Try and locate the client by the email address or name
            T_Client client = (values["email"] != null) ? GetClientByEmail(values["email"]) : GetClientByName(values["firstName"], values["lastName"]);
            
            // Fill in the relevant fields and add or update the existing record
            client.Salutation = values["salutation"];
            client.FirstName = values["firstName"];
            client.LastName = values["lastName"];
            client.Position = values["position"];
            client.Organization = values["organization"];
            client.Address = values["address"];
            client.Address2 = values["address2"];
            client.City = values["city"];
            client.Province = values["province"];
            client.PostalCode = values["postalCode"];
            client.Country = values["country"];
            client.Ctype = values["cType"];
            client.Phone = values["phone"];
            client.EMail = values["email"];
            client.Language = values["language"];
            if (client.CustNo == null)
            {
                client.DateIns = DateTime.Now;
                client.ToDelete = "False";
            }
            else
                client.DateVerified = DateTime.Now;

            // Save it
            client = T_Client.Get(client.Save());

            // Create a new T__CLIENT_ORDER entity and save it
            T_ClientOrder clientOrder = new T_ClientOrder();
            clientOrder.CustNo = client.CustNo;
            clientOrder.FirstName = client.FirstName;
            clientOrder.LastName = client.LastName;
            clientOrder.Position = client.Position;
            clientOrder.Organization = client.Organization;
            clientOrder.Address = client.Address;
            clientOrder.Address2 = client.Address2;
            clientOrder.City = client.City;
            clientOrder.ProvState = client.Province;
            clientOrder.PostalZip = client.PostalCode;
            clientOrder.Country = client.Country;
            clientOrder.TelWork = client.Phone + ((client.PhoneExt != null) ? " ext. " + client.PhoneExt : "");
            clientOrder.Email = client.EMail;
            clientOrder.Source = sessionID;
            clientOrder.DateIn = DateTime.Now;
            clientOrder.SubTotal = clientOrder.Sandh = 
                clientOrder.GST = clientOrder.PST = clientOrder.HST = clientOrder.TotalSale = 0m;
            clientOrder.OrdersShipped = "False";
            clientOrder.CustType = client.Ctype;
            clientOrder.Aboriginal = decimal.Parse(values["aboriginal"]);
            clientOrder = T_ClientOrder.Get(clientOrder.Save());

            // Update the constants table with the new invoice number
            FConstant constants = FConstant.Get();
            constants.InvoiceNo = clientOrder.OrderNo;
            constants.Save();

            // Dump the basket into T_PRODUCT_ORDER entities
            foreach (BasketItem bi in basket)
            {
                T_ProductOrder productOrder = new T_ProductOrder();
                productOrder.OrderNo = clientOrder.OrderNo;
                productOrder.CustNo = client.CustNo;
                productOrder.InvSeq = bi.InvSeq;
                productOrder.PODesc = (values["language"].Substring(0, 1) == "E") ? bi.Description : bi.DescriptionFr;
                productOrder.POQty = bi.Quantity;
                productOrder.Item = bi.Item;
                productOrder.PODateIns = DateTime.Now;
                productOrder.POUnitPrice = productOrder.POTotal = 0m;
                productOrder.PODone = "False";
                T_Inventory tInv = T_Inventory.Get(productOrder.Item);
                productOrder.POStatus = tInv.Status;
                productOrder.Save();
            }

            // Assemble and send the email
            if (values["email"] != "")
            {
                // Get the port number to use for sending email
                F_Control control = new F_Control();
                control = F_Control.Get("SMTP_PORT_WEB");
                if (control == null)
                {
                    email_port = 25;
                }
                else
                {
                    if (control.CNTR_VALUE != null)
                    {
                        try
                        {
                            email_port = Int32.Parse(control.CNTR_VALUE);
                        }
                        catch (Exception ex)
                        {
                            email_port = 25;
                        }
                    }
                    else
                    {
                        email_port = 25;
                    }
                }

                default_cred = true;
                control = F_Control.Get("SMTP_DEFLT_WEB");
                if (control == null)
                {
                    default_cred = true;
                }
                else if (control.CNTR_VALUE.ToUpper() == "NO" || control.CNTR_VALUE.ToUpper() == "FALSE")
                {
                    default_cred = false;
                }

                ssl_flag = false;
                control = F_Control.Get("SMTP_SSL_WEB");
                if (control != null)
                {
                    if (control.CNTR_VALUE.ToUpper() == "YES" || control.CNTR_VALUE.ToUpper() == "TRUE")
                    {
                        ssl_flag = true;
                    }
                }

                control = F_Control.Get("SMTP_CRED_WEB");
                smtp_cred = "";
                if (control != null)
                {
                    smtp_cred = control.CNTR_COMMENT;
                }

                oLang.SetLabel("ShippingResult");
                string emailShipping = oLang.GetLabel("AddressFormat");
                emailShipping = (values["salutation"] != "") 
                    ? emailShipping.Replace("[salutation]", values["salutation"])
                    : emailShipping.Replace("[salutation] ", "");
                emailShipping = emailShipping.Replace("[first_name]", values["firstName"]);
                emailShipping = emailShipping.Replace("[last_name]", values["lastName"]);

                if (values["position"] != "")
                    emailShipping = emailShipping.Replace("[job]", values["position"]);
                else
                    emailShipping = emailShipping.Replace("[job][CRLF]", "");

                if (values["organization"] != "")
                    emailShipping = emailShipping.Replace("[company]", values["organization"]);
                else
                    emailShipping = emailShipping.Replace("[company][CRLF]", "");

                emailShipping = emailShipping.Replace("[address1]", values["address"]);
                if (values["address2"] != "")
                    emailShipping = emailShipping.Replace("[address2]", values["address2"]);
                else
                    emailShipping = emailShipping.Replace("[address2][CRLF]", "");

                emailShipping = emailShipping.Replace("[city]", values["city"]);
                emailShipping = emailShipping.Replace("[province]", values["province"]);
                emailShipping = emailShipping.Replace("[postal_code]", values["postalCode"]);
                emailShipping = emailShipping.Replace("[country]", values["country"]);

                // Insert the line breaks
                emailShipping = emailShipping.Replace("[CRLF]", "\n");

                string emailBody = oLang.GetLabel("EmailBody");
                emailBody = emailBody.Replace("[shipping_address]", emailShipping);
                
                // Add the items ordered
                string emailOrders = "";
                bool oneStarPresent = false;
                bool twoStarPresent = false;
                foreach (BasketItem bi in basket)
                {
                    string stars = "";
                    if ((bi.Status == "B") || (bi.Status == "BackOrder"))
                    {
                        stars = " **";
                        twoStarPresent = true;
                    }
                    else if (bi.Quantity != null)
                    {
                        decimal available = GetQuantityAvailable(bi.Item);
                        if (available < bi.Quantity.Value)
                        {
                            stars = " *";
                            oneStarPresent = true;
                        }
                    }
                    emailOrders += "- " + ((oLang.CurrentLanguage == "E") ? bi.Description : bi.DescriptionFr) + ", " + bi.Quantity.ToString() 
                        + stars + "\n\n";
                }
                emailBody = emailBody.Replace("[pub_orders]", emailOrders);

                emailBody = emailBody.Replace("[CRLF]", "\n");
                emailBody += "\n" + oLang.GetLabel("ForInquiries") + "\n" +
                    oLang.GetLabel("ContactName").Replace("[CRLF]", "\n") + "\n" +
                    oLang.GetLabel("ContactPhone") + "\n" +
                    oLang.GetLabel("ContactEmail") + "\n\n";

                if (oneStarPresent)
                    emailBody += "\n* " + oLang.GetLabel("ItemUnAvail");
                if (twoStarPresent)
                    emailBody += "\n** " + oLang.GetLabel("ItemOnBackOrder");

                string emailSubject = oLang.GetLabel("EmailSubject").Replace("[order_no]", constants.InvoiceNo.Value.ToString());
                EmailManager eMan = new EmailManager();
                string errorMessage;
                eMan.SendMessage(constants.WebcatalogEmailServer,
                    email_port,
                    ssl_flag,
                    default_cred,
                    smtp_cred,
                    oLang.GetLabel("EmailFrom"),
                    new string[] { values["email"] },
                    new string[0],
                    new string[0],
                    emailSubject,
                    emailBody,
                    new string[0],
                    "Bad email address",
                    "Can't send email",
                    out errorMessage,
                    false);
            }

            return clientOrder.OrderNo.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public decimal GetNumberOfAvailableItems(
            string item)
        {
            // Calculate the number of items alredy committed
            DataSet ds = dataService.GetNumberOfCommittedFromOrdersInProcess(item);
            DataRow dr = ds.Tables[0].Rows[0];
            decimal committed = (dr["Committed"] != DBNull.Value) ? (decimal)dr["Committed"] : 0m;
            ds = dataService.GetNumberOfCommittedOnWebCataLog(item);
            dr = ds.Tables[0].Rows[0];
            if (dr["Committed"] != DBNull.Value)
                committed += (decimal)dr["Committed"];

            // Get the current # of availible items
            ds = dataService.GetNumberOnHandFromWarehouseInventory(item);
            dr = ds.Tables[0].Rows[0];
            decimal available = (dr["Available"] != DBNull.Value) ? (decimal)dr["Available"] : 0m;

            // Return the difference
            return (available - committed);
        }

        //
        // Get URL based on the product and document type
        //

        public string GetProductURL(
            string productCode,
            string type,
            string languate)
        {
            string returnValue;

            returnValue = "http://www.google.ca";
            // Calculate the number of items alredy committed
            //DataSet ds = dataService.GetProductRecord(productCode);
            //DataRow dr = ds.Tables[0].Rows[0];
            //dr = ds.Tables[0].Rows[0];
            return (returnValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="application"></param>
        /// <param name="module"></param>
        /// <param name="func"></param>
        /// <param name="details"></param>
        /// <param name="docType"></param>
        /// <param name="productCode"></param>
        /// <param name="language"></param>
        /// <param name="remoteIP"></param>
        public void LogActivity(
            string application,
            string module,
            string func,
            string details,
            string docType,
            string productCode,
            string language)
        {
            string s;
            s = sessionID.ToString();

            // Fill in an entity instance an save it to the database
            T_ApplTrack aptr = new T_ApplTrack();
            aptr.OccurredAt = DateTime.Now;
            aptr.IPAddress = remoteIP;
            aptr.SessionId = decSessionID;
            aptr.Application = application;
            aptr.Module = module;
            aptr.Function = func;
            aptr.Details = details;
            aptr.DocType = docType;
            aptr.ProductCode = productCode;
            aptr.UserLanguage = (language == "E") ? "EN" : "FR";
            aptr.Save();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public decimal GetQuantityAvailable(
            string item)
        {
            return dataService.GetQuantityAvailable(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="invSeq"></param>
        /// <param name="basket"></param>
        /// <returns></returns>
        public bool AddToBasket(
            decimal? invSeq,
            Collection<BasketItem> basket)
        {
            // Fetch the inventory item to be added
            T_Inventory inv = T_Inventory.Get(invSeq);

            // See if the item is already ins the basket
            BasketItem bi = new BasketItem();
            bi.InvSeq = inv.InvSeq;
            if (basket.IndexOf(bi) >= 0)
                return false;

            // Fill in and add the new item
            bi.Description = inv.Title;
            bi.DescriptionFr = inv.TitleAlternate;
            bi.Quantity = 1;
            bi.Item = inv.Item;
            bi.Status = (inv.Status == "B") ? "BackOrder" : "ShipOrder";
            bi.Price = inv.UnitPrice;
            bi.ShippingAndHandling = bi.GST = bi.HST = bi.PST = 0;
            bi.Quota = inv.InvQuota;
            bi.DateOfPublication = inv.InvDatePrinted;
            bi.NumberOfPages = inv.InvNumPages;
            basket.Add(bi);

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataSet GetPublicationYear()
        {
            return dataService.GetPublicationYear();
        }
    }
}
