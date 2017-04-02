﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.Library
{
    public class Builder
    {
        public IEnumerable<int> BuildIntegerSequence()
        {
            //var integers = 
            //    Enumerable.Range(0,10)
            //    .Select(i => 5+(10*i));

            var integers = Enumerable.Repeat(-1,10);

            return integers;
        }

        public IEnumerable<string> BuildStringSequence()
        {
            //Random rand = new Random();

            //var strings =
            //    Enumerable.Range(0, 10)
            //    .Select(i =>
            //        ((char)('A'+rand.Next(0,26))).ToString());

            var strings = Enumerable.Repeat("A", 10); 

            return strings;
        }

        public IEnumerable<int> CompareSequence()
        {
            var seq1 = Enumerable.Range(0, 10);
            var seq2 = Enumerable.Range(0, 10)
                .Select(i => i * i);

            //return Enumerable.Intersect(seq1, seq2); // these both are the same
            return seq1.Intersect(seq2);
        }

    }
}
