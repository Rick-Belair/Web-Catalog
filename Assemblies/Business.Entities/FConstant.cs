using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CallBaseCRM.DataAccess.Logic;

namespace CallBaseCRM.Business.Entities
{
    /// <summary>
    /// Instance variables
    /// </summary>
    public class FConstant:BaseObject
    {
        private decimal? _ConstSeq;
        private decimal? _InventoryRecNo;
        private decimal? _Conmacs;
        private decimal? _Customer;
        private decimal? _InventoryCode;
        private decimal? _Conlabels;
        private decimal? _ConfreezeInv;
        private decimal? _ConrefModule;
        private decimal? _HiRecNo;
        private DateTime? _TransDate;
        private string _Month;
        private string _Id;
        private decimal? _Thermal;
        private decimal? _RecHi;
        private string _Owner;
        private decimal? _Badge;
        private decimal? _PdcFee;
        private decimal? _BankFee;
        private decimal? _CashOut;
        private string _Ver;
        private string _PathPic;
        private string _OdbcSecurity;
        private string _Dpath;
        private string _Upath;
        private string _Remote;
        private decimal? _Gst;
        private decimal? _Pst;
        private string _Password;
        private string _Conmac;
        private string _UrlSurvey;
        private string _Ownfr;
        private decimal? _Markup;
        private string _DirImport;
        private string _DirDone;
        private string _Import;
        private decimal? _InvoiceNo;
        private string _Pic;
        private string _Pos;
        private string _City;
        private string _Prov;
        private decimal? _Refund;
        private string _OpenCash;
        private decimal? _WoNum;
        private decimal? _InvNo;
        private string _GstNo;
        private string _Logo;
        private string _EmailServer;
        private string _EmailAddress;
        private string _OwnerName;
        private string _OwnerAddress;
        private string _OwnerAddress2;
        private string _Autofind;
        private string _AccountPrompt;
        private string _AutoaddClients;
        private string _ProfitTrack;
        private string _LaserPrinter;
        private string _LabelPrinter;
        private string _LastYearEnd;
        private DateTime? _ReorderReport;
        private string _TrackWh2;
        private string _OfficeRef;
        private string _EmailService;
        private string _CnicCustomerId;
        private string _InternalLabel;
        private string _OwnerPhone;
        private string _OwnerTollfree;
        private string _OwnerFax;
        private decimal? _TaskDefaultSnooze;
        private string _EnforceUniqueKeywords;
        private string _EmailOrders;
        private decimal? _EmailorderSeq;
        private string _ExtraQs;
        private string _ForceProvCode;
        private string _BrowserPath;
        private string _TrackWh1;
        private string _FooterImage;
        private string _FtrImgAlt;
        private DateTime? _SkandataSync;
        private string _WebcatalogUrl;
        private string _WebcatalogEmailServer;
        private string _EmailAlerts;
        private string _WebcatShowCusttype;
        private string _Privacy;
        private string _SubjectMandatory;
        private string _CidmRequestUrl;
        private string _SingleRefType;
        private string _LdapLogon;
        private string _WindowsAuthentication;

        /// <summary>
        /// Property getter/setters
        /// </summary>
        public decimal? ConstSeq
        {
            get { return _ConstSeq; }
            set { _ConstSeq = value; }
        }

        public decimal? InventoryRecNo
        {
            get { return _InventoryRecNo; }
            set { _InventoryRecNo = value; }
        }

        public decimal? Conmacs
        {
            get { return _Conmacs; }
            set { _Conmacs = value; }
        }

        public decimal? Customer
        {
            get { return _Customer; }
            set { _Customer = value; }
        }

        public decimal? InventoryCode
        {
            get { return _InventoryCode; }
            set { _InventoryCode = value; }
        }

        public decimal? Conlabels
        {
            get { return _Conlabels; }
            set { _Conlabels = value; }
        }

        public decimal? ConfreezeInv
        {
            get { return _ConfreezeInv; }
            set { _ConfreezeInv = value; }
        }

        public decimal? ConrefModule
        {
            get { return _ConrefModule; }
            set { _ConrefModule = value; }
        }

        public decimal? HiRecNo
        {
            get { return _HiRecNo; }
            set { _HiRecNo = value; }
        }

