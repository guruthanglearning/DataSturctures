namespace WindowsFormsApplication3
{
    partial class Trees
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
            this.btn_Same_Tree = new System.Windows.Forms.Button();
            this.btn_Find_Binary_is_Symmetric_Tree = new System.Windows.Forms.Button();
            this.btn_Binary_Tree_Level_Order_Traversal_Get_Item_from_the_bottom_up = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Same_Tree
            // 
            this.btn_Same_Tree.Location = new System.Drawing.Point(12, 12);
            this.btn_Same_Tree.Name = "btn_Same_Tree";
            this.btn_Same_Tree.Size = new System.Drawing.Size(303, 36);
            this.btn_Same_Tree.TabIndex = 0;
            this.btn_Same_Tree.Text = "Same Tree";
            this.btn_Same_Tree.UseVisualStyleBackColor = true;
            this.btn_Same_Tree.Click += new System.EventHandler(this.btn_Same_Tree_Click);
            // 
            // btn_Find_Binary_is_Symmetric_Tree
            // 
            this.btn_Find_Binary_is_Symmetric_Tree.Location = new System.Drawing.Point(12, 54);
            this.btn_Find_Binary_is_Symmetric_Tree.Name = "btn_Find_Binary_is_Symmetric_Tree";
            this.btn_Find_Binary_is_Symmetric_Tree.Size = new System.Drawing.Size(303, 37);
            this.btn_Find_Binary_is_Symmetric_Tree.TabIndex = 1;
            this.btn_Find_Binary_is_Symmetric_Tree.Text = "Find Binary is Symmetric Tree";
            this.btn_Find_Binary_is_Symmetric_Tree.UseVisualStyleBackColor = true;
            this.btn_Find_Binary_is_Symmetric_Tree.Click += new System.EventHandler(this.btn_Find_Binary_is_Symmetric_Tree_Click);
            // 
            // btn_Binary_Tree_Level_Order_Traversal_Get_Item_from_the_bottom_up
            // 
            this.btn_Binary_Tree_Level_Order_Traversal_Get_Item_from_the_bottom_up.Location = new System.Drawing.Point(12, 97);
            this.btn_Binary_Tree_Level_Order_Traversal_Get_Item_from_the_bottom_up.Name = "btn_Binary_Tree_Level_Order_Traversal_Get_Item_from_the_bottom_up";
            this.btn_Binary_Tree_Level_Order_Traversal_Get_Item_from_the_bottom_up.Size = new System.Drawing.Size(303, 52);
            this.btn_Binary_Tree_Level_Order_Traversal_Get_Item_from_the_bottom_up.TabIndex = 2;
            this.btn_Binary_Tree_Level_Order_Traversal_Get_Item_from_the_bottom_up.Text = "Binary Tree Level Order Traversal Get Item from the bottom up";
            this.btn_Binary_Tree_Level_Order_Traversal_Get_Item_from_the_bottom_up.UseVisualStyleBackColor = true;
            this.btn_Binary_Tree_Level_Order_Traversal_Get_Item_from_the_bottom_up.Click += new System.EventHandler(this.btn_Binary_Tree_Level_Order_Traversal_Get_Item_from_the_bottom_up_Click);
            // 
            // Trees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_Binary_Tree_Level_Order_Traversal_Get_Item_from_the_bottom_up);
            this.Controls.Add(this.btn_Find_Binary_is_Symmetric_Tree);
            this.Controls.Add(this.btn_Same_Tree);
            this.Name = "Trees";
            this.Text = "Trees";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Same_Tree;
        private System.Windows.Forms.Button btn_Find_Binary_is_Symmetric_Tree;
        private System.Windows.Forms.Button btn_Binary_Tree_Level_Order_Traversal_Get_Item_from_the_bottom_up;
    }
}