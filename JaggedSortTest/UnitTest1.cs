using System;
using System.Diagnostics;
using ClassLibraryTask1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JaggedSortTest
{
    [TestClass]
    public class UnitTest1
    {
        
        [TestMethod]
        public void SortInAscendingOrderByAbsoluteMaxElements()
        {
            int[][] array = new int[3][] {new int[3] {1, 2, 3}, new int[3] {4, 5, -6}, new int[3] {0, 1, 2}};
            int[][] array1 = new int[3][] { array[2], array[0], array[1] };
            JaggedArraySort.DoSort(array, new ComparerByAbsoluteMaxToUp());
            Assert.IsTrue(Equals(array, array1));
        }

        [TestMethod]
        public void SortInDescendingOrderByAbsoluteMaxElements()
        {
            int[][] array = new int[3][] { new int[3] { 1, 2, 3 }, new int[3] { 4, 5, -6 }, new int[3] { 0, 1, 2 } };
            int[][] array1 = new int[3][] { array[1], array[0], array[2] };
            JaggedArraySort.DoSort(array, new ComparerByAbsoluteMaxToDown());
            Assert.IsTrue(Equals(array, array1));
        }

        [TestMethod]
        public void SortInDescendingOrderBySumOfElements()
        {
            int[][] array = new int[3][] { new int[3] { 1, 2, 3 }, new int[3] { 0, 1, -6 }, new int[3] { 10, 11, 12 } };
            int[][] array1 = new int[3][] { array[2], array[0], array[1] };
            JaggedArraySort.DoSort(array, new ComparerBySumToDown());
            Assert.IsTrue(Equals(array, array1));
        }

        [TestMethod]
        public void SortInAscendingOrderBySumOfElements()
        {
            int[][] array = new int[3][] { new int[3] { 1, 2, 3 }, new int[3] { 0, 1, -6 }, new int[3] { 10, 11, 12 } };
            int[][] array1 = new int[3][] { array[1], array[0], array[2] };
            JaggedArraySort.DoSort(array, new ComparerBySumToUp());
            Assert.IsTrue(Equals(array, array1));
        }


        private bool Equals(int[][] a, int[][] b)
        {
            if (a == null || b == null) return false;
            if (a.Length != b.Length) return false;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == null || b[i] == null) return false;
                if (a[i].Length != b[i].Length) return false;
                for (int j = 0; j < a[i].Length; j++)
                {
                    if (a[i][j] != b[i][j]) return false;
                }
            }
            return true;
        }
    }
}
