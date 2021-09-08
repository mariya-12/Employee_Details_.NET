using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace Employee
{
    class Validate
    {

        protected string employeeName;
        protected string employeeID;
        protected string employeePhoneNumber;
        protected string employeeEmail;
        protected string employeeDOB;
        public void validateEmployeeName()
        {
            do
            {
                Console.WriteLine("Enter the Employee Name :");
                string employeename = Console.ReadLine();
                if (employeename == null || employeename.Length == 0)
                {
                    Console.WriteLine("Employee name cannot be null or EMPTY!");
                
                }
                else
                {
                    var namecharacterset = new HashSet<char>();
                    var length = employeename.Length;

                    for (int count = 0; count < length; count++)
                    {
                        namecharacterset.Add(employeename[count]);
                    }
                    if (namecharacterset.Count == 1)
                    {
                        Console.WriteLine("Invalid Employee Name!");
                    }
                    else
                    {
                        var flag = 0;
                        var employeenametouppercase =

                        employeename.ToUpper();

                        char[] data =

                        employeenametouppercase.ToCharArray();

                        for (var i = 0; i < length; i++)
                        {
                            var asciinum = (int)data[i];
                            if (asciinum != 32)
                            {
                                if (asciinum < 65 || asciinum >

                                90)

                                {
                                    flag = 1;
                                    break;
                                }
                            }
                        }
                        if (flag == 1)
                        {
                            Console.WriteLine("Invalid Character in Employee Name!");
                        }
                        else
                        {
                            this.employeeName =employeename.ToUpper();
                        }
                    }
                }
            } while (this.employeeName == null);
        }
        public void validateEmployeeID()
        {
            do
            {
                Console.WriteLine("Enter the Employee ID:");
                string employeeId = Console.ReadLine();
                if (employeeId == null || employeeId.Length == 0)
                {
                    Console.WriteLine("Employee ID cannot be null or empty!");
                }
                else
                {
                    var length = employeeId.Length;
                    if (length == 7)
                    {
                        var employeeidtoUppercase =employeeId.ToUpper();

                        if (employeeidtoUppercase.StartsWith("ACE"))
                        {
                         if (employeeId.Substring(3, 7 - 3).Equals("0000"))
                            {
                                Console.WriteLine("Employee ID contains 0000!");
                            }
                            else
                            {
                                var flag = 0;
                                for (int count = 3; count < 7; count++)
                                {
                                    if (employeeId[count] >='0' && employeeId[count] <= '9')
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        flag = 1;
                                    }
                                    break;
                                }
                                if (flag == 1)
                                {
                                    Console.WriteLine("Invalid Character in ID!");
                                }
                                else
                                {
                                    this.employeeID = employeeId.ToUpper();
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Employee ID must start with ACE!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Employee ID length must be 7!");
                    }
                }
            } while (this.employeeID == null);
        }
        public void validateEmployeePhoneNumber()
        {
            string regex = "[6-9][0-9]{9}";
            Regex regularexpression = new Regex(regex);
            do
            {
                Console.WriteLine("Enter the Employee Phone Number :");
                string PhoneNumber = Console.ReadLine();
                Match match = regularexpression.Match(PhoneNumber);
                if (match.Success)
                {
                    this.employeePhoneNumber = PhoneNumber;
                }

                else
                {
                    Console.WriteLine("Invalid Phone Number!!! Phonenumber must start with 6, 7, 8, 9 & length should be 10");
                }
            } while (this.employeePhoneNumber == null);
        }
        public void validateEmployeeEmail()
        {
            string regex = "^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$";
            Regex re = new Regex(regex);
            do
            {
                Console.WriteLine("Enter the Employee Email ID :");
                string employeeemail = Console.ReadLine();
                Match match = re.Match(employeeemail);
                if (match.Success)
                {
                    this.employeeEmail = employeeemail;
                }
                else
                {
                    Console.WriteLine("Invalid Email Address!!! (eg: jenny@.com)");
                }
            } while (this.employeeEmail == null);
        }
        public void validateEmployeeDateofBirth()
        {
            int[] days = {31 , 28 , 31 , 30 , 31 , 30 , 31 , 31 , 30 , 31 ,30 , 31};

            //string regex = "^(3[01]|[12][0 - 9]|0[1 - 9])/(1[012]|0[1- 9])/[0 - 9]{ 4} $";
            //Regex regularexpression = new Regex(regex);
            do
            {
                Console.WriteLine("Enter the Employee Date of Birth [dd / mm / yyyy] :");
                var employeedob = Console.ReadLine();
                var length = employeedob.Length;

                if (length != 10)
                {
                    Console.WriteLine("ERROR!! Invalid Date of Birth format");
                }
                else
                {
                    var date = int.Parse(employeedob.Substring(0, 2 -0));
                    var month = int.Parse(employeedob.Substring(3, 5 - 3));
                    var year = int.Parse(employeedob.Substring(6));
                    if (year > 1980 && year <= 1999)
                    {
                        if (month > 0 && month <= 12)
                        {
                            if (date > 0 && date <= days[month - 1])

                            {
                                this.employeeDOB = employeedob;
                            }
                            else

                            {
                                Console.WriteLine("Invalid Date of Birth!!!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid Month!!!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Year of Birth must be between 1980 - 1999!!!");
                    }
                }
            } while (this.employeeDOB == null);
        }
        public virtual String getEmployeeName()
        {
            return this.employeeName;
        }
        public virtual String getEmployeeID()
        {
            return this.employeeID;
        }
        public virtual String getEmployeePhoneNumber()
        {
            return this.employeePhoneNumber;
        }
        public virtual String getEmail()
        {
            return this.employeeEmail;
        }
        public virtual String getEmployeeDOB()
        {
            return this.employeeDOB;
        }
    }
}