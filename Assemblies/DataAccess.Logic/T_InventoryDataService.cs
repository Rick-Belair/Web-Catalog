using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using CallBaseCRM.Shared.DataAccess.Helper;

namespace CallBaseCRM.DataAccess.Logic
{
    public class T_InventoryDataService: DAHelper
    {
        /// <summary>
        /// 
        /// </summary>
        public T_InventoryDataService()
            : base()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="invSeq"></param>
        /// <returns></returns>
        public DataSet Get(
            decimal? invSeq)
        {
            string strSQL =
                @"SELECT *
                FROM T_Inventory
                WHERE INV_SEQ = :invSeq";
            DbParameter[] parms = new DbParameter[]
            {
                CreateParameter(":invSeq", DbType.Decimal, ValueOrNull(invSeq))
            };

            return Execute(strSQL, CommandType.Text, parms);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public DataSet Get(
            string item)
        {
            string strSQL =
                @"SELECT *
                FROM T_Inventory
                WHERE Item = :item";
            DbParameter[] parms = new DbParameter[]
            {
                CreateParameter(":item", DbType.String, ValueOrNull(item))
            };

            return Execute(strSQL, CommandType.Text, parms);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="invSeq"></param>
        /// <param name="item"></param>
        /// <param name="title"></param>
        /// <param name="titleAlternate"></param>
        /// <param name="language"></param>
        /// <param name="unitCost"></param>
        /// <param name="unitPrice"></param>
        /// <param name="gstExempt"></param>
        /// <param name="pstExempt"></param>
        /// <param name="status"></param>
        /// <param name="type"></param>
        /// <param name="invDate"></param>
        /// <param name="invNotes"></param>
        /// <param name="invDescription"></param>
        /// <param name="invIbsn"></param>
        /// <param name="invAuthor"></param>
        /// <param name="invAvailableOnline"></param>
        /// <param name="invPictureFilename"></param>
        /// <param name="invPdfFilename"></param>
        /// <param name="invFrDescription"></param>
        /// <param name="invQuota"></param>
        /// <param name="invStartDate"></param>
        /// <param name="invEndDate"></param>
        /// <param name="invPictureFilenameFr"></param>
        /// <param name="invPdfFilenameFr"></param>
        /// <param name="inventoryKit"></param>
        /// <param name="inventoryKitAdd"></param>
        /// <param name="inventoryAbstractEng"></param>
        /// <param name="inventoryAbstractFrench"></param>
        /// <param name="invDatePrinted"></param>
        /// <param name="invNumPages"></param>
        /// <param name="invOrderE"></param>
        /// <param name="invOrderF"></param>
        /// <param name="invHtmlBrk"></param>
        /// <param name="invPdfBrk"></param>
        public void Save(
            decimal? invSeq,
            string item,
            string title,
            string titleAlternate,
            string language,
            decimal? unitCost,
            decimal? unitPrice,
            string gstExempt,
            string pstExempt,
            string status,
            string type,
            DateTime? invDate,
            string invNotes,
            string invDescription,
            string invIbsn,
            string invAuthor,
            string invAvailableOnline,
            string invPictureFilename,
            string invPdfFilename,
            string invFrDescription,
            decimal? invQuota,
            DateTime? invStartDate,
            DateTime? invEndDate,
            string invPictureFilenameFr,
            string invPdfFilenameFr,
            decimal? inventoryKit,
            string inventoryKitAdd,
            string inventoryAbstractEng,
            string inventoryAbstractFrench,
            decimal? invDatePrinted,
            decimal? invNumPages,
            string invOrderE,
            string invOrderF,
            string invHtmlBrk,
            string invPdfBrk)
        {
            // Updates only
            string strSQL =
                @"UPDATE T_Inventory
                SET ITEM = :item,
                    TITLE = :title,
                    TITLE_ALTERNATE = :titleAlternate,
                    LANGUAGE = :language,
                    UNIT_COST = :unitCost,
                    UNIT_PRICE = :unitPrice,
                    GST_EXEMPT = :gstExempt,
                    PST_EXEMPT = :pstExempt,
                    STATUS = :status,
                    TYPE = :type,
                    INV_DATE = :invDate,
                    INV_NOTES = :invNotes,
                    INV_DESCRIPTION = :invDescription,
                    INV_IBSN = :invIbsn,
                    INV_AUTHOR = :invAuthor,
                    INV_AVAILABLE_ONLINE = :invAvailableOnline,
                    INV_PICTURE_FILENAME = :invPictureFilename,
                    INV_PDF_FILENAME = :invPdfFilename,
                    INV_FR_DESCRIPTION = :invFrDescription,
                    INV_QUOTA = :invQuota,
                    INV_START_DATE = :invStartDate,
                    INV_END_DATE = :invEndDate,
                    INV_PICTURE_FILENAME_FR = :invPictureFilenameFr,
                    INV_PDF_FILENAME_FR = :invPdfFilenameFr,
                    INVENTORY_KIT = :inventoryKit,
                    INVENTORY_KIT_ADD = :inventoryKitAdd,
                    INVENTORY_ABSTRACT_ENG = :inventoryAbstractEng,
                    INVENTORY_ABSTRACT_FRENCH = :inventoryAbstractFrench,
                    INV_DATE_PRINTED = :invDatePrinted,
                    INV_NUM_PAGES = :invNumPages,
                    INV_ORDER_E = :invOrderE,
                    INV_ORDER_F = :invOrderF,
                    INV_HTML_BRK = :invHtmlBrk,
                    INV_PDF_BRK = :invPdfBrk
                WHERE INV_SEQ = :invSeq";
            DbParameter[] parms = new DbParameter[]
            {
                CreateParameter(":invSeq", DbType.Decimal, ValueOrNull(invSeq)),
                CreateParameter(":item", DbType.String, ValueOrNull(item)),
                CreateParameter(":title", DbType.String, ValueOrNull(title)),
                CreateParameter(":titleAlternate", DbType.String, ValueOrNull(titleAlternate)),
                CreateParameter(":language", DbType.String, ValueOrNull(language)),
                CreateParameter(":unitCost", DbType.Decimal, ValueOrNull(unitCost)),
                CreateParameter(":unitPrice", DbType.Decimal, ValueOrNull(unitPrice)),
                CreateParameter(":gstExempt", DbType.String, ValueOrNull(gstExempt)),
                CreateParameter(":pstExempt", DbType.String, ValueOrNull(pstExempt)),
                CreateParameter(":status", DbType.String, ValueOrNull(status)),
                CreateParameter(":type", DbType.String, ValueOrNull(type)),
                CreateParameter(":invDate", DbType.DateTime, ValueOrNull(invDate)),
                CreateParameter(":invNotes", DbType.String, ValueOrNull(invNotes)),
                CreateParameter(":invDescription", DbType.String, ValueOrNull(invDescription)),
                CreateParameter(":invIbsn", DbType.String, ValueOrNull(invIbsn)),
                CreateParameter(":invAuthor", DbType.String, ValueOrNull(invAuthor)),
                CreateParameter(":invAvailableOnline", DbType.String, ValueOrNull(invAvailableOnline)),
                CreateParameter(":invPictureFilename", DbType.String, ValueOrNull(invPictureFilename)),
                CreateParameter(":invPdfFilename", DbType.String, ValueOrNull(invPdfFilename)),
                CreateParameter(":invFrDescription", DbType.String, ValueOrNull(invFrDescription)),
                CreateParameter(":invQuota", DbType.Decimal, ValueOrNull(invQuota)),
                CreateParameter(":invStartDate", DbType.DateTime, ValueOrNull(invStartDate)),
                CreateParameter(":invEndDate", DbType.DateTime, ValueOrNull(invEndDate)),
                CreateParameter(":invPictureFilenameFr", DbType.String, ValueOrNull(invPictureFilenameFr)),
                CreateParameter(":invPdfFilenameFr", DbType.String, ValueOrNull(invPdfFilenameFr)),
                CreateParameter(":inventoryKit", DbType.Decimal, ValueOrNull(inventoryKit)),
                CreateParameter(":inventoryKitAdd", DbType.String, ValueOrNull(inventoryKitAdd)),
                CreateParameter(":inventoryAbstractEng", DbType.String, ValueOrNull(inventoryAbstractEng)),
                CreateParameter(":inventoryAbstractFrench", DbType.String, ValueOrNull(inventoryAbstractFrench)),
                CreateParameter(":invDatePrinted", DbType.Decimal, ValueOrNull(invDatePrinted)),
                CreateParameter(":invNumPages", DbType.Decimal, ValueOrNull(invNumPages)),
                CreateParameter(":invOrderE", DbType.String, ValueOrNull(invOrderE)),
                CreateParameter(":invOrderF", DbType.String, ValueOrNull(invOrderF)),
                CreateParameter(":invHtmlBrk", DbType.String, ValueOrNull(invHtmlBrk)),
                CreateParameter(":invPdfBrk", DbType.String, ValueOrNull(invPdfBrk))
            };

            ExecuteNonQuery(strSQL, CommandType.Text, parms);
        }
    }
}
