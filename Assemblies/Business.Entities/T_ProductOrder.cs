using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CallBaseCRM.DataAccess.Logic;

namespace CallBaseCRM.Business.Entities
{
    public class T_ProductOrder: BaseObject
    {
        /// <summary>
        /// Instance variables
        /// </summary>
        private decimal? _PONumber;
        private decimal? _OrderNo;
        private decimal? _CustNo;
        private decimal? _InvSeq;
        private string _Item;
        private string _PODesc;
        private decimal? _POUnitPrice;
        private decimal? _POQty;
        private decimal? _PODiscount;
        private decimal? _POPrice;
        private decimal? _POTotal;
        private decimal? _PODiscountTotal;
        private DateTime? _PODateSent;
        private string _POStatus;
        private string _PODone;
        private string _PORegion;
        private DateTime? _PODateIns;
        private DateTime? _PODateStart;
        private DateTime? _PODateEnd;
        private string _PONotes;
        private string _PORegionCode;

        /// <summary>
        /// Property getter/setters
        /// </summary>
        public decimal? PONumber
        {
            get { return _PONumber; }
            set { _PONumber = value; }
        }

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

        public decimal? InvSeq
        {
            get { return _InvSeq; }
            set { _InvSeq = value; }
        }

        public string Item
        {
            get { return _Item; }
            set { _Item = FixUpString(value); }
        }

        public string PODesc
        {
            get { return _PODesc; }
            set { _PODesc = FixUpString(value); }
        }

        public decimal? POUnitPrice
        {
            get { return _POUnitPrice; }
            set { _POUnitPrice = value; }
        }

        public decimal? POQty
        {
            get { return _POQty; }
            set { _POQty = value; }
        }

        public decimal? PODiscount
        {
            get { return _PODiscount; }
            set { _PODiscount = value; }
        }

        public decimal? POPrice
        {
            get { return _POPrice; }
            set { _POPrice = value; }
        }

        public decimal? POTotal
        {
            get { return _POTotal; }
            set { _POTotal = value; }
        }

        public decimal? PODiscountTotal
        {
            get { return _PODiscountTotal; }
            set { _PODiscountTotal = value; }
        }

        public DateTime? PODateSent
        {
            get { return _PODateSent; }
            set { _PODateSent = value; }
        }

        public string POStatus
        {
            get { return _POStatus; }
            set { _POStatus = FixUpString(value); }
        }

        public string PODone
        {
            get { return _PODone; }
            set { _PODone = FixUpString(value); }
        }

        public string PORegion
        {
            get { return _PORegion; }
            set { _PORegion = FixUpString(value); }
        }

        public DateTime? PODateIns
        {
            get { return _PODateIns; }
            set { _PODateIns = value; }
        }

        public DateTime? PODateStart
        {
            get { return _PODateStart; }
            set { _PODateStart = value; }
        }

        public DateTime? PODateEnd
        {
            get { return _PODateEnd; }
            set { _PODateEnd = value; }
        }

        public string PONotes
        {
            get { return _PONotes; }
            set { _PONotes = FixUpString(value); }
        }

        public string PORegionCode
        {
            get { return _PORegionCode; }
            set { _PORegionCode = FixUpString(value); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        public override void MapData(DataRow row)
        {
            _PONumber = GetDecimal(row, "PO_NUMBER");
            _OrderNo = GetDecimal(row, "ORDER_NO");
            _CustNo = GetDecimal(row, "CUST_NO");
            _InvSeq = GetDecimal(row, "INV_SEQ");
            _Item = GetString(row, "ITEM");
            _PODesc = GetString(row, "PO_DESC");
            _POUnitPrice = GetDecimal(row, "PO_UNIT_PRICE");
            _POQty = GetDecimal(row, "PO_QTY");
            _PODiscount = GetDecimal(row, "PO_DISCOUNT");
            _POPrice = GetDecimal(row, "PO_PRICE");
            _POTotal = GetDecimal(row, "PO_TOTAL");
            _PODiscountTotal = GetDecimal(row, "PO_DISCOUNT_TOTAL");
            _PODateSent = GetDateTime(row, "PO_DATE_SENT");
            _POStatus = GetString(row, "PO_STATUS");
            _PODone = GetString(row, "PO_DONE");
            _PORegion = GetString(row, "PO_REGION");
            _PODateIns = GetDateTime(row, "PO_DATE_INS");
            _PODateStart = GetDateTime(row, "PO_DATE_START");
            _PODateEnd = GetDateTime(row, "PO_DATE_END");
            _PONotes = GetString(row, "PO_NOTES");
            _PORegionCode = GetString(row, "PO_REGION_CODE");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poNumber"></param>
        /// <returns></returns>
        public static T_ProductOrder Get(
            decimal? poNumber)
        {
            T_ProductOrder order = new T_ProductOrder();
            order.MapData(new T_ProductOrderDataService().Get(poNumber));

            return order;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poNumber"></param>
        /// <returns></returns>
        public static bool Exists(
            decimal? poNumber)
        {
            return new T_ProductOrderDataService().Exists(poNumber);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poNumber"></param>
        public static void Delete(
            decimal? poNumber)
        {
            new T_ProductOrderDataService().Delete(poNumber);
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
        public static decimal Save(
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
            return new T_ProductOrderDataService().Save(
                poNumber, orderNo, custNo, invSeq, item,
                poDesc, poUnitPrice, poQty, poDiscount, poPrice,
                poTotal, poDiscountTotal, poDateSent, poStatus, poDone,
                poRegion, poDateIns, poDateStart, poDateEnd, poNotes,
                poRegionCode);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal Save()
        {
            return Save(
                PONumber, OrderNo, CustNo, InvSeq, Item,
                PODesc, POUnitPrice, POQty, PODiscount, POPrice,
                POTotal, PODiscountTotal, PODateSent, POStatus, PODone,
                PORegion, PODateIns, PODateStart, PODateEnd, PONotes,
                PORegionCode);
        }
    }
}
