using System.Text;

namespace LeetcodeQuestions;

public class Solution
{
    public static void Main(string[] args)
    {

        Console.WriteLine("Is 1221 a palindrome number? \n" + IsPalindrome(1221));
        Console.WriteLine("Is 123 a palindrome number? \n" + IsPalindrome(123));
        Console.WriteLine("2 cubed: " + MyPow(2.0, 3));
        Console.WriteLine("2^-3: " + MyPow(2.0, -3));
        int[] array = { 1, 1, 2 };
        Console.WriteLine(RemoveDuplicates(array));
        Console.WriteLine(IsValid("()"));
        Console.ReadLine();

    }

    public static bool IsPalindrome(int x)
    {
        var number = (x + "").ToCharArray();
        bool flag = true;
        for (int i = 0; i < number.Length; i++)
        {
            if (number[i] != number[(number.Length-1 -i )])
            {
                flag = false;
            }
        }
        return flag;
    }

    public static double MyPow(double x, int n)
    {
        double result = 1;
        if (n < 0)
        {
            n = -n;
            x = 1 / x;
        }

        while (n != 0)
        {
            if ((n & 1) != 0)
            {
                result *= x;
            }

            x *= x;
            n = (int)((uint)n >> 1);
        }
        return result;
    }

    public static int RemoveDuplicates(int[] nums)
    {
        int i = 1;

        foreach (int n in nums)
        {
            if (nums[i - 1] != n) nums[i++] = n;
        }

        return i;
    }

    public static string AddBinary(string a, string b)
    {
        var carry = 0;
        var stringbuilder = new StringBuilder();
        for (int i = a.Length - 1, j = b.Length - 1; i >= 0 || j >= 0; i--, j--)
        {
            var x = i >= 0 ? a[i] - '0' : 0;
            var y = j >= 0 ? b[j] - '0' : 0;

            var sum = x + y + carry;
            if (sum > 1)
            {
                stringbuilder.Insert(0, sum % 2);
                carry = 1;
            }
            else
            {
                stringbuilder.Insert(0, sum);
                carry = 0;
            }
        }
        if (carry == 1)
            stringbuilder.Insert(0, '1');
        return stringbuilder.ToString();
    }

    public static bool IsValid(string s)
    {
        var Mystack = new Stack<char>();

        foreach (var its in s)
        {
            if (its == '(' || its == '[' || its == '{')
            {
                Mystack.Push(its);
            }
            else if (its == ')' || its == ']' || its == '}')
            {
                if (Mystack.Count <= 0)
                {
                    return false;
                }
                var check = Mystack.Peek();
                if (its == ')' && check == '(' ||
                 its == ']' && check == '[' ||
                 its == '}' && check == '{')
                {
                    Mystack.Pop();
                }
                else
                {
                    return false;
                }
            }
        }

        var finalResult = Mystack.Count() == 0;
        return finalResult;
    }
}