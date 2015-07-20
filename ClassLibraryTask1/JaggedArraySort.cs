using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryTask1
{
    public interface IJaggedComparer
    {
        int Compare(int[] a, int[] b);
    }

    public static class SortingQueries
    {
        public static int FindMaxElement(int[] array)
        {
            if (array.Length == 0) throw new NullReferenceException("Array is empty");
            if (array.Length == 1) return array[0];
            int max = array[0];
            for (int i = 1; i < array.Length - 1; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }
            return max;
        }
        public static int FindMinElement(int[] array)
        {
            if (array.Length == 0) throw new NullReferenceException("Array is empty");
            if (array.Length == 1) return array[0];
            int min = array[0];
            for (int i = 1; i < array.Length - 1; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
            }
            return min;
        }
        public static int FindSumOfElements(int[] array)
        {
            if (array.Length == 0) throw new NullReferenceException("Array is empty");
            int sum = array.Sum();
            return sum;
        }

        public static int FindAbsoluteMaxOfElements(int[] array)
        {
            if (array.Length == 0) throw new NullReferenceException("Array is empty");
            if (array.Length == 1) return array[0];
            int max = Math.Abs(array[0]);
            for (int i = 1; i < array.Length - 1; i++)
            {
                if (Math.Abs(array[i]) > max)
                {
                    max = Math.Abs(array[i]);
                }
            }
            return max;
        }
    }

    public class ComparerByMaxToUp : IJaggedComparer
    {
        public int Compare(int[] a, int[] b)
        {
            int maxA = SortingQueries.FindMaxElement(a);
            int maxB = SortingQueries.FindMaxElement(b);
            if (maxA > maxB)
            {
                return 1;
            }
            if (maxA < maxB)
            {
                return -1;
            }
            return 0;
        }
    }

    public class ComparerByMaxToDown : IJaggedComparer
    {
        public int Compare(int[] a, int[] b)
        {
            int maxA = SortingQueries.FindMaxElement(a);
            int maxB = SortingQueries.FindMaxElement(b);
            if (maxA < maxB)
            {
                return 1;
            }
            if (maxA > maxB)
            {
                return -1;
            }
            return 0;
        }
    }


    public class ComparerByAbsoluteMaxToUp : IJaggedComparer
    {
        public int Compare(int[] a, int[] b)
        {
            int maxA = SortingQueries.FindAbsoluteMaxOfElements(a);
            int maxB = SortingQueries.FindAbsoluteMaxOfElements(b);
            if (maxA > maxB)
            {
                return 1;
            }
            if (maxA < maxB)
            {
                return -1;
            }
            return 0;
        }
    }

    public class ComparerByAbsoluteMaxToDown : IJaggedComparer
    {
        public int Compare(int[] a, int[] b)
        {
            int maxA = SortingQueries.FindAbsoluteMaxOfElements(a);
            int maxB = SortingQueries.FindAbsoluteMaxOfElements(b);
            if (maxA < maxB)
            {
                return 1;
            }
            if (maxA > maxB)
            {
                return -1;
            }
            return 0;
        }
    }

    public class ComparerBySumToUp : IJaggedComparer
    {
        public int Compare(int[] a, int[] b)
        {
            int sumA = SortingQueries.FindSumOfElements(a);
            int sumB = SortingQueries.FindSumOfElements(b);
            if (sumA > sumB)
            {
                return 1;
            }
            if (sumA < sumB)
            {
                return -1;
            }
            return 0;
        }
    }

    public class ComparerBySumToDown : IJaggedComparer
    {
        public int Compare(int[] a, int[] b)
        {
            int sumA = SortingQueries.FindSumOfElements(a);
            int sumB = SortingQueries.FindSumOfElements(b);
            if (sumA < sumB)
            {
                return 1;
            }
            if (sumA > sumB)
            {
                return -1;
            }
            return 0;
        }
    }

    public class ComparerByMinToUp : IJaggedComparer
    {
        public int Compare(int[] a, int[] b)
        {
            int minA = SortingQueries.FindMinElement(a);
            int minB = SortingQueries.FindMinElement(b);
            if (minA > minB)
            {
                return 1;
            }
            if (minA < minB)
            {
                return -1;
            }
            return 0;
        }
    }

    public class ComparerByMinToDown : IJaggedComparer
    {
        public int Compare(int[] a, int[] b)
        {
            int minA = SortingQueries.FindMinElement(a);
            int minB = SortingQueries.FindMinElement(b);
            if (minA < minB)
            {
                return 1;
            }
            if (minA > minB)
            {
                return -1;
            }
            return 0;
        }
    }

    public static class JaggedArraySort
    {
        public static void DoSort(int[][] array, IJaggedComparer comparer)
        {
            QuickSort(array, 0, array.Length - 1, comparer);
        }

        private static void QuickSort(int[][] array, int left, int right, IJaggedComparer comparer)
        {
            if (array == null || array.Length <= 1)
                return;
            if (left < right)
            {
                int pivot = Partition(array, left, right, comparer);

                if (pivot > 1)
                    QuickSort(array, left, pivot - 1, comparer);

                if (pivot + 1 < right)
                    QuickSort(array, pivot + 1, right, comparer);
            }
        }

        private static int Partition(int[][] array, int left, int right, IJaggedComparer comparer)
        {
            int[] pivot = array[left];

            while (true)
            {
                while (comparer.Compare(array[left], pivot) < 0)
                    left++;

                while (comparer.Compare(array[right], pivot) > 0)
                    right--;

                if (left < right)
                {
                    Swap(ref array[left], ref array[right]);
                }
                else
                {
                    return right;
                }
            }
        }

        private static void Swap(ref int[] a, ref int[] b)
        {
            int[] temp = a;
            a = b;
            b = temp;
        }

    }
}
