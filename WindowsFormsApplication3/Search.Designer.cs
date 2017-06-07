namespace WindowsFormsApplication3
{
    partial class Search
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
            this.btn_BinarySearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_BinarySearch
            // 
            this.btn_BinarySearch.Location = new System.Drawing.Point(12, 12);
            this.btn_BinarySearch.Name = "btn_BinarySearch";
            this.btn_BinarySearch.Size = new System.Drawing.Size(122, 26);
            this.btn_BinarySearch.TabIndex = 0;
            this.btn_BinarySearch.Text = "Binary Search";
            this.btn_BinarySearch.UseVisualStyleBackColor = true;
            this.btn_BinarySearch.Click += new System.EventHandler(this.btn_BinarySearch_Click);
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btn_BinarySearch);
            this.Name = "Search";
            this.Text = "Search";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_BinarySearch;
    }
}