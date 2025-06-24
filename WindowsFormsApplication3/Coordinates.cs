using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Coordinates : Form
    {
        public Coordinates()
        {
            InitializeComponent();
        }

        private void btn_Find_a_king_is_threatened_by_queen_in_a_cheese_board_Click(object sender, EventArgs e)
        {
            int kr, kc, qr, qc = 0;
            kr = 3; kc = 7;
            qr = 0; qc = 3;
            bool kingIsThreadByQueen = false;

            if (kr >= 0 && kr <= 7 && kc >= 0 && kc <= 7 && qr >= 0 && qr <= 7 && qc >= 0 && qc <= 7)
            {

                if (kr == qr || kc == qc || (Math.Abs(kr - qr) == Math.Abs(kc - qc)))
                {
                    kingIsThreadByQueen = true;
                }

                MessageBox.Show($"King is {(kingIsThreadByQueen ? "" : "not")} threatened by Queen");
            }
            else
            {
                MessageBox.Show($"Invalid inputs King row {kr.ToString()} and King column {kc.ToString()} \n  Queen row {qr.ToString()} and Queen column {qc.ToString()}  ");
            }
        }

        private bool IsSafe(int row, int column, Tuple<int, int>[,] queens)
        {
           for(int i = 0; i<queens.Length; i++)
            {
                
            }
            return false;
        }


        private bool PlaceQueens(int col)
        {
            return true;
        }

        private void N_Queens_Backtracking_Algorithm_Click(object sender, EventArgs e)
        {
            /*
            
                Time Complexity	        : O(S(N) × N²)
                Space Complexity	    : O(S(N) × N²)
                Aux Space (no results)	: O(N²)
                Optimized for	Backtracking with pruning

             Time Complexity
                Let:

                N = board size

                S(N) = number of valid solutions for given N

                ✔️ Backtracking Time:
                In worst case, you try N choices per row for N rows → O(N!)

                Due to pruning with cols, diag1, diag2, it’s faster in practice

                For each valid solution, you build a board → O(N²)
            
            */
            var results = this.SolveNQueens(4);

            Console.WriteLine("Number of Solutions: " + results.Count);
            foreach (var solution in results)
            {
                foreach (var line in solution)
                    Console.WriteLine(line);
                Console.WriteLine();
            }


        }


        public IList<IList<string>> SolveNQueens(int n)
        {
            var results = new List<IList<string>>();
            var board = new char[n][];
            for (int i = 0; i < n; i++)
                board[i] = new string('.', n).ToCharArray();

            // Use HashSets to track columns, diagonals
            HashSet<int> cols = new HashSet<int>();
            HashSet<int> diag1 = new HashSet<int>(); // (row - col)
            HashSet<int> diag2 = new HashSet<int>(); // (row + col)

            Backtrack(0, board, cols, diag1, diag2, results, n);
            return results;
        }

        private void Backtrack(int row, char[][] board, HashSet<int> cols, HashSet<int> diag1, HashSet<int> diag2, IList<IList<string>> results, int n)
        {
            if (row == n)
            {
                var solution = new List<string>();
                foreach (var r in board)
                    solution.Add(new string(r));
                results.Add(solution);
                return;
            }

            for (int col = 0; col < n; col++)
            {
                if (cols.Contains(col) || diag1.Contains(row - col) || diag2.Contains(row + col))
                    continue;

                board[row][col] = 'Q';
                cols.Add(col);
                diag1.Add(row - col);
                diag2.Add(row + col);

                Backtrack(row + 1, board, cols, diag1, diag2, results, n);

                // Backtrack
                board[row][col] = '.';
                cols.Remove(col);
                diag1.Remove(row - col);
                diag2.Remove(row + col);
            }
        }


        private void btn_Overlapping_rectangles_Click(object sender, EventArgs e)
        {

            
            Point L1 = new Point() { X = 1, Y = 7 };
            Point R1 = new Point() { X = 4, Y = 4 };
            Point L2 = new Point() { X = 2, Y = 3 };
            Point R2 = new Point() { X = 5, Y = 5 };
            bool isRectangleOverlap = true;

            // if (x2 < x3 || x1 > x4 || y2 > y3 || y1 < y4)            
            
            if (R1.X < L2.X || L1.X < R2.X || R1.Y > L2.Y || L1.Y < R2.Y)
                isRectangleOverlap =  false;

          
            MessageBox.Show($"Rectangle is {(isRectangleOverlap ? "" : "not" )} overlapping"); 
            


        }

        private void btn_Kangoro_Problem_Click(object sender, EventArgs e)
        {
            /*
             https://www.hackerrank.com/challenges/kangaroo/problem?h_r=next-challenge&h_v=zen&h_r=next-challenge&h_v=zen
             https://www.youtube.com/watch?v=52R2pLDjUBw&feature=youtu.be 
             https://www.youtube.com/watch?v=EvDkXTmUjGs -- See as an alternative approach;

             Time Complexity : O(1) constant time
             Space Complexity: O(1) constant space

             
             velocity = distance /time  (v= d/t) since we don't have time we have jump so v=d/j  so d = v*j 

              K1 = x1+v1 * j 
              K2 = x2+v2 * j

              x1 + v1*j = x2 + v2*j
              x1 + v1j = x2 + v2j
            
              v1j-v2j = x2-x1
              j(v1-v2) = (x2-x1)
              j = (x2-x1)/(v1-v2) we need to find j is the integer since j is an jump and it can be in decimal and we can identify by checking 
              (x2-x1) % (v1-v2) should be 0  K1.V1 > K2.V2 since K1 starts first than K2.
            
             
             */

            StringBuilder result = new StringBuilder();
            List<KangaruPoints> inputs = new List<KangaruPoints>();
            inputs.Add(new KangaruPoints() { Point1 = new Point(0, 3), Point2 = new Point(4, 2) });
            inputs.Add(new KangaruPoints() { Point1 = new Point(0, 2), Point2 = new Point(5, 3) });
            foreach(var input in inputs)
            {
                result.AppendLine($"Kangaru 1 X1,V1 :[{input.Point1.X.ToString()},{input.Point1.Y.ToString()}] Kangaru 2 X2,V2 :[{input.Point2.X.ToString()},{input.Point2.Y.ToString()}] is { (this.IsKangaruMeet(input.Point1, input.Point2) ? "meeting" : "not meeting" )}");
            }

            MessageBox.Show(result.ToString());

        }



        private bool IsKangaruMeet(Point k1, Point k2)
        {
            int reminder = 0;
            if (k1.Y > k2.Y)
            {
                reminder = (k2.X - k1.X) % (k1.Y - k2.Y);

                if (reminder == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public class KangaruPoints
        {
            public Point Point1;
            public Point Point2;
        }
        
    }
}
