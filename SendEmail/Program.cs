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
            string emailPass = Console.ReadLine();
            Console.Write("to: ");
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
    }
}
