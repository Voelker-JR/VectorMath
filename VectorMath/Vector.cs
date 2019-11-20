using System;
using System.Collections.Generic;

namespace VectorMath
{
    public class Vector
    {
        public const string dimensionsAreNotTheSameMessage = "The dimensions of the given vectors are not the same:";
        public const string matrixVectorExceptionMessage = "The column dimension and the dimension of the vector are not the same:";
        public const string vectorMatrixExceptionMessage = "The row dimension and the dimension of the vector are not the same:";

        public Vector(int dim)
        {
            Data = new double[dim];

            for (int i = 0; i < dim; i++)
                Data[i] = 0;
        }

        public Vector(Vector v)
        {
            Data = new double[v.Data.Length];

            for (int i = 0; i < Dim; i++)
                Data[i] = v.Data[i];
        }

        public Vector(double[] data)
        {
            Data = data;
        }

        /// <summary>
        /// Contains all values of the vector.
        /// </summary>
        public double[] Data { get; set; }

        public int Dim
        {
            get => Data.Length;
        }

        public double this[int index]
        {
            get => Data[index];
            set => Data[index] = value;
        }

        public static Vector operator +(Vector a, Vector b)
        {
            if (a.Dim != b.Dim)
                throw new DimensionException($"{ dimensionsAreNotTheSameMessage } Lefthand side: { a.Dim }, righthand side: { b.Dim }.");

            Vector result = new Vector(a);

            for (int i = 0; i < a.Dim; i++)
                result[i] += b[i];

            return result;
        }

        public static Vector operator -(Vector a, Vector b)
        {
            if (a.Dim != b.Dim)
                throw new DimensionException($"{ dimensionsAreNotTheSameMessage } Lefthand side: { a.Dim }, righthand side: { b.Dim }.");

            Vector result = new Vector(a);

            for (int i = 0; i < a.Dim; i++)
                result[i] -= b[i];

            return result;
        }

        public static Vector operator -(Vector v)
        {
            Vector result = new Vector(v);

            for (int i = 0; i < v.Dim; i++)
                result[i] = -result[i];

            return result;
        }

        /// <summary>
        /// Defines a product between a vector and a scalar.
        /// </summary>
        public static Vector operator *(Vector v, double lambda)
        {
            Vector result = new Vector(v);

            for (int i = 0; i < v.Dim; i++)
                result[i] *= lambda;

            return result;
        }

        /// <summary>
        /// Defines a product between a scalar and a vector.
        /// </summary>
        public static Vector operator *(double lambda, Vector v)
        {
            Vector result = new Vector(v);

            for (int i = 0; i < v.Dim; i++)
                result[i] *= lambda;

            return result;
        }

        /// <summary>
        /// Defines a scalar product between two vectors.
        /// </summary>
        public static double operator *(Vector a, Vector b)
        {
            if (a.Dim != b.Dim)
                throw new DimensionException($"{ dimensionsAreNotTheSameMessage } Lefthand side: { a.Dim }, righthand side: { b.Dim }.");

            double result = 0;

            for (int i = 0; i < a.Dim; i++)
                result += a[i] * b[i];

            return result;
        }

        /// <summary>
        /// Defines a componentwise product of two vectors.
        /// </summary>
        public static Vector operator ^(Vector a, Vector b)
        {
            if (a.Dim != b.Dim)
                throw new DimensionException($"{ dimensionsAreNotTheSameMessage } Lefthand side: { a.Dim }, righthand side: { b.Dim }.");

            Vector result = new Vector(a);

            for (int i = 0; i < a.Dim; i++)
                result[i] *= b[i];

            return result;
        }

        /// <summary>
        /// Defines a dyadic product between two vectors.
        /// </summary>
        public static Matrix operator |(Vector a, Vector b)
        {
            if (a.Dim == 0 || b.Dim == 0)
                return new Matrix(0, 0);

            Matrix result = new Matrix(a.Dim, b.Dim);

            for (int i = 0; i < a.Dim; i++)
                for (int j = 0; j < b.Dim; j++)
                    result[i, j] = a[i] * b[j];

            return result;
        }

        /// <summary>
        /// Defines a matrix-vector product (mat * v).
        /// </summary>
        public static Vector operator *(Matrix mat, Vector v)
        {
            if (mat.Columns != v.Dim)
                throw new DimensionException($"{ matrixVectorExceptionMessage } Columns: { mat.Columns }, dimension: { v.Dim }.");

            Vector result = new Vector(mat.Rows);

            for (int i = 0; i < mat.Rows; i++)
            {
                result[i] = 0;

                for (int j = 0; j < mat.Columns; j++)
                    result[i] += mat[i, j] * v[j];
            }

            return result;
        }

        /// <summary>
        /// Defines a vector-matrix product (v^T * mat).
        /// </summary>
        public static Vector operator *(Vector v, Matrix mat)
        {
            if (mat.Rows != v.Dim)
                throw new DimensionException($"{ vectorMatrixExceptionMessage } Rows: { mat.Rows }, dimension: { v.Dim }.");

            Vector result = new Vector(mat.Columns);

            for (int j = 0; j < mat.Columns; j++)
            {
                result[j] = 0;

                for (int i = 0; i < mat.Rows; i++)
                    result[j] += mat[i, j] * v[i];
            }

            return result;
        }

        public Vector Apply(AppliableFunction function)
        {
            Vector result = new Vector(this);

            for (int i = 0; i < result.Dim; i++)
                result[i] = function(result[i]);

            return result;
        }

        public override bool Equals(object o)
        {
            if (!(o is Vector)) return false;

            Vector v = o as Vector;

            if (Dim != v.Dim) return false;

            for (int i = 0; i < Dim; i++)
                if (Math.Abs(Data[i] - v[i]) > Constants.Eps)
                    return false;

            return true;
        }

        public override int GetHashCode()
        {
            var hashCode = 594937702;
            hashCode = hashCode * -1521134295 + EqualityComparer<double[]>.Default.GetHashCode(Data);
            hashCode = hashCode * -1521134295 + Dim.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            string result = "[";

            for (int i = 0; i < Dim; i++)
            {
                result += Data[i];

                if (i < Dim - 1)
                    result += ", ";
                else
                    result += "]";
            }

            return result;
        }
    }
}