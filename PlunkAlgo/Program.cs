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

        public int getMaxSubSumEtal(int[] arr) {
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
            int maxSum = 0;
            int partialSum = 0;
            for (int i = 0; i < arr.Length; i++) {
                partialSum = partialSum + arr[i];
                maxSum = Math.Max(partialSum, maxSum);
                if (partialSum < 0)
                    partialSum = 0;
            }
            return maxSum;
        }

        public int getMaxSubSumLong(int[] arr) {
            if (arr.Length == 0)
                return 0;
            var arrMin = arr.Min();

            ArrValue leftArrValue = null;

            for (int i = 0; i < arr.Length; i++) {
                if (leftArrValue == null) {
                    if (arr[i] > 0) {
                        leftArrValue = new ArrValue(arrMin, arr[i], i);
                    }
                }
                else {
                    leftArrValue.Update(arrMin, arr[i], i);
                }
            }

            int sum = 0;
            if (leftArrValue == null)
                return 0;
            leftArrValue.SetMax(ref sum);



            return sum;

        }
        public T[] SubArray<T>(T[] data, int index, int length) {
            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }
    }

    public class ArrValue {
        public ArrValue(int minValue) {
            maxSum = minValue;

        }

        public int maxSum;
        public int currSum;

        public ArrValue child;

        public ArrValue(int arrMin, int arrValue, int arrIndex) {
            maxSum = arrValue;
            currSum = arrValue;
        }
        bool isReadyForChild = false;
        List<int> interMediateMax = new List<int>();
        public void Update(int arrMin, int arrValue, int arrIndex) {
            currSum = currSum + arrValue;
            if (child != null)
                child.Update(arrMin, arrValue, arrIndex);
            if (arrValue > 0) {
                if (currSum >= maxSum) {
                    maxSum = currSum;
                }
                if (child == null && isReadyForChild) {
                    child = new ArrValue(arrMin, arrValue, arrIndex);
                    isReadyForChild = false;
                }
            }
            else {
                interMediateMax.Add(currSum - arrValue);
                isReadyForChild = true;
            }
        }

        public void SetMax(ref int currMax) {
            interMediateMax.Add(maxSum);
            var interMax = interMediateMax.Max();
            currMax = Math.Max(interMax, currMax);
            if (child != null)
                child.SetMax(ref currMax);

        }
    }
}
