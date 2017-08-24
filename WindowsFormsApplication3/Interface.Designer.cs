namespace WindowsFormsApplication3
{
    partial class Interface
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
            this.Making_Interface_Method_in_Derived_Class_As_Private = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Making_Interface_Method_in_Derived_Class_As_Private
            // 
            this.Making_Interface_Method_in_Derived_Class_As_Private.Location = new System.Drawing.Point(12, 12);
            this.Making_Interface_Method_in_Derived_Class_As_Private.Name = "Making_Interface_Method_in_Derived_Class_As_Private";
            this.Making_Interface_Method_in_Derived_Class_As_Private.Size = new System.Drawing.Size(419, 29);
            this.Making_Interface_Method_in_Derived_Class_As_Private.TabIndex = 0;
            this.Making_Interface_Method_in_Derived_Class_As_Private.Text = "Making Interface Method in Derived Class As Private";
            this.Making_Interface_Method_in_Derived_Class_As_Private.UseVisualStyleBackColor = true;
            this.Making_Interface_Method_in_Derived_Class_As_Private.Click += new System.EventHandler(this.Making_Interface_Method_in_Derived_Class_As_Private_Click);
            // 
            // Interface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 546);
            this.Controls.Add(this.Making_Interface_Method_in_Derived_Class_As_Private);
            this.Name = "Interface";
            this.Text = "Interface";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Making_Interface_Method_in_Derived_Class_As_Private;
    }
}