using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

enum Outcome {Indefinite,Low, High, Correct, NoMoreGuesses, PreviousGuess }
namespace Gissa_det_hemliga_talet.Model
{

    public class SecretNumber
    {
        int _number;
        List<int> _previousGuesses;
        const int MaxNumberOfGuesses = 7;

        //Egenskaper här.

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



        //OBS IMPLEMENTERA _PreviousGuesses  EGENSKAPEN!!!!


        //Konstruktor

        public SecretNumber() { 
        
            //Skapa ett random tal.

            _previousGuesses = new List<int>(MaxNumberOfGuesses);
        }

        
        //Metoder

        public void Initialize() { 
        

            //tilldela _number ett slumptal, mellan 1-100

            _previousGuesses.Clear();

            Outcome = Outcome.Indefinite;
        }

        public Outcome MakeGuess(int guess) {



            //**************OBS RETURNERAR INDEFINITE SÅ LÄNGE; ÄNDRAS!!!!!!!!!!!******************************

            return Outcome.Indefinite;
        }

    }
}