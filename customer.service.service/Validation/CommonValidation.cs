using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace customer.service.service.Validation
{
    public class CommonValidation
    {
        public bool CheckEmail(string email)
        {           
            string pattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"; 
            Regex rg = new Regex(pattern);
            return !rg.IsMatch(email);
        }
        public bool CheckTelePhone(string telephone)
        {
            string pattern = @"^[0-9]{10}$";
            Regex rg = new Regex(pattern);
            return !rg.IsMatch(telephone);
        }
        public bool CheckBirthDate(DateTime birthDate)
        {
           if(birthDate.Date >= DateTime.Now.Date)
            {
                return true;
            }
            return false;
        }
        public bool CheckCitizenId(string citizen)
        {
            if(citizen.Length != 13)
            {
                return true;
            }
            decimal step1 = (Convert.ToDecimal(citizen[0].ToString())* 13) + (Convert.ToDecimal(citizen[1].ToString()) * 12) + (Convert.ToDecimal(citizen[2].ToString()) * 11) + (Convert.ToDecimal(citizen[3].ToString()) * 10) + (Convert.ToDecimal(citizen[4].ToString()) * 9) + (Convert.ToDecimal(citizen[5].ToString()) * 8) + (Convert.ToDecimal(citizen[6].ToString()) * 7) + (Convert.ToDecimal(citizen[7].ToString()) * 6) + (Convert.ToDecimal(citizen[8].ToString()) * 5) + (Convert.ToDecimal(citizen[9].ToString()) * 4) + (Convert.ToDecimal(citizen[10].ToString()) * 3) + (Convert.ToDecimal(citizen[11].ToString()) * 2);
            decimal step2 = step1 % 11;
            decimal step3 = 11 - step2;
            if(step3.ToString().Length > 1)
            {
              
                step3 = Convert.ToDecimal(step3.ToString()[1].ToString());
            }
            return !(step3.ToString() == citizen[12].ToString());
        }
    }
}
