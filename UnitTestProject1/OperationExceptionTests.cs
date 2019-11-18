using Microsoft.VisualStudio.TestTools.UnitTesting;
using VectorMath;

namespace VectorMathTests
{
    [TestClass]
    public class OperationExceptionTests
    {
        [TestMethod]
        public void TestVectorAddition()
        {
            Vector a = new Vector(2);
            Vector b = new Vector(3);

            try
            {
                Vector res = a + b;
            }
            catch (DimensionException ex)
            {
                StringAssert.Contains(ex.Message, Vector.dimensionsAreNotTheSameMessage);
                return;
            }

            Assert.Fail("No exception thrown!");
        }

        [TestMethod]
        public void TestMatrixVectorMultiplication()
        {
            Vector a = new Vector(2);
            Matrix mat = new Matrix(2, 3);

            try
            {
                Vector res = mat * a;
            }
            catch (DimensionException ex)
            {
                StringAssert.Contains(ex.Message, Vector.matrixVectorExceptionMessage);
                return;
            }

            Assert.Fail("No exception thrown!");
        }

        [TestMethod]
        public void TestVectorMatrixMultiplication()
        {
            Vector a = new Vector(3);
            Matrix mat = new Matrix(2, 3);

            try
            {
                Vector res = a * mat;
            }
            catch (DimensionException ex)
            {
                StringAssert.Contains(ex.Message, Vector.vectorMatrixExceptionMessage);
                return;
            }

            Assert.Fail("No exception thrown!");
        }
    }
}
