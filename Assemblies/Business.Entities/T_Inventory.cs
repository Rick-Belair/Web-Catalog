using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CallBaseCRM.DataAccess.Logic;

namespace CallBaseCRM.Business.Entities
{
    public class T_Inventory: BaseObject
    {
        /// <summary>
        /// Instance varaibles
        /// </summary>
        private decimal? _InvSeq;
        private decimal? _PtSeq;
        private decimal? _PaSeq;
        private string _Item;
        private string _Title;
        private string _TitleAlternate;
        private string _Language;
        private decimal? _UnitCost;
        private decimal? _UnitPrice;
        private string _GstExempt;
        private string _PstExempt;
        private string _Status;
        private string _Type;
        private decimal? _QtyOnHand;
        private decimal? _QtyCommited;
        private decimal? _InvOriginalQty;
        private DateTime? _InvDate;
        private decimal? _QtyToDate;
        private string _InvNotes;
        private string _InvDescription;
        private string _InvYn;
        private string _InvActivity;
        private string _InvExpired;
        private string _InvSupplier;
        private string _InvIbsn;
        private string _InvCopyrightYear;
        private string _InvNumPage;
        private string _InvIllustrated;
        private string _InvAuthor;
        private string _InvLocation;
        private string _InvAvailableOnline;
        private string _InvPictureFilename;
        private string _InvPdfFilename;
        private string _InvFrDescription;
        private decimal? _InvQuota;
        private DateTime? _InvStartDate;
        private DateTime? _InvEndDate;
        private string _InvPictureFilenameFr;
        private string _InvPdfFilenameFr;
        private string _InvSh01;
        private string _InvSh02;
        private string _InvSh03;
        private string _InvSh04;
        private string _InvSh05;
        private string _InvSh06;
        private string _InvSh07;
        private string _InvSh08;
        private string _InvSh09;
        private string _InvSh10;
        private string _InvSh11;
        private string _InvSh12;
        private string _InvSh13;
        private string _InvSh14;
        private string _InvSh15;
        private string _InvSh16;
        private string _InvSh17;
        private string _InvSh18;
        private string _InvSh19;
        private string _InvSh20;
        private string _InvSh21;
        private string _InvSh22;
        private string _InvSh23;
        private string _InvSh24;
        private string _InvSh25;
        private decimal? _InventoryKit;
        private string _InventoryKitAdd;
        private string _InventoryAbstractEng;
        private string _InventoryAbstractFrench;
        private decimal? _InvDatePrinted;
        private decimal? _InvNumPages;
        private string _InvOrderE;
        private string _InvOrderF;
        private string _InvHtmlBrk;
        private string _InvPdfBrk;

        /// <summary>
        /// Property getter/setters
        /// </summary>
        public decimal? InvSeq
        {
            get { return _InvSeq; }
            set { _InvSeq = value; }
        }

        public decimal? PtSeq
        {
            get { return _PtSeq; }
        }

        public decimal? PaSeq
        {
            get { return _PaSeq; }
        }

        public string Item
        {
            get { return _Item; }
            set { _Item = FixUpString(value); }
        }

        public string Title
        {
            get { return _Title; }
            set { _Title = FixUpString(value); }
        }

        public string TitleAlternate
        {
            get { return _TitleAlternate; }
            set { _TitleAlternate = FixUpString(value); }
        }

        public string Language
        {
            get { return _Language; }
            set { _Language = FixUpString(value); }
        }

        public decimal? UnitCost
        {
            get { return _UnitCost; }
            set { _UnitCost = value; }
        }

        public decimal? UnitPrice
        {
            get { return _UnitPrice; }
            set { _UnitPrice = value; }
        }

        public string GstExempt
        {
            get { return _GstExempt; }
            set { _GstExempt = FixUpString(value); }
        }

        public string PstExempt
        {
            get { return _PstExempt; }
            set { _PstExempt = FixUpString(value); }
        }

        public string Status
        {
            get { return _Status; }
            set { _Status = FixUpString(value); }
        }

        public string Type
        {
            get { return _Type; }
            set { _Type = FixUpString(value); }
        }

        public decimal? QtyOnHand
        {
            get { return _QtyOnHand; }
        }

        public decimal? QtyCommited
        {
            get { return _QtyCommited; }
        }

