namespace WindowsFormsApplication3
{
    partial class DesignPatterns
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
            this.singleton = new System.Windows.Forms.Button();
            this.btn_Private_Methods_In_Abstract_Class = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // singleton
            // 
            this.singleton.Location = new System.Drawing.Point(21, 38);
            this.singleton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.singleton.Name = "singleton";
            this.singleton.Size = new System.Drawing.Size(274, 44);
            this.singleton.TabIndex = 0;
            this.singleton.Text = "SingleTon";
            this.singleton.UseVisualStyleBackColor = true;
            this.singleton.Click += new System.EventHandler(this.singleton_Click);
            // 
            // btn_Private_Methods_In_Abstract_Class
            // 
            this.btn_Private_Methods_In_Abstract_Class.Location = new System.Drawing.Point(955, 53);
            this.btn_Private_Methods_In_Abstract_Class.Name = "btn_Private_Methods_In_Abstract_Class";
            this.btn_Private_Methods_In_Abstract_Class.Size = new System.Drawing.Size(274, 49);
            this.btn_Private_Methods_In_Abstract_Class.TabIndex = 1;
            this.btn_Private_Methods_In_Abstract_Class.Text = "Private Methods in Abstract Class";
            this.btn_Private_Methods_In_Abstract_Class.UseVisualStyleBackColor = true;
            this.btn_Private_Methods_In_Abstract_Class.Click += new System.EventHandler(this.btn_Private_Methods_In_Abstract_Class_Click);
            // 
            // DesignPatterns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1485, 689);
            this.Controls.Add(this.btn_Private_Methods_In_Abstract_Class);
            this.Controls.Add(this.singleton);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DesignPatterns";
            this.Text = "DesignPatterns";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button singleton;
        private System.Windows.Forms.Button btn_Private_Methods_In_Abstract_Class;
    }
}