        public DateTime? TransDate
        {
            get { return _TransDate; }
            set { _TransDate = value; }
        }

        public string Month
        {
            get { return _Month; }
            set { _Month = FixUpString(value); }
        }

        public string Id
        {
            get { return _Id; }
            set { _Id = FixUpString(value); }
        }

        public decimal? Thermal
        {
            get { return _Thermal; }
            set { _Thermal = value; }
        }

        public decimal? RecHi
        {
            get { return _RecHi; }
            set { _RecHi = value; }
        }

        public string Owner
        {
            get { return _Owner; }
            set { _Owner = FixUpString(value); }
        }

        public decimal? Badge
        {
            get { return _Badge; }
            set { _Badge = value; }
        }

        public decimal? PdcFee
        {
            get { return _PdcFee; }
            set { _PdcFee = value; }
        }

        public decimal? BankFee
        {
            get { return _BankFee; }
            set { _BankFee = value; }
        }

        public decimal? CashOut
        {
            get { return _CashOut; }
            set { _CashOut = value; }
        }

        public string Ver
        {
            get { return _Ver; }
            set { _Ver = FixUpString(value); }
        }

        public string PathPic
        {
            get { return _PathPic; }
            set { _PathPic = FixUpString(value); }
        }

        public string OdbcSecurity
        {
            get { return _OdbcSecurity; }
            set { _OdbcSecurity = FixUpString(value); }
        }

        public string Dpath
        {
            get { return _Dpath; }
            set { _Dpath = FixUpString(value); }
        }

        public string Upath
        {
            get { return _Upath; }
            set { _Upath = FixUpString(value); }
        }

        public string Remote
        {
            get { return _Remote; }
            set { _Remote = FixUpString(value); }
        }

        public decimal? Gst
        {
            get { return _Gst; }
            set { _Gst = value; }
        }

        public decimal? Pst
        {
            get { return _Pst; }
            set { _Pst = value; }
        }

        public string Password
        {
            get { return _Password; }
            set { _Password = FixUpString(value); }
        }

        public string Conmac
        {
            get { return _Conmac; }
            set { _Conmac = FixUpString(value); }
        }

        public string UrlSurvey
        {
            get { return _UrlSurvey; }
            set { _UrlSurvey = FixUpString(value); }
        }

        public string Ownfr
        {
            get { return _Ownfr; }
            set { _Ownfr = FixUpString(value); }
        }

        public decimal? Markup
        {
            get { return _Markup; }
            set { _Markup = value; }
        }

        public string DirImport
        {
            get { return _DirImport; }
            set { _DirImport = FixUpString(value); }
        }

        public string DirDone
        {
            get { return _DirDone; }
            set { _DirDone = FixUpString(value); }
        }

        public string Import
        {
            get { return _Import; }
            set { _Import = FixUpString(value); }
        }

        public decimal? InvoiceNo
        {
            get { return _InvoiceNo; }
            set { _InvoiceNo = value; }
        }

        public string Pic
        {
            get { return _Pic; }
            set { _Pic = FixUpString(value); }
        }

        public string Pos
        {
            get { return _Pos; }
            set { _Pos = FixUpString(value); }
        }

        public string City
        {
            get { return _City; }
            set { _City = FixUpString(value); }
        }

        public string Prov
        {
            get { return _Prov; }
            set { _Prov = FixUpString(value); }
        }

        public decimal? Refund
        {
            get { return _Refund; }
            set { _Refund = value; }
        }

        public string OpenCash
        {
            get { return _OpenCash; }
            set { _OpenCash = FixUpString(value); }
        }

        public decimal? WoNum
        {
            get { return _WoNum; }
            set { _WoNum = value; }
        }

        public decimal? InvNo
        {
            get { return _InvNo; }
            set { _InvNo = value; }
        }

        public string GstNo
        {
            get { return _GstNo; }
            set { _GstNo = FixUpString(value); }
        }

        public string Logo
        {
            get { return _Logo; }
            set { _Logo = FixUpString(value); }
        }

        public string EmailServer
        {
            get { return _EmailServer; }
            set { _EmailServer = FixUpString(value); }
        }

