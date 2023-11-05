using System.Collections.Concurrent;

namespace DataStructure;

public class ConcurrentQueueExample
{
    public class IncomingCall
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public DateTime CallTime { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Consultant { get; set; }
    }

    public class CallCenter
    {
        private int _counter = 0;
        public ConcurrentQueue<IncomingCall> Calls { get; private set; }

        public CallCenter()
        {
            Calls = new ConcurrentQueue<IncomingCall>();
        }

        public int Call(int clientId)
        {
            IncomingCall call = new IncomingCall()
            {
                Id = ++_counter,
                ClientId = clientId,
                CallTime = DateTime.Now
            };
            Calls.Enqueue(call);
            return Calls.Count;
        }

        public IncomingCall Answer(string consultant)
        {
            if (Calls.Count > 0 && Calls.TryDequeue(out IncomingCall call))
            {
                call.Consultant = consultant;
                call.StartTime = DateTime.Now;
                return call;
            }

            return null;
        }

        public void End(IncomingCall call)
        {
            call.EndTime = DateTime.Now;
        }

        public bool AreWaitingCalls()
        {
            return Calls.Count > 0;
        }
    }

    public void Example()
    {
        CallCenter center = new CallCenter();
        Parallel.Invoke(() => CallersAction(center),
            () => ConsultantAction(center, "Marcin", ConsoleColor.Red),
            () => ConsultantAction(center, "James", ConsoleColor.Yellow),
            () => ConsultantAction(center, "Olivia", ConsoleColor.Green));
    }

    private static void CallersAction(CallCenter center)
    {
        Random random = new Random();
        while (true)
        {
            int clientId = random.Next(1, 10000);
            int waitingCount = center.Call(clientId);
            Console.WriteLine($"Incoming call from {clientId}, waiting in the queue: {waitingCount}");
            Thread.Sleep(random.Next(1000, 1500));
        }
    }

    private static void ConsultantAction(CallCenter center, string name, ConsoleColor color)
    {
        Random random = new Random();
        while (true)
        {
            IncomingCall call = center.Answer(name);
            if (call != null)
            {
                Console.ForegroundColor = color;
                Console.WriteLine($"Call #{call.Id} from {call.ClientId} is answered by {call.Consultant}.");
                Console.ForegroundColor = ConsoleColor.Gray;
                Thread.Sleep(random.Next(1000, 10000));
                center.End(call);
                Console.ForegroundColor = color;
                Console.WriteLine($"Call #{call.Id} from {call.ClientId} is ended by {call.Consultant}.");
                Console.ForegroundColor = ConsoleColor.Gray;
                Thread.Sleep(random.Next(500, 1000));
            }
            else
            {
                //Thread.Sleep(100);
            }
        }
    }
}