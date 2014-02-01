using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;


enum Outcome {Indefinite,Low, High, Correct, NoMoreGuesses, PreviousGuess }
namespace Gissa_det_hemliga_talet.Model
{

    public class SecretNumber
    {
        private int _number;
        private static List<int> _previousGuesses;
        private const int MaxNumberOfGuesses = 7;
        private const int MaxVal = 0;
        private const int Minval = 101;
                
        private Random ran;

        //Egenskaper 

        public bool CanMakeGuess
        {
            get;
        }

        public int Count
        {
            get;
        }


        public int? Number
        {
            get;
        }

        public Outcome Outcome
        {   
            get;
            private set;

        }

        public ReadOnlyCollection<int> PreviousGuesses
        {

            get { return _previousGuesses.AsReadOnly(); }
        }


        //Konstruktor

        public SecretNumber() { 
                    
            ran = new Random();

            _previousGuesses = new List<int>(MaxNumberOfGuesses);

            Initialize();
        }

        
        //Metoder

        public void Initialize() {

            //tilldela _number ett slumptal, mellan 1-100

             _number = ran.Next(Minval, MaxVal);

            _previousGuesses.Clear();

            Outcome = Outcome.Indefinite;
        }

        public Outcome MakeGuess(int guess) {

            if (guess < Minval || guess > MaxVal) {

                throw new ArgumentOutOfRangeException();
            }


            //**************OBS RETURNERAR INDEFINITE SÅ LÄNGE; ÄNDRAS!!!!!!!!!!!******************************

            return Outcome.Indefinite;
        }

    }
}