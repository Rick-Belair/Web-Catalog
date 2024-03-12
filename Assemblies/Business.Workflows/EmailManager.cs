using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Net;
using System.Net.Mail;
using CallBaseCRM.DataAccess.Logic;
using CallBaseCRM.Business.Entities;

namespace CallBaseCRM.Business.Workflows
{
    public class EmailManager
    {
        public bool SendMessage(
            string server,
            int port,
            bool use_ssl,
            bool use_default_cred,
            string cred,
            string from,
            string[] to,
            string[] cc,
            string[] bcc,
            string subject,
            string body,
            string[] attachments,
            string badEmailAddressMsgText,
            string cantSendToEmailAddressMsgText,
            out string errorMessage)
        {
            return SendMessage(server, port, use_ssl, use_default_cred, cred, from, to, cc, bcc, subject, body, attachments, badEmailAddressMsgText,
                        cantSendToEmailAddressMsgText, out errorMessage, false);
        }

        public bool SendMessage(
            string server,
            int port,
            bool use_ssl,
            bool use_default_cred,
            string cred,
            string from,
            string[] to,
            string[] cc,
            string[] bcc,
            string subject,
            string body,
            string[] attachments,
            string badEmailAddressMsgText,
            string cantSendToEmailAddressMsgText,
            out string errorMessage,
            bool isHTML)
        {
            // Set up the mailing list structures
            MailMessage message = new MailMessage();
            message.IsBodyHtml = isHTML;
            message.From = new MailAddress(from);
            message.Subject = subject;
            message.Body = body;
            foreach (string fileName in attachments)
                message.Attachments.Add(new Attachment(fileName));
            errorMessage = "";
            bool addressesAdded = false;

            // Add the "To" List addresses
            AddReceipientsToMessage(message.To, to, ref errorMessage, badEmailAddressMsgText,
                                    ref addressesAdded);

            // Add the "cc" List addresses
            AddReceipientsToMessage(message.CC, cc, ref errorMessage, badEmailAddressMsgText,
                                    ref addressesAdded);

            // Add the "bcc" List addresses
            AddReceipientsToMessage(message.Bcc, bcc, ref errorMessage, badEmailAddressMsgText,
                                    ref addressesAdded);

            // Terminate any dangling HTML in the error message
            if (errorMessage != "")
                errorMessage += "</ul>";

            // If any valid email addreses were added
            if (addressesAdded)
            {
                // Try and send the message
                SmtpClient smtpClient = new SmtpClient(server);
                smtpClient.Port = port;

                if (use_ssl == true)
                {
                    smtpClient.EnableSsl = true;
                }

                if (use_default_cred == false)
                {
                    string[] cred_array = cred.Split('/');  // Split user ID/password
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential(cred_array[0], cred_array[1]);
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                }
                try
                {                
                    smtpClient.Send(message);
                    message.Dispose();                   

                }
                catch (SmtpFailedRecipientsException ex)
                {
                    // Add the email address(s) to the list
                    if (errorMessage != "")
                        errorMessage += "<br />";
                    errorMessage += cantSendToEmailAddressMsgText + "<ul>";

                    for (int i = 0; i < ex.InnerExceptions.Length; i++)
                    {
                        string rcpt = ex.InnerExceptions[i].FailedRecipient;
                        rcpt = rcpt.Replace("<", "&lt;").Replace(">", "&gt;");
                        errorMessage += "<li>" + rcpt + "</li>";
                    }
                }
                catch (SmtpFailedRecipientException ex)
                {
                    if (errorMessage != "")
                        errorMessage += "<br />";
                    errorMessage += ex.Message + "<ul>";
                    errorMessage += "</li>" + ex.FailedRecipient.Replace("<", "&lt;").Replace(">", "&gt;") + "</li>";
                }
                catch (Exception ex)
                {
                    if (errorMessage != "")
                        errorMessage += "<br />";
                    errorMessage += ex.Message + "<ul>";
                    errorMessage += "</li>" + "" + "</li>";
                }
            }

            return (errorMessage == "");
        }

        private void AddReceipientsToMessage(
            MailAddressCollection mac,
            string[] addrs,
            ref string errorMessage,
            string badEmailAddressMsgText,
            ref bool addressesAdded)
        {
            // Add the addresses to to the list
            foreach (string addr in addrs)
            {
                try
                {
                    mac.Add(new MailAddress(addr));
                    addressesAdded = true;
                }
                catch (FormatException)
                {
                    if (errorMessage == "")
                        errorMessage = badEmailAddressMsgText + "<ul>";
                    errorMessage += "<li>" + addr + "</li>";
                }
            }
        }
    }
}