        public decimal? InvOriginalQty
        {
            get { return _InvOriginalQty; }
        }

        public DateTime? InvDate
        {
            get { return _InvDate; }
            set { _InvDate = value; }
        }

        public decimal? QtyToDate
        {
            get { return _QtyToDate; }
            set { _QtyToDate = value; }
        }

        public string InvNotes
        {
            get { return _InvNotes; }
            set { _InvNotes = FixUpString(value); }
        }

        public string InvDescription
        {
            get { return _InvDescription; }
            set { _InvDescription = FixUpString(value); }
        }

        public string InvYn
        {
            get { return _InvYn; }
        }

        public string InvActivity
        {
            get { return _InvActivity; }
       }

        public string InvExpired
        {
            get { return _InvExpired; }
        }

        public string InvSupplier
        {
            get { return _InvSupplier; }
        }

        public string InvIbsn
        {
            get { return _InvIbsn; }
            set { _InvIbsn = FixUpString(value); }
        }

        public string InvCopyrightYear
        {
            get { return _InvCopyrightYear; }
        }

        public string InvNumPage
        {
            get { return _InvNumPage; }
        }

        public string InvIllustrated
        {
            get { return _InvIllustrated; }
        }

        public string InvAuthor
        {
            get { return _InvAuthor; }
            set { _InvAuthor = FixUpString(value); }
        }

        public string InvLocation
        {
            get { return _InvLocation; }
        }

        public string InvAvailableOnline
        {
            get { return _InvAvailableOnline; }
            set { _InvAvailableOnline = FixUpString(value); }
        }

        public string InvPictureFilename
        {
            get { return _InvPictureFilename; }
            set { _InvPictureFilename = FixUpString(value); }
        }

        public string InvPdfFilename
        {
            get { return _InvPdfFilename; }
            set { _InvPdfFilename = FixUpString(value); }
        }

        public string InvFrDescription
        {
            get { return _InvFrDescription; }
            set { _InvFrDescription = FixUpString(value); }
        }

        public decimal? InvQuota
        {
            get { return _InvQuota; }
            set { _InvQuota = value; }
        }

        public DateTime? InvStartDate
        {
            get { return _InvStartDate; }
            set { _InvStartDate = value; }
        }

        public DateTime? InvEndDate
        {
            get { return _InvEndDate; }
            set { _InvEndDate = value; }
        }

        public string InvPictureFilenameFr
        {
            get { return _InvPictureFilenameFr; }
            set { _InvPictureFilenameFr = FixUpString(value); }
        }

        public string InvPdfFilenameFr
        {
            get { return _InvPdfFilenameFr; }
            set { _InvPdfFilenameFr = FixUpString(value); }
        }

        public string InvSh01
        {
            get { return _InvSh01; }
        }

        public string InvSh02
        {
            get { return _InvSh02; }
        }

        public string InvSh03
        {
            get { return _InvSh03; }
        }

        public string InvSh04
        {
            get { return _InvSh04; }
        }

        public string InvSh05
        {
            get { return _InvSh05; }
        }

        public string InvSh06
        {
            get { return _InvSh06; }
        }

        public string InvSh07
        {
            get { return _InvSh07; }
        }

        public string InvSh08
        {
            get { return _InvSh08; }
        }

        public string InvSh09
        {
            get { return _InvSh09; }
        }

        public string InvSh10
        {
            get { return _InvSh10; }
        }

        public string InvSh11
        {
            get { return _InvSh11; }
        }

        public string InvSh12
        {
            get { return _InvSh12; }
        }

        public string InvSh13
        {
            get { return _InvSh13; }
        }

        public string InvSh14
        {
            get { return _InvSh14; }
        }

        public string InvSh15
        {
            get { return _InvSh15; }
        }

        public string InvSh16
        {
            get { return _InvSh16; }
        }

        public string InvSh17
        {
            get { return _InvSh17; }
        }

        public string InvSh18
        {
            get { return _InvSh18; }
        }

        public string InvSh19
        {
            get { return _InvSh19; }
        }

        public string InvSh20
        {
            get { return _InvSh20; }
        }

        public string InvSh21
        {
            get { return _InvSh21; }
        }

        public string InvSh22
        {
            get { return _InvSh22; }
        }

        public string InvSh23
        {
            get { return _InvSh23; }
        }

