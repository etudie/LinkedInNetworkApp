using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        Main[] record; 
        public ActionResult Index()
        {
            System.Diagnostics.Debug.WriteLine("Meow2"); 
            BindData();
            var viewModel = new MainViewModel()
            {
                Main = record
            };
            return View(viewModel);
        }
        public void BindData()
        {
            MySqlConnection con = new MySqlConnection("server=localhost; user id=root; password=; database=connectionstrackerapp;SslMode=none");
            con.Open();
            string sql = "SELECT * FROM records WHERE iduser = 1";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rdr);
            record = new Main[dt.Rows.Count-1];
            int i = 0; 
            try
            {
                System.Diagnostics.Debug.WriteLine("START OF THIS MOFO");
                foreach (DataRow row in dt.Rows)
                {
                    record[i] = new Main(); 
                    record[i].id = (int)row["id"];
                    record[i].name = (string)row["name"];
                    record[i].company = (string)row["company"];
                    record[i].stage = (string)row["stage"];
                    record[i].platform = (string)row["platform"];
                    record[i].platformURL = (string)row["platformURL"];
                    record[i].email = (string)row["email"];
                    record[i].lastContacted = (string)row["lastContacted"];
                    record[i].firstContacted = (string)row["firstContacted"];
                    record[i].priority = (int)row["priority"];
                    record[i].iduser = (int)row["iduser"];
                    i++;
                }
            }catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            finally
            {
                System.Diagnostics.Debug.WriteLine("END OF THIS MOFO");
            }

            //Main[] record = new Main[dt.Rows.Count];

            //int i = 0; 
            //try
            //{
            //    System.Diagnostics.Debug.WriteLine("... TRYING TO READ RECORD");
            //    while (rdr.Read())
            //    {
            //        record[i] = new Main(); 
            //        record[i].name = rdr.GetString("name");
            //        i++;
            //    }

            //    System.Diagnostics.Debug.WriteLine("... DONE");
            //}
            //catch(Exception e)
            //{
            //    System.Diagnostics.Debug.WriteLine("ERROR " + e.Message);
            //}
            //finally
            //{
            //    System.Diagnostics.Debug.WriteLine(record[0].name);
            //    System.Diagnostics.Debug.WriteLine(record[3].name);
            //    System.Diagnostics.Debug.WriteLine("...END OF PROCESS");
            //}
            //con.Close();
        }
    }
}