using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using CallBaseCRM.Shared.DataAccess.Helper;

namespace CallBaseCRM.DataAccess.Logic
{
    public class WebCatalogManagerDataService: DAHelper
    {
        /// <summary>
        /// 
        /// </summary>
        public WebCatalogManagerDataService()
            : base()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lang"></param>
        /// <returns></returns>
        public DataSet GetCatalogCategories(
            string lang)
        {
            string suffix = (lang == "E") ? "" : "_Fr";
            string strSQL =
                @"SELECT DISTINCT T_PRODUCT_TYPE.Pt_Code, Pt_Definition" + suffix + @" AS Pt_Definition
                 FROM T_WEB_CATALOG INNER JOIN T_PRODUCT_TYPE ON T_WEB_CATALOG.wc_pt_seq =T_PRODUCT_TYPE.Pt_Seq
                 ORDER BY Pt_Definition" + suffix;

            return Execute(strSQL, CommandType.Text);
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
            string strSQL;

            switch (pubLang)
            {
                case "E":
                    strSQL =
                        @"select distinct inv_seq, item,  " + ((lang == "F") ? "Title_Alternate as Title" : "Title") + @", inv_ibsn, 
                            INVENTORY_ABSTRACT_ENG as inv_picture_filename, inv_pdf_filename, Status, Unit_Price, 
                            INV_END_DATE, LANGUAGE, INV_DATE_PRINTED, INV_NUM_PAGES, INV_ORDER_E, INV_ORDER_F, 
                            INV_QUOTA, INV_HTML_BRK, INV_PDF_BRK, INV_DESCRIPTION, INV_FR_DESCRIPTION
                        from T_WEB_CATALOG join T_PRODUCT_TYPE on T_WEB_CATALOG.wc_pt_seq = T_PRODUCT_TYPE.Pt_Seq 
                            join T_INVENTORY on T_WEB_CATALOG.wc_inv_seq = T_INVENTORY.inv_seq
                        where Language in ('B','E') and (Status in ('A','B','N','E') or inv_pdf_filename is not null)
                            and T_PRODUCT_TYPE.Pt_Code = :category
                        order by INV_ORDER_E";
                    break;

                case "F":
                    strSQL =
                        @"select distinct inv_seq, item,  " + ((lang == "F") ? "Title_Alternate as Title" : "Title") + @", inv_ibsn, 
                            INVENTORY_ABSTRACT_ENG as inv_picture_filename, inv_pdf_filename, Status, Unit_Price, 
                            INV_END_DATE, LANGUAGE, INV_DATE_PRINTED, INV_NUM_PAGES, INV_ORDER_E, INV_ORDER_F, 
                            INV_QUOTA, INV_HTML_BRK, INV_PDF_BRK, INV_DESCRIPTION, INV_FR_DESCRIPTION
                        from T_WEB_CATALOG join T_PRODUCT_TYPE on T_WEB_CATALOG.wc_pt_seq = T_PRODUCT_TYPE.Pt_Seq 
                            join T_INVENTORY on T_WEB_CATALOG.wc_inv_seq = T_INVENTORY.inv_seq
                        where Language in ('B','F') and (Status in ('A','B','N','E') or inv_pdf_filename is not null)
                            and T_PRODUCT_TYPE.Pt_Code = :category
                        order by INV_ORDER_F";
                    break;

                case "B":
                    strSQL =
                        @"select distinct inv_seq, item,  " + ((lang == "F") ? "Title_Alternate as Title" : "Title") + @", inv_ibsn, 
                            INVENTORY_ABSTRACT_ENG as inv_picture_filename, inv_pdf_filename, Status, Unit_Price, 
                            INV_END_DATE, LANGUAGE, INV_DATE_PRINTED, INV_NUM_PAGES, INV_ORDER_E, INV_ORDER_F, 
                            INV_QUOTA, INV_HTML_BRK, INV_PDF_BRK, INV_DESCRIPTION, INV_FR_DESCRIPTION
                        from T_WEB_CATALOG join T_PRODUCT_TYPE on T_WEB_CATALOG.wc_pt_seq = T_PRODUCT_TYPE.Pt_Seq 
                            join T_INVENTORY on T_WEB_CATALOG.wc_inv_seq = T_INVENTORY.inv_seq
                        where (Status in ('A','B','N','E') or inv_pdf_filename is not null)
                            and T_PRODUCT_TYPE.Pt_Code = :category
                        order by INV_ORDER_E";
                    break;

                default:
                    strSQL = null;
                    break;
            }

            DbParameter[] parms = new DbParameter[]
            {
                CreateParameter(":category", DbType.String, category)
            };

            return Execute(strSQL, CommandType.Text, parms);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public DataSet GetPublicationList(
            Dictionary<string, string> values)
        {
            string strSQL = null;
            Collection<DbParameter> paramCol = new Collection<DbParameter>();

            string abstractField = null;

            try
            {
                if ((values["PubLang"] == "E") || (values["PubLang"] == "F"))
                    abstractField = (values["PubLang"] == "E") ? "INVENTORY_ABSTRACT_ENG" : "INVENTORY_ABSTRACT_FRENCH";
                else if (values["PubLang"] == "B")
                    abstractField = (values["Lang"] == "E") ? "INVENTORY_ABSTRACT_ENG" : "INVENTORY_ABSTRACT_FRENCH";
            }
            catch
            {
                abstractField = "INVENTORY_ABSTRACT_ENG";
                values["Lang"] = "E";
                values["PubLang"] = "E";
            }

            // Fix problem of duplicated product orders by removing the PT_code. (which was not 'distinct'). Fixed Jun2014
            //if (values["Lang"] == "E")
            //    strSQL =
            //        @"SELECT DISTINCT inv_seq, item,  Title, inv_ibsn, " + abstractField + @" as inv_picture_filename, inv_pdf_filename, Status, 
            //        Unit_Price, INV_END_DATE, LANGUAGE, NVL(INV_DATE_PRINTED, 0) AS PubDatePrinted, INV_NUM_PAGES, INV_ORDER_E, INV_ORDER_F, INV_QUOTA, 
            //        INV_HTML_BRK, INV_PDF_BRK, INV_DESCRIPTION, INV_FR_DESCRIPTION, INV_AUTHOR, T_PRODUCT_TYPE.Pt_Code" + "\n";
            //else if (values["Lang"] == "F")
            //    strSQL =
            //        @"SELECT DISTINCT inv_seq, item,  Title_Alternate AS Title, inv_ibsn, " + abstractField + @" as inv_picture_filename, inv_pdf_filename_fr AS inv_pdf_filename, Status, 
            //        Unit_Price, INV_END_DATE, LANGUAGE, NVL(INV_DATE_PRINTED, 0) AS PubDatePrinted, INV_NUM_PAGES, INV_ORDER_E, INV_ORDER_F, INV_QUOTA, 
            //        INV_HTML_BRK, INV_PDF_BRK, INV_DESCRIPTION, INV_FR_DESCRIPTION, INV_AUTHOR, T_PRODUCT_TYPE.Pt_Code" + "\n";
            if (values["Lang"] == "E")
                strSQL =
                    @"SELECT DISTINCT inv_seq, item,  Title, inv_ibsn, " + abstractField + @" as inv_picture_filename, inv_pdf_filename, Status, 
                    Unit_Price, INV_END_DATE, LANGUAGE, NVL(INV_DATE_PRINTED, 0) AS PubDatePrinted, INV_NUM_PAGES, INV_ORDER_E, INV_ORDER_F, INV_QUOTA, 
                    INV_HTML_BRK, INV_PDF_BRK, INV_DESCRIPTION, INV_FR_DESCRIPTION, INV_AUTHOR" + "\n";
            else if (values["Lang"] == "F")
                strSQL =
                    @"SELECT DISTINCT inv_seq, item,  Title_Alternate AS Title, inv_ibsn, " + abstractField + @" as inv_picture_filename, inv_pdf_filename_fr AS inv_pdf_filename, Status, 
                    Unit_Price, INV_END_DATE, LANGUAGE, NVL(INV_DATE_PRINTED, 0) AS PubDatePrinted, INV_NUM_PAGES, INV_ORDER_E, INV_ORDER_F, INV_QUOTA, 
                    INV_HTML_BRK, INV_PDF_BRK, INV_DESCRIPTION, INV_FR_DESCRIPTION, INV_AUTHOR" + "\n";

            // Add the FROM clause
            strSQL +=
                @"FROM T_WEB_CATALOG INNER JOIN T_PRODUCT_TYPE ON T_WEB_CATALOG.wc_pt_seq = T_PRODUCT_TYPE.Pt_Seq 
                    INNER JOIN T_INVENTORY ON T_WEB_CATALOG.wc_inv_seq = T_INVENTORY.inv_seq" + "\n";

            // Start on the where clause 
            string pdfFileName = (values["Lang"] == "E") ? "inv_pdf_filename" : "inv_pdf_filename_fr";
            switch (values["PubLang"])
            {
                case "E":
                    strSQL +=
                        @"WHERE (Language in ('B','E')) 
                            AND ((Status in ('A','B','N','E')) OR (inv_pdf_filename IS NOT NULL))" + "\n";
                    break;

                case "F":
                    strSQL +=
                        @"WHERE (Language in ('B','F')) 
                            AND ((Status in ('A','B','N','E')) OR (inv_pdf_filename_fr IS NOT NULL))" + "\n";
                    break;

                case "B":
                    strSQL +=
                        @"WHERE ((Status in ('A','B','N','E')) OR (" + pdfFileName + @" IS NOT NULL))" + "\n";
                    break;

                default:
                    break;
            }

            // Add additional fields to the where clause
            if (values.ContainsKey("Category"))
            {

                if ((values["Category"].Trim() != "") && (values["Category"].Trim() != "All"))
                {
                    strSQL +=
                        "AND (T_PRODUCT_TYPE.Pt_Code = :category)\n";
                    paramCol.Add(CreateParameter(":category", DbType.String, values["Category"].Trim()));
                }
            }

            if ((values.ContainsKey("SearchField")) && (values["SearchField"].Trim() != ""))
            {
                string searchField = values["SearchField"].Trim();
                string titleField = (values["Lang"] == "E") ? "TITLE" : "TITLE_ALTERNATE";
                strSQL += string.Format("AND (LOWER({0}) LIKE LOWER('%' || :searchField || '%'))\n", titleField);
                paramCol.Add(CreateParameter(":searchField", DbType.String, searchField));
            }

            if (values.ContainsKey("YearFrom"))
            {
                string yearFrom = values["YearFrom"].Trim();
                string yearTo = values["YearTo"].Trim();
                if ((yearFrom.Length > 2) || (yearTo.Length > 2))   // Check to make sure its a proper 4 digit year
                {
                    if ((yearFrom.Length > 2) && (yearTo.Length > 2))
                    {
                        strSQL += "AND (INV_DATE_PRINTED BETWEEN :yearFrom AND :yearTo)\n";
                        decimal loVal = decimal.Parse(yearFrom);
                        decimal hiVal = decimal.Parse(yearTo);
                        if (loVal > hiVal)
                        {
                            decimal tmpVal = loVal;
                            loVal = hiVal;
                            hiVal = tmpVal;
                        }
                        paramCol.Add(CreateParameter(":yearFrom", DbType.Decimal, loVal));
                        paramCol.Add(CreateParameter(":yearTo", DbType.Decimal, hiVal));
                    }
                    else if (yearFrom.Length > 2)
                    {
                        strSQL += "AND (INV_DATE_PRINTED >= :yearFrom)\n";
                        paramCol.Add(CreateParameter(":yearFrom", DbType.Decimal, decimal.Parse(yearFrom)));
                    }
                    else if (yearTo.Length > 2)
                    {
                        strSQL += "AND (INV_DATE_PRINTED <= :yearTo)\n";
                        paramCol.Add(CreateParameter(":yearTo", DbType.Decimal, decimal.Parse(yearTo)));
                    }
                }
            }

            if ((values.ContainsKey("ISBN")) && (values["ISBN"].Trim() != ""))
            {
                strSQL += "AND (LOWER(INV_IBSN) LIKE LOWER('%' || :isbn || '%'))\n";
                paramCol.Add(CreateParameter(":isbn", DbType.String, values["ISBN"].ToString()));
            }

            if ((values.ContainsKey("CatNumber")) && (values["CatNumber"].Trim() != ""))
            {
                strSQL += "AND (LOWER(ITEM) LIKE LOWER('%' || :catNumber || '%'))\n";
                paramCol.Add(CreateParameter(":catNumber", DbType.String, values["CatNumber"].Trim()));
            }

            if ((values.ContainsKey("Author")) && (values["Author"].Trim() != ""))
            {
                strSQL += "AND (LOWER(INV_AUTHOR) LIKE LOWER('%' || :author || '%'))\n";
                paramCol.Add(CreateParameter(":author", DbType.String, values["Author"].Trim()));
            }

            // Now add the advanced search phrase crap
            if (values.ContainsKey("AllWords"))
            {
                if (values["AllWords"].Trim() != "")
                {
                    string[] words = values["AllWords"].Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string word in words)
                    {
                        switch (values["PubLang"])
                        {
                            case "B":
                                strSQL += string.Format(@"AND ((LOWER(Title_Alternate) LIKE '%{0}%') 
                                                            OR (LOWER(Inv_Fr_Description) LIKE '%{0}%')
                                                            OR (LOWER(Title) LIKE '%{0}')
                                                            OR (LOWER(Inv_Description) LIKE '%{0}%'))" + "\n",
                                                word.Replace("'", "''").ToLower());
                                break;

                            case "E":
                                strSQL += string.Format(@"AND ((LOWER(Title) LIKE '%{0}%') 
                                                            OR (LOWER(Inv_Description) LIKE '%{0}%'))" + "\n",
                                                word.Replace("'", "''").ToLower());
                                break;

                            case "F":
                                strSQL += string.Format(@"AND ((LOWER(Title_Alternate) LIKE '%{0}%') 
                                                            OR (LOWER(Inv_Fr_Description) LIKE '%{0}%'))" + "\n",
                                                word.Replace("'", "''").ToLower());
                                break;

                            default:
                                break;
                        }
                    }
                }

