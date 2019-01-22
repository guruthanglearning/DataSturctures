namespace WindowsFormsApplication3.Other
{
    partial class Questions
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
            this.btn_Find_closest_Veg_Resturant = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Find_closest_Veg_Resturant
            // 
            this.btn_Find_closest_Veg_Resturant.Location = new System.Drawing.Point(12, 22);
            this.btn_Find_closest_Veg_Resturant.Name = "btn_Find_closest_Veg_Resturant";
            this.btn_Find_closest_Veg_Resturant.Size = new System.Drawing.Size(505, 41);
            this.btn_Find_closest_Veg_Resturant.TabIndex = 0;
            this.btn_Find_closest_Veg_Resturant.Text = "Find closest Veg Resturant";
            this.btn_Find_closest_Veg_Resturant.UseVisualStyleBackColor = true;
            this.btn_Find_closest_Veg_Resturant.Click += new System.EventHandler(this.btn_Find_closest_Veg_Resturant_Click);
            // 
            // Questions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_Find_closest_Veg_Resturant);
            this.Name = "Questions";
            this.Text = "Questions";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Find_closest_Veg_Resturant;
    }
}