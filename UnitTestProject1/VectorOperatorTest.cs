using Microsoft.VisualStudio.TestTools.UnitTesting;
using VectorMath;

namespace VectorMathTests
{
    [TestClass]
    public class VectorOperatorTest
    {
        [TestMethod]
        public void TestComparison()
        {
            Vector a = new Vector(new double[] { 1, 2, 3 });
            Vector b = new Vector(new double[] { 1, 2, 2 });

            Assert.AreNotEqual(a, b);

            Vector expected = new Vector(new double[] { 1, 2, 3 });

            Assert.AreEqual(expected, a);
        }

        [TestMethod]
        public void TestInverseOperator()
        {
            Vector a = new Vector(new double[] { 21, 10, 2019 });
            Vector expected = new Vector(new double[] { -21, -10, -2019 });

            Assert.AreEqual(expected, -a);
        }

        [TestMethod]
        public void TestAdding()
        {
            Vector a = new Vector(new double[] { 1, 2, 3 });
            Vector b = new Vector(new double[] { 0, -1, -2 });

            Vector expected = new Vector(new double[] { 1, 1, 1 });

            Assert.AreEqual(expected, a + b);
        }

        [TestMethod]
        public void TestSubtracting()
        {
            Vector a = new Vector(new double[] { 1, 2, 3 });
            Vector b = new Vector(new double[] { 1, 1, 2});

            Vector expected = new Vector(new double[] { 0, 1, 1 });

            Assert.AreEqual(expected, a - b);
        }

        [TestMethod]
        public void TestScalarMultiplication()
        {
            Vector a = new Vector(new double[] { 1, 2, 3 });

            Vector expected = new Vector(new double[] { 1.5, 3, 4.5 });

            Assert.AreEqual(expected, a * 1.5);
            Assert.AreEqual(a * 1.25, 1.25 * a);
        }

        [TestMethod]
        public void TestScalarProduct()
        {
            Vector a = new Vector(new double[] { 1, 2, 3 });
            Vector b = new Vector(new double[] { 2, 2, 3 });

            double expected = 15;  // = 1 * 2 + 2 * 2 + 3 * 3.

            Assert.AreEqual(expected, a * b);
            Assert.AreEqual(expected, b * a);  // Symmetrie
        }

        [TestMethod]
        public void TestComponentwiseProduct()
        {
            Vector a = new Vector(new double[] { 2, 4, -1.5 });
            Vector b = new Vector(new double[] { 1, 3, 5 });

            Vector expected = new Vector(new double[] { 2, 12, -7.5 });

            Assert.AreEqual(expected, a ^ b);
            Assert.AreEqual(expected, b ^ a);  // Symmetrie
        }

        [TestMethod]
        public void TestDyadicProduct()
        {
            Vector a = new Vector(new double[] { 2, 3, 1 });
            Vector b = new Vector(new double[] { 1, 0, 5 });

            Matrix expected = new Matrix(new double[,]
            {
                { 2, 0, 10 },
                { 3, 0, 15 },
                { 1, 0, 5  }
            });

            Assert.AreEqual(expected, a | b);
        }

        [TestMethod]
        public void TestMatrixVectorProduct()
        {
            Vector a = new Vector(new double[] { 3, 2, 1 });
            Matrix mat = new Matrix(new double[,]
            {
                { 2, 4, 6 },
                { -1, -0.5, 0 }
            });

            Vector expected = new Vector(new double[] { 20, -4 });

            Assert.AreEqual(expected, mat * a);

            // Von der anderen Richtung multipliziert:
            Vector b = new Vector(new double[] { 10, -3.5 });

            expected = new Vector(new double[] { 23.5, 41.75, 60 });

            Assert.AreEqual(expected, b * mat);
        }

        [TestMethod]
        public void TestAdditionAssignment()
        {
            Vector a = new Vector(new double[] { 1, 2, 3 });
            Vector b = new Vector(new double[] { 1, 1, 1 });

            a += b;

            Vector expected = new Vector(new double[] { 2, 3, 4 });
            Assert.AreEqual(expected, a);
        }

        [TestMethod]
        public void TestFunctionApplication()
        {
            Vector a = new Vector(new double[] { 1, 2, 3 });
            static double f(double d) => 2 * d;

            Vector expected = new Vector(new double[] { 2, 4, 6 });

            Assert.AreEqual(expected, a.Apply(f));
        }

        [TestMethod]
        public void TestVectorScalarAdditionSubtraction()
        {
            Vector a = new Vector(new double[] { 1, 2, 3 });
            double d = 3;

            Vector expected = new Vector(new double[] { 4, 5, 6 });

            Assert.AreEqual(expected, a + d);
            Assert.AreEqual(expected, d + a);

            expected = new Vector(new double[] { -2, -1, 0 });

            Assert.AreEqual(expected, a - d);

            expected = new Vector(new double[] { 2, 1, 0 });

            Assert.AreEqual(expected, d - a);
        }
    }
}
