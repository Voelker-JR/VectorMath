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
            Vector a = new Vector(new decimal[] { 1, 2, 3 });
            Vector b = new Vector(new decimal[] { 1, 2, 2 });

            Assert.AreNotEqual(a, b);

            Vector expected = new Vector(new decimal[] { 1, 2, 3 });

            Assert.AreEqual(expected, a);
        }

        [TestMethod]
        public void TestInverseOperator()
        {
            Vector a = new Vector(new decimal[] { 21, 10, 2019 });
            Vector expected = new Vector(new decimal[] { -21, -10, -2019 });

            Assert.AreEqual(expected, -a);
        }

        [TestMethod]
        public void TestAdding()
        {
            Vector a = new Vector(new decimal[] { 1, 2, 3 });
            Vector b = new Vector(new decimal[] { 0, -1, -2 });

            Vector expected = new Vector(new decimal[] { 1, 1, 1 });

            Assert.AreEqual(expected, a + b);
        }

        [TestMethod]
        public void TestSubtracting()
        {
            Vector a = new Vector(new decimal[] { 1, 2, 3 });
            Vector b = new Vector(new decimal[] { 1, 1, 2});

            Vector expected = new Vector(new decimal[] { 0, 1, 1 });

            Assert.AreEqual(expected, a - b);
        }

        [TestMethod]
        public void TestScalarMultiplication()
        {
            Vector a = new Vector(new decimal[] { 1, 2, 3 });

            Vector expected = new Vector(new decimal[] { 1.5m, 3, 4.5m });

            Assert.AreEqual(expected, a * 1.5m);
            Assert.AreEqual(a * 1.25m, 1.25m * a);
        }

        [TestMethod]
        public void TestScalarProduct()
        {
            Vector a = new Vector(new decimal[] { 1, 2, 3 });
            Vector b = new Vector(new decimal[] { 2, 2, 3 });

            decimal expected = 15;  // = 1 * 2 + 2 * 2 + 3 * 3.

            Assert.AreEqual(expected, a * b);
            Assert.AreEqual(expected, b * a);  // Symmetrie
        }

        [TestMethod]
        public void TestComponentwiseProduct()
        {
            Vector a = new Vector(new decimal[] { 2, 4, -1.5m });
            Vector b = new Vector(new decimal[] { 1, 3, 5 });

            Vector expected = new Vector(new decimal[] { 2, 12, -7.5m });

            Assert.AreEqual(expected, a ^ b);
            Assert.AreEqual(expected, b ^ a);  // Symmetrie
        }

        [TestMethod]
        public void TestDyadicProduct()
        {
            Vector a = new Vector(new decimal[] { 2, 3, 1 });
            Vector b = new Vector(new decimal[] { 1, 0, 5 });

            Matrix expected = new Matrix(new decimal[,]
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
            Vector a = new Vector(new decimal[] { 3, 2, 1 });
            Matrix mat = new Matrix(new decimal[,]
            {
                { 2, 4, 6 },
                { -1, -0.5m, 0 }
            });

            Vector expected = new Vector(new decimal[] { 20, -4 });

            Assert.AreEqual(expected, mat * a);

            // Von der anderen Richtung multipliziert:
            Vector b = new Vector(new decimal[] { 10, -3.5m });

            expected = new Vector(new decimal[] { 23.5m, 41.75m, 60 });

            Assert.AreEqual(expected, b * mat);
        }

        [TestMethod]
        public void TestAdditionAssignment()
        {
            Vector a = new Vector(new decimal[] { 1, 2, 3 });
            Vector b = new Vector(new decimal[] { 1, 1, 1 });

            a += b;

            Vector expected = new Vector(new decimal[] { 2, 3, 4 });
            Assert.AreEqual(expected, a);
        }

        [TestMethod]
        public void TestFunctionApplication()
        {
            Vector a = new Vector(new decimal[] { 1, 2, 3 });
            static decimal f(decimal d) => 2 * d;

            Vector expected = new Vector(new decimal[] { 2, 4, 6 });

            Assert.AreEqual(expected, a.Apply(f));
        }

        [TestMethod]
        public void TestVectorScalarAdditionSubtraction()
        {
            Vector a = new Vector(new decimal[] { 1, 2, 3 });
            decimal d = 3;

            Vector expected = new Vector(new decimal[] { 4, 5, 6 });

            Assert.AreEqual(expected, a + d);
            Assert.AreEqual(expected, d + a);

            expected = new Vector(new decimal[] { -2, -1, 0 });

            Assert.AreEqual(expected, a - d);

            expected = new Vector(new decimal[] { 2, 1, 0 });

            Assert.AreEqual(expected, d - a);
        }
    }
}
