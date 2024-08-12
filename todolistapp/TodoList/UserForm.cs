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

        private void delete_Click(object sender, EventArgs e)
        {
            foreach (String s in listbox.SelectedItems.OfType<String>().ToList())
            {
                listbox.Items.Remove(s);
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (listbox.SelectedItem != null)
            {
                Object selectedItem = listbox.SelectedItem;
                ItemInput.updateString = (String) listbox.SelectedItem;
                itemInput = new ItemInput();
                itemInput.ShowDialog();
                int index = listbox.Items.IndexOf(selectedItem);
                if (index != -1)
                {
                    if (result.Length > 0)
                    {
                        listbox.Items[index] = result;
                    } else
                    {
                        listbox.Items.RemoveAt(index);
                    }
                    
                }
            }
        }
    }
}
