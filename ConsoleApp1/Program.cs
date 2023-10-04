using System.Xml;
using System;
using Newtonsoft.Json;

namespace program
{
    class Program
    {
        
        
        public static void Main()
        {    
            
            //located within ConsoleApp1\ConsoleApp1\bin\debug\net6.0  
            string json = File.ReadAllText("MOCK_DATA.json"); 
            
            List<TicketSol> tic = JsonConvert.DeserializeObject<List<TicketSol>>(json);

            foreach (var ticket in tic)
            {
                ticket.ID = Guid.NewGuid();
            }
            foreach (var ticket in tic)
            {
                ticket.Total = CalcTotal(ticket.Adult, ticket.Senior, ticket.Child);
            }
            foreach (var ticket in tic)
            {
                Console.WriteLine($"Receipt ID: {ticket.ID}");
                Console.WriteLine($"# of Seniors: {ticket.Senior}, # of Adults: {ticket.Adult}, # of Children: {ticket.Child}");
                Console.WriteLine($"Total Value: ${ticket.Total}, Reduced Value: ${ticket.Coupon}");
            }
        }
        public static double CalcTotal(int adult, int senior, int child)
        {
            const double AdultPrice = 6.25; 
            const double SeniorPrice = 3.25;
            const double ChildPrice = 4.25;

            double totalValue = (adult * AdultPrice) + (senior * SeniorPrice) + (child * ChildPrice);
            return totalValue;
        }
    }
    public class TicketSol
    {
        public Guid ID { get; set; }
        public int Senior { get; set; }
        public int Adult { get; set; }
        public int Child { get; set; }
        public double Total { get; set; } 
    }
      
} 