using Xunit;
using System;
using System.Linq;

namespace Lab2CSharp.Tests
{
    public class Lab2Tests
    {
        [Theory]
        [InlineData(0, true)]
        [InlineData(1, false)]
        [InlineData(2, true)]
        [InlineData(5, false)]
        public void Task1_1_VectorEvenIndexLogic(int index, bool expected)
        {
            bool isEven = index % 2 == 0;
            Assert.Equal(expected, isEven);
        }

        [Theory]
        [InlineData(0, 0, true)]
        [InlineData(0, 1, false)]
        [InlineData(1, 1, true)]
        [InlineData(2, 3, false)]
        public void Task1_2_MatrixIndexSumLogic(int i, int j, bool expected)
        {
            bool isSumEven = (i + j) % 2 == 0;
            Assert.Equal(expected, isSumEven);
        }

        [Theory]
        [InlineData(10, 5, true)]
        [InlineData(10, 3, false)]
        [InlineData(20, 1, true)]
        [InlineData(7, 14, false)]
        public void Task2_MultiplicityLogic(double current, double next, bool expected)
        {
            bool isMultiple = next != 0 && current % next == 0;
            Assert.Equal(expected, isMultiple);
        }

        [Theory]
        [InlineData(1, 1, 3, false)]
        [InlineData(2, 1, 3, true)]
        [InlineData(2, 2, 3, true)]
        [InlineData(0, 2, 3, false)]
        public void Task3_AntiDiagonalLogic(int i, int j, int n, bool expected)
        {
            bool isBelow = i + j > n - 1;
            Assert.Equal(expected, isBelow);
        }

        [Fact]
        public void Task4_JaggedArrayColumnSumLogic()
        {
            int[][] jagged = new int[2][];
            jagged[0] = new int[] { 2, 5, 4 };
            jagged[1] = new int[] { 6, 8 };

            int maxCols = jagged.Max(row => row.Length);
            int[] columnSums = new int[maxCols];

            for (int j = 0; j < maxCols; j++)
            {
                int sum = 0;
                for (int i = 0; i < jagged.Length; i++)
                {
                    if (j < jagged[i].Length)
                    {
                        int val = jagged[i][j];
                        if (val > 0 && val % 2 == 0) sum += val;
                    }
                }
                columnSums[j] = sum;
            }

            Assert.Equal(8, columnSums[0]);
            Assert.Equal(8, columnSums[1]);
            Assert.Equal(4, columnSums[2]);
        }

        [Fact]
        public void Array_RankAndLengthTests()
        {
            int[,] matrix = new int[3, 4];
            int[][] jagged = new int[3][];

            Assert.Equal(2, matrix.Rank);
            Assert.Equal(3, matrix.GetLength(0));
            Assert.Equal(4, matrix.GetLength(1));

            Assert.Equal(1, jagged.Rank);
            Assert.Equal(3, jagged.Length);
        }
    }
}