using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CallBaseCRM.DataAccess.Logic;

namespace CallBaseCRM.Business.Entities
{
    public class T_Client: BaseObject
    {
        /// <summary>
        /// Instance variables
        /// </summary>
        private decimal? _CustNo;
        private string _Language;
        private string _Salutation;
        private string _FirstName;
        private string _LastName;
        private string _Position;
        private string _Organization;
        private string _Organization2;
        private string _Address;
        private string _City;
        private string _Province;
        private string _PostalCode;
        private string _Country;
        private string _Address2;
        private string _Phone;
        private string _PhoneExt;
        private string _Mobile;
        private string _Fax;
        private string _EMail;
        private string _Phone2;
        private string _PhoneExt2;
        private string _Email2;
        private string _Web;
        private string _Notes;
        private string _Ctype;
        private string _GroupCode;
        private string _RegionCode;
        private string _ToDelete;
        private DateTime? _DateIns;
        private DateTime? _DateVerified;
        private string _Source;
        private string _OtherSalutation;
        private string _OtherFirstName;
        private string _OtherLastName;
        private string _OtherPosition;
        private string _OtherCompany;
        private string _OtherAddress;
        private string _OtherAddress2;
        private string _OtherCity;
        private string _OtherProvince;
        private string _OtherPostalCode;
        private string _OtherCountry;
        private string _OtherPhone;
        private string _OtherPhone2;
        private string _OtherFax;
        private string _OtherEmail;
        private string _OtherWebsite;

        /// <summary>
        /// Propery getter/setters
        /// </summary>
        public decimal? CustNo
        {
            get { return _CustNo; }
            set { _CustNo = value; }
        }

        public string Language
        {
            get { return _Language; }
            set { _Language = FixUpString(value); }
        }

