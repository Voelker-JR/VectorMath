using Microsoft.VisualStudio.TestTools.UnitTesting;
using VectorMath;

namespace VectorMathTests
{
    [TestClass]
    public class MatrixFactoryTests
    {
        [TestMethod]
        public void TestFillMethod()
        {
            Matrix mat = Matrix.Factory.Fill(2, 2, 1);

            Matrix expected = new Matrix(new double[,]
            {
                { 1, 1 },
                { 1, 1 }
            });

            Assert.AreEqual(expected, mat);
        }

        [TestMethod]
        public void TestIdentityMethod()
        {
            Matrix mat = Matrix.Factory.Identity(3);

            Matrix expected = new Matrix(new double[,] {
                { 1, 0, 0 },
                { 0, 1, 0 },
                { 0, 0, 1 }
            });

            Assert.AreEqual(expected, mat);
        }

        [TestMethod]
        public void TestRandomMethod()
        {
            Matrix mat = Matrix.Factory.Random(3, 2, -1, 2);

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 2; j++)
                    Assert.IsTrue(-1 <= mat[i, j] && mat[i, j] <= 2);
        }
    }
}
