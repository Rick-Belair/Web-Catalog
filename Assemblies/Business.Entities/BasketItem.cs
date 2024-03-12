using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CallBaseCRM.Business.Entities
{
    public class BasketItem: BaseObject
    {
        /// <summary>
        /// Instance variables
        /// </summary>
        private decimal? _InvSeq;
        private string _Description;
        private string _DescriptionFr;
        private decimal? _Quantity;
        private string _Item;
        private string _Status;
        private decimal? _Price;
        private decimal? _ShippingAndHandling;
        private decimal? _GST;
        private decimal? _PST;
        private decimal? _HST;
        private decimal? _Quota;
        private decimal? _DateOfPublication;
        private decimal? _NumberOfPages;

        /// <summary>
        /// Property getter/setters
        /// </summary>
        public decimal? InvSeq
        {
            get { return _InvSeq; }
            set { _InvSeq = value; }
        }

        public string Description
        {
            get { return _Description; }
            set { _Description = FixUpString(value); }
        }

        public string DescriptionFr
        {
            get { return _DescriptionFr; }
            set { _DescriptionFr = FixUpString(value); }
        }

        public decimal? Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }

        public string Item
        {
            get { return _Item; }
            set { _Item = FixUpString(value); }
        }

        public string Status
        {
            get { return _Status; }
            set { _Status = FixUpString(value); }
        }

        public decimal? Price
        {
            get { return _Price; }
            set { _Price = value; }
        }

        public decimal? ShippingAndHandling
        {
            get { return _ShippingAndHandling; }
            set { _ShippingAndHandling = value; }
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

        public decimal? Quota
        {
            get { return _Quota; }
            set { _Quota = value; }
        }

        public decimal? DateOfPublication
        {
            get {return _DateOfPublication;}
            set { _DateOfPublication = value; }
        }

        public decimal? NumberOfPages
        {
            get { return _NumberOfPages; }
            set { _NumberOfPages = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return (InvSeq == ((BasketItem)obj).InvSeq);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return ((InvSeq != null) ? (int)InvSeq : 0);
        }
    }
}
