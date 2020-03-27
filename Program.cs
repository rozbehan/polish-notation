using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
1. It seems we are only asked to summarize the numerical expressions. 
2. For example, we could summarize operations with zero and one, but the problem has not asked. 
3. We start from the end of the expression and copy the segments to the destination list, reversely. 
4. We calculate the sub-expression by facing a sequence of "n numbers followed by m operators" using stack, 
Then, we add the result to the destination list and continue. 
5. At the end, the result is the reverse of the destination list.
 */

namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> s = new List<string>();
            string line;
            while ((line = Console.ReadLine()) != null)
            {
                if (line.Length == 0) break;
                s.Add(line);
            }
            List<List<string>> l = new List<List<string>>();
            for (int i=0; i<s.Count; i++)
            {
                l.Add(new List<string>(s[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList<string>()));
            }
            List<string> o = new List<string>();
            for (int i = 0; i < s.Count; i++)
            {
                o.Add(Simplifier(l[i]));
                Console.WriteLine($"Case {i+1}: {o[i]}");
            }

            //Console.ReadLine();
        }
        static string Simplifier(List<string> l)
        {
            List<string> s = new List<string>();
            int o;
            int i = l.Count - 1;
            while (i>=0)
            {
                if (!int.TryParse(l[i], out o))
                {
                    s.Add(l[i]);
                    i--;
                }
                else
                {
                    int n = 0;
                    Stack<int> stack1 = new Stack<int>(IfNumber(l, i, out n));
                    if (stack1.Count > 0)
                    {
                        for (int k = 0; k < stack1.Count; k++)
                            s.Add("0");
                        for (int k = stack1.Count; k > 0 ; k--)
                            s[s.Count - k] = stack1.Pop().ToString();
                    }
                    i = i - n;
                }
            }
            return String.Join(" ", s.Reverse<string>());
            // - a b * + 9 2 x

        }
        static Stack<int> IfNumber(List<string> l, int i, out int n)
        {
            n = 0;
            int o, m;
            int j = i;
            string s = "";
            Stack<int> stack1 = new Stack<int>();
            while (j >= 0)
            {
                if (int.TryParse(l[j], out o))
                {
                    stack1.Push(o);
                    n++;
                }
                else
                {
                    if (!Char.IsLetter(l[j], 0))
                    {
                        if (stack1.Count == 1)
                        {
                            break;
                        }
                        else
                        {
                            int n1 = stack1.Pop();
                            int n2 = stack1.Pop();
                            switch (l[j])
                            {
                                case "+":
                                    n1 = n1 + n2;
                                    break;
                                case "-":
                                    n1 = n1 - n2;
                                    break;
                                case "*":
                                    n1 = n1 * n2;
                                    break;
                            }
                            stack1.Push(n1);
                            n++;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                j--;
            }
            return stack1;
        }
    }
}
