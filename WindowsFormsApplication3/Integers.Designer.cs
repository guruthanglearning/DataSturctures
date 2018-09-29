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
            // Integers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_Reverse_Integer);
            this.Name = "Integers";
            this.Text = "Integers";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Reverse_Integer;
    }
}