using System;

namespace Task4;

public static class Program
{

    public static bool IsValidTriangle(double a, double b, double c)
    {
        if (a <= 0 || b <= 0 || c <= 0)
        {
            return false;
        }
        return (a + b > c && a + c > b && b + c > a);
    }


    public static double GetPerimeter(double a, double b, double c)
    {
        if (!IsValidTriangle(a, b, c))
        {
            throw new ArgumentException("Вхідні сторони не утворюють дійсний трикутник.");
        }
        return a + b + c;
    }


    public static double GetArea(double a, double b, double c)
    {
        if (!IsValidTriangle(a, b, c))
        {
            throw new ArgumentException("Вхідні сторони не утворюють дійсний трикутник.");
        }

        double s = GetPerimeter(a, b, c) / 2;
        double areaSquared = s * (s - a) * (s - b) * (s - c);

        return Math.Sqrt(areaSquared);
    }


    public static string GetTriangleType(double a, double b, double c)
    {
        if (!IsValidTriangle(a, b, c))
        {
            throw new ArgumentException("Вхідні сторони не утворюють дійсний трикутник.");
        }

        const double tolerance = 1e-9;

        if (Math.Abs(a - b) < tolerance && Math.Abs(b - c) < tolerance)
        {
            return "рівносторонній";
        }

        double a2 = a * a;
        double b2 = b * b;
        double c2 = c * c;

        bool isIsosceles = Math.Abs(a - b) < tolerance || Math.Abs(a - c) < tolerance || Math.Abs(b - c) < tolerance;

        bool isRight = Math.Abs(a2 + b2 - c2) < tolerance ||
                       Math.Abs(a2 + c2 - b2) < tolerance ||
                       Math.Abs(b2 + c2 - a2) < tolerance;

        if (isRight)
        {
            return "прямокутний";
        }

        if (isIsosceles)
        {
            return "рівнобедрений";
        }

        return "довільний";
    }
}