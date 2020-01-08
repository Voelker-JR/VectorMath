using System.Collections.Generic;
using System;

namespace VectorMath
{
    public class Matrix
    {
        public const string rowDimensionsAreNotTheSame = "The row dimensions of the matrices are not the same:";
        public const string columnDimensionsAreNotTheSame = "The column dimensions of the matrices are not the same:";
        public const string columnRowDimensionsAreNotTheSame = "The column dimension of the left matrix and the row dimension of the right matrix are not the same:";

        public Matrix(int rows, int columns)
        {
            Data = new double[rows, columns];

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                    Data[i, j] = 0;
        }

        public Matrix(Matrix mat)
        {
            Data = new double[mat.Rows, mat.Columns];

            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Columns; j++)
                    Data[i, j] = mat[i, j];
        }

        public Matrix(double[,] data)
        {
            Data = data;
        }

        public double this[int row, int column]
        {
            get => Data[row, column];
            set => Data[row, column] = value;
        }

        public double[,] Data { get; set; }

        public int Rows { get => Data.GetLength(0); }

        public int Columns { get => Data.GetLength(1); }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.Rows != b.Rows)
                throw new DimensionException($"{ rowDimensionsAreNotTheSame } Lefthand side: { a.Rows }, righthand side { b.Rows }.");
            if (a.Columns != b.Columns)
                throw new DimensionException($"{ columnDimensionsAreNotTheSame } Lefthand side: { a.Columns }, righthand side { b.Columns }.");

            Matrix result = new Matrix(a);

            for (int i = 0; i < a.Rows; i++)
                for (int j = 0; j < a.Columns; j++)
                    result[i, j] += b[i, j];

            return result;
        }

        public static Matrix operator -(Matrix a, Matrix b)
        {
            if (a.Rows != b.Rows)
                throw new DimensionException($"{ rowDimensionsAreNotTheSame } Lefthand side: { a.Rows }, righthand side { b.Rows }.");
            if (a.Columns != b.Columns)
                throw new DimensionException($"{ columnDimensionsAreNotTheSame } Lefthand side: { a.Columns }, righthand side { b.Columns }.");

            Matrix result = new Matrix(a);

            for (int i = 0; i < a.Rows; i++)
                for (int j = 0; j < a.Columns; j++)
                    result[i, j] -= b[i, j];

            return result;
        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.Columns != b.Rows)
                throw new DimensionException($"{ columnRowDimensionsAreNotTheSame } Columns: { a.Columns }, rows: { b.Rows }.");

            Matrix result = new Matrix(a.Rows, b.Columns);

            for (int i = 0; i < a.Rows; i++)
                for (int j = 0; j < b.Columns; j++)
                {
                    result[i, j] = 0;

                    for (int k = 0; k < a.Columns; k++)
                        result[i, j] += a[i, k] * b[k, j];
                }

            return result;
        }

        public static Matrix operator -(Matrix mat)
        {
            Matrix result = new Matrix(mat);

            for (int i = 0; i < mat.Rows; i++)
                for (int j = 0; j < mat.Columns; j++)
                    result[i, j] = -result[i, j];

            return result;
        }

        public static Matrix operator *(Matrix mat, double lambda)
        {
            Matrix result = new Matrix(mat);

            for (int i = 0; i < mat.Rows; i++)
                for (int j = 0; j < mat.Columns; j++)
                    result[i, j] *= lambda;

            return result;
        }

        public static Matrix operator *(double lambda, Matrix mat)
        {
            Matrix result = new Matrix(mat);

            for (int i = 0; i < mat.Rows; i++)
                for (int j = 0; j < mat.Columns; j++)
                    result[i, j] *= lambda;

            return result;
        }

        public static Matrix operator /(Matrix mat, double lambda)
        {
            Matrix result = new Matrix(mat);

            for (int i = 0; i < mat.Rows; i++)
                for (int j = 0; j < mat.Columns; j++)
                    result[i, j] /= lambda;

            return result;
        }

        public static Matrix operator ^(Matrix a, Matrix b)
        {
            if (a.Rows != b.Rows)
                throw new DimensionException($"{ rowDimensionsAreNotTheSame } Lefthand side: { a.Rows }, righthand side { b.Rows }.");
            if (a.Columns != b.Columns)
                throw new DimensionException($"{ columnDimensionsAreNotTheSame } Lefthand side: { a.Columns }, righthand side { b.Columns }.");

            Matrix result = new Matrix(a);

            for (int i = 0; i < a.Rows; i++)
                for (int j = 0; j < a.Columns; j++)
                    result[i, j] *= b[i, j];

            return result;
        }

        public Matrix Transposed()
        {
            Matrix result = new Matrix(Columns, Rows);

            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Columns; j++)
                    result[j, i] = Data[i, j];

            return result;
        }

        public Matrix Apply(AppliableFunction function)
        {
            Matrix result = new Matrix(this);

            for (int i = 0; i < result.Rows; i++)
                for (int j = 0; j < result.Columns; j++)
                    result[i, j] = function(result[i, j]);

            return result;
        }

        public override bool Equals(object o)
        {
            if (!(o is Matrix)) return false;

            Matrix m = o as Matrix;

            for (int i = 0; i < m.Rows; i++)
                for (int j = 0; j < m.Columns; j++)
                    if (Math.Abs(Data[i, j] - m[i, j]) > Constants.Eps)
                        return false;

            return true;
        }

        public override int GetHashCode()
        {
            var hashCode = 328679401;
            hashCode = hashCode * -1521134295 + EqualityComparer<double[,]>.Default.GetHashCode(Data);
            hashCode = hashCode * -1521134295 + Rows.GetHashCode();
            hashCode = hashCode * -1521134295 + Columns.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            string result = "";

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                    result += Data[i, j] + " ";

                result += "\n";
            }

            return result;
        }


        public static class Factory
        {
            public static Matrix Fill(int rows, int columns, double value)
            {
                Matrix result = new Matrix(rows, columns);

                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < columns; j++)
                        result[i, j] = value;

                return result;
            }

            public static Matrix Random(int rows, int columns, double minValue, double maxValue)
            {
                Matrix result = new Matrix(rows, columns);
                Random random = new Random();

                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < columns; j++)
                        result[i, j] = random.NextDouble() * (maxValue - minValue) + minValue;

                return result;
            }

            public static Matrix Identity(int size)
            {
                Matrix result = new Matrix(size, size);

                for (int i = 0; i < size; i++)
                    result[i, i] = 1;

                return result;
            }
        }
    }
}