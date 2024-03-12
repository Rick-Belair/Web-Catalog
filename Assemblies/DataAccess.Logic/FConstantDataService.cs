using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using CallBaseCRM.Shared.DataAccess.Helper;

namespace CallBaseCRM.DataAccess.Logic
{
    public class FConstantDataService: DAHelper
    {
        /// <summary>
        /// 
        /// </summary>
        public FConstantDataService()
            : base()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataSet Get()
        {
            string strSQL =
                @"SELECT *
                FROM FCONSTANT
                WHERE CONSTSEQ = 1";

            return Execute(strSQL, CommandType.Text);
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
        public void Save(
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
            // Updates only
            string strSQL =
                @"UPDATE FCONSTANT
                SET CON_INVENTORY_REC_NO = :inventoryRecNo,
                    CONMACS = :conmacs,
                    CON_CUSTOMER = :customer,
                    CON_INVENTORY_CODE = :inventoryCode,
                    CONLABELS = :conlabels,
                    CONFREEZE_INV = :confreezeInv,
                    CONREF_MODULE = :conrefModule,
                    CON_HI_REC_NO = :hiRecNo,
                    CON_TRANS_DATE = :transDate,
                    CON_MONTH = :month,
                    CON_ID = :id,
                    CON_THERMAL = :thermal,
                    CON_REC_HI = :recHi,
                    CON_OWNER = :owner,
                    CON_BADGE = :badge,
                    CON_PDC_FEE = :pdcFee,
                    CON_BANK_FEE = :bankFee,
                    CON_CASH_OUT = :cashOut,
                    CON_VER = :ver,
                    CON_PATH_PIC = :pathPic,
                    CON_ODBC_SECURITY = :odbcSecurity,
                    CON_DPATH = :dpath,
                    CON_UPATH = :upath,
                    CON_REMOTE = :remote,
                    CON_GST = :gst,
                    CON_PST = :pst,
                    CON_PASSWORD = :password,
                    CONMAC = :conmac,
                    CON_URL_SURVEY = :urlSurvey,
                    CON_OWNFR = :ownfr,
                    CON_MARKUP = :markup,
                    CON_DIR_IMPORT = :dirImport,
                    CON_DIR_DONE = :dirDone,
                    CON_IMPORT = :import,
                    CON_INVOICE_NO = :invoiceNo,
                    CON_PIC = :pic,
                    CON_POS = :pos,
                    CON_CITY = :city,
                    CON_PROV = :prov,
                    CON_REFUND = :refund,
                    CON_OPEN_CASH = :openCash,
                    CON_WO_NUM = :woNum,
                    CON_INV_NO = :invNo,
                    CON_GST_NO = :gstNo,
                    CON_LOGO = :logo,
                    CON_EMAIL_SERVER = :emailServer,
                    CON_EMAIL_ADDRESS = :emailAddress,
                    CON_OWNER_NAME = :ownerName,
                    CON_OWNER_ADDRESS = :ownerAddress,
                    CON_OWNER_ADDRESS2 = :ownerAddress2,
                    CON_AUTOFIND = :autofind,
                    CON_ACCOUNT_PROMPT = :accountPrompt,
                    CON_AUTOADD_CLIENTS = :autoaddClients,
                    CON_PROFIT_TRACK = :profitTrack,
                    CON_LASER_PRINTER = :laserPrinter,
                    CON_LABEL_PRINTER = :labelPrinter,
                    CON_LAST_YEAR_END = :lastYearEnd,
                    CON_REORDER_REPORT = :reorderReport,
                    CON_TRACK_WH2 = :trackWh2,
                    CON_OFFICE_REF = :officeRef,
                    CON_EMAIL_SERVICE = :emailService,
                    CON_CNIC_CUSTOMER_ID = :cnicCustomerId,
                    CON_INTERNAL_LABEL = :internalLabel,
                    CON_OWNER_PHONE = :ownerPhone,
                    CON_OWNER_TOLLFREE = :ownerTollfree,
                    CON_OWNER_FAX = :ownerFax,
                    CON_TASK_DEFAULT_SNOOZE = :taskDefaultSnooze,
                    CON_ENFORCE_UNIQUE_KEYWORDS = :enforceUniqueKeywords,
                    CON_EMAIL_ORDERS = :emailOrders,
                    CON_EMAILORDER_SEQ = :emailorderSeq,
                    CON_EXTRA_QS = :extraQs,
                    CON_FORCE_PROV_CODE = :forceProvCode,
                    CON_BROWSER_PATH = :browserPath,
                    CON_TRACK_WH1 = :trackWh1,
                    CON_FOOTER_IMAGE = :footerImage,
                    CON_FTR_IMG_ALT = :ftrImgAlt,
                    CON_SKANDATA_SYNC = :skandataSync,
                    CON_WEBCATALOG_URL = :webcatalogUrl,
                    CON_WEBCATALOG_EMAIL_SERVER = :webcatalogEmailServer,
                    CON_EMAIL_ALERTS = :emailAlerts,
                    CON_WEBCAT_SHOW_CUSTTYPE = :webcatShowCusttype,
                    CON_PRIVACY = :privacy,
                    CON_SUBJECT_MANDATORY = :subjectMandatory,
                    CIDM_REQUEST_URL = :cidmRequestUrl,
                    CON_SINGLE_REF_TYPE = :singleRefType,
                    CON_LDAP_LOGON = :ldapLogon,
                    CON_WINDOWS_AUTHENTICATION = :windowsAuthentication
                WHERE CONSTSEQ = 1";
            DbParameter[] parms = new DbParameter[]
            {
                CreateParameter(":inventoryRecNo", DbType.Decimal, ValueOrNull(inventoryRecNo)),
                CreateParameter(":conmacs", DbType.Decimal, ValueOrNull(conmacs)),
                CreateParameter(":customer", DbType.Decimal, ValueOrNull(customer)),
                CreateParameter(":inventoryCode", DbType.Decimal, ValueOrNull(inventoryCode)),
                CreateParameter(":conlabels", DbType.Decimal, ValueOrNull(conlabels)),
                CreateParameter(":confreezeInv", DbType.Decimal, ValueOrNull(confreezeInv)),
                CreateParameter(":conrefModule", DbType.Decimal, ValueOrNull(conrefModule)),
                CreateParameter(":hiRecNo", DbType.Decimal, ValueOrNull(hiRecNo)),
                CreateParameter(":transDate", DbType.DateTime, ValueOrNull(transDate)),
                CreateParameter(":month", DbType.String, ValueOrNull(month)),
                CreateParameter(":id", DbType.String, ValueOrNull(id)),
                CreateParameter(":thermal", DbType.Decimal, ValueOrNull(thermal)),
                CreateParameter(":recHi", DbType.Decimal, ValueOrNull(recHi)),
                CreateParameter(":owner", DbType.String, ValueOrNull(owner)),
                CreateParameter(":badge", DbType.Decimal, ValueOrNull(badge)),
                CreateParameter(":pdcFee", DbType.Decimal, ValueOrNull(pdcFee)),
                CreateParameter(":bankFee", DbType.Decimal, ValueOrNull(bankFee)),
                CreateParameter(":cashOut", DbType.Decimal, ValueOrNull(cashOut)),
                CreateParameter(":ver", DbType.String, ValueOrNull(ver)),
                CreateParameter(":pathPic", DbType.String, ValueOrNull(pathPic)),
                CreateParameter(":odbcSecurity", DbType.String, ValueOrNull(odbcSecurity)),
                CreateParameter(":dpath", DbType.String, ValueOrNull(dpath)),
                CreateParameter(":upath", DbType.String, ValueOrNull(upath)),
                CreateParameter(":remote", DbType.String, ValueOrNull(remote)),
                CreateParameter(":gst", DbType.Decimal, ValueOrNull(gst)),
                CreateParameter(":pst", DbType.Decimal, ValueOrNull(pst)),
                CreateParameter(":password", DbType.String, ValueOrNull(password)),
                CreateParameter(":conmac", DbType.String, ValueOrNull(conmac)),
                CreateParameter(":urlSurvey", DbType.String, ValueOrNull(urlSurvey)),
                CreateParameter(":ownfr", DbType.String, ValueOrNull(ownfr)),
                CreateParameter(":markup", DbType.Decimal, ValueOrNull(markup)),
                CreateParameter(":dirImport", DbType.String, ValueOrNull(dirImport)),
                CreateParameter(":dirDone", DbType.String, ValueOrNull(dirDone)),
                CreateParameter(":import", DbType.String, ValueOrNull(import)),
                CreateParameter(":invoiceNo", DbType.Decimal, ValueOrNull(invoiceNo)),
                CreateParameter(":pic", DbType.String, ValueOrNull(pic)),
                CreateParameter(":pos", DbType.String, ValueOrNull(pos)),
                CreateParameter(":city", DbType.String, ValueOrNull(city)),
                CreateParameter(":prov", DbType.String, ValueOrNull(prov)),
                CreateParameter(":refund", DbType.Decimal, ValueOrNull(refund)),
                CreateParameter(":openCash", DbType.String, ValueOrNull(openCash)),
                CreateParameter(":woNum", DbType.Decimal, ValueOrNull(woNum)),
                CreateParameter(":invNo", DbType.Decimal, ValueOrNull(invNo)),
                CreateParameter(":gstNo", DbType.String, ValueOrNull(gstNo)),
                CreateParameter(":logo", DbType.String, ValueOrNull(logo)),
                CreateParameter(":emailServer", DbType.String, ValueOrNull(emailServer)),
                CreateParameter(":emailAddress", DbType.String, ValueOrNull(emailAddress)),
                CreateParameter(":ownerName", DbType.String, ValueOrNull(ownerName)),
                CreateParameter(":ownerAddress", DbType.String, ValueOrNull(ownerAddress)),
                CreateParameter(":ownerAddress2", DbType.String, ValueOrNull(ownerAddress2)),
                CreateParameter(":autofind", DbType.String, ValueOrNull(autofind)),
                CreateParameter(":accountPrompt", DbType.String, ValueOrNull(accountPrompt)),
                CreateParameter(":autoaddClients", DbType.String, ValueOrNull(autoaddClients)),
                CreateParameter(":profitTrack", DbType.String, ValueOrNull(profitTrack)),
                CreateParameter(":laserPrinter", DbType.String, ValueOrNull(laserPrinter)),
                CreateParameter(":labelPrinter", DbType.String, ValueOrNull(labelPrinter)),
                CreateParameter(":lastYearEnd", DbType.String, ValueOrNull(lastYearEnd)),
                CreateParameter(":reorderReport", DbType.DateTime, ValueOrNull(reorderReport)),
                CreateParameter(":trackWh2", DbType.String, ValueOrNull(trackWh2)),
                CreateParameter(":officeRef", DbType.String, ValueOrNull(officeRef)),
                CreateParameter(":emailService", DbType.String, ValueOrNull(emailService)),
                CreateParameter(":cnicCustomerId", DbType.String, ValueOrNull(cnicCustomerId)),
                CreateParameter(":internalLabel", DbType.String, ValueOrNull(internalLabel)),
                CreateParameter(":ownerPhone", DbType.String, ValueOrNull(ownerPhone)),
                CreateParameter(":ownerTollfree", DbType.String, ValueOrNull(ownerTollfree)),
                CreateParameter(":ownerFax", DbType.String, ValueOrNull(ownerFax)),
                CreateParameter(":taskDefaultSnooze", DbType.Decimal, ValueOrNull(taskDefaultSnooze)),
                CreateParameter(":enforceUniqueKeywords", DbType.String, ValueOrNull(enforceUniqueKeywords)),
                CreateParameter(":emailOrders", DbType.String, ValueOrNull(emailOrders)),
                CreateParameter(":emailorderSeq", DbType.Decimal, ValueOrNull(emailorderSeq)),
                CreateParameter(":extraQs", DbType.String, ValueOrNull(extraQs)),
                CreateParameter(":forceProvCode", DbType.String, ValueOrNull(forceProvCode)),
                CreateParameter(":browserPath", DbType.String, ValueOrNull(browserPath)),
                CreateParameter(":trackWh1", DbType.String, ValueOrNull(trackWh1)),
                CreateParameter(":footerImage", DbType.String, ValueOrNull(footerImage)),
                CreateParameter(":ftrImgAlt", DbType.String, ValueOrNull(ftrImgAlt)),
                CreateParameter(":skandataSync", DbType.DateTime, ValueOrNull(skandataSync)),
                CreateParameter(":webcatalogUrl", DbType.String, ValueOrNull(webcatalogUrl)),
                CreateParameter(":webcatalogEmailServer", DbType.String, ValueOrNull(webcatalogEmailServer)),
                CreateParameter(":emailAlerts", DbType.String, ValueOrNull(emailAlerts)),
                CreateParameter(":webcatShowCusttype", DbType.String, ValueOrNull(webcatShowCusttype)),
                CreateParameter(":privacy", DbType.String, ValueOrNull(privacy)),
                CreateParameter(":subjectMandatory", DbType.String, ValueOrNull(subjectMandatory)),
                CreateParameter(":cidmRequestUrl", DbType.String, ValueOrNull(cidmRequestUrl)),
                CreateParameter(":singleRefType", DbType.String, ValueOrNull(singleRefType)),
                CreateParameter(":ldapLogon", DbType.String, ValueOrNull(ldapLogon)),
                CreateParameter(":windowsAuthentication", DbType.String, ValueOrNull(windowsAuthentication)),
            };

            ExecuteNonQuery(strSQL, CommandType.Text, parms);
        }
    }
}
