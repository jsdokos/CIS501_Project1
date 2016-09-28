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
        ConsoleTerminal console = new ConsoleTerminal();

        public void myProgram()
        {
            Deck = new CardDeck();
            
            int computerPlayer = console.GetInt("Input Number of Computer Players (between 2 and 5) : ", 2, 5);
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
            bool answer = false;

            //do the loop
            do
            {
                shufflePlayers();
                for (int i = 0; i < allPlayers.Length; i++) //add players to currets players
                {
                    currentPlayers.Add(allPlayers[i]);
                }
                console.DisplayLine("++++++++++Shuffling and dealing cards++++++++++");
                Deck.Shuffle();
                dealCards();
                showAllPlayerHands();
                console.userWait();

                console.DisplayLine("XXXXXXXXXXShuffling and dealing cardsXXXXXXXXXX");
                removeDuplicatesAllPlayers();
                shufflePlayers();
                showAllPlayerHands();
                console.userWait();

                //repeat until only one player remains
                answer = keyAlgorithim();
            }
            while (answer);

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
                console.DisplayLine(play.ToString());
            }
        }

        private void removeDuplicatesAllPlayers()
        {
            foreach (Player play in currentPlayers)
            {
                play.DiscardAllPairs();
            }
        }

        private void shuffleAllPlayerHands()
        {
            foreach (Player play in currentPlayers)
            {
                play.Shuffle();
            }
        }

        private bool keyAlgorithim()
        {
            int drawer = 0;
            int drawee = -1000;
            bool playNext = true;

            do
            {
                drawee = (drawer + 1) % currentPlayers.Count;

                if (currentPlayers[drawee].NumCardsInHand == 0)
                {
                    
                }

                //might work
                //if (String.Compare(currentPlayers[drawee].GetType().ToString(), "HumanPlayer") == 0)
                if (currentPlayers[drawer].isHuman && currentPlayers[drawer].NumCardsInHand != 0)
                {
                    console.DisplayLine("%%%%%%%%%%It is now the User's turn%%%%%%%%%%");
                    console.DisplayLine(currentPlayers[drawer].ToString());
                    console.DisplayLine(currentPlayers[drawee].ToString());

                    ComputerPlayer temp = (ComputerPlayer) currentPlayers[drawee];
                    console.DisplayLine(temp.MakeCardIndices()); //there has to be a better way

                    int takenCard = console.GetInt("Pick One Card from Player" + drawee, 0,
                        currentPlayers[drawee].NumCardsInHand);

                    PlayingCard card = currentPlayers[drawee].PickCardAt(takenCard);

                    currentPlayers[drawer].AddCard(card);

                    console.DisplayLine("Player " + currentPlayers[drawer].Name + " picks up Player " + currentPlayers[drawee].Name + "'s Card at [" + takenCard + "], Card: " + card.ToString());
                    console.userWait();
                }
                else if (currentPlayers[drawer].NumCardsInHand != 0)
                {
                    Random r = new Random();
                    int cardToTake = r.Next(currentPlayers[drawee].NumCardsInHand);

                    PlayingCard card = currentPlayers[drawee].PickCardAt(cardToTake);

                    currentPlayers[drawer].AddCard(card);
                    console.DisplayLine("Player " + currentPlayers[drawer].Name + " picks up Player " + currentPlayers[drawee].Name + "'s Card at [" + cardToTake + "], Card: " + card.ToString());
                }

                if (currentPlayers[drawer].NumCardsInHand > 0)
                {
                    while (currentPlayers[drawee].NumCardsInHand <= 0)
                    {
                        drawee++;
                    }

                    if (drawer == drawee)
                    {
                        playNext = false;
                        break;
                    }
                }

                //remove all player who are done
                for (int i = currentPlayers.Count; i != 0; i--)
                {
                    if (currentPlayers[i].NumCardsInHand == 0)
                    {
                        currentPlayers.Remove(currentPlayers[i]);
                        console.DisplayLine("+++++Player " + currentPlayers[0].Name + " has finished playing.+++++");
                    }
                }

                shuffleAllPlayerHands();
                showAllPlayerHands();

                if (currentPlayers.Count <= 1)
                {
                    playNext = false;
                    console.DisplayLine("@@@@@Player " + currentPlayers[0].Name + " is the LOSER.@@@@@");
                    break;
                }

                drawer += 1;
                if (drawer > currentPlayers.Count - 1)
                {
                    drawer = 0; //might work?
                }
            }
            while (playNext);

            char ans = console.getChar("Do you want to play again? (Y/N)", "YN");

            if (ans.Equals('Y'))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
