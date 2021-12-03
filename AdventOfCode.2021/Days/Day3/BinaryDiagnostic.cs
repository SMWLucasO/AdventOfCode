using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days.Day3
{
    public static class BinaryDiagnostic
    {

        public static int Solution(string[] input)
        {
            // part 1
            int[] gammaBits = new int[12];
            int[] epsilonBits = new int[12];
            for (int i = 0; i < gammaBits.Length; i++)
            {

                int onesCount = 0;
                int zeroesCount = 0;
                
                foreach (var t in input)
                    if (t[i] == '0')
                        zeroesCount += 1;
                    else
                        onesCount += 1;
                
                
                gammaBits[i] = onesCount > zeroesCount ? 1 : 0;
                epsilonBits[i] = onesCount > zeroesCount ? 0 : 1;
            }

            int gammaRate = 0;
            int epsilonRate = 0;
            for (int i = 0; i < gammaBits.Length; i++)
            {
                gammaRate += gammaBits[i] * (int)Math.Pow(2, (gammaBits.Length - 1 - i));
                epsilonRate += epsilonBits[i] * (int)Math.Pow(2, (epsilonBits.Length - 1 - i));
            }

            return gammaRate * epsilonRate;
        }
        
    }
}