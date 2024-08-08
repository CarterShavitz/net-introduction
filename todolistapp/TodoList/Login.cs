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
            usernameList.Add("admin");
            passwordList.Add("password");
            
        }

        private void submit_Click(object sender, EventArgs e)
        {
            String username = usernameinput.Text;
            String password = passwordinput.Text;
            if (username == null || password == null)
            {
                //please fill in all fields
            }
            else
            {
                if (usernameList.Contains(username) && passwordList.Contains(password))
                {
                    userForm = new UserForm();
                    userForm.Show();
                    this.Hide();
                }
            }
        }
    }
}
