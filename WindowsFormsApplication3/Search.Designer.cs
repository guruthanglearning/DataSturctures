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
            this.btn_Given_an_split_array_in_the_sorted_order_search_given_value_exists = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_BinarySearch
            // 
            this.btn_BinarySearch.Location = new System.Drawing.Point(12, 11);
            this.btn_BinarySearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_BinarySearch.Name = "btn_BinarySearch";
            this.btn_BinarySearch.Size = new System.Drawing.Size(669, 32);
            this.btn_BinarySearch.TabIndex = 0;
            this.btn_BinarySearch.Text = "Binary Search";
            this.btn_BinarySearch.UseVisualStyleBackColor = true;
            this.btn_BinarySearch.Click += new System.EventHandler(this.btn_BinarySearch_Click);
            // 
            // btn_Given_an_split_array_in_the_sorted_order_search_given_value_exists
            // 
            this.btn_Given_an_split_array_in_the_sorted_order_search_given_value_exists.Location = new System.Drawing.Point(12, 50);
            this.btn_Given_an_split_array_in_the_sorted_order_search_given_value_exists.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Given_an_split_array_in_the_sorted_order_search_given_value_exists.Name = "btn_Given_an_split_array_in_the_sorted_order_search_given_value_exists";
            this.btn_Given_an_split_array_in_the_sorted_order_search_given_value_exists.Size = new System.Drawing.Size(669, 34);
            this.btn_Given_an_split_array_in_the_sorted_order_search_given_value_exists.TabIndex = 1;
            this.btn_Given_an_split_array_in_the_sorted_order_search_given_value_exists.Text = "Given an rotate array in the sorted order search  given value exists";
            this.btn_Given_an_split_array_in_the_sorted_order_search_given_value_exists.UseVisualStyleBackColor = true;
            this.btn_Given_an_split_array_in_the_sorted_order_search_given_value_exists.Click += new System.EventHandler(this.btn_Given_an_split_array_in_the_sorted_order_search_given_value_exists_Click);
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 322);
            this.Controls.Add(this.btn_Given_an_split_array_in_the_sorted_order_search_given_value_exists);
            this.Controls.Add(this.btn_BinarySearch);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Search";
            this.Text = "Search";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_BinarySearch;
        private System.Windows.Forms.Button btn_Given_an_split_array_in_the_sorted_order_search_given_value_exists;
    }
}