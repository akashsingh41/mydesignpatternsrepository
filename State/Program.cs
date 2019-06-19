using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    public interface State
    {
        void ExecuteCommand(Player player);
    }
    public class Player
    {
        State presentState;
        public Player()
        {
            this.presentState = new HealthyState();
        }

        public void Bullethit(int bullets)
        {
            Console.WriteLine("Bullets hits to the player: " + bullets);
            if (bullets < 5)
                this.presentState = new HealthyState();
            if (bullets >= 5 && bullets < 10)
                this.presentState = new HurtState();
            if (bullets >= 10)
                this.presentState = new DeadState();

            presentState.ExecuteCommand(this);
        }
    }

    public class HealthyState : State
    {
        public void ExecuteCommand(Player player)
        {
            Console.WriteLine("The player is in Healthy State.");
        }
    }

    public class HurtState : State
    {
        public void ExecuteCommand(Player player)
        {
            Console.WriteLine("The player is wounded. Please search health points");
        }
    }
    
    public class DeadState : State
    {
        public void ExecuteCommand(Player player)
        {
            Console.WriteLine("The player is dead. Game Over.");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            player.Bullethit(3);
            player.Bullethit(9);
            player.Bullethit(12);

            Console.ReadLine();
        }
    }
}
