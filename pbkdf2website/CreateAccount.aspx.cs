using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Text.RegularExpressions;

// Robert Sean McDonald 10/23/18

public partial class UserCreate : System.Web.UI.Page
{
    bool boolProceed = true;

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtFirstName.Text != "" && txtLastName.Text != "" && txtPassword.Text != "" && txtUsername.Text != "") // all fields must be filled out
        {
            if (checkPasswordValid(txtPassword.Text))
            {
                lblStatus.Text = "Valid Password!";
                boolProceed = true;
            }
            else
            {
                lblStatus.Text = "Invalid Password! Must be 8 Characters long, contain one number and one special character";
                boolProceed = false;
            }


            if (boolProceed)
            {
                // COMMIT VALUES
                try
                {
                    System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
                    sc.ConnectionString = ConfigurationManager.ConnectionStrings["cs"].ConnectionString; // connect to PBKDF2 database
                    lblStatus.Text = "Database Connection Successful";

                    sc.Open();

                    System.Data.SqlClient.SqlCommand createUser = new System.Data.SqlClient.SqlCommand();
                    createUser.Connection = sc;
                    // INSERT USER RECORD
                    createUser.CommandText = "insert into[dbo].[Person] values(@FName, @LName, @Username)";
                    createUser.Parameters.Add(new SqlParameter("@FName", txtFirstName.Text));
                    createUser.Parameters.Add(new SqlParameter("@LName", txtLastName.Text));
                    createUser.Parameters.Add(new SqlParameter("@Username", txtUsername.Text));
                    createUser.ExecuteNonQuery();

                    System.Data.SqlClient.SqlCommand setPass = new System.Data.SqlClient.SqlCommand();
                    setPass.Connection = sc;
                    // INSERT PASSWORD RECORD AND CONNECT TO USER
                    setPass.CommandText = "insert into[dbo].[Pass] values((select max(userid) from person), @Username, @Password)";
                    setPass.Parameters.Add(new SqlParameter("@Username", txtUsername.Text));
                    setPass.Parameters.Add(new SqlParameter("@Password", PasswordHash.HashPassword(txtPassword.Text))); // hash entered password
                    setPass.ExecuteNonQuery();

                    sc.Close();

                    lblStatus.Text = "User committed!";
                    txtFirstName.Enabled = false;
                    txtFirstName.Text = string.Empty;
                    txtLastName.Enabled = false;
                    txtLastName.Text = string.Empty;
                    txtUsername.Enabled = false;
                    txtUsername.Text = string.Empty;
                    txtPassword.Enabled = false;
                    btnSubmit.Enabled = false;
                    lnkAnother.Visible = true;
                }
                catch
                {
                    lblStatus.Text = "Database Error - User not committed.";
                }
            }
        }
        else
            lblStatus.Text = "Fill all fields.";
    }

    protected void lnkLogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("userLogin.aspx", false);
    }

    protected void lnkAnother_Click(object sender, EventArgs e)
    {
        txtFirstName.Enabled = true;
        txtLastName.Enabled = true;
        txtUsername.Enabled = true;
        txtPassword.Enabled = true;
        btnSubmit.Enabled = true;
        lnkAnother.Visible = false;
        txtFirstName.Text = "";
        txtLastName.Text = "";
        txtUsername.Text = "";
        txtPassword.Text = "";
    }

    public bool checkPasswordValid(string PW)
    {
        bool boolValid = false;
        //Regex Letters = new Regex(@"^A-Za-z");
        //Regex Numbers = new Regex(@"^0-9");
        //Regex Specials = new Regex(@"^[!@#$%^&*()-_+={}|\:;<,>>?/~`\'\']");
        Regex ChkPass = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
        //https://stackoverflow.com/questions/34715501/validating-password-using-regex-c-sharp

        //if ((Letters.Match(PW).Success) && (Numbers.Match(PW).Success) && (Specials.Match(PW).Success))
        if (ChkPass.Match(PW).Success)
        {
            boolValid = true;
        }
        else
        {
            boolValid = false;
        }

        return boolValid;

    }
}