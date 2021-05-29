using System;

namespace SendEmail
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("input email address: ");
            string email = Console.ReadLine();
            Console.Write("password: ");
            string emailPass = GetPassword();
            Console.Write("\nto: ");
            string to = Console.ReadLine();
            Console.Write("subject: ");
            string subject = Console.ReadLine();
            Console.Write("message: ");
            string message = Console.ReadLine();
            if (EmailSender.SendEmail(email, emailPass, to, subject, message))
            {
                Console.WriteLine("Send email complete!");
            }
            else
            {
                Console.WriteLine("Send email error!");
            }
        }
        static string GetPassword()
        {
            var pass = string.Empty;
            ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && pass.Length > 0)
                {
                    Console.Write("\b \b");
                    pass = pass[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    pass += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);
            return pass;
        }
    }
}
