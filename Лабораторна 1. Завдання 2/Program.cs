using System.Text.Json;

    class Program
    {
        static void Main(string[] args)
        {
            string jsonpath = @"C:\Users\kokok\OneDrive\Рабочий стол\file.json";
            Dictionary<char, int> d1 = new Dictionary<char, int>()
            {
                ['a'] = 1,
                ['b'] = 2,
                ['c'] = 3
            };
            Dictionary<char, int> d2 = new Dictionary<char, int>()
            {
                ['a'] = 3,
                ['b'] = 2,
                ['d'] = 4
            };
            Dictionary<char, int> d3 = new Dictionary<char, int>();
            foreach (var a in d1)
            {
                foreach (var b in d2)
                {
                if (a.Key == b.Key && !d3.ContainsKey(a.Key)) d3.Add(a.Key, a.Value + b.Value);
                else
                {
                    if (a.Key != b.Key && !d3.ContainsKey(a.Key) && !d2.ContainsKey(a.Key)) d3.Add(a.Key, a.Value);
                    if (a.Key != b.Key && !d3.ContainsKey(b.Key) && !d1.ContainsKey(b.Key)) d3.Add(b.Key, b.Value);
                }
                }
            }
            Console.WriteLine("Результат:");
            foreach (var c in d3)
            {
                Console.WriteLine($"key: {c.Key}  value: {c.Value}");
            }
            string jsontext = JsonSerializer.Serialize(d3);
            File.WriteAllText(jsonpath, jsontext);
            Console.WriteLine();
            Console.WriteLine($"Результат було записано у файл {jsonpath}");
        }
    }