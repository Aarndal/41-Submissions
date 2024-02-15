namespace VectorMath
{
    internal class Program
    {
        static void Main()
        {
            Vector vector1 = new(1, 0, 1);
            Vector vector2 = new(0, 1, 1);

            "Vector 1".WriteLine();
            PrintVector(vector1);
            "\nVector 2".WriteLine();
            PrintVector(vector2);

            "\nVector 1 + Vector 2 =".WriteLine();
            PrintVector(vector1 + vector2);

            Vector diffVector = vector2 - vector1;
            "\nVector 2 - Vector 1 =".WriteLine();
            PrintVector(diffVector);

            float scalar = 5.5f;
            "\nVector 1 * 5,5 =".WriteLine();
            PrintVector(vector1 * scalar);

            "\nSqared Length of Vector 1 = ".Write();
            $"{vector1.SqrLength}".WriteLine();

            "\nLength of Vector 1 = ".Write();
            $"{vector1.Length}".WriteLine();

            "\nDistance between Vector 1 and Vector 2".WriteLine();
            $"Non-static: {Vector.GetDistanceBetween(vector1, vector2)}".WriteLine();
            $"Static: {vector1.GetDistanceTo(vector2)}".WriteLine();

            "\nLength of Differece Vector (Vector 2 - Vector 1) = ".Write();
            $"{diffVector.Length}".WriteLine();

            Console.ReadKey();
        }

        private static void PrintVector(Vector _vector)
        {
            $"| {_vector.X} |".WriteLine();
            $"| {_vector.Y} |".WriteLine();
            $"| {_vector.Z} |".WriteLine();
        }
    }
}