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
        private SecretNumber? SecretNumber {

            get { return Session["SecretNumber"] as SecretNumber; }
            set { Session["SecretNumber"] = value; }
                       
        
        }
        

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!SecretNumber.HasValue) {

                SecretNumber secret = new SecretNumber();

            }

            else {

                Model.SecretNumber.MakeGuess(int.Parse(Guess.Text));
            }           
            
        }

       

        

        
    }
}