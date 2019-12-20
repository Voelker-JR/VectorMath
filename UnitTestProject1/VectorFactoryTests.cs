using Microsoft.VisualStudio.TestTools.UnitTesting;
using VectorMath;

namespace VectorMathTests
{
    [TestClass]
    public class VectorFactoryTests
    {
        [TestMethod]
        public void TestFitInMethod()
        {
            Vector a = new Vector(new decimal[] { 1, 2, 3, 4 });
            Vector b = new Vector(new decimal[] { -1, -2, -3, -4 });

            Vector expected = new Vector(new decimal[] { -1, 1, 2, 3 });

            Assert.AreEqual(expected, Vector.Factory.FitIn(b, 1, a));

            expected = new Vector(new decimal[] { 3, 4, -3, -4 });

            Assert.AreEqual(expected, Vector.Factory.FitIn(b, -2, a));

            b = Vector.Factory.FitIn(3, 0, b);

            Assert.AreEqual(b, new Vector(new decimal[] { -1, -2, -3 }));

            expected = new Vector(new decimal[] { 3, 4, -3 });

            Assert.AreEqual(expected, Vector.Factory.FitIn(b, -2, a));
        }

        [TestMethod]
        public void TestRandomMethod()
        {
            Vector v = Vector.Factory.Random(3, -1, 2);

            for (int i = 0; i < v.Dim; i++)
                Assert.IsTrue(-1 <= v[i] && v[i] <= 2);
        }

        [TestMethod]
        public void TestBasisVectorMethod()
        {
            Vector v = Vector.Factory.BasisVector(5, 3);
            Vector expected = new Vector(new decimal[] { 0, 0, 0, 1, 0 });

            Assert.AreEqual(expected, v);
        }

        [TestMethod]
        public void TestFillMethod()
        {
            Vector v = Vector.Factory.Fill(5, -3);
            Vector expected = new Vector(new decimal[] { -3, -3, -3, -3, -3 });

            Assert.AreEqual(expected, v);
        }

        [TestMethod]
        public void TestExtractRowMethod()
        {
            Matrix mat = new Matrix(new decimal[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 }
            });

            Vector expected = new Vector(new decimal[] { 4, 5, 6 });

            Assert.AreEqual(Vector.Factory.ExtractRow(mat, 1), expected);
        }

        [TestMethod]
        public void TestExtractColumnMethod()
        {
            Matrix mat = new Matrix(new decimal[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 }
            });

            Vector expected = new Vector(new decimal[] { 2, 5 });

            Assert.AreEqual(expected, Vector.Factory.ExtractColumn(mat, 1));
        }
    }
}
