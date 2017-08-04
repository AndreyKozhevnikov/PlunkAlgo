using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlunkAlgo {
    public class Program {
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
            Console.WriteLine(res + "  - " + ts);
            Console.ReadKey();

        }

        public int getMaxSubSum2(int[] arr) {
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

        public int getMaxSubSum(int[] arr) {
            if (arr.Length == 0)
                return 0;
            var arrMin = arr.Min();

            var leftIndex = 0;
            var rightIndex = arr.Length - 1;

            var leftMax = arrMin;
            var rightMax = arrMin;

            var leftSum = 0;
            var rigthSum = 0;

            var rightArrValue = new ArrValue(arrMin);
            var leftArrValue = new ArrValue(arrMin);

            for (int i = 0; i < arr.Length; i++) {
                leftSum = leftSum + arr[i];
                if (leftSum > leftArrValue.sum) {
                    leftArrValue.sum = leftSum;
                    leftArrValue.index = i;
                    leftArrValue.ClearChildren();
                }

                var rCurrIndex = arr.Length - 1 - i;
                rigthSum = rigthSum + arr[rCurrIndex];
                if (rigthSum > rightArrValue.sum) {
                    rightArrValue.sum = rigthSum;
                    rightArrValue.index = rCurrIndex;
                    rightArrValue.ClearChildren();
                }
            }
      
            var sum = 0;

            if (rightArrValue.index > leftArrValue.index) {
                sum= Math.Max(rightArrValue.sum, leftArrValue.sum);
            }
            else {
                var newArrLength = leftArrValue.index - rightArrValue.index + 1;
                var newArr = new int[newArrLength];
                Array.Copy(arr, rightArrValue.index, newArr, 0, newArrLength);
                sum = newArr.Sum();

            }

            if (sum > 0)
                return sum;
            else
                return 0;
        }

    }

    public class ArrValue {
        public ArrValue(int minValue) {
            sum = minValue;
        }
        public int index;
        public int sum;
        public ArrValue child;
        public void ClearChildren() {
            child = null;

        }
    }
}
