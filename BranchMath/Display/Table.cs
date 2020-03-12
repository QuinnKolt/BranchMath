using System;

namespace BranchMath.Display {
    public class Table<I, X, Y> {
        private I[,] entries;
        private X[] xlabels;
        private Y[] ylabels;
        
        public Table(I[,] entries, X[] xlabels, Y[] ylabels) {
            this.entries = entries;
            this.xlabels = xlabels;
            this.ylabels = ylabels;
        }

        public override string ToString() {
            int[] max = new int[ylabels.Length + 1];
            for(int j = 0; j < ylabels.Length; ++j) {
                max[j] = ylabels[j].ToString().Length;
            }

            max[ylabels.Length] = 1;
            foreach(var x in xlabels) {
                max[ylabels.Length] = Math.Max(max[ylabels.Length], x.ToString().Length);
            }
            
            for (int i = 0; i < xlabels.Length; ++i) {
                for (int j = 0; j < ylabels.Length; ++j) {
                    max[i] = Math.Max(max[i], entries[i, j].ToString().Length);
                }
            }

            var str = center("", max[ylabels.Length]  + 2) + " ||";

            for (int j = 0; j < ylabels.Length; ++j) {
                str += center(ylabels[j].ToString(), max[j] + 2);
                str += "|";
            }

            str += "\n";
            
            for (int i = 0; i < xlabels.Length; ++i) {
                str += "\n|";
                str += center(xlabels[i].ToString(), max[ylabels.Length] + 2);
                str += "||";
                for (int j = 0; j < ylabels.Length; ++j) {
                    str += center(entries[i, j].ToString(), max[j] + 2);
                    str += "|";
                }
            }
            
            return str;
        }
        
        private static string center(string str, int total) {
            var spaces = total - str.Length;
            var padLeft = spaces / 2 + str.Length;
            return str.PadLeft(padLeft).PadRight(total);
        }
    }
}