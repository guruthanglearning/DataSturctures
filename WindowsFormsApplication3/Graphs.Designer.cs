namespace WindowsFormsApplication3
{
    partial class Graphs
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
            this.btn_Traverse_a_graph_with_Depth_First_Search = new System.Windows.Forms.Button();
            this.btn_Traverse_a_graph_with_Depth_First_Search_To_Find_Dependencies_Of_A_Node = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Traverse_a_graph_with_Depth_First_Search
            // 
            this.btn_Traverse_a_graph_with_Depth_First_Search.Location = new System.Drawing.Point(12, 12);
            this.btn_Traverse_a_graph_with_Depth_First_Search.Name = "btn_Traverse_a_graph_with_Depth_First_Search";
            this.btn_Traverse_a_graph_with_Depth_First_Search.Size = new System.Drawing.Size(700, 46);
            this.btn_Traverse_a_graph_with_Depth_First_Search.TabIndex = 0;
            this.btn_Traverse_a_graph_with_Depth_First_Search.Text = "Traverse a graph with Depth First Search";
            this.btn_Traverse_a_graph_with_Depth_First_Search.UseVisualStyleBackColor = true;
            this.btn_Traverse_a_graph_with_Depth_First_Search.Click += new System.EventHandler(this.btn_Traverse_a_graph_with_Depth_First_Search_Click);
            // 
            // btn_Traverse_a_graph_with_Depth_First_Search_To_Find_Dependencies_Of_A_Node
            // 
            this.btn_Traverse_a_graph_with_Depth_First_Search_To_Find_Dependencies_Of_A_Node.Location = new System.Drawing.Point(12, 76);
            this.btn_Traverse_a_graph_with_Depth_First_Search_To_Find_Dependencies_Of_A_Node.Name = "btn_Traverse_a_graph_with_Depth_First_Search_To_Find_Dependencies_Of_A_Node";
            this.btn_Traverse_a_graph_with_Depth_First_Search_To_Find_Dependencies_Of_A_Node.Size = new System.Drawing.Size(700, 46);
            this.btn_Traverse_a_graph_with_Depth_First_Search_To_Find_Dependencies_Of_A_Node.TabIndex = 1;
            this.btn_Traverse_a_graph_with_Depth_First_Search_To_Find_Dependencies_Of_A_Node.Text = "Traverse a graph with Depth First Search for finding depencies of a node";
            this.btn_Traverse_a_graph_with_Depth_First_Search_To_Find_Dependencies_Of_A_Node.UseVisualStyleBackColor = true;
            this.btn_Traverse_a_graph_with_Depth_First_Search_To_Find_Dependencies_Of_A_Node.Click += new System.EventHandler(this.btn_Traverse_a_graph_with_Depth_First_Search_To_Find_Dependencies_Of_A_Node_Click);
            // 
            // Graphs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 477);
            this.Controls.Add(this.btn_Traverse_a_graph_with_Depth_First_Search_To_Find_Dependencies_Of_A_Node);
            this.Controls.Add(this.btn_Traverse_a_graph_with_Depth_First_Search);
            this.Name = "Graphs";
            this.Text = "Graphs";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Traverse_a_graph_with_Depth_First_Search;
        private System.Windows.Forms.Button btn_Traverse_a_graph_with_Depth_First_Search_To_Find_Dependencies_Of_A_Node;
    }
}