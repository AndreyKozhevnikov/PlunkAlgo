using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlunkAlgo {
  public  class Program {
        static void Main(string[] args) {
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
    }
}
