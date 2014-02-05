using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Gissa_det_hemliga_talet.Model;

namespace Gissa_det_hemliga_talet
{
    public partial class Gissa_det_hemliga_talet : System.Web.UI.Page
    {
        SecretNumber sec;

        private SecretNumber PrevGuess
        {

            get { return Session["SecretNumber"] as SecretNumber; }
            set { Session["SecretNumber"] = value; }

        }
        

        protected void Page_Load(object sender, EventArgs e)
        {
           

           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (PrevGuess == null)
            {
                sec = new SecretNumber();

                PrevGuess = sec;
            }
           
            
                //Om inga fler gissningar går att göras sätts enabled false på Skicka-knappen
                //Knappen med texten "Slumpa ett nytt tal" visas.

                              
                    PrevGuess.MakeGuess(int.Parse(Guess.Text));

                    
                    Result.Visible = true;

                    if (PrevGuess.CanMakeGuess == false)
                    {
                        Send.Enabled = false;
                        Guess.Enabled = false;
                        Randomize.Visible = true;

                        Randomize.Focus();

                            if (PrevGuess.Outcome == Outcome.Correct) {

                                AccuracyLiteral.Text = string.Format(AccuracyLiteral.Text, "Grattis du klarade det på ", PrevGuess.Count + " försök!");
                                
                            }

                            else if (PrevGuess.Outcome == Outcome.NoMoreGuesses) {

                                AccuracyLiteral.Text = string.Format(AccuracyLiteral.Text, "Du har inga gissningar kvar. Det hemliga talet var ", PrevGuess.Number + ".");
                            }

                    }

                    else if (PrevGuess.Outcome == Outcome.High) {

                        AccuracyLiteral.Text = string.Format(AccuracyLiteral.Text, "För ", "högt!");
                    
                    }

                    else if (PrevGuess.Outcome == Outcome.Low) {

                        AccuracyLiteral.Text = string.Format(AccuracyLiteral.Text, "För ", "lågt!");
                    
                    }

                    else if (PrevGuess.Outcome == Outcome.PreviousGuess) {

                        AccuracyLiteral.Text = string.Format(AccuracyLiteral.Text, "Du har redan ", "gissat på det talet.");
                    }


                    string joinedlist = string.Join(",", PrevGuess.PreviousGuesses.ToArray());        

                    PrevguessLiteral.Text = string.Format(PrevguessLiteral.Text, joinedlist);

                    PrevGuess = PrevGuess;
                     
            
        }

        protected void Randomize_Click(object sender, EventArgs e)
        {
            sec = new SecretNumber();

            PrevGuess = sec;

            
        }

       

        

        
    }
}