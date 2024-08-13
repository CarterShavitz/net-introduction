using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Input class to handle the actual text input of the todo
namespace TodoList
{
    public partial class ItemInput : Form
    {
        public static String updateString;

        public ItemInput()
        {
            InitializeComponent();
        }

        private void ItemInput_Load(object sender, EventArgs e)
        {
            if (updateString != null)
            {
                todoiteminput.Text = updateString;
            }
        }

        private void submititem_Click(object sender, EventArgs e)
        {
            String text = todoiteminput.Text;
            UserForm.result = text;
            this.Hide();
        }
    }
}
