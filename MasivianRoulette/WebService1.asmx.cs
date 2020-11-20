using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace MasivianRoulette
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string Roulette(int number_bet, int number_credit)
        {
            string answer = "";
           string credits = "";
            int credits1 = 0;
            SqlConnection conexion = new SqlConnection("server=MONICAS\\SQLEXPRESS; database=Roulette_User_Data; integrated security=true");
            conexion.Open();
            string query = "select * from Users where id_user = "+number_credit;
            SqlCommand credit = new SqlCommand(query,conexion);
            SqlDataReader reader = credit.ExecuteReader();
            if (reader.Read())
            {
                credits = reader["credit"].ToString(); 
            }
            conexion.Close();
            credits1 = Convert.ToInt32(credits);
            if (credits1>=10000)
            {
                int value;
                Random r = new Random();
                value = r.Next(0,36);
                if (number_bet==value)
                {
                    answer = "You are WINNER";
                }
                else
                {
                    answer = "You are LOSER";
                }
            }
            else
            {
                answer = "Credit insufficient";
            }
            return answer;
        }
    }
}