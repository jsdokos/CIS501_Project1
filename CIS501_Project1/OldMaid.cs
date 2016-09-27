using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS501_Project1
{
    class OldMaid
    {
        public CardDeck Deck;
        public List<Player> currentPlayers;
        public int numPlayers;
        public Player[] allPlayers;
        ConsoleTerminal ct = new ConsoleTerminal();

        public void myProgram()
        {
            Deck = new CardDeck();
            
            int computerPlayer = ct.GetInt("Input Number of Computer Players (between 2 and 5) : ", 2, 5);
            numPlayers = computerPlayer + 1;
            allPlayers = new Player[numPlayers];

            HumanPlayer human = new HumanPlayer(numPlayers, "Harambe");
            allPlayers[0] = human;
            human.Deck = Deck;

            for (int i = 1; i < numPlayers - 1; i++)
            {
                ComputerPlayer temp = new ComputerPlayer(numPlayers, "Frank" + i);
                temp.Deck = Deck;
                allPlayers[i] = temp;
            }

            //do the loop
            shufflePlayers();
            for (int i = 0; i < allPlayers.Length; i++) //add players to currets players
            {
                currentPlayers.Add(allPlayers[i]);
            }
            Deck.Shuffle();
            dealCards();
            showAllPlayerHands();

            removeDuplicatesAllPlayers();
            shufflePlayers();
            showAllPlayerHands();

        }

        //Using example code from http://rosettacode.org/wiki/Knuth_shuffle
        private void shufflePlayers()
        {
            Random random = new Random();
            for (int i = 0; i < allPlayers.Length; i++)
            {
                int j = random.Next(i, allPlayers.Length);
                Player temp = allPlayers[i];
                allPlayers[i] = allPlayers[j];
                allPlayers[j] = temp;
            }
        }

        private void dealCards()
        {
            int count = 0;

            while (count < 53)
            {
                foreach (Player play in currentPlayers)
                {
                    if (count != 53)
                        play.Deal(Deck.Draw());
                    count++;
                }
            } 
        }

        private void showAllPlayerHands()
        {
            foreach (Player play in currentPlayers)
            {
                ct.DisplayLine(play.ToString());
            }
        }

        private void removeDuplicatesAllPlayers()
        {
            foreach (Player play in currentPlayers)
            {
                play.DiscardAllPairs();
            }
        }
    }
}
