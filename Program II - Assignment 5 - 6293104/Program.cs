using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;
using System.Runtime.Intrinsics.X86;
using System.Security.Claims;
using System.Runtime.InteropServices;
using System;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Program_II___Assignment_5___6293104
{
    // Algoritrm : 


    // Goal: Use flowcharts or text to describe the overall logic of the program, including:
    // Key requirements: Interactions between card class, deck class, player hand class, and game status class.
    // Functional decomposition: Split tasks into independent modules(such as initializing decks, dealing cards, shuffling cards, etc.).
    // Function reuse: Mark which methods will be called repeatedly(such as Shuffle(), ToString()).
    // Example(text description) :
    // Initialize the game:
    // The user chooses whether to include the big and small jokers → Create a deck(Deck class).
    // Set the suit priority(such as ♥ > ♦ > ♣ > ♠).
    // Dealing logic:
    // Draw a card from the top of the deck → Add it to the player's hand.
    // If the deck is insufficient, reshuffle the cards in the discard pile into the deck.
    // Display game status:
    //Call GameState.ToString() to output the player's hand, remaining cards, and discard pile in the format.


    // Structure : 
    /* Main 
     * - Display Welcome Header
     * - Initialize Game components
     *      - Card Class
     *      - Deck Class
     *      - Hand Class
     *      - GameState Class
     * - Main Menu
     *      - SetUp the game
     *      - Deal Hands
     *      - Display GameBoard
     *      - Quit
     * - Clean & Exit
     * 
     */

    //public class Card
    //{
    //    public string Suit { get; set; }
    //    public string Value { get; set; }

    //    public Card(string value, string suit)
    //    {
    //        Value = value;
    //        Suit = suit;
    //    }

    //    public override string ToString()
    //    {
    //        return $"{Value} of {Suit}";
    //    }
    //}

    //Pseudocode : 

    //    CLASS Card
    //PROPERTIES:
    //    String value
    //    String suit

    //METHOD Constructor(value, suit)
    //    SET this.value = value
    //    SET this.suit = suit

    //METHOD ToString()
    //    RETURN value + " of " + suit

    //    CLASS Deck
    //PROPERTIES:
    //    List of Card cards
    //    Array suits = ["Hearts", "Diamonds", "Clubs", "Spades"]
    //    Array values = ["2", "3", ..., "Ace"]

    //METHOD Constructor()
    //    CALL GenerateDeck()

    //METHOD GenerateDeck()
    //    CLEAR cards
    //    FOR each suit IN suits
    //        FOR each value IN values
    //            ADD new Card(value, suit) to cards

    //METHOD Shuffle()
    //    FOR i from cards.Count - 1 DOWNTO 1
    //        randomIndex = random number between 0 and i
    //        SWAP cards[i] and cards[randomIndex]

    //METHOD DrawCard()
    //    IF cards is not empty
    //        REMOVE and RETURN first card
    //    ELSE
    //        RETURN null

    //METHOD DisplayDeck()
    //    FOR each card in cards
    //        PRINT card.ToString()

    //    CLASS Hand
    //PROPERTIES:
    //    List of Card cards

    //METHOD Constructor()
    //    INITIALIZE cards as empty list

    //METHOD AddCard(Card card)
    //    IF card IS NOT null
    //        ADD card to cards

    //METHOD DisplayHand()
    //    FOR each card in cards
    //        PRINT card.ToString()

    public class Card
    {
        private string rank;
        private string suit;
        private string color;

        public string Rank => rank;
        public string Suit => suit;
        public string Color => color;

        public Card(string rank, string suit)
        {
            this.Rank = rank;
            this.Suit = suit.ToLower();

            if (this.suit == "hearts" || this.suit == "diamonds")
            {
                this.color = "Red";
            }
            else if (this.suit == "clubs" || this.suit == "spades")
            {
                this.color = "Black";
            }
            else
            {
                this.color = "None";
            }
        }

        public Card(string color)
        {
            this.rank = "Joker";
            this.suit = null;
            this.color = color;
        }

        public Card(int id)
        {
            if (id == 53)
            {
                this.rank = "Joker";
                this.suit = null;
                this.color = "Red";
            }
            else if (id == 54)
            {
                this.rank = "Joker";
                this.suit = null;
                this.color = "Black";
            }
            else
            {
                string[] suits = { "hearts", "diamonds", "clubs", "spades" };
                string[] ranks = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10". "Jack", "Queen", "King" };

                int suit_Index = (id - 1) / 13;
                int rank_Index = (id - 1) % 13;

                this.rank = suits[suit_Index];
                this.rank = ranks[rank_Index];

                if (this.suit == "hearts" || this.suit == "diamonds")
                {
                    this.color = "Red";
                }
                else
                {
                    this.color = "Black";
                }
            }
        }

        public override string ToString()
        {
            if (rank == "Joker")
            {
                return color == "Red" ? "RJ" : "BJ";
            }
            else
            {
                string symbole = "";
                switch (suit)
                {
                    case "hearts": symbole = "\u2665"; break;
                    case "diamonds": symbole = "\u2666"; break;
                    case "clubs": symbole = "\u2663"; break;
                    case "spades": symbole = "\u2660"; break;
                }
                return $"{rank}{symbole}";
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Card other = (Card)
                return rank == other.rank && suit == other.suit && color == other.color;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + (rank != null ? rank.GetHashCode() : 0)
                    hash = hash * 23 + (rank != null ? rank.GetHashCode() : 0)
                    hash = hash * 23 + (color != null ? rank.GetHashCode() : 0)
                }
        }
    }

    public class Deck
    {
        private List<Card> cards;
        public int CardsLeft => cards.Count;

        public Deck()
        {
            cards = new List<Card>();
        }

        public Deck(bool Have_Jokers)
        {
            cards = new List<Card>();
            string[] suits = { "hearts", "diamonds", "clubs", "spades" };
            string[] ranks = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };

            foreach (string suit in suits)
            {
                foreach (string rank in ranks)
                {
                    cards.Add(new Card(rank, suit));
                }
            }

            if (Have_Jokers)
            {
                cards.Add(new Card("Red"));
                cards.Add(new Card("Black"));
            }
        }

        public Deck(string customRules)
        {
            cards = new List<Card>();

            cards.Add(new Card("Ace", "hearts"));
            cards.Add(new Card("King", "hearts"));
            cards.Add(new Card("Queen", "hearts"));
            cards.Add(new Card("Joker", "Red"));
        }

        public Card Draw()
        {
            if (cards.Count == 0)
            {
                throw new InvalidOperationException("Cannot draw from an empty deck");

                Card Top_Card = cards[0];
                cards.RemoveAt(0);
                return Top_Card;
            }
        }

        public void Shuffle()
        {
            Random RNG = new Random();
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = RNG.Next(n + 1);
                Card value = cards[k];
                cards[k] = cards[n]
                    cards[n] = value;
            }
        }

        public Card Peek()
        {
            if (cards.Count == 0)
            {
                return null;
            }
            return cards[0];
        }

        public void Plac_On_Top(Card card)
        {
            cards.Insert(0, card);
        }

        public override string ToString()
        {
            return $"Deck: {CardsLeft} cards remaining";
        }
    }

    public class Hand
    {
        private List<Card> cards;
        private string[] suitPriority;

        public int Size => cards.Count;

        public Hand(string[] suitPriority)
        {
            cards = new List<Card>();
            this.suitPriority = suitPriority
            }

        public void AddCard(Card card)
        {
            cards.Add(card);
            OrderBySuit();
        }

        public Card RemoveCard()
        {
            if (cards.Count == 0)
            {
                throw new InvalidOperationException("Cannot remove from an empty hand");
                Card card = cards[0];
                cards.RemoveAt(0);
                return card;
            }
        }

        public Card Contains(Card target)
        {
            foreach (Card card in cards)
            {
                if (card.Equals(target))
                {
                    return true;
                }
                return false;
            }
        }

        private void OrderBySuit()
        {
            List<Card> Ordered_Cards = new List<Card>();
            List<Card> Jokers = new List<Card>();

            foreach (Card card in cards)
            {
                if (card.Rank == "Joker")
                {
                    Jokers.Add(card);
                }
            }

            foreach (string suit in suitPriority)
            {
                foreach (Card card in cards)
                {
                    if (card.Suit == suit && card.Rank != "Joker")
                    {
                        Ordered_Cards.Add(card);
                    }
                }
            }


            Ordered_Cards.AddRange(Jokers);
            cards = Ordered_Cards;
        }

        public override string ToString()
        {
            StringBuilder SB = new StringBuilder();
            foreach (Card card in cards)
            {
                SB.Append(card.ToString());
                SB.Append(" ");
            }
            return SB.ToString().Trim();
        }
    }

    public class GameState
    {
        private Deck drawDeck;
        private Deck discardPile;
        private List<Hand> playerHands;
        private string[] suitPriority;

        public GameState(bool Have_Jokers, string[] suitPriority)
        {
            this.suitPriority = suitPriority;
            drawDeck = new Deck(Have_Jokers);
            discardPile = new Deck();
            playerHands = new List<Hand>();
            drawDeck.Shuffle();
        }

        public void SetUpGame(int numPlayers, int cardsPerPlayer)
        {
            playerHands.Clear();
            for (int i = 0; i < numPlayers; i++)
            {
                playerHands.Add(new Hand(suitPriority));
            }
            DealCards(cardsPerPlayer);
        }

        public void DealCards(int cardsPerPlayer)
        {
            foreach (Hand hand in playerHands)
            {
                for (int i = 0; i < cardsPerPlayer; i++)
                {
                    if (drawDeck.CardsLeft == 0)
                    {
                        ReshuffleDiscard();
                        if (drawDeck.CardsLeft == 0)
                        {
                            throw new InvalidOperationException("Not enough cards to deal");
                        }
                    }
                    hand.AddCard(drawDeck.Draw());
                }
            }
        }

        private void ReshuffleDiscard()
        {
            while (discardPile.CardsLeft > 0)
            {
                drawDeck.Plac_On_Top(discardPile.Draw());
            }
            drawDeck.Shuffle();
        }

        public override string ToString()
        {
            StringBuilder SB = new StringBuilder();
            SB.AppendLine("Player Hands:")
                for (int i = 0; i < playerHands.Count; i++)
            {
                SB.AppendLine($"Player {i + 1}: {playerHands[i].ToString()}");
            }
            SB.AppendLine($"Draw Deck: {drawDeck.ToString()}");
            SB.Append($"Discard Pile: {discardPile.CardsLeft} cards");
            if (discardPile.CardsLeft > 0)
            {
                SB.Append($" (Top: {discardPile.Peek()})");
            }
            return sb.ToString();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("************************************");
            Console.WriteLine("Welcome to Programming 2 - Assignment 5 – Winter 2025");
            Console.WriteLine($"Created by [Suheng LIi] [6293104) on {DateTime.Today:2025-04-16}");
            Console.WriteLine("************************************");

            GameState gameState = null;
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nMain Menu:");
                Console.WriteLine("1. Setup Game");
                Console.WriteLine("2. Deal Hands");
                Console.WriteLine("3. Display Gameboard");
                Console.WriteLine("4. Quit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": // Setup Game
                        Console.Write("Include jokers? (y/n): ");
                        bool hasJokers = Console.ReadLine().ToLower() == "y";

                        Console.WriteLine("Enter suit priority order (comma separated):");
                        Console.WriteLine("Options: hearts, diamonds, clubs, spades");
                        string[] suits = Console.ReadLine().Split(',');
                        for (int i = 0; i < suits.Length; i++)
                        {
                            suits[i] = suits[i].Trim().ToLower();
                        }

                        gameState = new GameState(hasJokers, suits);
                        Console.WriteLine("Game setup complete. Deck shuffled.");
                        break;

                    case "2":
                        if (gameState == null)
                        {
                            Console.WriteLine("Please setup the game first!");
                            break;
                        }

                        Console.Write("Number of players: ");
                        int numPlayers = int.Parse(Console.ReadLine());

                        Console.Write("Cards per player: ");
                        int cardsPerPlayer = int.Parse(Console.ReadLine());

                        try
                        {
                            gameState.SetupGame(numPlayers, cardsPerPlayer);
                            Console.WriteLine($"Dealt {cardsPerPlayer} cards to each of {numPlayers} players.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error dealing cards: {ex.Message}");
                        }
                        break;

                    case "3":
                        if (gameState == null)
                        {
                            Console.WriteLine("Please setup the game first!");
                            break;
                        }

                        Console.WriteLine("\nCurrent Game State:");
                        Console.WriteLine(gameState.ToString());
                        break;

                    case "4": // Quit
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;

                }
            }
            Console.WriteLine("\n Thank you for playing! Press Enter to exit...")
            Console.ReadLine();
        }
    }

    // private _rank, _suit, _color

    // public Card(rank, suit
    //      {
    //   _rank = rank , _suit = suit
    //   _color = (suit == "Heart" || "Diamond") ? "Red" : "Black"
    //        }

    //        public Card(int number
    //         {
    //             if (number == 53
    //             {
    //   _rank = "Joker"
    //    _color = "Red"
    //             }
    //           else if (number == 54
    //             {
    //   _rank = "Joker"
    //    _color = "Black"
    //             }
    //         }
    //   }


        }
    }