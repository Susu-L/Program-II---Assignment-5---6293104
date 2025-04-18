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

namespace Program_II___Assignment_5___6293104
{
    internal class Program
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

            public Card (string rank, string suit)
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

            public Card (string color)
            {
                this.rank = "Joker";
                this.suit = null;
                this.color = color;
            }

            public Card (int id)
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

            public override bool Equals (object obj)
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

            }
        }





        static void Main(string[] args)
        {

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


        Console.ReadLine();
        }
    }
}