        public string EmailAddress
        {
            get { return _EmailAddress; }
            set { _EmailAddress = FixUpString(value); }
        }

        public string OwnerName
        {
            get { return _OwnerName; }
            set { _OwnerName = FixUpString(value); }
        }

        public string OwnerAddress
        {
            get { return _OwnerAddress; }
            set { _OwnerAddress = FixUpString(value); }
        }

        public string OwnerAddress2
        {
            get { return _OwnerAddress2; }
            set { _OwnerAddress2 = FixUpString(value); }
        }

        public string Autofind
        {
            get { return _Autofind; }
            set { _Autofind = FixUpString(value); }
        }

        public string AccountPrompt
        {
            get { return _AccountPrompt; }
            set { _AccountPrompt = FixUpString(value); }
        }

        public string AutoaddClients
        {
            get { return _AutoaddClients; }
            set { _AutoaddClients = FixUpString(value); }
        }

        public string ProfitTrack
        {
            get { return _ProfitTrack; }
            set { _ProfitTrack = FixUpString(value); }
        }

        public string LaserPrinter
        {
            get { return _LaserPrinter; }
            set { _LaserPrinter = FixUpString(value); }
        }

        public string LabelPrinter
        {
            get { return _LabelPrinter; }
            set { _LabelPrinter = FixUpString(value); }
        }

        public string LastYearEnd
        {
            get { return _LastYearEnd; }
            set { _LastYearEnd = FixUpString(value); }
        }

        public DateTime? ReorderReport
        {
            get { return _ReorderReport; }
            set { _ReorderReport = value; }
        }

        public string TrackWh2
        {
            get { return _TrackWh2; }
            set { _TrackWh2 = FixUpString(value); }
        }

        public string OfficeRef
        {
            get { return _OfficeRef; }
            set { _OfficeRef = FixUpString(value); }
        }

        public string EmailService
        {
            get { return _EmailService; }
            set { _EmailService = FixUpString(value); }
        }

        public string CnicCustomerId
        {
            get { return _CnicCustomerId; }
            set { _CnicCustomerId = FixUpString(value); }
        }

        public string InternalLabel
        {
            get { return _InternalLabel; }
            set { _InternalLabel = FixUpString(value); }
        }

        public string OwnerPhone
        {
            get { return _OwnerPhone; }
            set { _OwnerPhone = FixUpString(value); }
        }

        public string OwnerTollfree
        {
            get { return _OwnerTollfree; }
            set { _OwnerTollfree = FixUpString(value); }
        }

        public string OwnerFax
        {
            get { return _OwnerFax; }
            set { _OwnerFax = FixUpString(value); }
        }

        public decimal? TaskDefaultSnooze
        {
            get { return _TaskDefaultSnooze; }
            set { _TaskDefaultSnooze = value; }
        }

        public string EnforceUniqueKeywords
        {
            get { return _EnforceUniqueKeywords; }
            set { _EnforceUniqueKeywords = FixUpString(value); }
        }

        public string EmailOrders
        {
            get { return _EmailOrders; }
            set { _EmailOrders = FixUpString(value); }
        }

        public decimal? EmailorderSeq
        {
            get { return _EmailorderSeq; }
            set { _EmailorderSeq = value; }
        }

        public string ExtraQs
        {
            get { return _ExtraQs; }
            set { _ExtraQs = FixUpString(value); }
        }

        public string ForceProvCode
        {
            get { return _ForceProvCode; }
            set { _ForceProvCode = FixUpString(value); }
        }

        public string BrowserPath
        {
            get { return _BrowserPath; }
            set { _BrowserPath = FixUpString(value); }
        }

        public string TrackWh1
        {
            get { return _TrackWh1; }
            set { _TrackWh1 = FixUpString(value); }
        }

        public string FooterImage
        {
            get { return _FooterImage; }
            set { _FooterImage = FixUpString(value); }
        }

        public string FtrImgAlt
        {
            get { return _FtrImgAlt; }
            set { _FtrImgAlt = FixUpString(value); }
        }

        public DateTime? SkandataSync
        {
            get { return _SkandataSync; }
            set { _SkandataSync = value; }
        }

