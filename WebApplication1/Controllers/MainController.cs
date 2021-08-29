using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace WebApplication1.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult Index()
        {
            System.Diagnostics.Debug.WriteLine("Meow2"); 
            BindData(); 
            return View();
        }
        public void BindData()
        {
            MySqlConnection con = new MySqlConnection("server=localhost; user id=root; password=; database=connectionstrackerapp;SslMode=none");
            con.Open();
            string sql = "SELECT * FROM records";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader rdr = cmd.ExecuteReader();

            try
            {
                System.Diagnostics.Debug.WriteLine("... TRYING TO READ RECORD");
                while (rdr.Read())
                {
                    System.Diagnostics.Debug.WriteLine(rdr["name"]);
                }
                
                System.Diagnostics.Debug.WriteLine("... DONE");
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine("ERROR" + e.Message);
            }
            finally
            {
                System.Diagnostics.Debug.WriteLine("...END OF PROCESS");
            }
            con.Close();
        }

    }
}