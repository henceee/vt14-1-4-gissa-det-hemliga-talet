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
        private static List<int> _previousGuesses;
        private const int MaxNumberOfGuesses = 7;
        private const int MinVal = 0;
        private const int MaxVal = 100;

        private Random ran;

        //Egenskaper 

        public bool CanMakeGuess
        {
            get
            {
                return Count < MaxNumberOfGuesses && !_previousGuesses.Contains(_number);
            }
        }

        public int Count
        {
            get { return _previousGuesses.Count; }
        }



        public int? Number
        {
            get
            {

                if (CanMakeGuess)
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

            Initialize();
        }


        //Metoder

        public void Initialize()
        {

            //tilldela _number ett slumptal, mellan 1-100

            _number = ran.Next(MinVal, MaxVal + 1);

            _previousGuesses.Clear();

            Outcome = Outcome.Indefinite;
        }


        public Outcome MakeGuess(int guess)
        {
            if (!CanMakeGuess)
            {
                Outcome = Outcome.NoMoreGuesses;
                return Outcome;
            }

            if (guess < MinVal || guess > MaxVal)
            {

                throw new ArgumentOutOfRangeException();
            }

            if (_previousGuesses.Contains(guess))
            {
                Outcome = Outcome.PreviousGuess;
            }
            else
            {
                _previousGuesses.Add(guess);

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
            }

            return Outcome;
        }

    }
}