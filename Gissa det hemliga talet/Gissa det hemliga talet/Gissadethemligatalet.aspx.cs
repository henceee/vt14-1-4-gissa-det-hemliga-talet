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

        private SecretNumber SecretNumber
        {

            get { return Session["SecretNumber"] as SecretNumber ?? (SecretNumber)(Session["SecretNumber"] = new SecretNumber()); }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                //Om inga fler gissningar går att göras sätts enabled false på Skicka-knappen
                //Knappen med texten "Slumpa ett nytt tal" visas.

                SecretNumber.MakeGuess(int.Parse(Guess.Text));

                if (!SecretNumber.CanMakeGuess)
                {
                    Send.Enabled = false;
                    Guess.Enabled = false;
                    Randomize.Visible = true;

                    Randomize.Focus();

                    if (SecretNumber.Outcome == Outcome.Correct)
                    {
                        AccuracyLiteral.Text = string.Format(AccuracyLiteral.Text, "Grattis du klarade det på ", SecretNumber.Count + " försök!");
                    }
                    else if (SecretNumber.Outcome == Outcome.NoMoreGuesses)
                    {
                        AccuracyLiteral.Text = string.Format(AccuracyLiteral.Text, "Du har inga gissningar kvar. Det hemliga talet var ", SecretNumber.Number + ".");
                    }
                }
                else if (SecretNumber.Outcome == Outcome.High)
                {
                    AccuracyLiteral.Text = string.Format(AccuracyLiteral.Text, "För ", "högt!");
                }
                else if (SecretNumber.Outcome == Outcome.Low)
                {
                    AccuracyLiteral.Text = string.Format(AccuracyLiteral.Text, "För ", "lågt!");
                }
                else if (SecretNumber.Outcome == Outcome.PreviousGuess)
                {
                    AccuracyLiteral.Text = string.Format(AccuracyLiteral.Text, "Du har redan ", "gissat på det talet.");
                }

                string joinedlist = string.Join(",", SecretNumber.PreviousGuesses);
                PrevguessLiteral.Text = string.Format(PrevguessLiteral.Text, joinedlist);

                Result.Visible = true;
            }
        }

        protected void Randomize_Click(object sender, EventArgs e)
        {
            SecretNumber.Initialize();
        }
    }
}