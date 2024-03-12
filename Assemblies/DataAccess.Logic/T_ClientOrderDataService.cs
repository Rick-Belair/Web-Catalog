using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using CallBaseCRM.Shared.DataAccess.Helper;

namespace CallBaseCRM.DataAccess.Logic
{
    public class T_ClientOrderDataService: DAHelper
    {
        /// <summary>
        /// 
        /// </summary>
        public T_ClientOrderDataService()
            : base()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        public DataSet Get(
            decimal? orderNo)
        {
            string strSQL =
                @"SELECT *
                FROM T_Client_Order
                WHERE Order_No = :orderNo";
            DbParameter[] parms = new DbParameter[]
            {
                CreateParameter(":orderNo", DbType.Decimal, ValueOrNull(orderNo))
            };

            return Execute(strSQL, CommandType.Text, parms);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        public bool Exists(
            decimal? orderNo)
        {
            DataSet ds = Get(orderNo);

            return (ds.Tables[0].Rows.Count != 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderNo"></param>
        public void Delete(
            decimal? orderNo)
        {
            string strSQL =
                @"DELETE FROM T_Client_Order
                WHERE Order_No = :orderNo";
            DbParameter[] parms = new DbParameter[]
            {
                CreateParameter(":orderNo", DbType.Decimal, ValueOrNull(orderNo))
            };

            ExecuteNonQuery(strSQL, CommandType.Text, parms);
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
        /// <param name="LrocessStatus"></param>
        /// <param name="provStateLong"></param>
        /// <param name="custType"></param>
        /// <param name="aboriginal"></param>
        /// <returns></returns>
        public decimal Save(
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

            // Create the parameter list
            DbParameter[] parms = new DbParameter[]
            {
                CreateParameter(":orderNo", DbType.Decimal, ValueOrNull(orderNo)),
                CreateParameter(":custNo", DbType.Decimal, ValueOrNull(custNo)),
                CreateParameter(":firstName", DbType.String, ValueOrNull(firstName)),
                CreateParameter(":lastName", DbType.String, ValueOrNull(lastName)),
                CreateParameter(":position", DbType.String, ValueOrNull(position)),
                CreateParameter(":organization", DbType.String, ValueOrNull(organization)),
                CreateParameter(":organization2", DbType.String, ValueOrNull(organization2)),
                CreateParameter(":address", DbType.String, ValueOrNull(address)),
                CreateParameter(":address2", DbType.String, ValueOrNull(address2)),
                CreateParameter(":city", DbType.String, ValueOrNull(city)),
                CreateParameter(":provState", DbType.String, ValueOrNull(provState)),
                CreateParameter(":postalZip", DbType.String, ValueOrNull(postalZip)),
                CreateParameter(":country", DbType.String, ValueOrNull(country)),
                CreateParameter(":telWork", DbType.String, ValueOrNull(telWork)),
                CreateParameter(":telHome", DbType.String, ValueOrNull(telHome)),
                CreateParameter(":fax", DbType.String, ValueOrNull(fax)),
                CreateParameter(":email", DbType.String, ValueOrNull(email)),
                CreateParameter(":num", DbType.Decimal, ValueOrNull(num)),
                CreateParameter(":evnt", DbType.String, ValueOrNull(evnt)),
                CreateParameter(":groupCode", DbType.String, ValueOrNull(groupCode)),
                CreateParameter(":useCode", DbType.String, ValueOrNull(useCode)),
                CreateParameter(":comments", DbType.String, ValueOrNull(comments)),
                CreateParameter(":subTotal", DbType.Decimal, ValueOrNull(subTotal)),
                CreateParameter(":discount", DbType.Decimal, ValueOrNull(discount)),
                CreateParameter(":subTotalDiscount", DbType.Decimal, ValueOrNull(subTotalDiscount)),
                CreateParameter(":gst", DbType.Decimal, ValueOrNull(gst)),
                CreateParameter(":pst", DbType.Decimal, ValueOrNull(pst)),
                CreateParameter(":hst", DbType.Decimal, ValueOrNull(hst)),
                CreateParameter(":sandh", DbType.Decimal, ValueOrNull(sandh)),
                CreateParameter(":sandhGST", DbType.Decimal, ValueOrNull(sandhGST)),
                CreateParameter(":sandhPST", DbType.Decimal, ValueOrNull(sandhPST)),
                CreateParameter(":sandhHST", DbType.Decimal, ValueOrNull(sandhHST)),
                CreateParameter(":totalSale", DbType.Decimal, ValueOrNull(totalSale)),
                CreateParameter(":ordersShipped", DbType.String, ValueOrNull(ordersShipped)),
                CreateParameter(":dateSent", DbType.DateTime, ValueOrNull(dateSent)),
                CreateParameter(":paymethode", DbType.Decimal, ValueOrNull(paymethode)),
                CreateParameter(":cardType", DbType.String, ValueOrNull(cardType)),
                CreateParameter(":nameOnCard", DbType.String, ValueOrNull(nameOnCard)),
                CreateParameter(":visano", DbType.String, ValueOrNull(visano)),
                CreateParameter(":expDate", DbType.DateTime, ValueOrNull(expDate)),
                CreateParameter(":po", DbType.String, ValueOrNull(po)),
                CreateParameter(":dateIn", DbType.DateTime, ValueOrNull(dateIn)),
                CreateParameter(":dateEdit", DbType.DateTime, ValueOrNull(dateEdit)),
                CreateParameter(":source", DbType.String, ValueOrNull(source)),
                CreateParameter(":shipMethodDesc", DbType.String, ValueOrNull(shipMethodDesc)),
                CreateParameter(":shipMethodCode", DbType.String, ValueOrNull(shipMethodCode)),
                CreateParameter(":distChannel", DbType.String, ValueOrNull(distChannel)),
                CreateParameter(":affiliation", DbType.String, ValueOrNull(affiliation)),
                CreateParameter(":sentToCallbase", DbType.DateTime, ValueOrNull(sentToCallbase)),
                CreateParameter(":processStatus", DbType.Decimal, ValueOrDefault(processStatus, 0m)),
                CreateParameter(":provStateLong", DbType.String, ValueOrNull(provStateLong)),
                CreateParameter(":custType", DbType.String, ValueOrNull(custType)),
                CreateParameter(":aboriginal", DbType.Decimal, ValueOrNull(aboriginal))
            };

            // Do an update or an insert
            string strSQL;
            decimal retval;
            if (Exists(orderNo))
            {
                strSQL =
                    @"UPDATE T_Client_Order
                    SET CUST_NO = :custNo,
                        FIRSTNAME = :firstName,
                        LASTNAME = :lastName,
                        POSITION = :position,
                        ORGANIZATION = :organization,
                        ORGANIZATION2 = :organization2,
                        ADDRESS = :address,
                        ADDRESS2 = :address2,
                        CITY = :city,
                        PROV_STATE = :provState,
                        POSTAL_ZIP = :postalZip,
                        COUNTRY = :country,
                        TEL_WORK = :telWork,
                        TEL_HOME = :telHome,
                        FAX = :fax,
                        EMAIL = :email,
                        NUM = :num,
                        EVENT = :evnt,
                        GROUP_CODE = :groupCode,
                        USE_CODE = :useCode,
                        COMMENTS = :comments,
                        SUB_TOTAL = :subTotal,
                        DISCOUNT = :discount,
                        SUB_TOTAL_DISCOUNT = :subTotalDiscount,
                        GST = :gst,
                        PST = :pst,
                        HST = :hst,
                        SANDH = :sandh,
                        SANDHGST = :sandhGST,
                        SANDHPST = :sandhPST,
                        SANDHHST = :sandhHST,
                        TOTAL_SALE = :totalSale,
                        ORDERSSHIPPED = :ordersShipped,
                        DATESENT = :dateSent,
                        PAYMETHODE = :paymethode,
                        CARDTYPE = :cardType,
                        NAMEONCARD = :nameOnCard,
                        VISANO = :visano,
                        EXPDATE = :expDate,
                        PO = :po,
                        DATEIN = :dateIn,
                        DATEEDIT = :dateEdit,
                        SOURCE = :source,
                        SHIPMETHODDESC = :shipMethodDesc,
                        SHIPMETHODCODE = :shipMethodCode,
                        DISTCHANNEL = :distChannel,
                        AFFILIATION = :affiliation,
                        SENT_TO_CALLBASE = :sentToCallbase,
                        PROCESS_STATUS = :processStatus,
                        PROV_STATE_LONG = :provStateLong,
                        CUST_TYPE = :custType,
                        ABORIGINAL = :aboriginal
                    WHERE Order_No = :orderNo";

                ExecuteNonQuery(strSQL, CommandType.Text, parms);
                retval = orderNo.Value;
            }
            else
            {
                decimal o = newOrderNumber();
                orderNo = o;
                DbParameter[] parms2 = new DbParameter[]
                {
                CreateParameter(":custNo", DbType.Decimal, ValueOrNull(custNo)),
                CreateParameter(":firstName", DbType.String, ValueOrNull(firstName)),
                CreateParameter(":lastName", DbType.String, ValueOrNull(lastName)),
                CreateParameter(":position", DbType.String, ValueOrNull(position)),
                CreateParameter(":organization", DbType.String, ValueOrNull(organization)),
                CreateParameter(":organization2", DbType.String, ValueOrNull(organization2)),
                CreateParameter(":address", DbType.String, ValueOrNull(address)),
                CreateParameter(":address2", DbType.String, ValueOrNull(address2)),
                CreateParameter(":city", DbType.String, ValueOrNull(city)),
                CreateParameter(":provState", DbType.String, ValueOrNull(provState)),
                CreateParameter(":postalZip", DbType.String, ValueOrNull(postalZip)),
                CreateParameter(":country", DbType.String, ValueOrNull(country)),
                CreateParameter(":telWork", DbType.String, ValueOrNull(telWork)),
                CreateParameter(":telHome", DbType.String, ValueOrNull(telHome)),
                CreateParameter(":fax", DbType.String, ValueOrNull(fax)),
                CreateParameter(":email", DbType.String, ValueOrNull(email)),
                CreateParameter(":num", DbType.Decimal, ValueOrNull(num)),
                CreateParameter(":evnt", DbType.String, ValueOrNull(evnt)),
                CreateParameter(":groupCode", DbType.String, ValueOrNull(groupCode)),
                CreateParameter(":useCode", DbType.String, ValueOrNull(useCode)),
                CreateParameter(":comments", DbType.String, ValueOrNull(comments)),
                CreateParameter(":subTotal", DbType.Decimal, ValueOrNull(subTotal)),
                CreateParameter(":discount", DbType.Decimal, ValueOrNull(discount)),
                CreateParameter(":subTotalDiscount", DbType.Decimal, ValueOrNull(subTotalDiscount)),
                CreateParameter(":gst", DbType.Decimal, ValueOrNull(gst)),
                CreateParameter(":pst", DbType.Decimal, ValueOrNull(pst)),
                CreateParameter(":hst", DbType.Decimal, ValueOrNull(hst)),
                CreateParameter(":sandh", DbType.Decimal, ValueOrNull(sandh)),
                CreateParameter(":sandhGST", DbType.Decimal, ValueOrNull(sandhGST)),
                CreateParameter(":sandhPST", DbType.Decimal, ValueOrNull(sandhPST)),
                CreateParameter(":sandhHST", DbType.Decimal, ValueOrNull(sandhHST)),
                CreateParameter(":totalSale", DbType.Decimal, ValueOrNull(totalSale)),
                CreateParameter(":ordersShipped", DbType.String, ValueOrNull(ordersShipped)),
                CreateParameter(":dateSent", DbType.DateTime, ValueOrNull(dateSent)),
                CreateParameter(":paymethode", DbType.Decimal, ValueOrNull(paymethode)),
                CreateParameter(":cardType", DbType.String, ValueOrNull(cardType)),
                CreateParameter(":nameOnCard", DbType.String, ValueOrNull(nameOnCard)),
                CreateParameter(":visano", DbType.String, ValueOrNull(visano)),
                CreateParameter(":expDate", DbType.DateTime, ValueOrNull(expDate)),
                CreateParameter(":po", DbType.String, ValueOrNull(po)),
                CreateParameter(":dateIn", DbType.DateTime, ValueOrNull(dateIn)),
                CreateParameter(":dateEdit", DbType.DateTime, ValueOrNull(dateEdit)),
                CreateParameter(":source", DbType.String, ValueOrNull(source)),
                CreateParameter(":shipMethodDesc", DbType.String, ValueOrNull(shipMethodDesc)),
                CreateParameter(":shipMethodCode", DbType.String, ValueOrNull(shipMethodCode)),
                CreateParameter(":distChannel", DbType.String, ValueOrNull(distChannel)),
                CreateParameter(":affiliation", DbType.String, ValueOrNull(affiliation)),
                CreateParameter(":sentToCallbase", DbType.DateTime, ValueOrNull(sentToCallbase)),
                CreateParameter(":processStatus", DbType.Decimal, ValueOrDefault(processStatus, 0m)),
                CreateParameter(":provStateLong", DbType.String, ValueOrNull(provStateLong)),
                CreateParameter(":custType", DbType.String, ValueOrNull(custType)),
                CreateParameter(":aboriginal", DbType.Decimal, ValueOrNull(aboriginal))
            };

                strSQL =
                    @"INSERT INTO T_Client_Order
                        (ORDER_NO, CUST_NO, FIRSTNAME, LASTNAME, POSITION,
                        ORGANIZATION, ORGANIZATION2, ADDRESS, ADDRESS2, CITY,
                        PROV_STATE, POSTAL_ZIP, COUNTRY, TEL_WORK, TEL_HOME,
                        FAX, EMAIL, NUM, EVENT, GROUP_CODE,
                        USE_CODE, COMMENTS, SUB_TOTAL, DISCOUNT, SUB_TOTAL_DISCOUNT,
                        GST, PST, HST, SANDH, SANDHGST,
                        SANDHPST, SANDHHST, TOTAL_SALE, ORDERSSHIPPED, DATESENT,
                        PAYMETHODE, CARDTYPE, NAMEONCARD, VISANO, EXPDATE,
                        PO, DATEIN, DATEEDIT, SOURCE, SHIPMETHODDESC,
                        SHIPMETHODCODE, DISTCHANNEL, AFFILIATION, SENT_TO_CALLBASE, PROCESS_STATUS,
                        PROV_STATE_LONG, CUST_TYPE, ABORIGINAL)";
                strSQL = strSQL + "VALUES (" + o.ToString() + ", ";
                strSQL = strSQL + @":custNo, :firstName, :lastName, :position,
                        :organization, :organization2, :address, :address2, :city,
                        :provState, :postalZip, :country, :telWork, :telHome,
                        :fax, :email, :num, :evnt, :groupCode,
                        :useCode, :comments, :subTotal, :discount, :subTotalDiscount,
                        :gst, :pst, :hst, :sandh, :sandhGST,
                        :sandhPST, :sandhHST, :totalSale, :ordersShipped, :dateSent,
                        :paymethode, :cardType, :nameOnCard, :visano, :expDate,
                        :po, :dateIn, :dateEdit, :source, :shipMethodDesc,
                        :shipMethodCode, :distChannel, :affiliation, :sentToCallbase, :processStatus,
                        :provStateLong, :custType, :aboriginal)";

                parms2[0].Direction = ParameterDirection.Input;
                ExecuteNonQuery(strSQL, CommandType.Text, parms2);
                //retval = (decimal)parms2[0].Value;
                retval = o;
            }

            return retval;
        }


        public decimal newOrderNumber()
        {
            decimal x;
            string strSQL =
        @"SELECT INVOICE_SEQ.nextVal from dual";

            DataSet ds = Execute(strSQL, CommandType.Text);
            x = Convert.ToDecimal(ds.Tables[0].Rows[0].ItemArray[0].ToString());
            return x;
        }

    }
}
