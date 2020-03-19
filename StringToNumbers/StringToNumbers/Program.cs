namespace StringToNumbers
{
    class Program
    {
        static private ulong ConvertString(string Value)
        {
            ulong ret = 0;
            Value = Value.ToUpper().Replace(" ", "");
            foreach (char c in Value)
            {
                int temp = c;
                while (temp > 0)
                {
                    ret = ret * 10;
                    temp = temp / 10;
                }
                ret += c;
            }
            return ret;
        }

        static void Main(string[] args)
        {
            System.Console.Out.WriteLine("Insert string to convert");
            string value = System.Console.In.ReadLine();
            System.Console.Out.WriteLine("The converted string is:");
            System.Console.Out.WriteLine(ConvertString(value));
            System.Console.Out.WriteLine("Press any key to continue...");
            System.Console.In.Read();
        }
    }
}
