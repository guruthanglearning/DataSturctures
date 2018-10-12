namespace WindowsFormsApplication3
{
    partial class OopsConcepts
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
            this.btn_Protected_Access_Specifier = new System.Windows.Forms.Button();
            this.btn_Abstract_Class = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Protected_Access_Specifier
            // 
            this.btn_Protected_Access_Specifier.Location = new System.Drawing.Point(12, 12);
            this.btn_Protected_Access_Specifier.Name = "btn_Protected_Access_Specifier";
            this.btn_Protected_Access_Specifier.Size = new System.Drawing.Size(512, 39);
            this.btn_Protected_Access_Specifier.TabIndex = 0;
            this.btn_Protected_Access_Specifier.Text = "Protected Access Specifier";
            this.btn_Protected_Access_Specifier.UseVisualStyleBackColor = true;
            this.btn_Protected_Access_Specifier.Click += new System.EventHandler(this.btn_Protected_Access_Specifier_Click);
            // 
            // btn_Abstract_Class
            // 
            this.btn_Abstract_Class.Location = new System.Drawing.Point(12, 57);
            this.btn_Abstract_Class.Name = "btn_Abstract_Class";
            this.btn_Abstract_Class.Size = new System.Drawing.Size(512, 43);
            this.btn_Abstract_Class.TabIndex = 1;
            this.btn_Abstract_Class.Text = "Abstract Class";
            this.btn_Abstract_Class.UseVisualStyleBackColor = true;
            this.btn_Abstract_Class.Click += new System.EventHandler(this.btn_Abstract_Class_Click);
            // 
            // OopsConcepts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_Abstract_Class);
            this.Controls.Add(this.btn_Protected_Access_Specifier);
            this.Name = "OopsConcepts";
            this.Text = "OopsConcepts";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Protected_Access_Specifier;
        private System.Windows.Forms.Button btn_Abstract_Class;
    }
}