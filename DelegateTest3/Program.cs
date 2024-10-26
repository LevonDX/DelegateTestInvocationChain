namespace DelegateTest3
{
    internal class Program
    {
        delegate string StringDelegate(ref string str);

        public static string ToUpper(ref string str)
        {
            str = str.ToUpper();
            return str;
        }

        public static string Reverse(ref string str)
        {
            str = new string(str.Reverse().ToArray());

            return str;
        }

        public static string Display(ref string str)
        {
            Console.WriteLine(str);
            return str;
        }

        static void Main(string[] args)
        {
            //StringDelegate? stringDelegate = ToUpper;

            //stringDelegate = Delegate.Combine(stringDelegate, new StringDelegate(Reverse))
            //    as StringDelegate; // creates chain of delegates

            //stringDelegate = Delegate.Combine(stringDelegate, new StringDelegate(Display))
            //    as StringDelegate;

            //string str = "Hello World!";

            //str = stringDelegate.Invoke(ref str);

            StringDelegate stringDelegate = ToUpper;
            stringDelegate += Reverse;
            stringDelegate += Display;

            stringDelegate -= Reverse; // StringDelegate? stringDelegate = Delegate.Remove(stringDelegate, new StringDelegate(Reverse)) as StringDelegate;

            string str = "Hello World!";
            stringDelegate(ref str);
        }
    }
}