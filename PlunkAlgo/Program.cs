﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlunkAlgo {
  public  class Program {
        static void Main(string[] args) {
            var k = 100000;
            var arr = new int[k];
            var rand = new Random();
            for (int i = 0; i < k; i++) {
                arr[i] = rand.Next(-50, 50);
            }
            DateTime d1 = DateTime.Now;
            var p = new Program();
            var res = p.getMaxSubSum(arr);
            DateTime d2 = DateTime.Now;
            var ts = d2 - d1;
            Console.WriteLine(res + "  - " +ts);
            Console.ReadKey();

        }

        public int getMaxSubSum(int[] arr) {
            var max = 0;
            for (int i = 0; i < arr.Length; i++) {
                var currMax = 0;
                var sum = 0;
                for (int j = i; j < arr.Length; j++) {
                    sum = sum + arr[j];
                    if (sum > currMax) {
                        currMax = sum;
                    }
                }
                if (currMax > max) {
                    max = currMax;
                }
            }
            return max;
        }

        public int getMaxSubSum2(int[] arr) {
            // var arrMin = Math.Min(arr);
            return 0;
        }
        
    }
}
