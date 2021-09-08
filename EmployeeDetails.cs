using System;
using System.Data.SqlClient;
namespace Employee
{
    class EmployeeDetails : Validate
    {
        private String EmployeeName;
        private String EmployeeId;
        private String EmployeeDateofBirth;
        private String PhoneNumber;
        private String EmailAddress;
        public EmployeeDetails(String employeename, String employeeId, String PhoneNumber, String employeeEmail, String employeeDOB)
        {
            this.EmployeeName = employeename;
            this.EmployeeId = employeeId;
            this.PhoneNumber = PhoneNumber;
            this.EmailAddress = employeeEmail;
            this.EmployeeDateofBirth = employeeDOB;
        }
        public EmployeeDetails()
        {
        }
        public override String getEmployeeName()
        {
            return this.EmployeeName;
        }
        public override String getEmployeeID()
        {
            return this.EmployeeId;
        }
        public override String getEmployeePhoneNumber()
        {
            return this.PhoneNumber;
        }
        public override String getEmail()
        {
            return this.EmailAddress;
        }
        public override String getEmployeeDOB()
        {
            return this.EmployeeDateofBirth;
        }
        public void getvalidateDetailsandPrintDetails()
        {
            Validate validate = new Validate();
            validate.validateEmployeeName();
            validate.validateEmployeeID();
            validate.validateEmployeeDateofBirth();
            validate.validateEmployeePhoneNumber();
            validate.validateEmployeeEmail();
            string name = validate.getEmployeeName();
            string ID = validate.getEmployeeID();
            string phoneNumber = validate.getEmployeePhoneNumber();
            string email = validate.getEmail();
            string DOB = validate.getEmployeeDOB();
            EmployeeDetails employeedetails = new EmployeeDetails(name,ID, phoneNumber, email, DOB);
            Console.WriteLine("\nEMPLOYEE DETAILS\n--------------------------\nEmployee Name: " + employeedetails.getEmployeeName());
            Console.WriteLine("Employee ID: " + employeedetails.getEmployeeID());
            Console.WriteLine("Date Of Birth: " + employeedetails.getEmployeeDOB());
            Console.WriteLine("Phone Number: " +
            employeedetails.getEmployeePhoneNumber());
            Console.WriteLine("Email Address: " + employeedetails.getEmail());
            string ConnectionString = "data source=.; database=Employee; user id = sa;password = 1234";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand insertCommand = new SqlCommand("INSERT INTO employee_details(name, employee_id, dob, phone_number, email_address) VALUES(@0, @1,@2,@3, @4)", connection);
                insertCommand.Parameters.Add(new SqlParameter("0", name));
                insertCommand.Parameters.Add(new SqlParameter("1", ID));
                insertCommand.Parameters.Add(new SqlParameter("2", DOB));
                insertCommand.Parameters.Add(new SqlParameter("3", phoneNumber));
                insertCommand.Parameters.Add(new SqlParameter("4", email));
                Console.WriteLine("Commands executed! Total rows affected are "+insertCommand.ExecuteNonQuery());
                connection.Close();
            }
        }
    }
}