namespace WindowsFormsApplication3
{
    partial class Coordinates
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
            this.btn_Find_a_king_is_threatened_by_queen_in_a_cheese_board = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Find_a_king_is_threatened_by_queen_in_a_cheese_board
            // 
            this.btn_Find_a_king_is_threatened_by_queen_in_a_cheese_board.Location = new System.Drawing.Point(2, 12);
            this.btn_Find_a_king_is_threatened_by_queen_in_a_cheese_board.Name = "btn_Find_a_king_is_threatened_by_queen_in_a_cheese_board";
            this.btn_Find_a_king_is_threatened_by_queen_in_a_cheese_board.Size = new System.Drawing.Size(832, 47);
            this.btn_Find_a_king_is_threatened_by_queen_in_a_cheese_board.TabIndex = 0;
            this.btn_Find_a_king_is_threatened_by_queen_in_a_cheese_board.Text = "Find a king is threatened by queen in a cheese board";
            this.btn_Find_a_king_is_threatened_by_queen_in_a_cheese_board.UseVisualStyleBackColor = true;
            this.btn_Find_a_king_is_threatened_by_queen_in_a_cheese_board.Click += new System.EventHandler(this.btn_Find_a_king_is_threatened_by_queen_in_a_cheese_board_Click);
            // 
            // Coordinates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 501);
            this.Controls.Add(this.btn_Find_a_king_is_threatened_by_queen_in_a_cheese_board);
            this.Name = "Coordinates";
            this.Text = "Coordinates";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Find_a_king_is_threatened_by_queen_in_a_cheese_board;
    }
}