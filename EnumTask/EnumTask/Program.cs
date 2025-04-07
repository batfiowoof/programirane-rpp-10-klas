using System;

// Enum за типовете билети
enum TicketType
{
    Economy,
    Business,
    FirstClass
}

// Enum за статуса на резервацията
enum ReservationStatus
{
    Pending,
    Confirmed,
    Cancelled
}

// Клас за резервация
class Reservation
{
    public string PassengerName { get; set; }
    public TicketType Ticket { get; set; }
    public ReservationStatus Status { get; set; }

    public Reservation(string name, TicketType ticket)
    {
        PassengerName = name;
        Ticket = ticket;
        Status = ReservationStatus.Pending;
    }

    public override string ToString()
    {
        return $"{PassengerName} - {Ticket} - {Status}";
    }
}

class Program
{
    static Reservation reservation;

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nИзберете опция:");
            Console.WriteLine("1. Създай резервация");
            Console.WriteLine("2. Промени статуса");
            Console.WriteLine("3. Показване на резервацията");
            Console.WriteLine("4. Изход");
            Console.Write("> ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateReservation();
                    break;
                case "2":
                    ChangeReservationStatus();
                    break;
                case "3":
                    ShowReservation();
                    break;
                case "5": 
                    return;
                default:
                    Console.WriteLine("Невалидна опция. Опитайте отново.");
                    break;
            }
        }
    }

    // Създаване на резервация
    static void CreateReservation()
    {
        Console.Write("Въведете име на пътника: ");
        string name = Console.ReadLine();

        Console.Write("Изберете тип билет (Economy, Business, FirstClass): ");
        string ticketInput = Console.ReadLine();

        if (Enum.TryParse(ticketInput, true, out TicketType ticket))
        {
            reservation = new Reservation(name, ticket);
            Console.WriteLine("Резервацията е създадена успешно със статус Pending.");
        }
        else
        {
            Console.WriteLine("Невалиден тип билет!");
        }
    }

    // Промяна на статуса
    static void ChangeReservationStatus()
    {
        if (reservation == null)
        {
            Console.WriteLine("Няма съществуваща резервация!");
            return;
        }

        Console.Write("Изберете нов статус (Pending, Confirmed, Cancelled): ");
        string statusInput = Console.ReadLine();

        if (Enum.TryParse(statusInput, true, out ReservationStatus newStatus))
        {
            reservation.Status = newStatus;
            Console.WriteLine("Статусът е променен успешно.");
        }
        else
        {
            Console.WriteLine("Невалиден статус!");
        }
    }

    // Показване на резервацията
    static void ShowReservation()
    {
        if (reservation == null)
        {
            Console.WriteLine("Няма съществуваща резервация.");
            return;
        }

        Console.WriteLine("\nРезервация:");
        Console.WriteLine(reservation);
    }
}
