using NMatrix;
using static NMatrix.Matrix;

namespace TestMatrix
{
   
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void getEntryTest()
        {
            int[] first = new int[3];
            int[] second = new int[3];
            int[] third = new int[3];

            first[0] = 1;
            first[1] = 2;
            first[2] = 3;

            second[0] = 1;
            second[1] = 4;
            second[2] = 5;

            third[0] = 6;
            third[1] = 7;
            third[2] = 3;

            Matrix m1 = new Matrix(3, first, second, third);

            //Get the element with the same indexes (X2,2)
            int expected = 2;
            int actual = m1.GetValue(2, 2);
            Assert.AreEqual(expected, actual);

            //Get the element with different indexes (X2,3)
            int expected2 = 7;
            int actual2 = m1.GetValue(2, 3);
            Assert.AreEqual(expected2, actual2);

            //Get the element with index outside the matrix (X3,4)
            Assert.ThrowsException<invalidIndexException>(() => m1.GetValue(3, 4));
        }

        [TestMethod]
        public void summationTest()
        {


            //2x2 -	Add two 2x2 matrices
            int[] first3 = new int[2];
            int[] second3 = new int[2];
            int[] third3 = new int[2];

            first3[0] = 1;
            first3[1] = 2;

            second3[0] = 1;
            second3[1] = 4;

            third3[0] = 5;
            third3[1] = 2;

            int[] first4 = new int[2];
            int[] second4 = new int[2];
            int[] third4 = new int[2];

            first4[0] = 1;
            first4[1] = 2;

            second4[0] = 1;
            second4[1] = 4;

            third4[0] = 5;
            third4[1] = 2;

            Matrix m3 = new Matrix(2, first3, second3, third3);
            Matrix m4 = new Matrix(2, first4, second4, third4);

            Matrix mR2 = m3.Add(m4);

            Assert.AreEqual(2, mR2.GetValue(1, 1));
            Assert.AreEqual(10, mR2.GetValue(1, 2));
            Assert.AreEqual(8, mR2.GetValue(2, 1));
            Assert.AreEqual(4, mR2.GetValue(2, 2));

            //3x3 - Add two 3x3 matrices
            int[] first5 = new int[3];
            int[] second5 = new int[3];
            int[] third5 = new int[3];

            first5[0] = 1;
            first5[1] = 2;
            first5[2] = 3;

            second5[0] = 1;
            second5[1] = 4;
            second5[2] = 5;

            third5[0] = 6;
            third5[1] = 7;
            third5[2] = 3;

            int[] first6 = new int[3];
            int[] second6 = new int[3];
            int[] third6 = new int[3];

            first6[0] = 1;
            first6[1] = 2;
            first6[2] = 3;

            second6[0] = 1;
            second6[1] = 4;
            second6[2] = 5;

            third6[0] = 6;
            third6[1] = 7;
            third6[2] = 3;

            Matrix m6 = new Matrix(3, first5, second5, third5);
            Matrix m7 = new Matrix(3, first6, second6, third6);

            Matrix mR3 = m6.Add(m7);

            Assert.AreEqual(2, mR3.GetValue(1, 1));
            Assert.AreEqual(0, mR3.GetValue(1, 2));
            Assert.AreEqual(12, mR3.GetValue(1, 3));
            Assert.AreEqual(8, mR3.GetValue(2, 1));
            Assert.AreEqual(4, mR3.GetValue(2, 2));
            Assert.AreEqual(14, mR3.GetValue(2, 3));
            Assert.AreEqual(10, mR3.GetValue(3, 1));
            Assert.AreEqual(0, mR3.GetValue(3, 2));
            Assert.AreEqual(6, mR3.GetValue(3, 3));

            //Add two different size matrices
            Assert.ThrowsException<ArgumentException>(() => mR2.Add(mR3));

          
        }

