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
            return rg.IsMatch(email);
        }
        public bool CheckTelePhone(string telephone)
        {
            string pattern = @"^[0-9]{10}$";
            Regex rg = new Regex(pattern);
            return rg.IsMatch(telephone);
        }
        public bool CheckBirthDate(DateTime birthDate)
        {
           if(birthDate.Date >= DateTime.Now.Date)
            {
                return false;
            }
            return true;
        }
        public bool CheckCitizenId(string citizen)
        {
            if(citizen.Length != 13)
            {
                return false;
            }
            decimal step1 = (citizen[0] * 13) + (citizen[1] * 12) + (citizen[2] * 11) + (citizen[3] * 10) + (citizen[4] * 9) + (citizen[5] * 8) + (citizen[6] * 7) + (citizen[7] * 6) + (citizen[8] * 5) + (citizen[9] * 4) + (citizen[10] * 3) + (citizen[12] * 2);
            decimal step2 = step1 % 11;
            decimal step3 = 11 - step2;
            if(step3.ToString().Length > 1)
            {
                
                step3 = Convert.ToDecimal((step3.ToString())[0]) + Convert.ToDecimal((step3.ToString())[1]);
            }
            return step3 == citizen[12];
        }
    }
}
