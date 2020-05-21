﻿namespace WindowsFormsApplication3
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
            this.btn_Static_Constructor_in_Sealed_Class = new System.Windows.Forms.Button();
            this.btn_Shallow_Copy_vs_Deep_Copy = new System.Windows.Forms.Button();
            this.btn_Online_Stock_Span = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Protected_Access_Specifier
            // 
            this.btn_Protected_Access_Specifier.Location = new System.Drawing.Point(11, 10);
            this.btn_Protected_Access_Specifier.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Protected_Access_Specifier.Name = "btn_Protected_Access_Specifier";
            this.btn_Protected_Access_Specifier.Size = new System.Drawing.Size(455, 31);
            this.btn_Protected_Access_Specifier.TabIndex = 0;
            this.btn_Protected_Access_Specifier.Text = "Protected Access Specifier";
            this.btn_Protected_Access_Specifier.UseVisualStyleBackColor = true;
            this.btn_Protected_Access_Specifier.Click += new System.EventHandler(this.btn_Protected_Access_Specifier_Click);
            // 
            // btn_Abstract_Class
            // 
            this.btn_Abstract_Class.Location = new System.Drawing.Point(11, 46);
            this.btn_Abstract_Class.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Abstract_Class.Name = "btn_Abstract_Class";
            this.btn_Abstract_Class.Size = new System.Drawing.Size(455, 34);
            this.btn_Abstract_Class.TabIndex = 1;
            this.btn_Abstract_Class.Text = "Abstract Class";
            this.btn_Abstract_Class.UseVisualStyleBackColor = true;
            this.btn_Abstract_Class.Click += new System.EventHandler(this.btn_Abstract_Class_Click);
            // 
            // btn_Static_Constructor_in_Sealed_Class
            // 
            this.btn_Static_Constructor_in_Sealed_Class.Location = new System.Drawing.Point(11, 85);
            this.btn_Static_Constructor_in_Sealed_Class.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Static_Constructor_in_Sealed_Class.Name = "btn_Static_Constructor_in_Sealed_Class";
            this.btn_Static_Constructor_in_Sealed_Class.Size = new System.Drawing.Size(455, 38);
            this.btn_Static_Constructor_in_Sealed_Class.TabIndex = 2;
            this.btn_Static_Constructor_in_Sealed_Class.Text = "Static Constructor in Sealed Class";
            this.btn_Static_Constructor_in_Sealed_Class.UseVisualStyleBackColor = true;
            this.btn_Static_Constructor_in_Sealed_Class.Click += new System.EventHandler(this.btn_Static_Constructor_in_Sealed_Class_Click);
            // 
            // btn_Shallow_Copy_vs_Deep_Copy
            // 
            this.btn_Shallow_Copy_vs_Deep_Copy.Location = new System.Drawing.Point(11, 128);
            this.btn_Shallow_Copy_vs_Deep_Copy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Shallow_Copy_vs_Deep_Copy.Name = "btn_Shallow_Copy_vs_Deep_Copy";
            this.btn_Shallow_Copy_vs_Deep_Copy.Size = new System.Drawing.Size(455, 38);
            this.btn_Shallow_Copy_vs_Deep_Copy.TabIndex = 3;
            this.btn_Shallow_Copy_vs_Deep_Copy.Text = "Shallow Copy vs Deep Copy";
            this.btn_Shallow_Copy_vs_Deep_Copy.UseVisualStyleBackColor = true;
            this.btn_Shallow_Copy_vs_Deep_Copy.Click += new System.EventHandler(this.btn_Shallow_Copy_vs_Deep_Copy_Click);
            // 
            // btn_Online_Stock_Span
            // 
            this.btn_Online_Stock_Span.Location = new System.Drawing.Point(11, 171);
            this.btn_Online_Stock_Span.Name = "btn_Online_Stock_Span";
            this.btn_Online_Stock_Span.Size = new System.Drawing.Size(455, 40);
            this.btn_Online_Stock_Span.TabIndex = 4;
            this.btn_Online_Stock_Span.Text = "Online Stock Span";
            this.btn_Online_Stock_Span.UseVisualStyleBackColor = true;
            this.btn_Online_Stock_Span.Click += new System.EventHandler(this.btn_Online_Stock_Span_Click);
            // 
            // OopsConcepts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 360);
            this.Controls.Add(this.btn_Online_Stock_Span);
            this.Controls.Add(this.btn_Shallow_Copy_vs_Deep_Copy);
            this.Controls.Add(this.btn_Static_Constructor_in_Sealed_Class);
            this.Controls.Add(this.btn_Abstract_Class);
            this.Controls.Add(this.btn_Protected_Access_Specifier);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "OopsConcepts";
            this.Text = "OopsConcepts";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Protected_Access_Specifier;
        private System.Windows.Forms.Button btn_Abstract_Class;
        private System.Windows.Forms.Button btn_Static_Constructor_in_Sealed_Class;
        private System.Windows.Forms.Button btn_Shallow_Copy_vs_Deep_Copy;
        private System.Windows.Forms.Button btn_Online_Stock_Span;
    }
}