        [TestMethod]
        public void multiplicationTest()
        {
            //1x1 - Multiply two 1x1 matrices
            int[] first = new int[1];
            int[] second = new int[1];
            int[] third = new int[1];

            first[0] = 1;
            second[0] = 1;
            third[0] = 1;

            int[] first2 = new int[1];
            int[] second2 = new int[1];
            int[] third2 = new int[1];

            first2[0] = 2;
            second2[0] = 2;
            third2[0] = 2;


            Matrix m1 = new Matrix(1, first, second, third);
            Matrix m2 = new Matrix(1, first2, second2, third2);

            Matrix mR = m1.Multiply(m2);

            Assert.AreEqual(2, mR.GetValue(1, 1));

            //2x2 -	Multiply two 2x2 matrices
            int[] first3 = new int[2];
            int[] second3 = new int[2];
            int[] third3 = new int[2];

            first3[0] = 1;
            first3[1] = 2;

            second3[0] = 1;
            second3[1] = 4;

            third3[0] = 5;
            third3[1] = 2;

            int[] first4 = new int[2];
            int[] second4 = new int[2];
            int[] third4 = new int[2];

            first4[0] = 1;
            first4[1] = 2;

            second4[0] = 1;
            second4[1] = 4;

            third4[0] = 5;
            third4[1] = 2;

            Matrix m3 = new Matrix(2, first3, second3, third3);
            Matrix m4 = new Matrix(2, first4, second4, third4);

            Matrix mR2 = m3.Multiply(m4);

            Assert.AreEqual(21, mR2.GetValue(1, 1));
            Assert.AreEqual(15, mR2.GetValue(1, 2));
            Assert.AreEqual(12, mR2.GetValue(2, 1));
            Assert.AreEqual(24, mR2.GetValue(2, 2));

            //3x3 - Mutiply two 3x3 matrices
            int[] first5 = new int[3];
            int[] second5 = new int[3];
            int[] third5 = new int[3];

            first5[0] = 1;
            first5[1] = 2;
            first5[2] = 3;

            second5[0] = 1;
            second5[1] = 4;
            second5[2] = 5;

            third5[0] = 6;
            third5[1] = 7;
            third5[2] = 3;

            int[] first6 = new int[3];
            int[] second6 = new int[3];
            int[] third6 = new int[3];

            first6[0] = -1;
            first6[1] = -2;
            first6[2] = -3;

            second6[0] = -1;
            second6[1] = -4;
            second6[2] = -5;

            third6[0] = -6;
            third6[1] = -7;
            third6[2] = -3;

            Matrix m6 = new Matrix(3, first5, second5, third5);
            Matrix m7 = new Matrix(3, first6, second6, third6);

            Matrix mR3 = m6.Multiply(m7);

            Assert.AreEqual(-31, mR3.GetValue(1, 1));
            Assert.AreEqual(0, mR3.GetValue(1, 2));
            Assert.AreEqual(-24, mR3.GetValue(1, 3));
            Assert.AreEqual(-47, mR3.GetValue(2, 1));
            Assert.AreEqual(-4, mR3.GetValue(2, 2));
            Assert.AreEqual(-59, mR3.GetValue(2, 3));
            Assert.AreEqual(-20, mR3.GetValue(3, 1));
            Assert.AreEqual(0, mR3.GetValue(3, 2));
            Assert.AreEqual(-39, mR3.GetValue(3, 3));


            //Multiply two different size matrices
            Assert.ThrowsException<ArgumentException>(() => mR2.Multiply(mR3));


           
        }

        [TestMethod]
        public void MatrixConstructorException()
        {
            int[] firsttemp2 = new int[1];
            int[] secondtemp2 = new int[1];
            int[] thirdtemp2 = new int[1];

            firsttemp2[0] = 1;
            secondtemp2[0] = 1;
            thirdtemp2[0] = 1;

            int[] firsttemp3 = new int[0];
            int[] secondtemp3 = new int[0];
            int[] thirdtemp3 = new int[0];

            int[] firsttemp4 = new int[1];
            int[] secondtemp4 = new int[1];
            int[] thirdtemp4 = new int[1];

            Assert.ThrowsException<negativeException>(() => new Matrix(-1, firsttemp2, secondtemp2, thirdtemp2));
            Assert.ThrowsException<negativeException>(() => new Matrix(-9));
            Assert.ThrowsException<emptyArrayException>(() => new Matrix(1, firsttemp3, secondtemp3, thirdtemp3));
            Assert.ThrowsException<differentException>(() => new Matrix(2, firsttemp4, secondtemp4, thirdtemp4));
        }

