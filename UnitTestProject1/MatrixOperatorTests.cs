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
            Matrix a = new Matrix(new double[,]
            {
                { 1, 2, 3 },
                { 4, -5, 6 }
            });

            Matrix b = new Matrix(new double[,]
            {
                { 1.5, 2.5, 3.5 },
                { -4.5, 5.5, 6.5 }
            });

            Matrix expected = new Matrix(new double[,]
            {
                { 2.5, 4.5, 6.5 },
                { -0.5, 0.5, 12.5 }
            });

            Assert.AreEqual(expected, a + b);
        }

        [TestMethod]
        public void TestMatrixSubtraction()
        {
            Matrix a = new Matrix(new double[,]
            {
                { 7, 9, -3 },
                { 8, -5, 6 }
            });

            Matrix b = new Matrix(new double[,]
            {
                { 1.5, 2.5, 3.5 },
                { -4.5, 5.5, 6.5 }
            });

            Matrix expected = new Matrix(new double[,]
            {
                { 5.5, 6.5, -6.5 },
                { 12.5, -10.5, -0.5 }
            });

            Assert.AreEqual(expected, a - b);
        }

        [TestMethod]
        public void TestMatrixMultiplication()
        {
            Matrix a = new Matrix(new double[,]
            {
                { 1, 2, 3 },
                { 4, -5, 6 }
            });

            Matrix b = new Matrix(new double[,]
            {
                { 0, 0, 1 },
                { 1, -0.5, -1 },
                { 1, 0, 1 }
            });

            Matrix expected = new Matrix(new double[,]
            {
                { 5, -1, 2 },
                { 1, 2.5, 15 }
            });

            Assert.AreEqual(expected, a * b);
        }

        [TestMethod]
        public void TestMatrixScalarMultiplication()
        {
            Matrix a = new Matrix(new double[,]
            {
                { 1, 2 },
                { 4, -5 }
            });

            double lambda = 0.25;

            Matrix expected = new Matrix(new double[,]
            {
                { 0.25, 0.5 },
                { 1, -1.25 }
            });

            Assert.AreEqual(expected, a * lambda);
            Assert.AreEqual(expected, lambda * a);
        }

        [TestMethod]
        public void TestMatrixTransposed()
        {
            Matrix a = new Matrix(new double[,]
            {
                { 1, 2, 3 },
                { 4, -5, 6 }
            });

            Matrix expected = new Matrix(new double[,]
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
            Matrix a = new Matrix(new double[,]
            {
                { 1, 2, 3 },
                { 4, -5, 6 }
            });

            Matrix expected = new Matrix(new double[,]
            {
                { -1, -2, -3 },
                { -4, 5, -6 }
            });

            Assert.AreEqual(expected, -a);
        }
    }
}
