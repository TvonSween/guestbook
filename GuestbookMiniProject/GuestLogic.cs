
using System.ComponentModel.Design;

namespace GuestbookMiniProject
{
    public static class GuestLogic
    {
        public static void Welcome()
        {
            Console.WriteLine("Welcome to the party.");
            Console.WriteLine("*********************");
            Console.WriteLine();
        }
        
        public static string GetName() 
        {
            Console.Write("Please sign your group in: ");
            string? name = Console.ReadLine();
            return (name == null) ? "Anonymous" : name;
        }

        public static int GetTotalGuests(string name)
        {
            bool isValidInt;
            int output;
            do
            {
                Console.Write($"{name}, enter the number of people in your party. ");
                string? partyCount = Console.ReadLine();
                isValidInt = int.TryParse(partyCount, out output);
                if (!isValidInt)
                    Console.WriteLine("You need to enter a valid number.");

            } while (isValidInt == false);
            return output;
        }

        public static (List<string>, int guestTotal) GetGuestList()
        {
            int guestTotal = 0;
            List<string> guests = new List<string>();
            string status = "";

            do
            {
                string guestName = GuestLogic.GetName();
                guests.Add(guestName);
                int partyNumber = GuestLogic.GetTotalGuests(guestName);
                guestTotal += partyNumber;
                status = CheckStatus();

            } while (IsPartyOpen(status));

            return (guests, guestTotal);
        }

        public static string CheckStatus()
        {
            Console.Write("Is the party still going on? : ");
            string? status = Console.ReadLine().ToLower();
            return status;
        }

        public static void DisplayGuestList(List<string> guests, int guestTotal)
        {
            Console.WriteLine("**** The Guestlist **** ");
            foreach (string? guest in guests)
            {
                Console.WriteLine(guest);
            }

            Console.WriteLine($"The total amount of guests attending: {guestTotal}");

        }

        public static bool IsPartyOpen(string input)
        {
            bool isOpen;

            if (input == "yes")
                isOpen = true;
            else 
                isOpen = false;

            return isOpen;

        }

    }
}
