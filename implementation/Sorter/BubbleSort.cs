﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    public class BubbleSort : ISorter
    {
        public void Sort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {
            int n = sequence.Length;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (comparer.Compare(sequence[j], sequence[j + 1]) > 0)
                    {
                        Swap(ref sequence[j], ref sequence[j + 1]);
                    }
                }
            }
        }

        public void Swap<K>(ref K a, ref K b)
        {
            K temp;
            temp = a;
            a = b;
            b = temp;
        }
    }
}
