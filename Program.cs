using System;

namespace ConsoleApp1
{
    class Program
    {
        // global defs
        static int      BIG_MATRIX_ROW_SIZE = 50;
        static int      BIG_MATRIX_COL_SIZE = 50;
        static int      ONE_DIM_ARRAY_SIZE = 25;
        static int[]    foundNums = new int[ONE_DIM_ARRAY_SIZE];
        static int[]    missingNums = new int[ONE_DIM_ARRAY_SIZE];

        static private void searchForNum(int[] oneDimArray, int[,] bigMatrix)
        {
            int i = 0;
            int found = 0;
            int missed = 0;
            for(i = 0; i < 25; i++)
            {
                var numToFind = oneDimArray[i];
                
                if(SearchBigMatrix(numToFind, bigMatrix))
                {
                    foundNums[i] = numToFind;
                    found++;
                    Console.WriteLine("foundNums: " + foundNums[i]);
                }
                else
                {
                    missingNums[i] = numToFind;
                    missed++;
                    Console.WriteLine("missingNums: " + missingNums[i]);
                }
            }

            Console.WriteLine($"***FOUND {found} NUMS & MISSED {missed} NUMS in 50x50 MATRIX!!!***");
        }

        static private bool SearchBigMatrix(int numToFind, int[,] bigMatrix)
        {
            for (int i = 0; i < BIG_MATRIX_ROW_SIZE; i++)
            {
                for (int j = 0; j < BIG_MATRIX_COL_SIZE; j++)
                {
                    if (numToFind == bigMatrix[i, j])
                        return true;
                }

            }
            return false;
        }

        //Generate RandomNo
        static private int GenerateRandomNo()
        {
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Find random number in 50x50 Matrix...: ");

            // create 50x50 bigMatrix
            // fill bigMatrix by random numbers
            // generate 4 digit number
            int[,] bigMatrix = new int[BIG_MATRIX_ROW_SIZE, BIG_MATRIX_COL_SIZE];
            Console.WriteLine("50x50 bigMatrix table:");
            for (int i = 0; i < 50; i++)
            {
                int j = 0;
                for (j = 0; j < 50; j++)
                {
                    bigMatrix[i, j] = GenerateRandomNo();
                    Console.Write(bigMatrix[i, j] + " ");
                }
                Console.WriteLine("\n");
            }


            // fill one dim array with 4 digit 25 randomly generated numbers
            int[] oneDimArray = new int[ONE_DIM_ARRAY_SIZE];
            Console.WriteLine("4 digit random nums:");
            for (int i = 0; i < ONE_DIM_ARRAY_SIZE; i++)
            {
                oneDimArray[i] = GenerateRandomNo();
                Console.Write(oneDimArray[i] + " ");
            }
            Console.WriteLine("\n");

            // search oneDimArray in bigMatrix , display found and missing numbers separately
            searchForNum(oneDimArray, bigMatrix);
        }
    }
}
