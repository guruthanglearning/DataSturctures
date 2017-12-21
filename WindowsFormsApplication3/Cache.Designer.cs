namespace WindowsFormsApplication3
{
    partial class Cache
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
            this.btn_Implement_Cache_From_Amazon = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Implement_Cache_From_Amazon
            // 
            this.btn_Implement_Cache_From_Amazon.Location = new System.Drawing.Point(12, 12);
            this.btn_Implement_Cache_From_Amazon.Name = "btn_Implement_Cache_From_Amazon";
            this.btn_Implement_Cache_From_Amazon.Size = new System.Drawing.Size(289, 36);
            this.btn_Implement_Cache_From_Amazon.TabIndex = 0;
            this.btn_Implement_Cache_From_Amazon.Text = "Implement Cache from Amazon";
            this.btn_Implement_Cache_From_Amazon.UseVisualStyleBackColor = true;
            this.btn_Implement_Cache_From_Amazon.Click += new System.EventHandler(this.btn_Implement_Cache_From_Amazon_Click);
            // 
            // Cache
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 576);
            this.Controls.Add(this.btn_Implement_Cache_From_Amazon);
            this.Name = "Cache";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Implement_Cache_From_Amazon;
    }
}