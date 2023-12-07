namespace VectorMath
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vector vector1 = new Vector(5, 12, 1);
            Vector vector2 = new Vector(0, 12, 1);
            Vector resultVector = vector2 - vector1;
            resultVector = resultVector.Normalize();

            Console.WriteLine($"{resultVector.Length()}");
        }
    }
}