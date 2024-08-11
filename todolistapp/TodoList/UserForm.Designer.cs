namespace TodoList
{
    partial class UserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            add = new Button();
            listbox = new ListBox();
            SuspendLayout();
            // 
            // add
            // 
            add.Location = new Point(658, 87);
            add.Name = "add";
            add.Size = new Size(78, 23);
            add.TabIndex = 0;
            add.Text = "Add";
            add.UseVisualStyleBackColor = true;
            add.Click += Add_Click;
            // 
            // listbox
            // 
            listbox.Font = new Font("Segoe UI", 20F);
            listbox.FormattingEnabled = true;
            listbox.ItemHeight = 37;
            listbox.Location = new Point(24, 38);
            listbox.Name = "listbox";
            listbox.Size = new Size(607, 263);
            listbox.TabIndex = 2;
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(818, 450);
            Controls.Add(listbox);
            Controls.Add(add);
            Name = "UserForm";
            Text = "Todo List";
            Load += User_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button add;
        private ListBox listbox;
    }
}