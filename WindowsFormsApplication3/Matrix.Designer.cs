namespace WindowsFormsApplication3
{
    partial class Matrix
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
            this.button1 = new System.Windows.Forms.Button();
            this.btn_Count_Negative_Numbers_in_a_Column_Wise_and_Row_Wise_Sorted_Matrix = new System.Windows.Forms.Button();
            this.btn_Find_the_largest_square_of_1_in_a_given_matrix = new System.Windows.Forms.Button();
            this.btn_Find_No_of_times_X_occurance_for_NXN_multiplication_table = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(2, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(583, 38);
            this.button1.TabIndex = 0;
            this.button1.Text = "Kth smallest element in a row-wise and column-wise sorted 2D array | Set 1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_Count_Negative_Numbers_in_a_Column_Wise_and_Row_Wise_Sorted_Matrix
            // 
            this.btn_Count_Negative_Numbers_in_a_Column_Wise_and_Row_Wise_Sorted_Matrix.Location = new System.Drawing.Point(2, 56);
            this.btn_Count_Negative_Numbers_in_a_Column_Wise_and_Row_Wise_Sorted_Matrix.Name = "btn_Count_Negative_Numbers_in_a_Column_Wise_and_Row_Wise_Sorted_Matrix";
            this.btn_Count_Negative_Numbers_in_a_Column_Wise_and_Row_Wise_Sorted_Matrix.Size = new System.Drawing.Size(583, 40);
            this.btn_Count_Negative_Numbers_in_a_Column_Wise_and_Row_Wise_Sorted_Matrix.TabIndex = 1;
            this.btn_Count_Negative_Numbers_in_a_Column_Wise_and_Row_Wise_Sorted_Matrix.Text = "Count Negative Numbers in a Column-Wise and Row-Wise Sorted Matrix";
            this.btn_Count_Negative_Numbers_in_a_Column_Wise_and_Row_Wise_Sorted_Matrix.UseVisualStyleBackColor = true;
            this.btn_Count_Negative_Numbers_in_a_Column_Wise_and_Row_Wise_Sorted_Matrix.Click += new System.EventHandler(this.btn_Count_Negative_Numbers_in_a_Column_Wise_and_Row_Wise_Sorted_Matrix_Click);
            // 
            // btn_Find_the_largest_square_of_1_in_a_given_matrix
            // 
            this.btn_Find_the_largest_square_of_1_in_a_given_matrix.Location = new System.Drawing.Point(2, 102);
            this.btn_Find_the_largest_square_of_1_in_a_given_matrix.Name = "btn_Find_the_largest_square_of_1_in_a_given_matrix";
            this.btn_Find_the_largest_square_of_1_in_a_given_matrix.Size = new System.Drawing.Size(583, 43);
            this.btn_Find_the_largest_square_of_1_in_a_given_matrix.TabIndex = 20;
            this.btn_Find_the_largest_square_of_1_in_a_given_matrix.Text = "Find the largest square of 1 in a given matrix";
            this.btn_Find_the_largest_square_of_1_in_a_given_matrix.UseVisualStyleBackColor = true;
            this.btn_Find_the_largest_square_of_1_in_a_given_matrix.Click += new System.EventHandler(this.btn_Find_the_largest_square_of_1_in_a_given_matrix_Click);
            // 
            // btn_Find_No_of_times_X_occurance_for_NXN_multiplication_table
            // 
            this.btn_Find_No_of_times_X_occurance_for_NXN_multiplication_table.Location = new System.Drawing.Point(2, 151);
            this.btn_Find_No_of_times_X_occurance_for_NXN_multiplication_table.Name = "btn_Find_No_of_times_X_occurance_for_NXN_multiplication_table";
            this.btn_Find_No_of_times_X_occurance_for_NXN_multiplication_table.Size = new System.Drawing.Size(583, 39);
            this.btn_Find_No_of_times_X_occurance_for_NXN_multiplication_table.TabIndex = 21;
            this.btn_Find_No_of_times_X_occurance_for_NXN_multiplication_table.Text = "Find No of times X occurance for NXN multiplication table";
            this.btn_Find_No_of_times_X_occurance_for_NXN_multiplication_table.UseVisualStyleBackColor = true;
            this.btn_Find_No_of_times_X_occurance_for_NXN_multiplication_table.Click += new System.EventHandler(this.btn_Find_No_of_times_X_occurance_for_NXN_multiplication_table_Click);
            // 
            // Matrix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 425);
            this.Controls.Add(this.btn_Find_No_of_times_X_occurance_for_NXN_multiplication_table);
            this.Controls.Add(this.btn_Find_the_largest_square_of_1_in_a_given_matrix);
            this.Controls.Add(this.btn_Count_Negative_Numbers_in_a_Column_Wise_and_Row_Wise_Sorted_Matrix);
            this.Controls.Add(this.button1);
            this.Name = "Matrix";
            this.Text = "Matrix";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_Count_Negative_Numbers_in_a_Column_Wise_and_Row_Wise_Sorted_Matrix;
        private System.Windows.Forms.Button btn_Find_the_largest_square_of_1_in_a_given_matrix;
        private System.Windows.Forms.Button btn_Find_No_of_times_X_occurance_for_NXN_multiplication_table;
    }
}