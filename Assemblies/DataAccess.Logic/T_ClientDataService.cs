using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using CallBaseCRM.Shared.DataAccess.Helper;

namespace CallBaseCRM.DataAccess.Logic
{
    public class T_ClientDataService: DAHelper
    {
        /// <summary>
        /// 
        /// </summary>
        public T_ClientDataService()
            : base()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="custNo"></param>
        /// <returns></returns>
        public DataSet Get(
            decimal? custNo)
        {
            string strSQL =
                @"SELECT *
                FROM T_Client
                WHERE Cust_No = :custNo";
            DbParameter[] parms = new DbParameter[]
            {
                CreateParameter(":custNo", DbType.Decimal, ValueOrNull(custNo))
            };

            return Execute(strSQL, CommandType.Text, parms);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="custNo"></param>
        /// <returns></returns>
        public bool Exists(
            decimal? custNo)
        {
            DataSet ds = Get(custNo);

            return (ds.Tables[0].Rows.Count != 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="custNo"></param>
        public void Delete(
            decimal? custNo)
        {
            string strSQL =
                @"DELETE FROM T_Client
                WHERE Cust_No = :custNo";
            DbParameter[] parms = new DbParameter[]
            {
                CreateParameter(":custNo", DbType.Decimal, ValueOrNull(custNo))
            };

            ExecuteNonQuery(strSQL, CommandType.Text, parms);
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
        public decimal Save(
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
            // Create the parameter list
            DbParameter[] parms = new DbParameter[]
            {
                CreateParameter(":custNo", DbType.Decimal, ValueOrNull(custNo)),
                CreateParameter(":language", DbType.String, ValueOrNull(language)),
                CreateParameter(":salutation", DbType.String, ValueOrNull(salutation)),
                CreateParameter(":firstName", DbType.String, ValueOrNull(firstName)),
                CreateParameter(":lastName", DbType.String, ValueOrNull(lastName)),
                CreateParameter(":position", DbType.String, ValueOrNull(position)),
                CreateParameter(":organization", DbType.String, ValueOrNull(organization)),
                CreateParameter(":organization2", DbType.String, ValueOrNull(organization2)),
                CreateParameter(":address", DbType.String, ValueOrNull(address)),
                CreateParameter(":city", DbType.String, ValueOrNull(city)),
                CreateParameter(":province", DbType.String, ValueOrNull(province)),
                CreateParameter(":postalCode", DbType.String, ValueOrNull(postalCode)),
                CreateParameter(":country", DbType.String, ValueOrNull(country)),
                CreateParameter(":address2", DbType.String, ValueOrNull(address2)),
                CreateParameter(":phone", DbType.String, ValueOrNull(phone)),
                CreateParameter(":phoneExt", DbType.String, ValueOrNull(phoneExt)),
                CreateParameter(":mobile", DbType.String, ValueOrNull(mobile)),
                CreateParameter(":fax", DbType.String, ValueOrNull(fax)),
                CreateParameter(":eMail", DbType.String, ValueOrNull(eMail)),
                CreateParameter(":phone2", DbType.String, ValueOrNull(phone2)),
                CreateParameter(":phoneExt2", DbType.String, ValueOrNull(phoneExt2)),
                CreateParameter(":email2", DbType.String, ValueOrNull(email2)),
                CreateParameter(":web", DbType.String, ValueOrNull(web)),
                CreateParameter(":notes", DbType.String, ValueOrNull(notes)),
                CreateParameter(":ctype", DbType.String, ValueOrNull(ctype)),
                CreateParameter(":groupCode", DbType.String, ValueOrNull(groupCode)),
                CreateParameter(":regionCode", DbType.String, ValueOrNull(regionCode)),
                CreateParameter(":toDelete", DbType.String, ValueOrNull(toDelete)),
                CreateParameter(":dateIns", DbType.DateTime, ValueOrNull(dateIns)),
                CreateParameter(":dateVerified", DbType.DateTime, ValueOrNull(dateVerified)),
                CreateParameter(":source", DbType.String, ValueOrNull(source)),
                CreateParameter(":otherSalutation", DbType.String, ValueOrNull(otherSalutation)),
                CreateParameter(":otherFirstName", DbType.String, ValueOrNull(otherFirstName)),
                CreateParameter(":otherLastName", DbType.String, ValueOrNull(otherLastName)),
                CreateParameter(":otherPosition", DbType.String, ValueOrNull(otherPosition)),
                CreateParameter(":otherCompany", DbType.String, ValueOrNull(otherCompany)),
                CreateParameter(":otherAddress", DbType.String, ValueOrNull(otherAddress)),
                CreateParameter(":otherAddress2", DbType.String, ValueOrNull(otherAddress2)),
                CreateParameter(":otherCity", DbType.String, ValueOrNull(otherCity)),
                CreateParameter(":otherProvince", DbType.String, ValueOrNull(otherProvince)),
                CreateParameter(":otherPostalCode", DbType.String, ValueOrNull(otherPostalCode)),
                CreateParameter(":otherCountry", DbType.String, ValueOrNull(otherCountry)),
                CreateParameter(":otherPhone", DbType.String, ValueOrNull(otherPhone)),
                CreateParameter(":otherPhone2", DbType.String, ValueOrNull(otherPhone2)),
                CreateParameter(":otherFax", DbType.String, ValueOrNull(otherFax)),
                CreateParameter(":otherEmail", DbType.String, ValueOrNull(otherEmail)),
                CreateParameter(":otherWebsite", DbType.String, ValueOrNull(otherWebsite))
            };

            // Do an update or a insert
            string strSQL;
            decimal retval;
            if (Exists(custNo))
            {
                strSQL =
                    @"UPDATE T_Client
                    SET LANGUAGE = :language,
                        SALUTATION = :salutation,
                        FIRSTNAME = :firstName,
                        LASTNAME = :lastName,
                        POSITION = :position,
                        ORGANIZATION = :organization,
                        ORGANIZATION2 = :organization2,
                        ADDRESS = :address,
                        CITY = :city,
                        PROVINCE = :province,
                        POSTALCODE = :postalCode,
                        COUNTRY = :country,
                        ADDRESS2 = :address2,
                        PHONE = :phone,
                        PHONE_EXT = :phoneExt,
                        MOBILE = :mobile,
                        FAX = :fax,
                        E_MAIL = :eMail,
                        PHONE2 = :phone2,
                        PHONE_EXT2 = :phoneExt2,
                        EMAIL2 = :email2,
                        WEB = :web,
                        NOTES = :notes,
                        CTYPE = :ctype,
                        GROUP_CODE = :groupCode,
                        REGION_CODE = :regionCode,
                        TODELETE = :toDelete,
                        DATE_INS = :dateIns,
                        DATE_VERIFIED = :dateVerified,
                        SOURCE = :source,
                        OTHERSALUTATION = :otherSalutation,
                        OTHERFIRSTNAME = :otherFirstName,
                        OTHERLASTNAME = :otherLastName,
                        OTHERPOSITION = :otherPosition,
                        OTHERCOMPANY = :otherCompany,
                        OTHERADDRESS = :otherAddress,
                        OTHERADDRESS2 = :otherAddress2,
                        OTHERCITY = :otherCity,
                        OTHERPROVINCE = :otherProvince,
                        OTHERPOSTALCODE = :otherPostalCode,
                        OTHERCOUNTRY = :otherCountry,
                        OTHERPHONE = :otherPhone,
                        OTHERPHONE2 = :otherPhone2,
                        OTHERFAX = :otherFax,
                        OTHEREMAIL = :otherEmail,
                        OTHERWEBSITE = :otherWebsite
                    WHERE CUST_NO = :custNo";

                ExecuteNonQuery(strSQL, CommandType.Text, parms);
                retval = custNo.Value;
            }
            else
            {
                strSQL =
                    @"INSERT INTO T_Client
                        (CUST_NO, LANGUAGE, SALUTATION, FIRSTNAME, LASTNAME,
                        POSITION, ORGANIZATION, ORGANIZATION2, ADDRESS, CITY,
                        PROVINCE, POSTALCODE, COUNTRY, ADDRESS2, PHONE,
                        PHONE_EXT, MOBILE, FAX, E_MAIL, PHONE2,
                        PHONE_EXT2, EMAIL2, WEB, NOTES, CTYPE,
                        GROUP_CODE, REGION_CODE, TODELETE, DATE_INS, DATE_VERIFIED,
                        SOURCE, OTHERSALUTATION, OTHERFIRSTNAME, OTHERLASTNAME, OTHERPOSITION,
                        OTHERCOMPANY, OTHERADDRESS, OTHERADDRESS2, OTHERCITY, OTHERPROVINCE,
                        OTHERPOSTALCODE, OTHERCOUNTRY, OTHERPHONE, OTHERPHONE2, OTHERFAX,
                        OTHEREMAIL, OTHERWEBSITE)
                    VALUES (CUST_NO.nextVal, :language, :salutation, :firstName, :lastName,
	                        :position, :organization, :organization2, :address, :city,
                            :province, :postalCode, :country, :address2, :phone,
                            :phoneExt, :mobile, :fax, :eMail, :phone2,
                            :phoneExt2, :email2, :web, :notes, :ctype,
    	                    :groupCode, :regionCode, :toDelete, :dateIns, :dateVerified,
                            :source, :otherSalutation, :otherFirstName, :otherLastName, :otherPosition,
                            :otherCompany, :otherAddress, :otherAddress2, :otherCity, :otherProvince,
                            :otherPostalCode, :otherCountry, :otherPhone, :otherPhone2, :otherFax,
                            :otherEmail, :otherWebsite)
                    RETURNING CUST_NO INTO :custNO";
                parms[0].Direction = ParameterDirection.Output;
                ExecuteNonQuery(strSQL, CommandType.Text, parms);

                // Retrieve the key of the last record inserted
                retval = (decimal)parms[0].Value;
            }

            return retval;
        }
    }
}
