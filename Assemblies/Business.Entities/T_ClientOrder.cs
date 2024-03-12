using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CallBaseCRM.DataAccess.Logic;

namespace CallBaseCRM.Business.Entities
{
    public class T_ClientOrder: BaseObject
    {
        /// <summary>
        /// Instance variables
        /// </summary>
        private decimal? _OrderNo;
        private decimal? _CustNo;
        private string _FirstName;
        private string _LastName;
        private string _Position;
        private string _Organization;
        private string _Organization2;
        private string _Address;
        private string _Address2;
        private string _City;
        private string _ProvState;
        private string _PostalZip;
        private string _Country;
        private string _TelWork;
        private string _TelHome;
        private string _Fax;
        private string _Email;
        private decimal? _Num;
        private string _Event;
        private string _GroupCode;
        private string _UseCode;
        private string _Comments;
        private decimal? _SubTotal;
        private decimal? _Discount;
        private decimal? _SubTotalDiscount;
        private decimal? _GST;
        private decimal? _PST;
        private decimal? _HST;
        private decimal? _Sandh;
        private decimal? _SandhGST;
        private decimal? _SandhPST;
        private decimal? _SandhHST;
        private decimal? _TotalSale;
        private string _OrdersShipped;
        private DateTime? _DateSent;
        private decimal? _Paymethode;
        private string _CardType;
        private string _NameOnCard;
        private string _Visano;
        private DateTime? _ExpDate;
        private string _PO;
        private DateTime? _DateIn;
        private DateTime? _DateEdit;
        private string _Source;
        private string _ShipMethodDesc;
        private string _ShipMethodCode;
        private string _DistChannel;
        private string _Affiliation;
        private DateTime? _SentToCallbase;
        private decimal? _ProcessStatus;
        private string _ProvStateLong;
        private string _CustType;
        private decimal? _Aboriginal;

        /// <summary>
        ///  Property getter/setters
        /// </summary>
        public decimal? OrderNo
        {
            get { return _OrderNo; }
            set { _OrderNo = value; }
        }

