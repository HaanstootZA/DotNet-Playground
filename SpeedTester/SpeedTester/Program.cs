using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SpeedTester
{
    class Program
    {
        delegate int MyDelegate(string Value, char Char);
        private static char[] Alphabet = new char[26] {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 
                                               'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static int RecurseImp(string Value, char Char, int LastIndex)
        {
            LastIndex = Value.IndexOf(Char, LastIndex);
            if (LastIndex > -1)
                return RecurseImp(Value, Char, LastIndex + 1) + 1;
            else
                return 0;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static int RecurseImp(string Value, char Char)
        {
            return RecurseImp(Value, Char, 0);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static int WhileImp(string Value, char Char)
        {
            int count = 0;
            int i = 0;
            while ((i = Value.IndexOf(Char, i)) > -1)
            {
                count++;
                i++;
            }
            return count;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static int ForImp(string Value, char Char)
        {
            int count = 0;
            for (int i = Value.IndexOf(Char, 0); i > -1; i = Value.IndexOf(Char, i))
            {
                    count++;
                    i++;
            }
            return count;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static int ForEachImp(string Value, char Char)
        {
            int count = 0;
            foreach (char c in Value)
            {
                if (Char.Equals(c))
                    count++;
            }
            return count;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static int RegexImpl(string Value, char Char)
        {
            Regex reg = new Regex(string.Format("[{0}]", Char));
            return reg.Matches(Value).Count;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static int LinqImpl(string Value, char Char)
        {
            IEnumerable<char> ret = from c in Value
                                    where c.Equals(Char)
                                    select c;
            return ret.Count();
        }

        private static string GetValue(ref char Char)
        {
            Random rand = new Random(System.DateTime.Now.Millisecond);
            string name = "";
            int Size = rand.Next(1, 1000);
            for (int i = 0; i < Size; i++)
            {
                int val = rand.Next(26);
                string sVal = string.Format("{0}", Alphabet[val]);
                name += sVal;
            }
            Char = name[rand.Next(name.Length)];
            return name;
        }

        private static TimeSpan MeasureFunction(MyDelegate function, string Value, char Char)
        {
            Stopwatch s1 = new Stopwatch();
            s1.Start();
            int RetInt = function(Value, Char);
            s1.Stop();
            return s1.Elapsed;
        }

        static void PrintLine(string Name, double Total, double Average1, double Average2)
        {
            Console.Out.WriteLine(@"
    {0} Implentation:
    Total Time:     {1} min
    Average Time:   {2} ms
    Average TpC:    {3} ms",
                   Name, Total, Average1, Average2);
        }

        static void Main(string[] args)
        {
            string Value;
            char Find = '\0';
            TimeSpan Recursion = new TimeSpan(0);
            TimeSpan For = new TimeSpan(0);
            //TimeSpan While = new TimeSpan(0);
            //TimeSpan LinQ = new TimeSpan(0);
            //TimeSpan RegEx = new TimeSpan(0);
            //TimeSpan ForEach = new TimeSpan(0);
            int Itterations = 10000000;
            int ValueLengths = 0;

            for (int i = 0; i < Itterations; i++)
            {
                Value = GetValue(ref Find);
                ValueLengths += Value.Length;

                Recursion += MeasureFunction(new MyDelegate(RecurseImp), Value, Find);
                For += MeasureFunction(new MyDelegate(ForImp), Value, Find);
                //LinQ += MeasureFunction(new MyDelegate(LinqImpl), Value, Find);
                //While += MeasureFunction(new MyDelegate(WhileImp), Value, Find);
                //RegEx += MeasureFunction(new MyDelegate(RegexImpl), Value, Find);
                //ForEach += MeasureFunction(new MyDelegate(ForEachImp), Value, Find);
            }
            double Split = ValueLengths * 1.0 / Itterations * 1.0;

            double RecursionSplit = Recursion.TotalMilliseconds / Itterations;
            double ForSplit = For.TotalMilliseconds / Itterations;
            //double LinqSplit = LinQ.TotalMilliseconds / Itterations;
            //double RegexSplit = RegEx.TotalMilliseconds / Itterations;
            //double ForEachSplit = ForEach.TotalMilliseconds / Itterations;
            //double WhileSplit = While.TotalMilliseconds / Itterations;
            Console.Out.WriteLine(@"Statistics:
Itterations:         {0}
Total String Length: {1}
Average Length:      {2}",
                   Itterations, ValueLengths, Split);

            PrintLine("Recursion", Recursion.TotalMinutes, RecursionSplit, RecursionSplit / Split);
            PrintLine("For", For.TotalMinutes, ForSplit, ForSplit / Split);
            //PrintLine("While", While.TotalMinutes, WhileSplit, WhileSplit * 100000 / Split);
            //PrintLine("LINQ", LinQ.TotalMinutes, LinqSplit, LinqSplit * 100000 / Split);
            //PrintLine("RegEx", RegEx.TotalMinutes, RegexSplit, RegexSplit * 100000 / Split);
            //PrintLine("ForEach", ForEach.TotalMinutes, ForEachSplit, ForEachSplit * 100000 / Split);

            Console.Out.WriteLine("Press any key to continue...");
            Console.In.ReadLine();
        }
    }
}