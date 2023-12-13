namespace VectorMath
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vector vector1 = new Vector(1, 0);
            Vector vector2 = new Vector(-1, 12);
            float angle = Vector.GetAngle(vector1, vector2);


            Console.WriteLine($"{angle}");
        }
    }
}