        public decimal? CustNo
        {
            get { return _CustNo; }
            set { _CustNo = value; }
        }

        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = FixUpString(value); }
        }

        public string LastName
        {
            get { return _LastName; }
            set { _LastName = FixUpString(value); }
        }

        public string Position
        {
            get { return _Position; }
            set { _Position = FixUpString(value); }
        }

        public string Organization
        {
            get { return _Organization; }
            set { _Organization = FixUpString(value); }
        }

        public string Organization2
        {
            get { return _Organization2; }
            set { _Organization2 = FixUpString(value); }
        }

        public string Address
        {
            get { return _Address; }
            set { _Address = FixUpString(value); }
        }

        public string Address2
        {
            get { return _Address2; }
            set { _Address2 = FixUpString(value); }
        }

        public string City
        {
            get { return _City; }
            set { _City = FixUpString(value); }
        }

        public string ProvState
        {
            get { return _ProvState; }
            set { _ProvState = FixUpString(value); }
        }

        public string PostalZip
        {
            get { return _PostalZip; }
            set { _PostalZip = FixUpString(value); }
        }

        public string Country
        {
            get { return _Country; }
            set { _Country = FixUpString(value); }
        }

        public string TelWork
        {
            get { return _TelWork; }
            set { _TelWork = FixUpString(value); }
        }

        public string TelHome
        {
            get { return _TelHome; }
            set { _TelHome = FixUpString(value); }
        }

        public string Fax
        {
            get { return _Fax; }
            set { _Fax = FixUpString(value); }
        }

        public string Email
        {
            get { return _Email; }
            set { _Email = FixUpString(value); }
        }

        public decimal? Num
        {
            get { return _Num; }
            set { _Num = value; }
        }

        public string Event
        {
            get { return _Event; }
            set { _Event = FixUpString(value); }
        }

        public string GroupCode
        {
            get { return _GroupCode; }
            set { _GroupCode = FixUpString(value); }
        }

        public string UseCode
        {
            get { return _UseCode; }
            set { _UseCode = FixUpString(value); }
        }

        public string Comments
        {
            get { return _Comments; }
            set { _Comments = FixUpString(value); }
        }

        public decimal? SubTotal
        {
            get { return _SubTotal; }
            set { _SubTotal = value; }
        }

        public decimal? Discount
        {
            get { return _Discount; }
            set { _Discount = value; }
        }

        public decimal? SubTotalDiscount
        {
            get { return _SubTotalDiscount; }
            set { _SubTotalDiscount = value; }
        }

        public decimal? GST
        {
            get { return _GST; }
            set { _GST = value; }
        }

        public decimal? PST
        {
            get { return _PST; }
            set { _PST = value; }
        }

        public decimal? HST
        {
            get { return _HST; }
            set { _HST = value; }
        }

        public decimal? Sandh
        {
            get { return _Sandh; }
            set { _Sandh = value; }
        }

        public decimal? SandhGST
        {
            get { return _SandhGST; }
            set { _SandhGST = value; }
        }

        public decimal? SandhPST
        {
            get { return _SandhPST; }
            set { _SandhPST = value; }
        }

        public decimal? SandhHST
        {
            get { return _SandhHST; }
            set { _SandhHST = value; }
        }

        public decimal? TotalSale
        {
            get { return _TotalSale; }
            set { _TotalSale = value; }
        }

        public string OrdersShipped
        {
            get { return _OrdersShipped; }
            set { _OrdersShipped = FixUpString(value); }
        }

        public DateTime? DateSent
        {
            get { return _DateSent; }
            set { _DateSent = value; }
        }

        public decimal? Paymethode
        {
            get { return _Paymethode; }
            set { _Paymethode = value; }
        }

        public string CardType
        {
            get { return _CardType; }
            set { _CardType = FixUpString(value); }
        }

        public string NameOnCard
        {
            get { return _NameOnCard; }
            set { _NameOnCard = FixUpString(value); }
        }

        public string Visano
        {
            get { return _Visano; }
            set { _Visano = FixUpString(value); }
        }

        public DateTime? ExpDate
        {
            get { return _ExpDate; }
            set { _ExpDate = value; }
        }

        public string PO
        {
            get { return _PO; }
            set { _PO = FixUpString(value); }
        }

        public DateTime? DateIn
        {
            get { return _DateIn; }
            set { _DateIn = value; }
        }

        public DateTime? DateEdit
        {
            get { return _DateEdit; }
            set { _DateEdit = value; }
        }

        public string Source
        {
            get { return _Source; }
            set { _Source = FixUpString(value); }
        }

        public string ShipMethodDesc
        {
            get { return _ShipMethodDesc; }
            set { _ShipMethodDesc = FixUpString(value); }
        }

        public string ShipMethodCode
        {
            get { return _ShipMethodCode; }
            set { _ShipMethodCode = FixUpString(value); }
        }

        public string DistChannel
        {
            get { return _DistChannel; }
            set { _DistChannel = FixUpString(value); }
        }

        public string Affiliation
        {
            get { return _Affiliation; }
            set { _Affiliation = FixUpString(value); }
        }

        public DateTime? SentToCallbase
        {
            get { return _SentToCallbase; }
            set { _SentToCallbase = value; }
        }

        public decimal? ProcessStatus
        {
            get { return _ProcessStatus; }
            set { _ProcessStatus = value; }
        }

        public string ProvStateLong
        {
            get { return _ProvStateLong; }
            set { _ProvStateLong = FixUpString(value); }
        }

        public string CustType
        {
            get { return _CustType; }
            set { _CustType = FixUpString(value); }
        }

        public decimal? Aboriginal
        {
            get { return _Aboriginal; }
            set { _Aboriginal = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        public override void MapData(DataRow row)
        {
            _OrderNo = GetDecimal(row, "ORDER_NO");
            _CustNo = GetDecimal(row, "CUST_NO");
            _FirstName = GetString(row, "FIRSTNAME");
            _LastName = GetString(row, "LASTNAME");
            _Position = GetString(row, "POSITION");
            _Organization = GetString(row, "ORGANIZATION");
            _Organization2 = GetString(row, "ORGANIZATION2");
            _Address = GetString(row, "ADDRESS");
            _Address2 = GetString(row, "ADDRESS2");
            _City = GetString(row, "CITY");
            _ProvState = GetString(row, "PROV_STATE");
            _PostalZip = GetString(row, "POSTAL_ZIP");
            _Country = GetString(row, "COUNTRY");
            _TelWork = GetString(row, "TEL_WORK");
            _TelHome = GetString(row, "TEL_HOME");
            _Fax = GetString(row, "FAX");
            _Email = GetString(row, "EMAIL");
            _Num = GetDecimal(row, "NUM");
            _Event = GetString(row, "EVENT");
            _GroupCode = GetString(row, "GROUP_CODE");
            _UseCode = GetString(row, "USE_CODE");
            _Comments = GetString(row, "COMMENTS");
            _SubTotal = GetDecimal(row, "SUB_TOTAL");
            _Discount = GetDecimal(row, "DISCOUNT");
            _SubTotalDiscount = GetDecimal(row, "SUB_TOTAL_DISCOUNT");
            _GST = GetDecimal(row, "GST");
            _PST = GetDecimal(row, "PST");
            _HST = GetDecimal(row, "HST");
            _Sandh = GetDecimal(row, "SANDH");
            _SandhGST = GetDecimal(row, "SANDHGST");
            _SandhPST = GetDecimal(row, "SANDHPST");
            _SandhHST = GetDecimal(row, "SANDHHST");
            _TotalSale = GetDecimal(row, "TOTAL_SALE");
            _OrdersShipped = GetString(row, "ORDERSSHIPPED");
            _DateSent = GetDateTime(row, "DATESENT");
            _Paymethode = GetDecimal(row, "PAYMETHODE");
            _CardType = GetString(row, "CARDTYPE");
            _NameOnCard = GetString(row, "NAMEONCARD");
            _Visano = GetString(row, "VISANO");
            _ExpDate = GetDateTime(row, "EXPDATE");
            _PO = GetString(row, "PO");
            _DateIn = GetDateTime(row, "DATEIN");
            _DateEdit = GetDateTime(row, "DATEEDIT");
            _Source = GetString(row, "SOURCE");
            _ShipMethodDesc = GetString(row, "SHIPMETHODDESC");
            _ShipMethodCode = GetString(row, "SHIPMETHODCODE");
            _DistChannel = GetString(row, "DISTCHANNEL");
            _Affiliation = GetString(row, "AFFILIATION");
            _SentToCallbase = GetDateTime(row, "SENT_TO_CALLBASE");
            _ProcessStatus = GetDecimal(row, "PROCESS_STATUS");
            _ProvStateLong = GetString(row, "PROV_STATE_LONG");
            _CustType = GetString(row, "CUST_TYPE");
            _Aboriginal = GetDecimal(row, "ABORIGINAL");
        }

        public static T_ClientOrder Get(
            decimal? orderNo)
        {
            T_ClientOrder co = new T_ClientOrder();
            co.MapData(new T_ClientOrderDataService().Get(orderNo));

            return co;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        public static bool Exists(
            decimal? orderNo)
        {
            return new T_ClientOrderDataService().Exists(orderNo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderNo"></param>
        public static void Delete(
            decimal? orderNo)
        {
            new T_ClientOrderDataService().Delete(orderNo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderNo"></param>
        /// <param name="custNo"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="position"></param>
        /// <param name="organization"></param>
        /// <param name="organization2"></param>
        /// <param name="address"></param>
        /// <param name="address2"></param>
        /// <param name="city"></param>
        /// <param name="provState"></param>
        /// <param name="postalZip"></param>
        /// <param name="country"></param>
        /// <param name="telWork"></param>
        /// <param name="telHome"></param>
        /// <param name="fax"></param>
        /// <param name="email"></param>
        /// <param name="num"></param>
        /// <param name="evnt"></param>
        /// <param name="groupCode"></param>
        /// <param name="useCode"></param>
        /// <param name="comments"></param>
        /// <param name="subTotal"></param>
        /// <param name="discount"></param>
        /// <param name="subTotalDiscount"></param>
        /// <param name="gst"></param>
        /// <param name="pst"></param>
        /// <param name="hst"></param>
        /// <param name="sandh"></param>
        /// <param name="sandhGST"></param>
        /// <param name="sandhPST"></param>
        /// <param name="sandhHST"></param>
        /// <param name="totalSale"></param>
        /// <param name="ordersShipped"></param>
        /// <param name="dateSent"></param>
        /// <param name="paymethode"></param>
        /// <param name="cardType"></param>
        /// <param name="nameOnCard"></param>
        /// <param name="visano"></param>
        /// <param name="expDate"></param>
        /// <param name="po"></param>
        /// <param name="dateIn"></param>
        /// <param name="dateEdit"></param>
        /// <param name="source"></param>
        /// <param name="shipMethodDesc"></param>
        /// <param name="shipMethodCode"></param>
        /// <param name="distChannel"></param>
        /// <param name="affiliation"></param>
        /// <param name="sentToCallbase"></param>
        /// <param name="processStatus"></param>
        /// <param name="provStateLong"></param>
        /// <param name="custType"></param>
        /// <param name="aboriginal"></param>
        /// <returns></returns>
        public static decimal Save(
            decimal? orderNo,
            decimal? custNo,
            string firstName,
            string lastName,
            string position,
            string organization,
            string organization2,
            string address,
            string address2,
            string city,
            string provState,
            string postalZip,
            string country,
            string telWork,
            string telHome,
            string fax,
            string email,
            decimal? num,
            string evnt,
            string groupCode,
            string useCode,
            string comments,
            decimal? subTotal,
            decimal? discount,
            decimal? subTotalDiscount,
            decimal? gst,
            decimal? pst,
            decimal? hst,
            decimal? sandh,
            decimal? sandhGST,
            decimal? sandhPST,
            decimal? sandhHST,
            decimal? totalSale,
            string ordersShipped,
            DateTime? dateSent,
            decimal? paymethode,
            string cardType,
            string nameOnCard,
            string visano,
            DateTime? expDate,
            string po,
            DateTime? dateIn,
            DateTime? dateEdit,
            string source,
            string shipMethodDesc,
            string shipMethodCode,
            string distChannel,
            string affiliation,
            DateTime? sentToCallbase,
            decimal? processStatus,
            string provStateLong,
            string custType,
            decimal? aboriginal)
        {
            return new T_ClientOrderDataService().Save(
                orderNo, custNo, firstName, lastName, position,
                organization, organization2, address, address2, city,
                provState, postalZip, country, telWork, telHome,
                fax, email, num, evnt, groupCode,
                useCode, comments, subTotal, discount, subTotalDiscount,
                gst, pst, hst, sandh, sandhGST,
                sandhPST, sandhHST, totalSale, ordersShipped, dateSent,
                paymethode, cardType, nameOnCard, visano, expDate,
                po, dateIn, dateEdit, source, shipMethodDesc,
                shipMethodCode, distChannel, affiliation, sentToCallbase, processStatus,
                provStateLong, custType, aboriginal);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal Save()
        {
            return Save(
                OrderNo, CustNo, FirstName, LastName, Position,
                Organization, Organization2, Address, Address2, City,
                ProvState, PostalZip, Country, TelWork, TelHome,
                Fax, Email, Num, Event, GroupCode,
                UseCode, Comments, SubTotal, Discount, SubTotalDiscount,
                GST, PST, HST, Sandh, SandhGST,
                SandhPST, SandhHST, TotalSale, OrdersShipped, DateSent,
                Paymethode, CardType, NameOnCard, Visano, ExpDate,
                PO, DateIn, DateEdit, Source, ShipMethodDesc,
                ShipMethodCode, DistChannel, Affiliation, SentToCallbase, ProcessStatus,
                ProvStateLong, CustType, Aboriginal);
        }
    }
}
