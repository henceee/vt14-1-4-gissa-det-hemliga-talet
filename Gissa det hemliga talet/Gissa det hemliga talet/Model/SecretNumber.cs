using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;


public enum Outcome { Indefinite, Low, High, Correct, NoMoreGuesses, PreviousGuess };

namespace Gissa_det_hemliga_talet.Model
{

    public class SecretNumber
    {
        private static int _number;
        private static int _count;
        private static List<int> _previousGuesses;
        private const int MaxNumberOfGuesses = 7;
        private const int MinVal = 0;
        private const int MaxVal = 101;

        private Random ran;

        //Egenskaper 

        public bool CanMakeGuess
        {
            get
            {

                if (Outcome == Outcome.Correct || Outcome == Outcome.NoMoreGuesses)
                {

                    return false;
                }
                //else if (Outcome == Outcome.NoMoreGuesses) {

                //    return false;
                //}
                else
                {

                    return true;
                }

            }
        }

        public int Count
        {
            get { return _count; }
        }



        public int? Number
        {
            get
            {

                if (CanMakeGuess == true)
                {

                    return null;
                }
                else
                {

                    return _number;
                }


            }
        }

        public Outcome Outcome
        {
            get;
            private set;

        }

        public IEnumerable<int> PreviousGuesses
        {

            get { return _previousGuesses.AsReadOnly(); }
        }


        //Konstruktor

        public SecretNumber()
        {

            ran = new Random();

            _previousGuesses = new List<int>(MaxNumberOfGuesses);

            _count = 0;

            Initialize();
        }


        //Metoder

        public void Initialize()
        {

            //tilldela _number ett slumptal, mellan 1-100

            _number = ran.Next(MinVal, MaxVal);

            _previousGuesses.Clear();

            Outcome = Outcome.Indefinite;
        }


        public Outcome MakeGuess(int guess)
        {


            if (guess < MinVal || guess > MaxVal-1)
            {

                throw new ArgumentOutOfRangeException();
            }

            bool previousguess = false;

            for (int i = 0; i < _previousGuesses.Count; i++)
            {

                if (_previousGuesses[i] == guess)
                {

                    Outcome = Outcome.PreviousGuess;

                    previousguess = true;

                }
            }

            if (!previousguess)
            {

                if (guess > _number)
                {

                    Outcome = Outcome.High;

                }

                else if (guess < _number)
                {

                    Outcome = Outcome.Low;
                }


                else
                {

                    Outcome = Outcome.Correct;

                }

                _count++;
                _previousGuesses.Add(guess);
            }

            if (Count == MaxNumberOfGuesses && guess != _number)
            {

                Outcome = Outcome.NoMoreGuesses;

            }
                                    

            return Outcome;
        }

    }
}