        public string WebcatalogUrl
        {
            get { return _WebcatalogUrl; }
            set { _WebcatalogUrl = FixUpString(value); }
        }

        public string WebcatalogEmailServer
        {
            get { return _WebcatalogEmailServer; }
            set { _WebcatalogEmailServer = FixUpString(value); }
        }

        public string EmailAlerts
        {
            get { return _EmailAlerts; }
            set { _EmailAlerts = FixUpString(value); }
        }

        public string WebcatShowCusttype
        {
            get { return _WebcatShowCusttype; }
            set { _WebcatShowCusttype = FixUpString(value); }
        }

        public string Privacy
        {
            get { return _Privacy; }
            set { _Privacy = FixUpString(value); }
        }

        public string SubjectMandatory
        {
            get { return _SubjectMandatory; }
            set { _SubjectMandatory = FixUpString(value); }
        }

        public string CidmRequestUrl
        {
            get { return _CidmRequestUrl; }
            set { _CidmRequestUrl = FixUpString(value); }
        }

        public string SingleRefType
        {
            get { return _SingleRefType; }
            set { _SingleRefType = FixUpString(value); }
        }

        public string LdapLogon
        {
            get { return _LdapLogon; }
            set { _LdapLogon = FixUpString(value); }
        }

        public string WindowsAuthentication
        {
            get { return _WindowsAuthentication; }
            set { _WindowsAuthentication = FixUpString(value); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        public override void MapData(DataRow row)
        {
            _ConstSeq = GetDecimal(row, "CONSTSEQ");
            _InventoryRecNo = GetDecimal(row, "CON_INVENTORY_REC_NO");
            _Conmacs = GetDecimal(row, "CONMACS");
            _Customer = GetDecimal(row, "CON_CUSTOMER");
            _InventoryCode = GetDecimal(row, "CON_INVENTORY_CODE");
            _Conlabels = GetDecimal(row, "CONLABELS");
            _ConfreezeInv = GetDecimal(row, "CONFREEZE_INV");
            _ConrefModule = GetDecimal(row, "CONREF_MODULE");
            _HiRecNo = GetDecimal(row, "CON_HI_REC_NO");
            _TransDate = GetDateTime(row, "CON_TRANS_DATE");
            _Month = GetString(row, "CON_MONTH");
            _Id = GetString(row, "CON_ID");
            _Thermal = GetDecimal(row, "CON_THERMAL");
            _RecHi = GetDecimal(row, "CON_REC_HI");
            _Owner = GetString(row, "CON_OWNER");
            _Badge = GetDecimal(row, "CON_BADGE");
            _PdcFee = GetDecimal(row, "CON_PDC_FEE");
            _BankFee = GetDecimal(row, "CON_BANK_FEE");
            _CashOut = GetDecimal(row, "CON_CASH_OUT");
            _Ver = GetString(row, "CON_VER");
            _PathPic = GetString(row, "CON_PATH_PIC");
            _OdbcSecurity = GetString(row, "CON_ODBC_SECURITY");
            _Dpath = GetString(row, "CON_DPATH");
            _Upath = GetString(row, "CON_UPATH");
            _Remote = GetString(row, "CON_REMOTE");
            _Gst = GetDecimal(row, "CON_GST");
            _Pst = GetDecimal(row, "CON_PST");
            _Password = GetString(row, "CON_PASSWORD");
            _Conmac = GetString(row, "CONMAC");
            _UrlSurvey = GetString(row, "CON_URL_SURVEY");
            _Ownfr = GetString(row, "CON_OWNFR");
            _Markup = GetDecimal(row, "CON_MARKUP");
            _DirImport = GetString(row, "CON_DIR_IMPORT");
            _DirDone = GetString(row, "CON_DIR_DONE");
            _Import = GetString(row, "CON_IMPORT");
            _InvoiceNo = GetDecimal(row, "CON_INVOICE_NO");
            _Pic = GetString(row, "CON_PIC");
            _Pos = GetString(row, "CON_POS");
            _City = GetString(row, "CON_CITY");
            _Prov = GetString(row, "CON_PROV");
            _Refund = GetDecimal(row, "CON_REFUND");
            _OpenCash = GetString(row, "CON_OPEN_CASH");
            _WoNum = GetDecimal(row, "CON_WO_NUM");
            _InvNo = GetDecimal(row, "CON_INV_NO");
            _GstNo = GetString(row, "CON_GST_NO");
            _Logo = GetString(row, "CON_LOGO");
            _EmailServer = GetString(row, "CON_EMAIL_SERVER");
            _EmailAddress = GetString(row, "CON_EMAIL_ADDRESS");
            _OwnerName = GetString(row, "CON_OWNER_NAME");
            _OwnerAddress = GetString(row, "CON_OWNER_ADDRESS");
            _OwnerAddress2 = GetString(row, "CON_OWNER_ADDRESS2");
            _Autofind = GetString(row, "CON_AUTOFIND");
            _AccountPrompt = GetString(row, "CON_ACCOUNT_PROMPT");
            _AutoaddClients = GetString(row, "CON_AUTOADD_CLIENTS");
            _ProfitTrack = GetString(row, "CON_PROFIT_TRACK");
            _LaserPrinter = GetString(row, "CON_LASER_PRINTER");
            _LabelPrinter = GetString(row, "CON_LABEL_PRINTER");
            _LastYearEnd = GetString(row, "CON_LAST_YEAR_END");
            _ReorderReport = GetDateTime(row, "CON_REORDER_REPORT");
            _TrackWh2 = GetString(row, "CON_TRACK_WH2");
            _OfficeRef = GetString(row, "CON_OFFICE_REF");
            _EmailService = GetString(row, "CON_EMAIL_SERVICE");
            _CnicCustomerId = GetString(row, "CON_CNIC_CUSTOMER_ID");
            _InternalLabel = GetString(row, "CON_INTERNAL_LABEL");
            _OwnerPhone = GetString(row, "CON_OWNER_PHONE");
            _OwnerTollfree = GetString(row, "CON_OWNER_TOLLFREE");
            _OwnerFax = GetString(row, "CON_OWNER_FAX");
            _TaskDefaultSnooze = GetDecimal(row, "CON_TASK_DEFAULT_SNOOZE");
            _EnforceUniqueKeywords = GetString(row, "CON_ENFORCE_UNIQUE_KEYWORDS");
            _EmailOrders = GetString(row, "CON_EMAIL_ORDERS");
            _EmailorderSeq = GetDecimal(row, "CON_EMAILORDER_SEQ");
            _ExtraQs = GetString(row, "CON_EXTRA_QS");
            _ForceProvCode = GetString(row, "CON_FORCE_PROV_CODE");
            _BrowserPath = GetString(row, "CON_BROWSER_PATH");
            _TrackWh1 = GetString(row, "CON_TRACK_WH1");
            _FooterImage = GetString(row, "CON_FOOTER_IMAGE");
            _FtrImgAlt = GetString(row, "CON_FTR_IMG_ALT");
            _SkandataSync = GetDateTime(row, "CON_SKANDATA_SYNC");
            _WebcatalogUrl = GetString(row, "CON_WEBCATALOG_URL");
            _WebcatalogEmailServer = GetString(row, "CON_WEBCATALOG_EMAIL_SERVER");
            _EmailAlerts = GetString(row, "CON_EMAIL_ALERTS");
            _WebcatShowCusttype = GetString(row, "CON_WEBCAT_SHOW_CUSTTYPE");
            _Privacy = GetString(row, "CON_PRIVACY");
            _SubjectMandatory = GetString(row, "CON_SUBJECT_MANDATORY");
            _CidmRequestUrl = GetString(row, "CIDM_REQUEST_URL");
            _SingleRefType = GetString(row, "CON_SINGLE_REF_TYPE");
            _LdapLogon = GetString(row, "CON_LDAP_LOGON");
            _WindowsAuthentication = GetString(row, "CON_WINDOWS_AUTHENTICATION");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static FConstant Get()
        {
            FConstant constants = new FConstant();
            constants.MapData(new FConstantDataService().Get());

            return constants;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inventoryRecNo"></param>
        /// <param name="conmacs"></param>
        /// <param name="customer"></param>
        /// <param name="inventoryCode"></param>
        /// <param name="conlabels"></param>
        /// <param name="confreezeInv"></param>
        /// <param name="conrefModule"></param>
        /// <param name="hiRecNo"></param>
        /// <param name="transDate"></param>
        /// <param name="month"></param>
        /// <param name="id"></param>
        /// <param name="thermal"></param>
        /// <param name="recHi"></param>
        /// <param name="owner"></param>
        /// <param name="badge"></param>
        /// <param name="pdcFee"></param>
        /// <param name="bankFee"></param>
        /// <param name="cashOut"></param>
        /// <param name="ver"></param>
        /// <param name="pathPic"></param>
        /// <param name="odbcSecurity"></param>
        /// <param name="dpath"></param>
        /// <param name="upath"></param>
        /// <param name="remote"></param>
        /// <param name="gst"></param>
        /// <param name="pst"></param>
        /// <param name="password"></param>
        /// <param name="conmac"></param>
        /// <param name="urlSurvey"></param>
        /// <param name="ownfr"></param>
        /// <param name="markup"></param>
        /// <param name="dirImport"></param>
        /// <param name="dirDone"></param>
        /// <param name="import"></param>
        /// <param name="invoiceNo"></param>
        /// <param name="pic"></param>
        /// <param name="pos"></param>
        /// <param name="city"></param>
        /// <param name="prov"></param>
        /// <param name="refund"></param>
        /// <param name="openCash"></param>
        /// <param name="woNum"></param>
        /// <param name="invNo"></param>
        /// <param name="gstNo"></param>
        /// <param name="logo"></param>
        /// <param name="emailServer"></param>
        /// <param name="emailAddress"></param>
        /// <param name="ownerName"></param>
        /// <param name="ownerAddress"></param>
        /// <param name="ownerAddress2"></param>
        /// <param name="autofind"></param>
        /// <param name="accountPrompt"></param>
        /// <param name="autoaddClients"></param>
        /// <param name="profitTrack"></param>
        /// <param name="laserPrinter"></param>
        /// <param name="labelPrinter"></param>
        /// <param name="lastYearEnd"></param>
        /// <param name="reorderReport"></param>
        /// <param name="trackWh2"></param>
        /// <param name="officeRef"></param>
        /// <param name="emailService"></param>
        /// <param name="cnicCustomerId"></param>
        /// <param name="internalLabel"></param>
        /// <param name="ownerPhone"></param>
        /// <param name="ownerTollfree"></param>
        /// <param name="ownerFax"></param>
        /// <param name="taskDefaultSnooze"></param>
        /// <param name="enforceUniqueKeywords"></param>
        /// <param name="emailOrders"></param>
        /// <param name="emailorderSeq"></param>
        /// <param name="extraQs"></param>
        /// <param name="forceProvCode"></param>
        /// <param name="browserPath"></param>
        /// <param name="trackWh1"></param>
        /// <param name="footerImage"></param>
        /// <param name="ftrImgAlt"></param>
        /// <param name="skandataSync"></param>
        /// <param name="webcatalogUrl"></param>
        /// <param name="webcatalogEmailServer"></param>
        /// <param name="emailAlerts"></param>
        /// <param name="webcatShowCusttype"></param>
        /// <param name="privacy"></param>
        /// <param name="subjectMandatory"></param>
        /// <param name="cidmRequestUrl"></param>
        /// <param name="singleRefType"></param>
        /// <param name="ldapLogon"></param>
        /// <param name="windowsAuthentication"></param>
        public static void Save(
            decimal? inventoryRecNo,
            decimal? conmacs,
            decimal? customer,
            decimal? inventoryCode,
            decimal? conlabels,
            decimal? confreezeInv,
            decimal? conrefModule,
            decimal? hiRecNo,
            DateTime? transDate,
            string month,
            string id,
            decimal? thermal,
            decimal? recHi,
            string owner,
            decimal? badge,
            decimal? pdcFee,
            decimal? bankFee,
            decimal? cashOut,
            string ver,
            string pathPic,
            string odbcSecurity,
            string dpath,
            string upath,
            string remote,
            decimal? gst,
            decimal? pst,
            string password,
            string conmac,
            string urlSurvey,
            string ownfr,
            decimal? markup,
            string dirImport,
            string dirDone,
            string import,
            decimal? invoiceNo,
            string pic,
            string pos,
            string city,
            string prov,
            decimal? refund,
            string openCash,
            decimal? woNum,
            decimal? invNo,
            string gstNo,
            string logo,
            string emailServer,
            string emailAddress,
            string ownerName,
            string ownerAddress,
            string ownerAddress2,
            string autofind,
            string accountPrompt,
            string autoaddClients,
            string profitTrack,
            string laserPrinter,
            string labelPrinter,
            string lastYearEnd,
            DateTime? reorderReport,
            string trackWh2,
            string officeRef,
            string emailService,
            string cnicCustomerId,
            string internalLabel,
            string ownerPhone,
            string ownerTollfree,
            string ownerFax,
            decimal? taskDefaultSnooze,
            string enforceUniqueKeywords,
            string emailOrders,
            decimal? emailorderSeq,
            string extraQs,
            string forceProvCode,
            string browserPath,
            string trackWh1,
            string footerImage,
            string ftrImgAlt,
            DateTime? skandataSync,
            string webcatalogUrl,
            string webcatalogEmailServer,
            string emailAlerts,
            string webcatShowCusttype,
            string privacy,
            string subjectMandatory,
            string cidmRequestUrl,
            string singleRefType,
            string ldapLogon,
            string windowsAuthentication)
        {
            new FConstantDataService().Save(
                inventoryRecNo, conmacs, customer, inventoryCode, conlabels,
                confreezeInv, conrefModule, hiRecNo, transDate, month,
                id, thermal, recHi, owner, badge,
                pdcFee, bankFee, cashOut, ver, pathPic,
                odbcSecurity, dpath, upath, remote, gst,
                pst, password, conmac, urlSurvey, ownfr,
                markup, dirImport, dirDone, import, invoiceNo,
                pic, pos, city, prov, refund,
                openCash, woNum, invNo, gstNo, logo,
                emailServer, emailAddress, ownerName, ownerAddress, ownerAddress2,
                autofind, accountPrompt, autoaddClients, profitTrack, laserPrinter,
                labelPrinter, lastYearEnd, reorderReport, trackWh2, officeRef,
                emailService, cnicCustomerId, internalLabel, ownerPhone, ownerTollfree,
                ownerFax, taskDefaultSnooze, enforceUniqueKeywords, emailOrders, emailorderSeq,
                extraQs, forceProvCode, browserPath, trackWh1, footerImage,
                ftrImgAlt, skandataSync, webcatalogUrl, webcatalogEmailServer, emailAlerts,
                webcatShowCusttype, privacy, subjectMandatory, cidmRequestUrl, singleRefType,
                ldapLogon, windowsAuthentication);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Save()
        {
            Save(
                InventoryRecNo, Conmacs, Customer, InventoryCode, Conlabels,
                ConfreezeInv, ConrefModule, HiRecNo, TransDate, Month,
                Id, Thermal, RecHi, Owner, Badge,
                PdcFee, BankFee, CashOut, Ver, PathPic,
                OdbcSecurity, Dpath, Upath, Remote, Gst,
                Pst, Password, Conmac, UrlSurvey, Ownfr,
                Markup, DirImport, DirDone, Import, InvoiceNo,
                Pic, Pos, City, Prov, Refund,
                OpenCash, WoNum, InvNo, GstNo, Logo,
                EmailServer, EmailAddress, OwnerName, OwnerAddress, OwnerAddress2,
                Autofind, AccountPrompt, AutoaddClients, ProfitTrack, LaserPrinter,
                LabelPrinter, LastYearEnd, ReorderReport, TrackWh2, OfficeRef,
                EmailService, CnicCustomerId, InternalLabel, OwnerPhone, OwnerTollfree,
                OwnerFax, TaskDefaultSnooze, EnforceUniqueKeywords, EmailOrders, EmailorderSeq,
                ExtraQs, ForceProvCode, BrowserPath, TrackWh1, FooterImage,
                FtrImgAlt, SkandataSync, WebcatalogUrl, WebcatalogEmailServer, EmailAlerts,
                WebcatShowCusttype, Privacy, SubjectMandatory, CidmRequestUrl, SingleRefType,
                LdapLogon,
                WindowsAuthentication);
        }
    }
}
