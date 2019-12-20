using Microsoft.VisualStudio.TestTools.UnitTesting;
using VectorMath;

namespace VectorMathTests
{
    [TestClass]
    public class MatrixOperatorTests
    {
        [TestMethod]
        public void TestMatrixAddition()
        {
            Matrix a = new Matrix(new decimal[,]
            {
                { 1, 2, 3 },
                { 4, -5, 6 }
            });

            Matrix b = new Matrix(new decimal[,]
            {
                { 1.5m, 2.5m, 3.5m },
                { -4.5m, 5.5m, 6.5m }
            });

            Matrix expected = new Matrix(new decimal[,]
            {
                { 2.5m, 4.5m, 6.5m },
                { -0.5m, 0.5m, 12.5m }
            });

            Assert.AreEqual(expected, a + b);
        }

        [TestMethod]
        public void TestMatrixSubtraction()
        {
            Matrix a = new Matrix(new decimal[,]
            {
                { 7, 9, -3 },
                { 8, -5, 6 }
            });

            Matrix b = new Matrix(new decimal[,]
            {
                { 1.5m, 2.5m, 3.5m },
                { -4.5m, 5.5m, 6.5m }
            });

            Matrix expected = new Matrix(new decimal[,]
            {
                { 5.5m, 6.5m, -6.5m },
                { 12.5m, -10.5m, -0.5m }
            });

            Assert.AreEqual(expected, a - b);
        }

        [TestMethod]
        public void TestMatrixMultiplication()
        {
            Matrix a = new Matrix(new decimal[,]
            {
                { 1, 2, 3 },
                { 4, -5, 6 }
            });

            Matrix b = new Matrix(new decimal[,]
            {
                { 0, 0, 1 },
                { 1, -0.5m, -1 },
                { 1, 0, 1 }
            });

            Matrix expected = new Matrix(new decimal[,]
            {
                { 5, -1, 2 },
                { 1, 2.5m, 15 }
            });

            Assert.AreEqual(expected, a * b);
        }

        [TestMethod]
        public void TestCoordinatewiseMultiplication()
        {
            Matrix a = new Matrix(new decimal[,]
            {
                { 1, 2, 3 },
                { 4, -5, 6 }
            });

            Matrix b = new Matrix(new decimal[,]
            {
                { 3, 2, 1 },
                { 5, 4, 6 }
            });

            Matrix expected = new Matrix(new decimal[,]
            {
                { 3, 4, 3 },
                { 20, -20, 36 }
            });

            Assert.AreEqual(expected, a ^ b);
        }

        [TestMethod]
        public void TestMatrixScalarMultiplication()
        {
            Matrix a = new Matrix(new decimal[,]
            {
                { 1, 2 },
                { 4, -5 }
            });

            decimal lambda = 0.25m;

            Matrix expected = new Matrix(new decimal[,]
            {
                { 0.25m, 0.5m },
                { 1, -1.25m }
            });

            Assert.AreEqual(expected, a * lambda);
            Assert.AreEqual(expected, lambda * a);
        }

        [TestMethod]
        public void TestMatrixTransposed()
        {
            Matrix a = new Matrix(new decimal[,]
            {
                { 1, 2, 3 },
                { 4, -5, 6 }
            });

            Matrix expected = new Matrix(new decimal[,]
            {
                { 1, 4 },
                { 2, -5 },
                { 3, 6 }
            });

            Assert.AreEqual(expected, a.Transposed());
        }

        [TestMethod]
        public void TestMatrixInversionOperation()
        {
            Matrix a = new Matrix(new decimal[,]
            {
                { 1, 2, 3 },
                { 4, -5, 6 }
            });

            Matrix expected = new Matrix(new decimal[,]
            {
                { -1, -2, -3 },
                { -4, 5, -6 }
            });

            Assert.AreEqual(expected, -a);
        }

        [TestMethod]
        public void TestAdditionAssignment()
        {
            Matrix a = new Matrix(new decimal[,] {
                { 1, 2, 3 },
                { 4, 5, 6 }
            });

            Matrix b = new Matrix(new decimal[,]
            {
                { 1, 1, 1 },
                { 1, 1, 1 }
            });

            a += b;

            Matrix expected = new Matrix(new decimal[,]
            {
                { 2, 3, 4 },
                { 5, 6, 7 }
            });

            Assert.AreEqual(expected, a);
        }

        [TestMethod]
        public void TestFunctionApplication()
        {
            Matrix mat = new Matrix(new decimal[,]
            {
                { 1, 2 },
                { 3, 4 },
                { 5, 6 }
            });

            static decimal f(decimal d) => 2 * d;

            Matrix expected = new Matrix(new decimal[,] {
                { 2, 4 },
                { 6, 8 },
                { 10, 12 }
            });

            Assert.AreEqual(expected, mat.Apply(f));
        }
    }
}