        public string InvSh24
        {
            get { return _InvSh24; }
        }

        public string InvSh25
        {
            get { return _InvSh25; }
        }

        public decimal? InventoryKit
        {
            get { return _InventoryKit; }
        }

        public string InventoryKitAdd
        {
            get { return _InventoryKitAdd; }
            set { _InventoryKitAdd = FixUpString(value); }
        }

        public string InventoryAbstractEng
        {
            get { return _InventoryAbstractEng; }
            set { _InventoryAbstractEng = FixUpString(value); }
        }

        public string InventoryAbstractFrench
        {
            get { return _InventoryAbstractFrench; }
            set { _InventoryAbstractFrench = FixUpString(value); }
        }

        public decimal? InvDatePrinted
        {
            get { return _InvDatePrinted; }
            set { _InvDatePrinted = value; }
        }

        public decimal? InvNumPages
        {
            get { return _InvNumPages; }
            set { _InvNumPages = value; }
        }

        public string InvOrderE
        {
            get { return _InvOrderE; }
            set { _InvOrderE = FixUpString(value); }
        }

        public string InvOrderF
        {
            get { return _InvOrderF; }
            set { _InvOrderF = FixUpString(value); }
        }

        public string InvHtmlBrk
        {
            get { return _InvHtmlBrk; }
            set { _InvHtmlBrk = FixUpString(value); }
        }

