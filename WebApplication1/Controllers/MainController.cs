using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
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
        List<Main> record;
        MySqlConnection con = new MySqlConnection("server=localhost; user id=root; password=; database=connectionstrackerapp;SslMode=none");
        public ActionResult Index()
        {
            //BindData();
            getData();
            return View(record);
        }
        public void getData()
        {
            using (var db = new RecordContext())
            {
                record = new List<Main>();
                //db.records.Load();
                var query = from r in db.records
                            orderby r.id
                            select r;
                foreach (var item in query)
                {
                    record.Add(new Main
                    {
                        id = item.id,
                        name = item.name,
                        company = item.company,
                        stage = item.stage,
                        platform = item.platform,
                        platformURL = item.platformURL,
                        email = item.email,
                        lastContacted = Convert.ToString(item.lastContacted),
                        firstContacted = Convert.ToString(item.firstContacted),
                        priority = (int)item.priority,
                        iduser = item.iduser
                    });
                }
            }
        }
        [HttpPost]
        public String CreateRecord(string name, string company, string stage, string platform, string platformURL, string email, DateTime lastContacted, DateTime firstContacted, int priority, int iduser)
        {
            using (var db = new RecordContext())
            {
                //DEFAULT VALUES 
                iduser = 1;
                var newRecord = new record()
                {
                    name = name,
                    company = company,
                    stage = stage,
                    platform = platform,
                    platformURL = platformURL,
                    email = email,
                    lastContacted = lastContacted,
                    firstContacted = firstContacted,
                    priority = priority,
                    iduser = iduser
                };
                db.records.Add(newRecord);
                db.SaveChanges();
            }
            return "{}";
        }

        [HttpGet]
        public JsonResult ReadRecord(int id, int iduser)
        {
            using (var db = new RecordContext())
            {
                //DEFAULT VALUES 
                iduser = 1;
                var query = (from r in db.records
                            where r.id == id && r.iduser == iduser
                            select r).FirstOrDefault();
                return Json(query);
            }
        }
        
        //public void BindData()
        //{
        //    con.Open();
        //    // TODO: Update iduser to reflect current user
        //    string sql = "SELECT * FROM records WHERE iduser = 1";
        //    MySqlCommand cmd = new MySqlCommand(sql, con);
        //    MySqlDataReader rdr = cmd.ExecuteReader();
        //    DataTable dt = new DataTable();
        //    dt.Load(rdr);
        //    record = new List<Main>();
        //    try
        //    {
        //        System.Diagnostics.Debug.WriteLine("STARTING DATABIND");
        //        foreach (DataRow row in dt.Rows)
        //        {
        //            record.Add(new Main()
        //            {
        //                id = (int)row["id"],
        //                name = (string)row["name"],
        //                company = (string)row["company"],
        //                stage = (string)row["stage"],
        //                platform = (string)row["platform"],
        //                platformURL = (string)row["platformURL"],
        //                email = (string)row["email"],
        //                lastContacted = Convert.ToString(row["lastContacted"]),
        //                firstContacted = Convert.ToString(row["firstContacted"]),
        //                priority = (int)row["priority"],
        //                iduser = (int)row["iduser"]
        //            });
        //        }
        //        System.Diagnostics.Debug.WriteLine("SUCCESSFUL DATABIND");
        //    }
        //    catch (Exception e)
        //    {
        //        System.Diagnostics.Debug.WriteLine("ERROR IN DATABIND");
        //        System.Diagnostics.Debug.WriteLine(e.Message);
        //    }
        //    con.Close();
        //}

        //[HttpPost]
        //public String CreateRecord(string name, string company, string stage, string platform, string platformURL, string email, string lastContacted, string firstContacted, int priority, int iduser)
        //{
        //    con.Open();
        //    try
        //    {
        //        // DEFAULT VALUES
        //        iduser = 1;
        //        string sql = "INSERT INTO records(id, name, company, stage, platform, platformURL, email, lastContacted, firstContacted, priority, iduser)" +
        //                    $"VALUES('','{name}','{company}','{stage}','{platform}','{platformURL}','{email}','{lastContacted}','{firstContacted}',{priority},{iduser})";
        //        MySqlCommand cmd = new MySqlCommand(sql, con);
        //        cmd.ExecuteNonQuery();
        //    }
        //    catch (Exception e)
        //    {
        //        System.Diagnostics.Debug.WriteLine("ERROR IN CREATERECORD");
        //        System.Diagnostics.Debug.WriteLine(e.Message);
        //    }
        //    con.Close();
        //    return "{}";
        //}
        //[HttpGet]
        //public String ReadRecord(int id, int iduser)
        //{
        //    string sql = $"SELECT * WHERE id={id} AND iduser={iduser} LIMIT 1";
        //    MySqlCommand cmd = new MySqlCommand(sql, con);
        //    MySqlDataReader rdr = cmd.ExecuteReader();
        //    DataTable dt = new DataTable();
        //    dt.Load(rdr);
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        record.Add(new Main()
        //        {
        //            id = (int)row["id"],
        //            name = (string)row["name"],
        //            company = (string)row["company"],
        //            stage = (string)row["stage"],
        //            platform = (string)row["platform"],
        //            platformURL = (string)row["platformURL"],
        //            email = (string)row["email"],
        //            lastContacted = Convert.ToString(row["lastContacted"]),
        //            firstContacted = Convert.ToString(row["firstContacted"]),
        //            priority = (int)row["priority"],
        //            iduser = (int)row["iduser"]
        //        });
        //    }
        //    return "{}";
        //}
    }
}