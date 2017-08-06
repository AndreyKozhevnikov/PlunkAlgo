using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlunkAlgo {
    [TestFixture]
    public class Tests {
        public Tests() {
            p = new Program();
        }
        Program p;

        [Test]
        public void Test1() {
            //arrange
            var res = p.getMaxSubSum(new int[] { 1, 2, 3 });
            //assert
            Assert.AreEqual(6, res);
        }
        [Test]
        public void Test2() {
            //arrange
            var res = p.getMaxSubSum(new int[] { -1, 2, 3, -9 });
            //assert
            Assert.AreEqual(5, res);
        }
        [Test]
        public void Test3() {
            //arrange
            var res = p.getMaxSubSum(new int[] { -1, 2, 3, -9, 11 });
            //assert
            Assert.AreEqual(11, res);
        }
        [Test]
        public void Test33() {
            //arrange
            var res = p.getMaxSubSum(new int[] { -1, 2, 3, -2, 11 });
            //assert
            Assert.AreEqual(14, res);
        }

        [Test]
        public void Test333() {
            //arrange
            var res = p.getMaxSubSum(new int[] { -1, 2, 3, -10, 11 });
            //assert
            Assert.AreEqual(11, res);
        }
        [Test]
        public void Test4() {
            //arrange
            var res = p.getMaxSubSum(new int[] { -2, -1, 1, 2 });
            //assert
            Assert.AreEqual(3, res);
        }
        [Test]
        public void Test5() {
            //arrange
            var res = p.getMaxSubSum(new int[] { 100, -9, 2, -3, 5 });
            //assert
            Assert.AreEqual(100, res);
        }
        [Test]
        public void Test6() {
            //arrange
            var res = p.getMaxSubSum(new int[] { });
            //assert
            Assert.AreEqual(0, res);
        }
        [Test]
        public void Test7() {
            //arrange
            var res = p.getMaxSubSum(new int[] { -1 });
            //assert
            Assert.AreEqual(0, res);
        }
        [Test]
        public void Test8() {
            //arrange
            var res = p.getMaxSubSum(new int[] { -1, -2 });
            //assert
            Assert.AreEqual(0, res);
        }
        [Test]
        public void Test9() {
            //arrange
            var res = p.getMaxSubSum(new int[] { 10, -2, 20, 7 });
            //assert
            Assert.AreEqual(35, res);
        }
        [Test]
        public void Test10() {
            //arrange
            var res = p.getMaxSubSum(new int[] { 10, 20, -200, 5, 35 });
            //assert
            Assert.AreEqual(40, res);
        }
        [Test]
        public void Test11() {
            //arrange
            var res = p.getMaxSubSum(new int[] { 10, 20, -200, 40, 5, -300, 5, 35 });
            //assert
            Assert.AreEqual(45, res);
        }

        [Test]
        public void ComplexTest() {
            //arrange
            var rand = new Random(DateTime.Now.Millisecond);
            var arr = new int[100];
            int resEtal = 0;
            int res = 0;
            //act-assert
            for (int i = 0; i < 100; i++) {
                for (int j = 0; j < 100; j++) {
                    arr[j] = rand.Next(-500, 500);
                }
                resEtal = p.getMaxSubSumEtal(arr);
                res = p.getMaxSubSum(arr);
                Assert.AreEqual(resEtal, res,arr.ToString());
            }
        }
    }
}
