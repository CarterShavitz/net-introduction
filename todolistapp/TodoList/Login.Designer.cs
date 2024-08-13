namespace TodoList
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            username = new Label();
            password = new Label();
            passwordinput = new TextBox();
            usernameinput = new TextBox();
            submit = new Button();
            header = new Label();
            signup = new Button();
            SuspendLayout();
            // 
            // username
            // 
            username.AutoSize = true;
            username.Location = new Point(43, 95);
            username.Name = "username";
            username.Size = new Size(63, 15);
            username.TabIndex = 0;
            username.Text = "Username:";
            // 
            // password
            // 
            password.AutoSize = true;
            password.Location = new Point(43, 138);
            password.Name = "password";
            password.Size = new Size(60, 15);
            password.TabIndex = 1;
            password.Text = "Password:";
            // 
            // passwordinput
            // 
            passwordinput.Location = new Point(112, 138);
            passwordinput.Name = "passwordinput";
            passwordinput.Size = new Size(200, 23);
            passwordinput.TabIndex = 2;
            // 
            // usernameinput
            // 
            usernameinput.Location = new Point(113, 92);
            usernameinput.Name = "usernameinput";
            usernameinput.Size = new Size(200, 23);
            usernameinput.TabIndex = 3;
            // 
            // submit
            // 
            submit.Location = new Point(43, 205);
            submit.Name = "submit";
            submit.Size = new Size(184, 23);
            submit.TabIndex = 4;
            submit.Text = "Log In";
            submit.UseVisualStyleBackColor = true;
            submit.Click += submit_Click;
            // 
            // header
            // 
            header.AutoSize = true;
            header.Font = new Font("Segoe UI", 30F);
            header.Location = new Point(297, 9);
            header.Name = "header";
            header.Size = new Size(181, 54);
            header.TabIndex = 5;
            header.Text = "Todo List";
            // 
            // signup
            // 
            signup.Location = new Point(238, 205);
            signup.Name = "signup";
            signup.Size = new Size(75, 23);
            signup.TabIndex = 6;
            signup.Text = "Sign Up";
            signup.UseVisualStyleBackColor = true;
            signup.Click += signup_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(786, 473);
            Controls.Add(signup);
            Controls.Add(header);
            Controls.Add(submit);
            Controls.Add(usernameinput);
            Controls.Add(passwordinput);
            Controls.Add(password);
            Controls.Add(username);
            Name = "Login";
            Text = "Todo List";
            Load += Login_load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label username;
        private Label password;
        private TextBox passwordinput;
        private TextBox usernameinput;
        private Button submit;
        private Label header;
        private Button signup;
    }
}
