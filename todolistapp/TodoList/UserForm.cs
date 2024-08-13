using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
//Class to handle the Specific Users TodoList
namespace TodoList
{
    public partial class UserForm : Form
    {
        private ItemInput itemInput;
        public static String result;
        private String connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public int id;
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
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String query = "SELECT TodoItem FROM Todo.dbo.todos WHERE UserID = @id;";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                listbox.Items.Add(reader["TodoItem"]);
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
            listbox.SelectionMode = SelectionMode.MultiExtended;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            itemInput = new ItemInput();
            itemInput.ShowDialog();
            if (result.Length > 0)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        String query = "INSERT INTO Todo.dbo.todos (UserID, TodoItem) VALUES (@userID, @todoItem);";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@userID", id);
                            command.Parameters.AddWithValue("@todoItem", result);
                            command.ExecuteNonQuery();
                        }
                        connection.Close();
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                listbox.Items.Add(result);
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            foreach (String s in listbox.SelectedItems.OfType<String>().ToList())
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        String query = "DELETE FROM Todo.dbo.todos WHERE UserID = @userID AND TodoItem = @todoItem;";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@userID", id);
                            command.Parameters.AddWithValue("@todoItem", s);
                            command.ExecuteNonQuery();
                        }
                        connection.Close();
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
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
                        try
                        {
                            using (SqlConnection connection = new SqlConnection(connectionString))
                            {
                                connection.Open();
                                String query = "UPDATE Todo.dbo.todos SET TodoItem = @newTodoItem WHERE UserID = @userID AND TodoItem = @todoItem;";
                                using (SqlCommand command = new SqlCommand(query, connection))
                                {
                                    command.Parameters.AddWithValue("@userID", id);
                                    command.Parameters.AddWithValue("@newTodoItem", result);
                                    command.Parameters.AddWithValue("@todoItem", (String)listbox.SelectedItem);
                                    command.ExecuteNonQuery();
                                }
                                connection.Close();
                            }
                        }
                        catch (SqlException ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                        listbox.Items[index] = result;
                    } else
                    {
                        try
                        {
                            using (SqlConnection connection = new SqlConnection(connectionString))
                            {
                                connection.Open();
                                String query = "DELETE FROM Todo.dbo.todos WHERE UserID = @userID AND TodoItem = @todoItem;";
                                using (SqlCommand command = new SqlCommand(query, connection))
                                {
                                    command.Parameters.AddWithValue("@userID", id);
                                    command.Parameters.AddWithValue("@todoItem", (String)listbox.SelectedItem);
                                    command.ExecuteNonQuery();
                                }
                                connection.Close();
                            }
                        }
                        catch (SqlException ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                        listbox.Items.RemoveAt(index);
                    }
                    
                }
            }
        }
    }
}