        public string Salutation
        {
            get { return _Salutation; }
            set { _Salutation = FixUpString(value); }
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

        public string City
        {
            get { return _City; }
            set { _City = FixUpString(value); }
        }

        public string Province
        {
            get { return _Province; }
            set { _Province = FixUpString(value); }
        }

        public string PostalCode
        {
            get { return _PostalCode; }
            set { _PostalCode = FixUpString(value); }
        }

        public string Country
        {
            get { return _Country; }
            set { _Country = FixUpString(value); }
        }

        public string Address2
        {
            get { return _Address2; }
            set { _Address2 = FixUpString(value); }
        }

        public string Phone
        {
            get { return _Phone; }
            set { _Phone = FixUpString(value); }
        }

        public string PhoneExt
        {
            get { return _PhoneExt; }
            set { _PhoneExt = FixUpString(value); }
        }

        public string Mobile
        {
            get { return _Mobile; }
            set { _Mobile = FixUpString(value); }
        }

        public string Fax
        {
            get { return _Fax; }
            set { _Fax = FixUpString(value); }
        }

        public string EMail
        {
            get { return _EMail; }
            set { _EMail = FixUpString(value); }
        }

        public string Phone2
        {
            get { return _Phone2; }
            set { _Phone2 = FixUpString(value); }
        }

        public string PhoneExt2
        {
            get { return _PhoneExt2; }
            set { _PhoneExt2 = FixUpString(value); }
        }

        public string Email2
        {
            get { return _Email2; }
            set { _Email2 = FixUpString(value); }
        }

        public string Web
        {
            get { return _Web; }
            set { _Web = FixUpString(value); }
        }

        public string Notes
        {
            get { return _Notes; }
            set { _Notes = FixUpString(value); }
        }

        public string Ctype
        {
            get { return _Ctype; }
            set { _Ctype = FixUpString(value); }
        }

        public string GroupCode
        {
            get { return _GroupCode; }
            set { _GroupCode = FixUpString(value); }
        }

        public string RegionCode
        {
            get { return _RegionCode; }
            set { _RegionCode = FixUpString(value); }
        }

        public string ToDelete
        {
            get { return _ToDelete; }
            set { _ToDelete = FixUpString(value); }
        }

        public DateTime? DateIns
        {
            get { return _DateIns; }
            set { _DateIns = value; }
        }

        public DateTime? DateVerified
        {
            get { return _DateVerified; }
            set { _DateVerified = value; }
        }

        public string Source
        {
            get { return _Source; }
            set { _Source = FixUpString(value); }
        }

        public string OtherSalutation
        {
            get { return _OtherSalutation; }
            set { _OtherSalutation = FixUpString(value); }
        }

        public string OtherFirstName
        {
            get { return _OtherFirstName; }
            set { _OtherFirstName = FixUpString(value); }
        }

        public string OtherLastName
        {
            get { return _OtherLastName; }
            set { _OtherLastName = FixUpString(value); }
        }

        public string OtherPosition
        {
            get { return _OtherPosition; }
            set { _OtherPosition = FixUpString(value); }
        }

        public string OtherCompany
        {
            get { return _OtherCompany; }
            set { _OtherCompany = FixUpString(value); }
        }

        public string OtherAddress
        {
            get { return _OtherAddress; }
            set { _OtherAddress = FixUpString(value); }
        }

        public string OtherAddress2
        {
            get { return _OtherAddress2; }
            set { _OtherAddress2 = FixUpString(value); }
        }

        public string OtherCity
        {
            get { return _OtherCity; }
            set { _OtherCity = FixUpString(value); }
        }

        public string OtherProvince
        {
            get { return _OtherProvince; }
            set { _OtherProvince = FixUpString(value); }
        }

        public string OtherPostalCode
        {
            get { return _OtherPostalCode; }
            set { _OtherPostalCode = FixUpString(value); }
        }

        public string OtherCountry
        {
            get { return _OtherCountry; }
            set { _OtherCountry = FixUpString(value); }
        }

        public string OtherPhone
        {
            get { return _OtherPhone; }
            set { _OtherPhone = FixUpString(value); }
        }

        public string OtherPhone2
        {
            get { return _OtherPhone2; }
            set { _OtherPhone2 = FixUpString(value); }
        }

        public string OtherFax
        {
            get { return _OtherFax; }
            set { _OtherFax = FixUpString(value); }
        }

        public string OtherEmail
        {
            get { return _OtherEmail; }
            set { _OtherEmail = FixUpString(value); }
        }

        public string OtherWebsite
        {
            get { return _OtherWebsite; }
            set { _OtherWebsite = FixUpString(value); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        public override void MapData(DataRow row)
        {
            _CustNo = GetDecimal(row, "CUST_NO");
            _Language = GetString(row, "LANGUAGE");
            _Salutation = GetString(row, "SALUTATION");
            _FirstName = GetString(row, "FIRSTNAME");
            _LastName = GetString(row, "LASTNAME");
            _Position = GetString(row, "POSITION");
            _Organization = GetString(row, "ORGANIZATION");
            _Organization2 = GetString(row, "ORGANIZATION2");
            _Address = GetString(row, "ADDRESS");
            _City = GetString(row, "CITY");
            _Province = GetString(row, "PROVINCE");
            _PostalCode = GetString(row, "POSTALCODE");
            _Country = GetString(row, "COUNTRY");
            _Address2 = GetString(row, "ADDRESS2");
            _Phone = GetString(row, "PHONE");
            _PhoneExt = GetString(row, "PHONE_EXT");
            _Mobile = GetString(row, "MOBILE");
            _Fax = GetString(row, "FAX");
            _EMail = GetString(row, "E_MAIL");
            _Phone2 = GetString(row, "PHONE2");
            _PhoneExt2 = GetString(row, "PHONE_EXT2");
            _Email2 = GetString(row, "EMAIL2");
            _Web = GetString(row, "WEB");
            _Notes = GetString(row, "NOTES");
            _Ctype = GetString(row, "CTYPE");
            _GroupCode = GetString(row, "GROUP_CODE");
            _RegionCode = GetString(row, "REGION_CODE");
            _ToDelete = GetString(row, "TODELETE");
            _DateIns = GetDateTime(row, "DATE_INS");
            _DateVerified = GetDateTime(row, "DATE_VERIFIED");
            _Source = GetString(row, "SOURCE");
            _OtherSalutation = GetString(row, "OTHERSALUTATION");
            _OtherFirstName = GetString(row, "OTHERFIRSTNAME");
            _OtherLastName = GetString(row, "OTHERLASTNAME");
            _OtherPosition = GetString(row, "OTHERPOSITION");
            _OtherCompany = GetString(row, "OTHERCOMPANY");
            _OtherAddress = GetString(row, "OTHERADDRESS");
            _OtherAddress2 = GetString(row, "OTHERADDRESS2");
            _OtherCity = GetString(row, "OTHERCITY");
            _OtherProvince = GetString(row, "OTHERPROVINCE");
            _OtherPostalCode = GetString(row, "OTHERPOSTALCODE");
            _OtherCountry = GetString(row, "OTHERCOUNTRY");
            _OtherPhone = GetString(row, "OTHERPHONE");
            _OtherPhone2 = GetString(row, "OTHERPHONE2");
            _OtherFax = GetString(row, "OTHERFAX");
            _OtherEmail = GetString(row, "OTHEREMAIL");
            _OtherWebsite = GetString(row, "OTHERWEBSITE");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="custNo"></param>
        /// <returns></returns>
        public static T_Client Get(
            decimal? custNo)
        {
            T_Client client = new T_Client();
            client.MapData(new T_ClientDataService().Get(custNo));

            return client;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="custNo"></param>
        /// <returns></returns>
        public static bool Exists(
            decimal? custNo)
        {
            return new T_ClientDataService().Exists(custNo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="custNo"></param>
        public static void Delete(
            decimal? custNo)
        {
            new T_ClientDataService().Delete(custNo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="custNo"></param>
        /// <param name="language"></param>
        /// <param name="salutation"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="position"></param>
        /// <param name="organization"></param>
        /// <param name="organization2"></param>
        /// <param name="address"></param>
        /// <param name="city"></param>
        /// <param name="province"></param>
        /// <param name="postalCode"></param>
        /// <param name="country"></param>
        /// <param name="address2"></param>
        /// <param name="phone"></param>
        /// <param name="phoneExt"></param>
        /// <param name="mobile"></param>
        /// <param name="fax"></param>
        /// <param name="eMail"></param>
        /// <param name="phone2"></param>
        /// <param name="phoneExt2"></param>
        /// <param name="email2"></param>
        /// <param name="web"></param>
        /// <param name="notes"></param>
        /// <param name="ctype"></param>
        /// <param name="groupCode"></param>
        /// <param name="regionCode"></param>
        /// <param name="toDelete"></param>
        /// <param name="dateIns"></param>
        /// <param name="dateVerified"></param>
        /// <param name="source"></param>
        /// <param name="otherSalutation"></param>
        /// <param name="otherFirstName"></param>
        /// <param name="otherLastName"></param>
        /// <param name="otherPosition"></param>
        /// <param name="otherCompany"></param>
        /// <param name="otherAddress"></param>
        /// <param name="otherAddress2"></param>
        /// <param name="otherCity"></param>
        /// <param name="otherProvince"></param>
        /// <param name="otherPostalCode"></param>
        /// <param name="otherCountry"></param>
        /// <param name="otherPhone"></param>
        /// <param name="otherPhone2"></param>
        /// <param name="otherFax"></param>
        /// <param name="otherEmail"></param>
        /// <param name="otherWebsite"></param>
        /// <returns></returns>
        public static decimal Save(
            decimal? custNo,
            string language,
            string salutation,
            string firstName,
            string lastName,
            string position,
            string organization,
            string organization2,
            string address,
            string city,
            string province,
            string postalCode,
            string country,
            string address2,
            string phone,
            string phoneExt,
            string mobile,
            string fax,
            string eMail,
            string phone2,
            string phoneExt2,
            string email2,
            string web,
            string notes,
            string ctype,
            string groupCode,
            string regionCode,
            string toDelete,
            DateTime? dateIns,
            DateTime? dateVerified,
            string source,
            string otherSalutation,
            string otherFirstName,
            string otherLastName,
            string otherPosition,
            string otherCompany,
            string otherAddress,
            string otherAddress2,
            string otherCity,
            string otherProvince,
            string otherPostalCode,
            string otherCountry,
            string otherPhone,
            string otherPhone2,
            string otherFax,
            string otherEmail,
            string otherWebsite)
        {
            return new T_ClientDataService().Save(
                        custNo, language, salutation, firstName, lastName,
                        position, organization, organization2, address, city,
                        province, postalCode, country, address2, phone,
                        phoneExt, mobile, fax, eMail, phone2,
                        phoneExt2, email2, web, notes, ctype,
                        groupCode, regionCode, toDelete, dateIns, dateVerified,
                        source, otherSalutation, otherFirstName, otherLastName, otherPosition,
                        otherCompany, otherAddress, otherAddress2, otherCity, otherProvince,
                        otherPostalCode, otherCountry, otherPhone, otherPhone2, otherFax,
                        otherEmail, otherWebsite);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal Save()
        {
            return Save(
                CustNo, Language, Salutation, FirstName, LastName,
                Position, Organization, Organization2, Address, City,
                Province, PostalCode, Country, Address2, Phone,
                PhoneExt, Mobile, Fax, EMail, Phone2,
                PhoneExt2, Email2, Web, Notes, Ctype,
                GroupCode, RegionCode, ToDelete, DateIns, DateVerified,
                Source, OtherSalutation, OtherFirstName, OtherLastName, OtherPosition,
                OtherCompany, OtherAddress, OtherAddress2, OtherCity, OtherProvince,
                OtherPostalCode, OtherCountry, OtherPhone, OtherPhone2, OtherFax,
                OtherEmail, OtherWebsite);
        }
    }
}
