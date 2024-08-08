using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TodoList
{
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
        }

        public UserForm CreateUserForm()
        {
            InitializeComponent();
            return this;
        }

        private void User_Load(object sender, EventArgs e)
        {

        }
    }
}
