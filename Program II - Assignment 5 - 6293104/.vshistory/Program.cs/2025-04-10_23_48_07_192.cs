using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;
using System.Runtime.Intrinsics.X86;

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



        static void Main(string[] args)
        {
            // public class Card
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
}