        public string InvPdfBrk
        {
            get { return _InvPdfBrk; }
            set { _InvPdfBrk = FixUpString(value); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        public override void MapData(DataRow row)
        {
            _InvSeq = GetDecimal(row, "INV_SEQ");
            _PtSeq = GetDecimal(row, "PT_SEQ");
            _PaSeq = GetDecimal(row, "PA_SEQ");
            _Item = GetString(row, "ITEM");
            _Title = GetString(row, "TITLE");
            _TitleAlternate = GetString(row, "TITLE_ALTERNATE");
            _Language = GetString(row, "LANGUAGE");
            _UnitCost = GetDecimal(row, "UNIT_COST");
            _UnitPrice = GetDecimal(row, "UNIT_PRICE");
            _GstExempt = GetString(row, "GST_EXEMPT");
            _PstExempt = GetString(row, "PST_EXEMPT");
            _Status = GetString(row, "STATUS");
            _Type = GetString(row, "TYPE");
            _QtyOnHand = GetDecimal(row, "QTY_ON_HAND");
            _QtyCommited = GetDecimal(row, "QTY_COMMITED");
            _InvOriginalQty = GetDecimal(row, "INV_ORIGINAL_QTY");
            _InvDate = GetDateTime(row, "INV_DATE");
            _QtyToDate = GetDecimal(row, "QTY_TO_DATE");
            _InvNotes = GetString(row, "INV_NOTES");
            _InvDescription = GetString(row, "INV_DESCRIPTION");
            _InvYn = GetString(row, "INV_YN");
            _InvActivity = GetString(row, "INV_ACTIVITY");
            _InvExpired = GetString(row, "INV_EXPIRED");
            _InvSupplier = GetString(row, "INV_SUPPLIER");
            _InvIbsn = GetString(row, "INV_IBSN");
            _InvCopyrightYear = GetString(row, "INV_COPYRIGHT_YEAR");
            _InvNumPage = GetString(row, "INV_NUM_PAGE");
            _InvIllustrated = GetString(row, "INV_ILLUSTRATED");
            _InvAuthor = GetString(row, "INV_AUTHOR");
            _InvLocation = GetString(row, "INV_LOCATION");
            _InvAvailableOnline = GetString(row, "INV_AVAILABLE_ONLINE");
            _InvPictureFilename = GetString(row, "INV_PICTURE_FILENAME");
            _InvPdfFilename = GetString(row, "INV_PDF_FILENAME");
            _InvFrDescription = GetString(row, "INV_FR_DESCRIPTION");
            _InvQuota = GetDecimal(row, "INV_QUOTA");
            _InvStartDate = GetDateTime(row, "INV_START_DATE");
            _InvEndDate = GetDateTime(row, "INV_END_DATE");
            _InvPictureFilenameFr = GetString(row, "INV_PICTURE_FILENAME_FR");
            _InvPdfFilenameFr = GetString(row, "INV_PDF_FILENAME_FR");
            _InvSh01 = GetString(row, "INV_SH_01");
            _InvSh02 = GetString(row, "INV_SH_02");
            _InvSh03 = GetString(row, "INV_SH_03");
            _InvSh04 = GetString(row, "INV_SH_04");
            _InvSh05 = GetString(row, "INV_SH_05");
            _InvSh06 = GetString(row, "INV_SH_06");
            _InvSh07 = GetString(row, "INV_SH_07");
            _InvSh08 = GetString(row, "INV_SH_08");
            _InvSh09 = GetString(row, "INV_SH_09");
            _InvSh10 = GetString(row, "INV_SH_10");
            _InvSh11 = GetString(row, "INV_SH_11");
            _InvSh12 = GetString(row, "INV_SH_12");
            _InvSh13 = GetString(row, "INV_SH_13");
            _InvSh14 = GetString(row, "INV_SH_14");
            _InvSh15 = GetString(row, "INV_SH_15");
            _InvSh16 = GetString(row, "INV_SH_16");
            _InvSh17 = GetString(row, "INV_SH_17");
            _InvSh18 = GetString(row, "INV_SH_18");
            _InvSh19 = GetString(row, "INV_SH_19");
            _InvSh20 = GetString(row, "INV_SH_20");
            _InvSh21 = GetString(row, "INV_SH_21");
            _InvSh22 = GetString(row, "INV_SH_22");
            _InvSh23 = GetString(row, "INV_SH_23");
            _InvSh24 = GetString(row, "INV_SH_24");
            _InvSh25 = GetString(row, "INV_SH_25");
            _InventoryKit = GetDecimal(row, "INVENTORY_KIT");
            _InventoryKitAdd = GetString(row, "INVENTORY_KIT_ADD");
            _InventoryAbstractEng = GetString(row, "INVENTORY_ABSTRACT_ENG");
            _InventoryAbstractFrench = GetString(row, "INVENTORY_ABSTRACT_FRENCH");
            _InvDatePrinted = GetDecimal(row, "INV_DATE_PRINTED");
            _InvNumPages = GetDecimal(row, "INV_NUM_PAGES");
            _InvOrderE = GetString(row, "INV_ORDER_E");
            _InvOrderF = GetString(row, "INV_ORDER_F");
            _InvHtmlBrk = GetString(row, "INV_HTML_BRK");
            _InvPdfBrk = GetString(row, "INV_PDF_BRK");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="invSeq"></param>
        /// <returns></returns>
        public static T_Inventory Get(
            decimal? invSeq)
        {
            T_Inventory inv = new T_Inventory();
            inv.MapData(new T_InventoryDataService().Get(invSeq));

            return inv;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static T_Inventory Get(
            string item)
        {
            T_Inventory inv = new T_Inventory();
            inv.MapData(new T_InventoryDataService().Get(item));

            return inv;
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
        public static void Save(
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
            new T_InventoryDataService().Save(
                invSeq, item, title, titleAlternate, language,
                unitCost, unitPrice, gstExempt, pstExempt, status,
                type, invDate, invNotes, invDescription, invIbsn,
                invAuthor, invAvailableOnline, invPictureFilename, invPdfFilename, invFrDescription,
                invQuota, invStartDate, invEndDate, invPictureFilenameFr, invPdfFilenameFr,
                inventoryKit, inventoryKitAdd, inventoryAbstractEng, inventoryAbstractFrench, invDatePrinted,
                invNumPages, invOrderE, invOrderF, invHtmlBrk, invPdfBrk);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Save()
        {
            Save(
                InvSeq, Item, Title, TitleAlternate, Language,
                UnitCost, UnitPrice, GstExempt, PstExempt, Status,
                Type, InvDate, InvNotes, InvDescription, InvIbsn,
                InvAuthor, InvAvailableOnline, InvPictureFilename, InvPdfFilename, InvFrDescription,
                InvQuota, InvStartDate, InvEndDate, InvPictureFilenameFr, InvPdfFilenameFr,
                InventoryKit, InventoryKitAdd, InventoryAbstractEng, InventoryAbstractFrench, InvDatePrinted,
                InvNumPages, InvOrderE, InvOrderF, InvHtmlBrk, InvPdfBrk);
        }
    }
}
