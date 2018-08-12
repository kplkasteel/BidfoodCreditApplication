using System;
using System.Web;
using BidfoodCreditApplication.Models;

namespace BidfoodCreditApplication
{
    public class Global : HttpApplication
    {
        public static string Redirect = "/BidfoodCreditApplication/NewCustomer.aspx";

        public static CherwellWebConnector CherwellConnection = new CherwellWebConnector();

        private void Application_Start(object sender, EventArgs e)
        {
        }

        public static bool CherwellLogin()
        {
            var username = "CSDAdmin";
            var password = "CSDAdmin";
            return CherwellConnection.Login(username, password);
        }

        public static void Cherwelllogout()
        {
            CherwellConnection.Logout();
        }

        public static bool ConfirmLogin()
        {
            var username = "CSDAdmin";
            var password = "CSDAdmin";
            if (CherwellConnection.ConfirmLogin(username, password))
            {
                return true;
            }
            else
            {
                Cherwelllogout();
                if (CherwellLogin())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }
    }
}