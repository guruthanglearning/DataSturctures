namespace WindowsFormsApplication3
{
    partial class Integers
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
            this.btn_Reverse_Integer = new System.Windows.Forms.Button();
            this.btn_Check_the_given_integer_is_Plandrom = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Reverse_Integer
            // 
            this.btn_Reverse_Integer.Location = new System.Drawing.Point(12, 12);
            this.btn_Reverse_Integer.Name = "btn_Reverse_Integer";
            this.btn_Reverse_Integer.Size = new System.Drawing.Size(519, 43);
            this.btn_Reverse_Integer.TabIndex = 0;
            this.btn_Reverse_Integer.Text = "Reverse Integer";
            this.btn_Reverse_Integer.UseVisualStyleBackColor = true;
            this.btn_Reverse_Integer.Click += new System.EventHandler(this.btn_Reverse_Integer_Click);
            // 
            // btn_Check_the_given_integer_is_Plandrom
            // 
            this.btn_Check_the_given_integer_is_Plandrom.Location = new System.Drawing.Point(12, 61);
            this.btn_Check_the_given_integer_is_Plandrom.Name = "btn_Check_the_given_integer_is_Plandrom";
            this.btn_Check_the_given_integer_is_Plandrom.Size = new System.Drawing.Size(519, 42);
            this.btn_Check_the_given_integer_is_Plandrom.TabIndex = 1;
            this.btn_Check_the_given_integer_is_Plandrom.Text = "Check the given integer is Plandrom";
            this.btn_Check_the_given_integer_is_Plandrom.UseVisualStyleBackColor = true;
            this.btn_Check_the_given_integer_is_Plandrom.Click += new System.EventHandler(this.btn_Check_the_given_integer_is_Plandrom_Click);
            // 
            // Integers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_Check_the_given_integer_is_Plandrom);
            this.Controls.Add(this.btn_Reverse_Integer);
            this.Name = "Integers";
            this.Text = "Integers";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Reverse_Integer;
        private System.Windows.Forms.Button btn_Check_the_given_integer_is_Plandrom;
    }
}