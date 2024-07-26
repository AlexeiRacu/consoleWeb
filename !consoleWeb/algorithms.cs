using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithms
{
    internal class match
    {
        public static double percentageOfMatch(string title, string search) 
        {
            while (true)
            {
                int matchCount = 0;
                string[] titlePromts = title.Split(' ');
                if (search.Length < title.Length)
                {
                    search = search.PadRight(title.Length, ' ');
                }

                for (int i = 0; i < title.Length; i++)
                {
                    if (title[i] == search[i])
                    {
                        matchCount++;
                    }
                }
                double similarityScore = (double)matchCount / title.Length * 100;

                return similarityScore;
            }
        }
    }
}
