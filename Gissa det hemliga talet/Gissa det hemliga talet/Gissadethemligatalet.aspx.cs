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
            //Skapar en ny sessionsnyckel om PrevGuess inte har ngt värde.
            
            if (PrevGuess == null)
            {
                sec = new SecretNumber();

                PrevGuess = sec;
            }

            
                //Om inga fler gissningar går att göras sätts enabled false på Skicka-knappen
                //Knappen med texten "Slumpa ett nytt tal" visas.

                if (PrevGuess.CanMakeGuess == false)
                {
                    Send.Enabled = false;
                    Guess.Enabled = false;
                    Randomize.Visible = true;

                }
                else
                {
                    sec.MakeGuess(int.Parse(Guess.Text));        

                }

                PrevGuess = sec;
                     
            
        }

       

        

        
    }
}