using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.ComponentModel.Design;
using System.Data.SqlClient;
namespace eBuy
{
    public partial class login : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\geinore.biniyam\source\repos\eBuy\eBuy\DatabaseTest.mdf;Integrated Security=True");
        public string UserEmail { get; set; }
        public string Userpassword { get; set; }
        public string ErrorMessage;
        

        public int errorCount = 0;
        public login()
        {
            InitializeComponent();

        }

        private bool EmailIsValid(string emailAddress)
        {
            Regex ValidEmailRegex = new Regex(@"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$", RegexOptions.IgnoreCase);
            bool isValid =false;
            if (string.IsNullOrEmpty(emailAddress.Trim()))
            {
                ErrorMessage += "Email filed is empty \n";
            }
            
            else if (!ValidEmailRegex.IsMatch(emailAddress))
            {
                ErrorMessage +="Email Is not in correct format (someone@somecompany.com)\n";
            }
            else{
                isValid = true;
            }
            return isValid;
        }
        private bool ValidatePassword(string password)
        {
            var input = password;
            bool isValid = false;
            
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{8,12}");
            var hasLowerChar = new Regex(@"[a-z]+");
            //var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");
            if (string.IsNullOrEmpty(input))
            {
                ErrorMessage +="Password Filed is empty\n";
            }
            else if (!hasLowerChar.IsMatch(input))
            {
                ErrorMessage += ("Password should contain At least one lower case letter\n");

               
            }
            else if (!hasUpperChar.IsMatch(input))
            {
                ErrorMessage += ("Password should contain At least one UPPER case letter\n");

               
            }
            else if (!hasMiniMaxChars.IsMatch(input))
            {
                ErrorMessage += ("Password should not be < 8  & > 12 characters\n");
              
            }
            else if (!hasNumber.IsMatch(input))
            {
                ErrorMessage += ("Password should contain At least one numeric value\n");
               
            }

           
            else
            {
                isValid = true;
            }
            return isValid;
        }


        private void button1_Click(object sender, EventArgs e)
        { //define local variables from the user inputs
            string email = tbEmail.Text;
            string password = tbPassword.Text;
            string name = "Benjamin";
            string phone = "34534654";
            string address ="Gogota";
            //check if eligible to be logged in

            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ErrorMessage = "";
                return;
            }
            
            if (!EmailIsValid(email))
            {
                control.Text = ErrorMessage;
                control.ForeColor = Color.Red;
                return;
            }
           
            if (!ValidatePassword(password))
            {
              control.Text = ErrorMessage;
                control.ForeColor = Color.Red;
                return;
            }
            var rand = new Random();
            int id = rand.Next(10000);
            connection.Open();
            //var command = new SqlCommand("INSERT INTO Contact(Id,name,email,password) Values('" + model + "','" + model.FirstName + " " + model.LastName + "','" + model.Email + " " + model.Phone + "','" + model.CompanyID + "')", connection);
            //command.ExecuteNonQuery();

            SqlCommand cmd = new SqlCommand("INSERT INTO Customer VALUES('" + id + "','" + name + "','" + email + "','" + password + "','" + phone + "','" + address + "')",connection);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Database updated");
            connection.Close();


        }
    }
}
