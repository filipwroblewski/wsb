using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSortowanie
{
    class Program
    {
        static void SelectionSort(int[] tab)
        {
            for (int i = 0; i < tab.Length; i++)
                for (int j = i + 1; j < tab.Length; j++)
                    if (tab[i] > tab[j])
                        (tab[i], tab[j]) = (tab[j], tab[i]);
        }

        static void InsertionSort(int[] tab)
        {
            for (int i = 1; i < tab.Length; i++)
                for (int j = i; j > 0 && tab[j] < tab[j - 1]; j--)
                    (tab[j], tab[j - 1]) = (tab[j - 1], tab[j]);
        }

        static void QuickSortImpl(int[] tab, int left, int right)
        {
            if (left >= right)
                return;
            int pivot = tab[left];
            int l = left - 1;
            int r = right + 1;
            while (l < r)
            {
                l++;
                r--;
                while (tab[l] < pivot)
                    l++;
                while (tab[r] > pivot)
                    r--;
                (tab[l], tab[r]) = (tab[r], tab[l]);
            }
            (tab[l], tab[r]) = (tab[r], tab[l]);
            QuickSortImpl(tab, left, r);
            QuickSortImpl(tab, r + 1, right);
        }

        static void QuickSort(int[] tab)
        {
            QuickSortImpl(tab, 0, tab.Length - 1);
        }

        static void MergeSortImpl(int[] tab, int l, int r)
        {
            if (l >= r)
                return;
            int mid = (l + r) / 2;
            MergeSortImpl(tab, l, mid);
            MergeSortImpl(tab, mid + 1, r);
            var outTab = new int[r - l + 1];
            int first = l, second = mid + 1, outIndex = 0;
            while (first <= mid && second <= r)
            {
                if (tab[first] < tab[second])
                {
                    outTab[outIndex++] = tab[first++];
                }
                else
                {
                    outTab[outIndex++] = tab[second++];
                }
            }
            while (first <= mid)
                outTab[outIndex++] = tab[first++];
            while (second <= r)
                outTab[outIndex++] = tab[second++];
            for (int i = 0; i < outTab.Length; i++)
                tab[l + i] = outTab[i];
        }

        static void MergeSort(int[] tab)
        {
            MergeSortImpl(tab, 0, tab.Length - 1);
        }

        static void ShellMethodSort(int[] tab)
        {
            int i, j, gap, x;
            gap = 1;
            while (gap >= tab.Length)
            {
                gap = 3 * gap + 1;
            }
            if (gap == 0)
                gap = 1;
            while (gap > 0)
            {
                for (j = tab.Length - gap; j >= 0; j--)
                {
                    x = tab[j];
                    i = j + gap;
                    while ((i < tab.Length) && (x > tab[i]))
                    {
                        tab[i - gap] = tab[i];
                        i = i + gap;
                    }
                    tab[i - gap] = x;
                }
                gap = gap / 3;
            }
        }

        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();

            //klucze rosnące, malejące, V-kształtne, A-kształtne, stałe, losowe
            Console.WriteLine("n;rosnące;malejące;V-kształtne;A-kształtne;stałe;losowe");
            for (int num_of_elems = 1000; num_of_elems <= 10000; num_of_elems += 1000)
                {
                //dane rosnące
                int[] data_asc = new int[num_of_elems];
                for (int i = 0; i < num_of_elems; i++)
                    data_asc[i] = i;

                stopwatch.Reset();
                stopwatch.Start();
                SelectionSort(data_asc);
                stopwatch.Stop();
                long time_data_asc = stopwatch.ElapsedMilliseconds;

                //dane malejące
                int[] data_desc = new int[num_of_elems];
                List<int> data_desc_list = new List<int>();
                for (int i = num_of_elems - 1; i >= 0; i--)
                    data_desc_list.Add(i);
                data_desc = data_desc_list.ToArray();

                stopwatch.Reset();
                stopwatch.Start();
                SelectionSort(data_desc);
                stopwatch.Stop();
                long time_data_desc = stopwatch.ElapsedMilliseconds;


                //dane V-kształtne
                int[] data_V = new int[num_of_elems];
                List<int> data_V_list = new List<int>();
                int tmp_num_of_elems = num_of_elems / 2;
                for (int i = tmp_num_of_elems; i >= 0; i--)
                    data_V_list.Add(i);
                for (int i = tmp_num_of_elems + 1; i < num_of_elems; i++)
                    data_V_list.Add(i);
                data_V = data_V_list.ToArray();

                stopwatch.Reset();
                stopwatch.Start();
                SelectionSort(data_V);
                stopwatch.Stop();
                long time_data_V = stopwatch.ElapsedMilliseconds;


                //dane A-kształtne
                int[] data_A = new int[num_of_elems];
                List<int> data_A_list = new List<int>();
                tmp_num_of_elems = num_of_elems / 2;
                for (int i = tmp_num_of_elems + 1; i < num_of_elems; i++)
                    data_A_list.Add(i);
                for (int i = tmp_num_of_elems; i >= 0; i--)
                    data_A_list.Add(i);
                data_A = data_A_list.ToArray();

                stopwatch.Reset();
                stopwatch.Start();
                SelectionSort(data_A);
                stopwatch.Stop();
                long time_data_A = stopwatch.ElapsedMilliseconds;


                //dane stałe
                int[] data_static = new int[num_of_elems];
                for (int i = 0; i < num_of_elems; i++)
                    data_static[i] = 1;

                stopwatch.Reset();
                stopwatch.Start();
                SelectionSort(data_static);
                stopwatch.Stop();
                long time_data_static = stopwatch.ElapsedMilliseconds;


                //dane losowe
                int[] data_random = new int[num_of_elems];
                Random gen = new Random();
                int n;
                bool flag;
                for (int i = 0; i < num_of_elems; i++)
                {
                    flag = true;
                    while (flag)
                    {
                        n = gen.Next(0, num_of_elems + 1);

                        if (false == Array.Exists(data_random, element => element == n))
                        {
                            data_random[i] = n;
                            flag = false;
                        }
                    }
                }

                stopwatch.Reset();
                stopwatch.Start();
                SelectionSort(data_random);
                stopwatch.Stop();
                long time_data_random = stopwatch.ElapsedMilliseconds;

                Console.WriteLine($"{num_of_elems};{time_data_asc}ms;{time_data_desc}ms;{time_data_V}ms;{time_data_A}ms;{time_data_static}ms;{time_data_random}ms");
            }

            Console.ReadLine();
        }
    }
}
