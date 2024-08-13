using System.Collections;
using System.Configuration;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Data.SqlClient;
//Login form to handle the loging in and creation of users
namespace TodoList
{
    public partial class Login : Form
    {
        private UserForm userForm;
        private List<String> usernameList = new List<string>();
        private List<String> passwordList = new List<string>();

        public Login()
        {
            InitializeComponent();
        }

        private void Login_load(object sender, EventArgs e)
        {
            passwordinput.Text = "";
            passwordinput.PasswordChar = '*';
            passwordinput.MaxLength = 20;
        }

        private void submit_Click(object sender, EventArgs e)
        {
            String username = usernameinput.Text.Trim();
            String password = passwordinput.Text.Trim();
            String connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String query = "SELECT UserID, Password, Salt FROM Todo.dbo.users WHERE UserName = @username;";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        using (SqlDataReader reader = command.ExecuteReader())

                        {
                            if (reader.Read())
                            {
                                byte[] salt = (byte[])reader["Salt"];
                                byte[] storedHash = (byte[])reader["Password"];

                                byte[] hashedPassword = HashPassword(password, salt);

                                if(StructuralComparisons.StructuralEqualityComparer.Equals(storedHash, hashedPassword))
                                {
                                    userForm = new UserForm();
                                    userForm.id = (int)reader["UserID"];
                                    userForm.Show();
                                    this.Hide();
                                } else
                                {
                                    usernameinput.Text = storedHash.Length.ToString();
                                    passwordinput.Text = hashedPassword.Length.ToString();
                                    //throw error message
                                }
                            } else
                            {
                                //throw error message
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void signup_Click(object sender, EventArgs e)
        {
            String connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String username = usernameinput.Text.Trim();
                    String password = passwordinput.Text.Trim();
                    byte[] salt = new byte[16];
                    RandomNumberGenerator.Fill(salt);
                    byte[] hashPassword = HashPassword(password, salt);

                    String query = "INSERT INTO Todo.dbo.users (UserName, Password, Salt) VALUES (@username, @hashPassword, @salt);";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@hashPassword", hashPassword);
                        command.Parameters.AddWithValue("@salt", salt);
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                usernameinput.Text = ex.Message;
                Console.WriteLine(ex.ToString());
            }
        }

        private byte[] HashPassword(String password, byte[] salt)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] combined = new byte[salt.Length + password.Length];
                Buffer.BlockCopy(salt, 0, combined, 0, salt.Length);
                Buffer.BlockCopy(Encoding.UTF8.GetBytes(password), 0, combined, salt.Length, password.Length);
                return sha256.ComputeHash(combined);
            }
        }
    }
}
