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
        private ItemInput itemInput;
        public static String result;
        public UserForm()
        {
            InitializeComponent();
        }

        public UserForm CreateUserForm()
        {
            InitializeComponent();
            return this;
        } //TODO add remove, move orders, etc.

        private void User_Load(object sender, EventArgs e)
        {
            listbox.SelectionMode = SelectionMode.MultiExtended;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            itemInput = new ItemInput();
            itemInput.ShowDialog();
            if (result.Length > 0)
            {
                listbox.Items.Add(result);
            }
        }
    }
}
