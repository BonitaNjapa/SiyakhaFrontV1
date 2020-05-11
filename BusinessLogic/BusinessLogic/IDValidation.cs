using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class IDValidationAttribute : ValidationAttribute
    {
        public void getIDnumberDetails(string IDnumber, out string gender, out int age, out string Dob)
        {
            int year = Convert.ToInt32(IDnumber.Substring(0, 2));
            int month = Convert.ToInt32(IDnumber.Substring(2, 2));
            int days = Convert.ToInt32(IDnumber.Substring(4, 2));
            int gendeDigit = Convert.ToInt32(IDnumber.Substring(6, 1));
            string y = "" + year;
            if (year > 30)
            {
                year = Convert.ToInt32("19" + year);
            }

            else
            {
                if (year <= 9)
                {
                    y = "0" + year;
                }
                year = Convert.ToInt32("20" + y);
            }
            string d = "" + days;
            string m = "" + month;
            if (days <= 9)
            {
                d = "0" + days;
            }

            if (month <= 9)
            {
                m = "0" + month;
            }
            Dob = d + "/" + m + "/" + year;
            age = DateTime.Now.Year - year;


            if (gendeDigit < 5)
            {
                gender = "Female";
            }
            else
            {
                gender = "Male";
            }
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string Idnumber = Convert.ToString(value);
            int oddPositionValue = 0;
            int evenPositionValue = 0;
            string evenPosition = "";
            int checkdigit = 0;
            char[] IdNumber = Idnumber.ToCharArray();
            for (int i = 0; i < 6; i++)
            {
                try
                {
                    oddPositionValue += Convert.ToInt32(IdNumber[i * 2].ToString());
                    evenPosition += Convert.ToInt32(IdNumber[i * 2 + 1].ToString());
                }
                catch
                {

                }

            }
            evenPositionValue = Convert.ToInt32(evenPosition) * 2;
            char[] evenposition = evenPositionValue.ToString().ToCharArray();

            evenPositionValue = 0;
            for (int i = 0; i < evenposition.Length; i++)
            {
                evenPositionValue += Convert.ToInt32(evenposition[i].ToString());
            }
            checkdigit = oddPositionValue + evenPositionValue;
            checkdigit = Convert.ToInt32(checkdigit.ToString().ToCharArray().Last().ToString());
            checkdigit = 10 - checkdigit;

            if (checkdigit == 10)
            {
                checkdigit = 0;
            }

            if (Convert.ToInt32(Idnumber.Substring(0, 2)) <= 0 || Convert.ToInt32(Idnumber.Substring(2, 2)) <= 0 || Convert.ToInt32(Idnumber.Substring(4, 2)) <= 0 || Convert.ToInt32(Idnumber.Substring(2, 2)) > 12)
                return new ValidationResult("Please check your ID Number (eg 8408315408082)");

            else if (DateTime.DaysInMonth(Convert.ToInt32(Idnumber.Substring(0, 2)), Convert.ToInt32(Idnumber.Substring(2, 2))) < Convert.ToInt32(Idnumber.Substring(4, 2)))
                return new ValidationResult("Please check your ID Number (eg 8408205408082)");

            else if (Convert.ToInt32(Idnumber.Substring(11, 1)) != 8)
                return new ValidationResult("Please check your ID Number (eg 8408205408082)");

            else if (checkdigit != Convert.ToInt32(Idnumber.ToCharArray().Last().ToString()))
                return new ValidationResult("Please check your ID Number (eg 8408205408082)");

            return ValidationResult.Success;
        }
    }
}
