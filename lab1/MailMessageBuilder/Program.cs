using MailMessageBuilder;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введіть відправника:");
        string from = Console.ReadLine();

        Console.WriteLine("Введіть отримувача:");
        string to = Console.ReadLine();

        Console.WriteLine("Введіть заголовок:");
        string subject = Console.ReadLine();

        Console.WriteLine("Введіть текст повідомлення:");
        string body = Console.ReadLine();

        Builder builder = new MailMessageConcreteBuilder();
        Director director = new Director();

        MailMessage message = director.Construct(
            builder,
            from,
            to,
            subject,
            body);

        Console.WriteLine("\nСтворений лист:");
        message.Show();

        Console.ReadKey();
    }
}