using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp71
{
    class Bet
    {
        public Bet(int amount)
        {
            Amount = amount;
        }
        public int Amount { get; set; }
        public virtual bool IsWinningBet(int diceRoll)
        {
            return false;
        }
        public virtual int PayOut()
        {
            return Amount * 2;
        }
    }
    class NumberBet : Bet
    {
        public NumberBet(int amount, int number) : base(amount)
        {
            Number = number;
        }
        public int Number { get; set; }
        public override bool IsWinningBet(int diceRoll)
        {
            if (diceRoll == Number)
            {
                return true;
            }
            return false;
        }
        public override int PayOut()
        {
            return Amount * 6;
        }
    }
    class OddBet : Bet
    {
        public OddBet(int amount) : base(amount)
        {
        }
        public override bool IsWinningBet(int diceRoll)
        {
            if (diceRoll % 2 == 1)
            {
                return true;
            }
            return false;
        }
        public override int PayOut()
        {
            return base.PayOut();
        }
    }
    class EvenBet : Bet
    {
        public EvenBet(int amount) : base(amount)
        {
        }
        public override bool IsWinningBet(int diceRoll)
        {
            if (diceRoll % 2 == 0)
            {
                return true;
            }
            return false;
        }
        public override int PayOut()
        {
            return base.PayOut();
        }
    }
    class Casino
    {
        public int playerBalance;
        public Casino(int initalBalance)
        {
            playerBalance = initalBalance;
        }
        public void PlaceBet(Bet bet)
        {
            if (bet.Amount > playerBalance)
            {
                Console.WriteLine("there is no sufficient balance.");
            }
            else
            {
                playerBalance -= bet.Amount;
            }
            Random random = new Random();
            int randomNumber = random.Next(1, 7);
            if (bet.IsWinningBet(randomNumber))
            {
                playerBalance += bet.PayOut();
                Console.WriteLine(playerBalance);
            }
        }
    }
   

    internal class Program
    {
        static void Main(string[] args)
        {
            Bet bet = new Bet(1000);
            Casino casino = new Casino(2000);
            Console.WriteLine("Choose game.");
            int n = Convert.ToInt32(Console.ReadLine());
            if (n == 1)
            {
                NumberBet numberBet = new NumberBet(1000, 4);
            }
            else if (n == 2)
            {
                OddBet oddBet = new OddBet(1500);
            }
            else if (n == 3)
            {
                EvenBet evenBet = new EvenBet(1500);
            }
            else
            {
                Console.WriteLine("Game does not exist");
            }
        }
    }
}