                if (values["ExactPhrase"].Trim() != "")
                {
                    string exactPhrase = values["ExactPhrase"].Trim();
                    switch (values["PubLang"])
                    {
                        case "B":
                            strSQL += string.Format(@"AND ((LOWER(Title_Alternate) LIKE '%{0}%') 
                                                            OR (LOWER(Inv_Fr_Description) LIKE '%{0}%')
                                                            OR (LOWER(Title) LIKE '%{0}')
                                                            OR (LOWER(Inv_Description) LIKE '%{0}%'))" + "\n",
                                            exactPhrase.Replace("'", "''").ToLower());
                            break;

                        case "E":
                            strSQL += string.Format(@"AND ((LOWER(Title) LIKE '%{0}%') 
                                                            OR (LOWER(Inv_Description) LIKE '%{0}%'))" + "\n",
                                            exactPhrase.Replace("'", "''").ToLower());
                            break;

                        case "F":
                            strSQL += string.Format(@"AND ((LOWER(Title_Alternate) LIKE '%{0}%') 
                                                            OR (LOWER(Inv_Fr_Description) LIKE '%{0}%'))" + "\n",
                                            exactPhrase.Replace("'", "''").ToLower());
                            break;

                        default:
                            break;
                    }
                }

                if (values["AnyWord"].Trim() != "")
                {
                    string[] words = values["AnyWord"].Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < words.Length; i++)
                    {
                        strSQL += ((i == 0) ? "AND (" : "OR ");
                        
                        switch (values["PubLang"])
                        {
                            case "B":
                                strSQL += string.Format(@"((LOWER(Title_Alternate) LIKE '%{0}%') 
                                                            OR (LOWER(Inv_Fr_Description) LIKE '%{0}%')
                                                            OR (LOWER(Title) LIKE '%{0}')
                                                            OR (LOWER(Inv_Description) LIKE '%{0}%'))",
                                                words[i].Replace("'", "''").ToLower());
                                break;

                            case "E":
                                strSQL += string.Format(@"((LOWER(Title) LIKE '%{0}%') 
                                                            OR (LOWER(Inv_Description) LIKE '%{0}%'))",
                                                words[i].Replace("'", "''").ToLower());
                                break;

                            case "F":
                                strSQL += string.Format(@"((LOWER(Title_Alternate) LIKE '%{0}%') 
                                                            OR (LOWER(Inv_Fr_Description) LIKE '%{0}%'))",
                                                words[i].Replace("'", "''").ToLower());
                                break;

                            default:
                                break;
                        }
                        
                        strSQL += ((i != (words.Length - 1)) ? "\n" : ")\n");
                    }
                }

                if (values["Without"].Trim() != "")
                {
                    string[] words = values["Without"].Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string word in words)
                    {
                        switch (values["PubLang"])
                        {
                            case "B":
                                strSQL += string.Format(@"AND (LOWER(NVL(Title_Alternate, ' ')) NOT LIKE '%{0}%') 
                                                        AND (LOWER(NVL(Inv_Fr_Description, ' ')) NOT LIKE '%{0}%')
                                                        AND (LOWER(NVL(Title, ' ')) NOT LIKE '%{0}')
                                                        AND (LOWER(NVL(Inv_Description, ' ')) NOT LIKE '%{0}%')" + "\n",
                                                word.Replace("'", "''").ToLower());
                                break;

                            case "E":
                                strSQL += string.Format(@"AND (LOWER(NVL(Title, ' ')) NOT LIKE '%{0}%') 
                                                        AND (LOWER(NVL(Inv_Description, ' ')) NOT LIKE '%{0}%')" + "\n",
                                                word.Replace("'", "''").ToLower());
                                break;

                            case "F":
                                strSQL += string.Format(@"AND (LOWER(NVL(Title_Alternate, ' ')) NOT LIKE '%{0}%') 
                                                        AND (LOWER(NVL(Inv_Fr_Description, ' ')) NOT LIKE '%{0}%')" + "\n",
                                                word.Replace("'", "''").ToLower());
                                break;

                            default:
                                break;
                        }
                    }
                }
            }

            // Add the the order clause
            if (values.ContainsKey("Sort"))
            {
                string field = null;
                string direction = "ASC";
                switch (values["Sort"])
                {
                    case "T":
                        field = (values["Lang"] == "E") ? "INV_ORDER_E" : "INV_ORDER_F";
                        break;

                    case "D":
                        field = "PubDatePrinted";
                        direction = "DESC";
                        break;

                    case "A":
                        field = "INV_AUTHOR";
                        break;

                    default:
                        break;
                }

                strSQL += string.Format("ORDER BY {0} {1}", field, direction);
            }
            else
                strSQL += "ORDER BY " + ((values["Lang"] == "E") ? "INV_ORDER_E" : "INV_ORDER_F");

            DbParameter[] parms = new DbParameter[paramCol.Count];
            paramCol.CopyTo(parms, 0);

            return Execute(strSQL, CommandType.Text, parms);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public DataSet GetClientByEmail(
            string email)
        {
            string strSQL =
                @"SELECT *
                FROM T_CLIENT
                WHERE LOWER(E_MAIL) = LOWER(:email)";
            DbParameter[] parms = new DbParameter[]
            {
                CreateParameter(":email", DbType.String, ValueOrNull(email))
            };

            return Execute(strSQL, CommandType.Text, parms);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public DataSet GetClientByName(
            string firstName,
            string lastName)
        {
            string strSQL =
                @"SELECT *
                FROM T_CLIENT
                WHERE (LOWER(FIRSTNAME) = LOWER(:firstName))
                    AND (LOWER(LASTNAME) = LOWER(:lastName))";
            DbParameter[] parms = new DbParameter[]
            {
                CreateParameter(":firstName", DbType.String, ValueOrNull(firstName)),
                CreateParameter(":lastName", DbType.String, ValueOrNull(lastName))
            };

            return Execute(strSQL, CommandType.Text, parms);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lang"></param>
        /// <returns></returns>
        public DataSet GetProvinceList(
            string lang)
        {
            string namePart = (lang == "E") ? "" : "F";
            string strSQL =
                @"SELECT PROV_CODE AS CODE, PROV_" + namePart + @"DEFINITION AS DEFINITION
                FROM FPROV_CODES
                WHERE (PROV_INACTIVE = 0)
                    AND (UPPER(PROV_CODE) NOT IN ('US', 'XX', 'ZZ'))
                ORDER BY UPPER(PROV_" + namePart + @"DEFINITION)";

            return Execute(strSQL, CommandType.Text);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lang"></param>
        /// <returns></returns>
        public DataSet GetAffiliationList(
            string lang)
        {
            string suffix = (lang == "E") ? "" : "_FR";
            string strSQL =
                @"SELECT AFF_CODE, AFF_GEN_DEF" + suffix + @" AS GEN_DEF
                FROM F_AFFILIATION
                WHERE AFF_WEBCAT_DISPLAY = 'YES'";

            return Execute(strSQL, CommandType.Text);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public DataSet GetNumberOfCommittedFromOrdersInProcess(
            string item)
        {
            string strSQL =
                @"SELECT SUM(OIP_QTY) AS Committed
                FROM ORDERS_IN_PROCESS
                WHERE (OIP_INV_CODE = :item)
                    AND (OIP_WH IN (1,2))";
            DbParameter[] parms = new DbParameter[]
            {
                CreateParameter(":item", DbType.String, ValueOrNull(item))
            };

            return Execute(strSQL, CommandType.Text, parms);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public DataSet GetNumberOfCommittedOnWebCataLog(
            string item)
        {
            string strSQL =
                @"SELECT SUM(p.PO_QTY) AS Committed
                FROM T_PRODUCT_ORDER p INNER JOIN T_CLIENT_ORDER c ON p.ORDER_NO = c.ORDER_NO
                WHERE (p.ITEM = :item)
                    AND (c.SENT_TO_CALLBASE  is null)
                    AND (c.PROCESS_STATUS = 0)";
            DbParameter[] parms = new DbParameter[]
            {
                CreateParameter(":item", DbType.String, ValueOrNull(item))
            };

            return Execute(strSQL, CommandType.Text, parms);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public DataSet GetNumberOnHandFromWarehouseInventory(
            string item)
        {
            string strSQL =
                @"SELECT SUM(WI_QTY_ONHAND) AS Available
                FROM F_WAREHOUSE_INV
                WHERE (WI_INV_CODE = :item)
                    AND (WI_WH_NUM IN (1,2))";
            DbParameter[] parms = new DbParameter[]
            {
                CreateParameter(":item", DbType.String, ValueOrNull(item))
            };

            return Execute(strSQL, CommandType.Text, parms);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public decimal GetQuantityAvailable(
            string item)
        {
            string strSQL =
                "WEB_CATALOG.GET_QUANTITY_AVAILABLE";
            DbParameter[] parms = new DbParameter[]
            {
                CreateParameter("p_ItemCode", DbType.String, ValueOrNull(item)),
                CreateParameter("returnValue", DbType.Decimal, 0)
            };

            parms[1].Direction = ParameterDirection.ReturnValue;
            ExecuteNonQuery(strSQL, CommandType.StoredProcedure, parms);

            return (parms[1].Value != DBNull.Value) ? (decimal)parms[1].Value : -111111;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataSet GetPublicationYear()
        {
            string strSQL =
                @"select Distinct(INV_DATE_PRINTED) AS Year
                from T_WEB_CATALOG 
                join T_PRODUCT_TYPE on T_WEB_CATALOG.wc_pt_seq=T_PRODUCT_TYPE.Pt_Seq 
                join T_INVENTORY on T_WEB_CATALOG.wc_inv_seq=T_INVENTORY.inv_seq 
                WHERE length(INV_DATE_PRINTED) = 4
                order by INV_DATE_PRINTED";

            return Execute(strSQL, CommandType.Text);

        }
    }
   
}
