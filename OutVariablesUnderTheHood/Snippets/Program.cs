using static System.Console;

namespace Snippets
{
    class GettingSingleOutValue
    {
        public bool GetSingleOutValue(out int value)
        {
            value = 0;
            return true;
        }

        public void Before()
        {
            int value;
            GetSingleOutValue(out value);
        }

        public void After()
        {
            GetSingleOutValue(out int value);
        }

        public void AfterWithTypeInference()
        {
            GetSingleOutValue(out var value);
        }

        public void AfterWithIgnore()
        {
            GetSingleOutValue(out _);
        }
    }

    class GettingSeveralOutValues
    {
        public bool GetSeveralOutValues(out int first, out int second)
        {
            first = 0;
            second = 0;
            return true;
        }

        public void IgnoringBothValues()
        {
            GetSeveralOutValues(out _, out _);
        }
    }

    static class WhyNotHavingSinglePlaceholderForIgnoredValuesOfTheSameType
    {
        public static int GetSeveralOutValues(out int first, out int second)
        {
            first = 1;
            second = 2;
            return first + second;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int first, second;
            int result = WhyNotHavingSinglePlaceholderForIgnoredValuesOfTheSameType.GetSeveralOutValues(out first, out second);
            WriteLine(result);
            WriteLine(first);
            WriteLine(second);

            WriteLine("------------------------");

            int outPlaceholder;
            result = WhyNotHavingSinglePlaceholderForIgnoredValuesOfTheSameType.GetSeveralOutValues(out outPlaceholder, out outPlaceholder);
            WriteLine(result);
            WriteLine(outPlaceholder);

            ReadKey();
        }
    }
}
