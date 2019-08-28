namespace WindowsFormsApplication3
{
    partial class Functions
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_Create_Job_Schedule_which_runs_function_for_a_given_milliseconds = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(18, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(553, 34);
            this.button1.TabIndex = 0;
            this.button1.Text = "Square Root";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(18, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(273, 26);
            this.textBox1.TabIndex = 1;
            // 
            // btn_Create_Job_Schedule_which_runs_function_for_a_given_milliseconds
            // 
            this.btn_Create_Job_Schedule_which_runs_function_for_a_given_milliseconds.Location = new System.Drawing.Point(18, 88);
            this.btn_Create_Job_Schedule_which_runs_function_for_a_given_milliseconds.Name = "btn_Create_Job_Schedule_which_runs_function_for_a_given_milliseconds";
            this.btn_Create_Job_Schedule_which_runs_function_for_a_given_milliseconds.Size = new System.Drawing.Size(553, 43);
            this.btn_Create_Job_Schedule_which_runs_function_for_a_given_milliseconds.TabIndex = 2;
            this.btn_Create_Job_Schedule_which_runs_function_for_a_given_milliseconds.Text = "Create Job Schedule which runs function for a given milliseconds";
            this.btn_Create_Job_Schedule_which_runs_function_for_a_given_milliseconds.UseVisualStyleBackColor = true;
            this.btn_Create_Job_Schedule_which_runs_function_for_a_given_milliseconds.Click += new System.EventHandler(this.btn_Create_Job_Schedule_which_runs_function_for_a_given_milliseconds_Click);
            // 
            // Functions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 544);
            this.Controls.Add(this.btn_Create_Job_Schedule_which_runs_function_for_a_given_milliseconds);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "Functions";
            this.Text = "Functions";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_Create_Job_Schedule_which_runs_function_for_a_given_milliseconds;
    }
}