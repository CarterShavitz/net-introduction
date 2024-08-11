namespace TodoList
{
    partial class ItemInput
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
            todoiteminput = new TextBox();
            submititem = new Button();
            SuspendLayout();
            // 
            // todoiteminput
            // 
            todoiteminput.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            todoiteminput.Font = new Font("Segoe UI", 20F);
            todoiteminput.Location = new Point(42, 41);
            todoiteminput.Multiline = true;
            todoiteminput.Name = "todoiteminput";
            todoiteminput.Size = new Size(761, 175);
            todoiteminput.TabIndex = 1;
            // 
            // submititem
            // 
            submititem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            submititem.Location = new Point(42, 260);
            submititem.Name = "submititem";
            submititem.Size = new Size(761, 113);
            submititem.TabIndex = 2;
            submititem.Text = "Submit";
            submititem.UseVisualStyleBackColor = true;
            submititem.Click += submititem_Click;
            // 
            // ItemInput
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(851, 455);
            Controls.Add(submititem);
            Controls.Add(todoiteminput);
            Name = "ItemInput";
            Text = "Item Input";
            Load += ItemInput_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox todoiteminput;
        private Button submititem;
    }
}