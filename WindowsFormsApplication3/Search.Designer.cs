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
            this.btn_Search_in_Rotated_Sorted_Array_Duplicate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_BinarySearch
            // 
            this.btn_BinarySearch.Location = new System.Drawing.Point(9, 9);
            this.btn_BinarySearch.Name = "btn_BinarySearch";
            this.btn_BinarySearch.Size = new System.Drawing.Size(117, 26);
            this.btn_BinarySearch.TabIndex = 0;
            this.btn_BinarySearch.Text = "Binary Search";
            this.btn_BinarySearch.UseVisualStyleBackColor = true;
            this.btn_BinarySearch.Click += new System.EventHandler(this.btn_BinarySearch_Click);
            // 
            // btn_Given_an_split_array_in_the_sorted_order_search_given_value_exists
            // 
            this.btn_Given_an_split_array_in_the_sorted_order_search_given_value_exists.Location = new System.Drawing.Point(9, 41);
            this.btn_Given_an_split_array_in_the_sorted_order_search_given_value_exists.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_Given_an_split_array_in_the_sorted_order_search_given_value_exists.Name = "btn_Given_an_split_array_in_the_sorted_order_search_given_value_exists";
            this.btn_Given_an_split_array_in_the_sorted_order_search_given_value_exists.Size = new System.Drawing.Size(117, 54);
            this.btn_Given_an_split_array_in_the_sorted_order_search_given_value_exists.TabIndex = 1;
            this.btn_Given_an_split_array_in_the_sorted_order_search_given_value_exists.Text = "Given an rotate array in the sorted order search  given value exists";
            this.btn_Given_an_split_array_in_the_sorted_order_search_given_value_exists.UseVisualStyleBackColor = true;
            this.btn_Given_an_split_array_in_the_sorted_order_search_given_value_exists.Click += new System.EventHandler(this.btn_Given_an_split_array_in_the_sorted_order_search_given_value_exists_Click);
            // 
            // btn_Search_in_Rotated_Sorted_Array_Duplicate
            // 
            this.btn_Search_in_Rotated_Sorted_Array_Duplicate.Location = new System.Drawing.Point(9, 99);
            this.btn_Search_in_Rotated_Sorted_Array_Duplicate.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Search_in_Rotated_Sorted_Array_Duplicate.Name = "btn_Search_in_Rotated_Sorted_Array_Duplicate";
            this.btn_Search_in_Rotated_Sorted_Array_Duplicate.Size = new System.Drawing.Size(117, 52);
            this.btn_Search_in_Rotated_Sorted_Array_Duplicate.TabIndex = 2;
            this.btn_Search_in_Rotated_Sorted_Array_Duplicate.Text = "Given an rotate array in the sorted order(duplicate)\r\n search  given value exists" +
    "";
            this.btn_Search_in_Rotated_Sorted_Array_Duplicate.UseVisualStyleBackColor = true;
            this.btn_Search_in_Rotated_Sorted_Array_Duplicate.Click += new System.EventHandler(this.btn_Search_in_Rotated_Sorted_Array_Duplicate_Click);
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 262);
            this.Controls.Add(this.btn_Search_in_Rotated_Sorted_Array_Duplicate);
            this.Controls.Add(this.btn_Given_an_split_array_in_the_sorted_order_search_given_value_exists);
            this.Controls.Add(this.btn_BinarySearch);
            this.Name = "Search";
            this.Text = "Search";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_BinarySearch;
        private System.Windows.Forms.Button btn_Given_an_split_array_in_the_sorted_order_search_given_value_exists;
        private System.Windows.Forms.Button btn_Search_in_Rotated_Sorted_Array_Duplicate;
    }
}