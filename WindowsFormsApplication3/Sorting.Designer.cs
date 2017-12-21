namespace WindowsFormsApplication3
{
    partial class Sorting
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
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.HeapSort = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.btn_Bubble_Sort = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 23);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(380, 37);
            this.button1.TabIndex = 0;
            this.button1.Text = "Quick Sort Lomuto partition scheme";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(16, 212);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(373, 37);
            this.button2.TabIndex = 1;
            this.button2.Text = "Insertion Sort";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(16, 258);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(373, 37);
            this.button3.TabIndex = 2;
            this.button3.Text = "Selection Sort";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // HeapSort
            // 
            this.HeapSort.Location = new System.Drawing.Point(16, 165);
            this.HeapSort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.HeapSort.Name = "HeapSort";
            this.HeapSort.Size = new System.Drawing.Size(373, 37);
            this.HeapSort.TabIndex = 3;
            this.HeapSort.Text = "Heap Sort";
            this.HeapSort.UseVisualStyleBackColor = true;
            this.HeapSort.Click += new System.EventHandler(this.HeapSort_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(15, 69);
            this.button5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(374, 42);
            this.button5.TabIndex = 4;
            this.button5.Text = "Quick Sort Hoare\'s partition scheme";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(15, 120);
            this.button6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(374, 35);
            this.button6.TabIndex = 5;
            this.button6.Text = "Merge Sort";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // btn_Bubble_Sort
            // 
            this.btn_Bubble_Sort.Location = new System.Drawing.Point(16, 303);
            this.btn_Bubble_Sort.Name = "btn_Bubble_Sort";
            this.btn_Bubble_Sort.Size = new System.Drawing.Size(373, 40);
            this.btn_Bubble_Sort.TabIndex = 6;
            this.btn_Bubble_Sort.Text = "Bubble Sort";
            this.btn_Bubble_Sort.UseVisualStyleBackColor = true;
            this.btn_Bubble_Sort.Click += new System.EventHandler(this.btn_Bubble_Sort_Click);
            // 
            // Sorting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 669);
            this.Controls.Add(this.btn_Bubble_Sort);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.HeapSort);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Sorting";
            this.Text = "Sorting";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button HeapSort;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button btn_Bubble_Sort;
    }
}