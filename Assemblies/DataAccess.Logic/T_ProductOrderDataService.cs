using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using CallBaseCRM.Shared.DataAccess.Helper;

namespace CallBaseCRM.DataAccess.Logic
{
    public class T_ProductOrderDataService: DAHelper
    {
        /// <summary>
        /// 
        /// </summary>
        public T_ProductOrderDataService()
            : base()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poNumber"></param>
        /// <returns></returns>
        public DataSet Get(
            decimal? poNumber)
        {
            string strSQL =
                @"SELECT *
                FROM T_Product_Order
                WHERE PO_NUMBER = :poNumber";
            DbParameter[] parms = new DbParameter[]
            {
                CreateParameter(":poNumber", DbType.Decimal, ValueOrNull(poNumber))
            };

            return Execute(strSQL, CommandType.Text, parms);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poNumber"></param>
        /// <returns></returns>
        public bool Exists(
            decimal? poNumber)
        {
            DataSet ds = Get(poNumber);

            return (ds.Tables[0].Rows.Count != 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poNumber"></param>
        public void Delete(
            decimal? poNumber)
        {
            string strSQL =
                @"DELETE FROM T_Product_Order
                WGERE PO_NUMBER = :poNumber";
            DbParameter[] parms = new DbParameter[]
            {
                CreateParameter(":poNumber", DbType.Decimal, ValueOrNull(poNumber))
            };

            ExecuteNonQuery(strSQL, CommandType.Text, parms);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poNumber"></param>
        /// <param name="orderNo"></param>
        /// <param name="custNo"></param>
        /// <param name="invSeq"></param>
        /// <param name="item"></param>
        /// <param name="poDesc"></param>
        /// <param name="poUnitPrice"></param>
        /// <param name="poQty"></param>
        /// <param name="poDiscount"></param>
        /// <param name="poPrice"></param>
        /// <param name="poTotal"></param>
        /// <param name="poDiscountTotal"></param>
        /// <param name="poDateSent"></param>
        /// <param name="poStatus"></param>
        /// <param name="poDone"></param>
        /// <param name="poRegion"></param>
        /// <param name="poDateIns"></param>
        /// <param name="poDateStart"></param>
        /// <param name="poDateEnd"></param>
        /// <param name="poNotes"></param>
        /// <param name="poRegionCode"></param>
        /// <returns></returns>
        public decimal Save(
            decimal? poNumber,
            decimal? orderNo,
            decimal? custNo,
            decimal? invSeq,
            string item,
            string poDesc,
            decimal? poUnitPrice,
            decimal? poQty,
            decimal? poDiscount,
            decimal? poPrice,
            decimal? poTotal,
            decimal? poDiscountTotal,
            DateTime? poDateSent,
            string poStatus,
            string poDone,
            string poRegion,
            DateTime? poDateIns,
            DateTime? poDateStart,
            DateTime? poDateEnd,
            string poNotes,
            string poRegionCode)
        {
            // Create the parameter list
            DbParameter[] parms = new DbParameter[]
            {
                CreateParameter(":poNumber", DbType.Decimal, ValueOrNull(poNumber)),
                CreateParameter(":orderNo", DbType.Decimal, ValueOrNull(orderNo)),
                CreateParameter(":custNo", DbType.Decimal, ValueOrNull(custNo)),
                CreateParameter(":invSeq", DbType.Decimal, ValueOrNull(invSeq)),
                CreateParameter(":item", DbType.String, ValueOrNull(item)),
                CreateParameter(":poDesc", DbType.String, ValueOrNull(poDesc)),
                CreateParameter(":poUnitPrice", DbType.Decimal, ValueOrNull(poUnitPrice)),
                CreateParameter(":poQty", DbType.Decimal, ValueOrNull(poQty)),
                CreateParameter(":poDiscount", DbType.Decimal, ValueOrNull(poDiscount)),
                CreateParameter(":poPrice", DbType.Decimal, ValueOrNull(poPrice)),
                CreateParameter(":poTotal", DbType.Decimal, ValueOrNull(poTotal)),
                CreateParameter(":poDiscountTotal", DbType.Decimal, ValueOrNull(poDiscountTotal)),
                CreateParameter(":poDateSent", DbType.DateTime, ValueOrNull(poDateSent)),
                CreateParameter(":poStatus", DbType.String, ValueOrNull(poStatus)),
                CreateParameter(":poDone", DbType.String, ValueOrNull(poDone)),
                CreateParameter(":poRegion", DbType.String, ValueOrNull(poRegion)),
                CreateParameter(":poDateIns", DbType.DateTime, ValueOrNull(poDateIns)),
                CreateParameter(":poDateStart", DbType.DateTime, ValueOrNull(poDateStart)),
                CreateParameter(":poDateEnd", DbType.DateTime, ValueOrNull(poDateEnd)),
                CreateParameter(":poNotes", DbType.String, ValueOrNull(poNotes)),
                CreateParameter(":poRegionCode", DbType.String, ValueOrNull(poRegionCode))
            };

            // Do an update or an insert
            string strSQL;
            decimal retval;
            if (Exists(poNumber))
            {
                strSQL =
                    @"UPDATE T_Product_Order
                    SET ORDER_NO = :orderNo,
                        CUST_NO = :custNo,
                        INV_SEQ = :invSeq,
                        ITEM = :item,
                        PO_DESC = :poDesc,
                        PO_UNIT_PRICE = :poUnitPrice,
                        PO_QTY = :poQty,
                        PO_DISCOUNT = :poDiscount,
                        PO_PRICE = :poPrice,
                        PO_TOTAL = :poTotal,
                        PO_DISCOUNT_TOTAL = :poDiscountTotal,
                        PO_DATE_SENT = :poDateSent,
                        PO_STATUS = :poStatus,
                        PO_DONE = :poDone,
                        PO_REGION = :poRegion,
                        PO_DATE_INS = :poDateIns,
                        PO_DATE_START = :poDateStart,
                        PO_DATE_END = :poDateEnd,
                        PO_NOTES = :poNotes,
                        PO_REGION_CODE = :poRegionCode
                    WHERE PO_NUMBER = :poNumber";

                ExecuteNonQuery(strSQL, CommandType.Text, parms);
                retval = poNumber.Value;
            }
            else
            {
                strSQL =
                    @"INSERT INTO T_Product_Order
                        (PO_NUMBER, ORDER_NO, CUST_NO, INV_SEQ, ITEM,
                        PO_DESC, PO_UNIT_PRICE, PO_QTY, PO_DISCOUNT, PO_PRICE,
                        PO_TOTAL, PO_DISCOUNT_TOTAL, PO_DATE_SENT, PO_STATUS, PO_DONE,
                        PO_REGION, PO_DATE_INS, PO_DATE_START, PO_DATE_END, PO_NOTES,
                        PO_REGION_CODE)
                    VALUES (PO_NUMBER.nextVal, :orderNo, :custNo, :invSeq, :item,
                            :poDesc, :poUnitPrice, :poQty, :poDiscount, :poPrice,
                            :poTotal, :poDiscountTotal, :poDateSent, :poStatus, :poDone,
                            :poRegion, :poDateIns, :poDateStart, :poDateEnd, :poNotes,
                            :poRegionCode)
                    RETURNING PO_NUMBER INTO :poNumber";

                parms[0].Direction = ParameterDirection.Output;
                ExecuteNonQuery(strSQL, CommandType.Text, parms);
                retval = (decimal)parms[0].Value;
            }

            return retval;
        }
    }
}