        [TestMethod]
        public void getValueException()
        {
            int[] firstTemp = new int[2];
            int[] secondTemp = new int[2];
            int[] thirdTemp = new int[2];

            firstTemp[0] = 0;
            firstTemp[1] = 0;

            secondTemp[0] = 0;
            secondTemp[1] = 0;

            thirdTemp[0] = 0;
            thirdTemp[1] = 0;
            Matrix mTemp = new Matrix(2, firstTemp, secondTemp, thirdTemp);
            Assert.ThrowsException<negativeException>(() => mTemp.GetValue(-1, -1));
        }
    }
}
/*            ////1x1 - Add two 1x1 matrices
            //int[] first = new int[1];
            //int[] second = new int[1];
            //int[] third = new int[1];

            //first[0] = 1;
            //second[0] = 1;
            //third[0] = 1;

            //int[] first2 = new int[1];
            //int[] second2 = new int[1];
            //int[] third2 = new int[1];

            //first2[0] = 2;
            //second2[0] = 2;
            //third2[0] = 2;


            //Matrix m1 = new Matrix(1, first, second, third);
            //Matrix m2 = new Matrix(1, first2, second2, third2);

            //Matrix mR = m1.Add(m2);

            //Assert.AreEqual(3, mR.GetValue(1, 1));

  ////Check the (a * b = b * a) property
            //Matrix mR4 = m4.Multiply(m3);
            //Assert.AreEqual(mR4.GetValue(1, 1), mR2.GetValue(1, 1));
            //Assert.AreEqual(mR4.GetValue(1, 2), mR2.GetValue(1, 2));
            //Assert.AreEqual(mR4.GetValue(2, 1), mR2.GetValue(2, 1));
            //Assert.AreEqual(mR4.GetValue(2, 2), mR2.GetValue(2, 2));


            ////Check the(a * 0 = a) property
            //int[] firstTemp = new int[2];
            //int[] secondTemp = new int[2];
            //int[] thirdTemp = new int[2];

            //firstTemp[0] = 0;
            //firstTemp[1] = 0;

            //secondTemp[0] = 0;
            //secondTemp[1] = 0;

            //thirdTemp[0] = 0;
            //thirdTemp[1] = 0;
            //Matrix mTemp = new Matrix(2, firstTemp, secondTemp, thirdTemp);

            //Matrix mR5 = m4.Multiply(mTemp);
            //Assert.AreEqual(0, mR5.GetValue(1, 1));
            //Assert.AreEqual(0, mR5.GetValue(1, 2));
            //Assert.AreEqual(0, mR5.GetValue(2, 1));
            //Assert.AreEqual(0, mR5.GetValue(2, 2));

   ////Check the (a + b = b + a) property
            //Matrix mR4 = m4.Add(m3);
            //Assert.AreEqual(mR4.GetValue(1, 1), mR2.GetValue(1, 1));
            //Assert.AreEqual(mR4.GetValue(1, 2), mR2.GetValue(1, 2));
            //Assert.AreEqual(mR4.GetValue(2, 1), mR2.GetValue(2, 1));
            //Assert.AreEqual(mR4.GetValue(2, 2), mR2.GetValue(2, 2));

            ////Check the(a + 0 = a) property
            //int[] firstTemp = new int[2];
            //int[] secondTemp = new int[2];
            //int[] thirdTemp = new int[2];

            //firstTemp[0] = 0;
            //firstTemp[1] = 0;

            //secondTemp[0] = 0;
            //secondTemp[1] = 0;

            //thirdTemp[0] = 0;
            //thirdTemp[1] = 0;
            //Matrix mTemp = new Matrix(2, firstTemp, secondTemp, thirdTemp);

            //Matrix mR5 = m4.Add(mTemp);
            //Assert.AreEqual(1, mR5.GetValue(1, 1));
            //Assert.AreEqual(5, mR5.GetValue(1, 2));
            //Assert.AreEqual(4, mR5.GetValue(2, 1));
            //Assert.AreEqual(2, mR5.GetValue(2, 2));*/