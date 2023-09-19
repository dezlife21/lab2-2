using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.IO;
class Ar
{
    private int n;         
    private int[] a;       
    private int s;         

    public int N
    {
        get { return n; }
    }

    public int S
    {
        get { return s; }
    }

    public Ar(int a, int b)
    {
        n = b - a + 1;     
        this.a = new int[n];
        for (int i = 0; i < n; i++)
        {
            this.a[i] = (int)Math.Pow(a + i, 3);
        }
        CalculateSum();
    }

    public Ar(string fileName)
    {
        try
        {
            string[] lines = File.ReadAllText(fileName).Split(':');
            n = lines.Length;
            a = new int[n];

            for (int i = 0; i < n; i++)
            {
                a[i] = int.Parse(lines[i]);
            }

            CalculateSum();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Помилка: " + ex.Message);
        }
    }

    public void Print()
    {
        Console.WriteLine("Масив:");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(a[i]);
        }
    }

    public int P()
    {
        for (int i = n - 1; i >= 0; i--)
        {
            if (a[i] % 2 != 0)
            {
                return i;
            }
        }
        return -1; 
    }

    public int Sum(int i1, int i2)
    {
        int sum = 0;
        for (int i = i1; i <= i2; i++)
        {
            sum += a[i];
        }
        return sum;
    }

    private void CalculateSum()
    {
        s = 0;
        foreach (int num in a)
        {
            if (num < 50)
            {
                s += num;
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введiть номер конструктора (1 або 2): ");
        int r = Convert.ToInt32(Console.ReadLine());
        Ar mas;

        if (r == 1)
        {
            Console.Write("Введiть a: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введiть b: ");
            int b = Convert.ToInt32(Console.ReadLine());
            mas = new Ar(a, b);
        }
        else if (r == 2)
        {
            Console.Write("Введiть iм'я текстового файлу: ");
            string fileName = Console.ReadLine();
            mas = new Ar(fileName);
        }
        else
        {
            Console.WriteLine("Неправильний вибiр конструктора.");
            return;
        }

        mas.Print();

        Console.WriteLine($"Сума елементiв менше 50: {mas.S}");

        int lastIndex = mas.P();
        if (lastIndex != -1)
        {
            Console.WriteLine($"Iндекс останнього непарного елемента: {lastIndex}");
            Console.Write("Введiть i1: ");
            int i1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введiть i2: ");
            int i2 = Convert.ToInt32(Console.ReadLine());
            int sum = mas.Sum(i1, i2);
            Console.WriteLine($"Сума елементiв з iндексами вiд {i1} до {i2}: {sum}");
        }
        else
        {
            Console.WriteLine("Непарних елементiв немає.");
        }

        Console.ReadKey();
 
    }
}