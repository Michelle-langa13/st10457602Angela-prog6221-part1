using System;
using System.Speech.Synthesis;

class Program
{
    static Random rand = new Random();
    static SpeechSynthesizer synth = new SpeechSynthesizer();

    static void Main()
    {
        Console.Title = "Cybersecurity Awareness Bot";
        DisplayHeader();

        string name = GetUserName();
        DisplayWelcome(name);

        RunChatBot(name);
    }

    // ===============================
    // HEADER SECTION
    // ===============================
    static void DisplayHeader()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("=====================================================");
        Console.WriteLine("            CYBERSECURITY AWARENESS BOT              ");
        Console.WriteLine("=====================================================");
        Console.WriteLine("                  [ SAFE ONLINE BOT ]                ");
        Console.WriteLine("                     /-----------\\");
        Console.WriteLine("                    |   0     0   |");
        Console.WriteLine("                    |      ^      |");
        Console.WriteLine("                    |     ---     |");
        Console.WriteLine("                     \\___________/");
        Console.WriteLine("=====================================================");
        Console.ResetColor();

        // Voice introduction
        synth.Speak("Hello! I am your Cybersecurity Awareness Bot. Let's learn how to stay safe online.");
    }

    // ===============================
    // GET USER NAME
    // ===============================
    static string GetUserName()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("\n➤ Enter your name: ");
        Console.ResetColor();

        string name = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(name))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("⚠ Name cannot be empty. Try again: ");
            Console.ResetColor();
            name = Console.ReadLine();
        }

        return name;
    }

    // ===============================
    // WELCOME MESSAGE
    // ===============================
    static void DisplayWelcome(string name)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n✔ Welcome, {name}!");
        Console.ResetColor();

        // Voice greeting
        synth.Speak($"Welcome {name}! I am here to help you with cybersecurity awareness.");

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\n---------------- AVAILABLE TOPICS ----------------");
        Console.WriteLine("• Password Safety");
        Console.WriteLine("• Phishing");
        Console.WriteLine("• Safe Browsing");
        Console.WriteLine("• General Questions");
        Console.WriteLine("Type 'exit' to quit.");
        Console.WriteLine("--------------------------------------------------");
        Console.ResetColor();
    }

    // ===============================
    // MAIN CHAT LOOP
    // ===============================
    static void RunChatBot(string name)
    {
        string[] passwordResponses =
        {
            "Use passwords longer than 12 characters with letters, numbers, symbols, Including a mix of upper and " +
            "lowercase letters, numbers, and special characters.",
            "Never reuse passwords across multiple accounts.",
            "Avoid personal information like birthdays in passwords.",
            "Use a password manager for better security."
        };

        string[] phishingResponses =
        {
            "Phishing is when attackers trick you into revealing personal information.",
            "Check the sender’s email carefully before clicking links.",
            "Be cautious of urgent messages requesting sensitive information.",
            "Never download attachments from unknown sources."
        };

        string[] browsingResponses =
        {
            "Always check for HTTPS and a padlock icon.",
            "Avoid downloading files from suspicious websites.",
            "Keep your browser and antivirus updated.",
            "Do not enter personal data on unknown sites."
        };

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\n➤ Ask a question: ");
            Console.ResetColor();

            string question = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(question))
            {
                ShowError("Please enter a question.");
                continue;
            }

            question = question.ToLower();
            ShowDivider();

            // ===== EXIT =====
            if (question == "exit")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"👋 Goodbye {name}! Stay safe online.");
                Console.ResetColor();
                synth.Speak($"Goodbye {name}! Stay safe online.");
                break;
            }

            // ===== SPECIFIC QUESTIONS FIRST =====
            else if (question.Contains("create") && question.Contains("strong password"))
                Respond("A strong password should contain at least 12 characters including letters, numbers, and symbols. \"MyDogIs123!\" is much stronger than \"dog123.\" " +
                    "A password that's both long and diverse in its characters increases the number of possible combinations exponentially, " +
                    "making it harder for someone to break into your accounts.");

            else if (question.Contains("why") && question.Contains("password"))
                Respond("Password safety prevents hackers from accessing your personal accounts to make it significantly harder for attackers to " +
                    "crack them using brute force methods, where every possible combination is attempted..");

            else if (question.Contains("same password"))
                Respond("Each account should have a unique password to reduce risk, increases the complexity of your password" +
                    ",making it much more difficult for hackers to guess..Reusing the same password for multiple accounts can create a serious security risk. " +
                    "If one of your accounts is compromised (for example, through a data breach or phishing attack), " +
                    "a hacker can use that password to try and access your other accounts");

            else if (question.Contains("how often") && question.Contains("password"))
                Respond("Change important passwords if you suspect suspicious activity. For sensitive accounts (like banking, email, or work-related accounts)" +
                    ", it's a good idea to change your passwords every 3 to 6 months.");

            else if (question.Contains("recognize") && question.Contains("phishing"))
                Respond("Phishing emails often contain urgent language, spelling errors, and suspicious links. Phishing emails often use generic greetings like “Dear Customer” or " +
                    "“Dear User,” rather than addressing you by name. Real companies with whom you have accounts will usually address you by your full name or " +
                    "the name you registered with.");

            else if (question.Contains("why") && question.Contains("phishing"))
                Respond("Phishing attacks are relatively easy to execute compared to other types of cybercrime. " +
                    "Attackers don’t need to be technical experts or have sophisticated hacking tools to send phishing emails or create fake websites.");

            else if (question.Contains("avoid") && question.Contains("phishing"))
                Respond("The first rule of avoiding phishing is to question any unsolicited communication—whether it’s an email" +
                    ",text message, or phone call. Phishing attempts often come from seemingly legitimate sources that you weren’t expecting to hear from.");

            else if (question.Contains("public wifi") || question.Contains("public wi-fi"))
                Respond("Using public Wi-Fi (like in coffee shops, airports, or hotels) can be risky for your online security and privacy" +
                    ",especially if you're not careful. Cybercriminals often exploit public networks to steal data or infect devices with malware..");

            else if (question.Contains("how are you"))
                Respond("I don’t really have feelings like humans do, but I'm functioning perfectly and ready to help you stay secure!");

            else if (question.Contains("purpose"))
                Respond("to equip individuals, organizations, and even entire communities with the knowledge and skills needed to recognize and protect against cyber threats. " +
                    "In a world where cyber attacks are increasingly sophisticated and frequent, awareness is the first line of defense..");

            else if (question.Contains("how can i help"))
                Respond("You can help by practicing safe online habits and educating others.");

            // ===== GENERAL TOPIC RESPONSES =====
            else if (question.Contains("password"))
                Respond(passwordResponses[rand.Next(passwordResponses.Length)]);

            else if (question.Contains("phishing"))
                Respond(phishingResponses[rand.Next(phishingResponses.Length)]);

            else if (question.Contains("brows"))
                Respond(browsingResponses[rand.Next(browsingResponses.Length)]);

            // ===== DEFAULT =====
            else
                ShowError("I did not understand that. Could you rephrase?");

            ShowDivider();
        }
    }

    // ===============================
    // HELPER METHODS
    // ===============================
    static void Respond(string message)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("🤖 " + message);
        Console.ResetColor();

        // Voice response
        synth.Speak(message);
    }

    static void ShowError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("⚠ " + message);
        Console.ResetColor();

        // Voice error
        synth.Speak(message);
    }

    static void ShowDivider()
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("==================================================");
        Console.ResetColor();
    }
}
