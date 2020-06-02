﻿namespace WindowsFormsApplication3
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
            this.btn_Given_a_weighted_graph_print_the_path_of_the_each_node_with_weight = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Traverse_a_graph_with_Depth_First_Search
            // 
            this.btn_Traverse_a_graph_with_Depth_First_Search.Location = new System.Drawing.Point(11, 10);
            this.btn_Traverse_a_graph_with_Depth_First_Search.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Traverse_a_graph_with_Depth_First_Search.Name = "btn_Traverse_a_graph_with_Depth_First_Search";
            this.btn_Traverse_a_graph_with_Depth_First_Search.Size = new System.Drawing.Size(314, 39);
            this.btn_Traverse_a_graph_with_Depth_First_Search.TabIndex = 0;
            this.btn_Traverse_a_graph_with_Depth_First_Search.Text = "Traverse a graph with Depth First Search";
            this.btn_Traverse_a_graph_with_Depth_First_Search.UseVisualStyleBackColor = true;
            this.btn_Traverse_a_graph_with_Depth_First_Search.Click += new System.EventHandler(this.btn_Traverse_a_graph_with_Depth_First_Search_Click);
            // 
            // btn_Traverse_a_graph_with_Depth_First_Search_To_Find_Dependencies_Of_A_Node
            // 
            this.btn_Traverse_a_graph_with_Depth_First_Search_To_Find_Dependencies_Of_A_Node.Location = new System.Drawing.Point(12, 53);
            this.btn_Traverse_a_graph_with_Depth_First_Search_To_Find_Dependencies_Of_A_Node.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Traverse_a_graph_with_Depth_First_Search_To_Find_Dependencies_Of_A_Node.Name = "btn_Traverse_a_graph_with_Depth_First_Search_To_Find_Dependencies_Of_A_Node";
            this.btn_Traverse_a_graph_with_Depth_First_Search_To_Find_Dependencies_Of_A_Node.Size = new System.Drawing.Size(314, 72);
            this.btn_Traverse_a_graph_with_Depth_First_Search_To_Find_Dependencies_Of_A_Node.TabIndex = 1;
            this.btn_Traverse_a_graph_with_Depth_First_Search_To_Find_Dependencies_Of_A_Node.Text = "Traverse a graph with Depth First Search for finding depencies of a node";
            this.btn_Traverse_a_graph_with_Depth_First_Search_To_Find_Dependencies_Of_A_Node.UseVisualStyleBackColor = true;
            this.btn_Traverse_a_graph_with_Depth_First_Search_To_Find_Dependencies_Of_A_Node.Click += new System.EventHandler(this.btn_Traverse_a_graph_with_Depth_First_Search_To_Find_Dependencies_Of_A_Node_Click);
            // 
            // btn_Given_a_weighted_graph_print_the_path_of_the_each_node_with_weight
            // 
            this.btn_Given_a_weighted_graph_print_the_path_of_the_each_node_with_weight.Location = new System.Drawing.Point(12, 129);
            this.btn_Given_a_weighted_graph_print_the_path_of_the_each_node_with_weight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Given_a_weighted_graph_print_the_path_of_the_each_node_with_weight.Name = "btn_Given_a_weighted_graph_print_the_path_of_the_each_node_with_weight";
            this.btn_Given_a_weighted_graph_print_the_path_of_the_each_node_with_weight.Size = new System.Drawing.Size(314, 74);
            this.btn_Given_a_weighted_graph_print_the_path_of_the_each_node_with_weight.TabIndex = 2;
            this.btn_Given_a_weighted_graph_print_the_path_of_the_each_node_with_weight.Text = "Given a weighted graph print the path of the each node with weight";
            this.btn_Given_a_weighted_graph_print_the_path_of_the_each_node_with_weight.UseVisualStyleBackColor = true;
            this.btn_Given_a_weighted_graph_print_the_path_of_the_each_node_with_weight.Click += new System.EventHandler(this.btn_Given_a_weighted_graph_print_the_path_of_the_each_node_with_weight_Click);
            // 
            // Graphs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 382);
            this.Controls.Add(this.btn_Given_a_weighted_graph_print_the_path_of_the_each_node_with_weight);
            this.Controls.Add(this.btn_Traverse_a_graph_with_Depth_First_Search_To_Find_Dependencies_Of_A_Node);
            this.Controls.Add(this.btn_Traverse_a_graph_with_Depth_First_Search);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Graphs";
            this.Text = "Graphs";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Traverse_a_graph_with_Depth_First_Search;
        private System.Windows.Forms.Button btn_Traverse_a_graph_with_Depth_First_Search_To_Find_Dependencies_Of_A_Node;
        private System.Windows.Forms.Button btn_Given_a_weighted_graph_print_the_path_of_the_each_node_with_weight;
    }
}