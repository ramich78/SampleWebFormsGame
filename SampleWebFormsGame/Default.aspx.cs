using System;
using System.Web;
using System.Web.UI;

namespace SampleWebFormsGame
{
    // ReSharper disable once InconsistentNaming
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                divLoggedInUserContent.Visible = true;
            }
            else
            {
                divNotLoggedInUserContent.Visible = true;
            }
        }
    }
}