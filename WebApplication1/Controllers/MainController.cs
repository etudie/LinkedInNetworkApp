﻿using System;
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
        List<Main> record;
        public ActionResult Index()
        {
            BindData();
            return View(record);
        }
        public void BindData()
        {
            MySqlConnection con = new MySqlConnection("server=localhost; user id=root; password=; database=connectionstrackerapp;SslMode=none");
            con.Open();
            // TODO: Update iduser to reflect current user
            string sql = "SELECT * FROM records WHERE iduser = 1";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rdr);
            record = new List<Main> (); 
            try
            {
                System.Diagnostics.Debug.WriteLine("STARTING DATABIND");
                foreach (DataRow row in dt.Rows)
                {   
                    record.Add(new Main() {
                        id = (int)row["id"],
                        name = (string)row["name"],
                        company = (string)row["company"],
                        stage = (string)row["stage"],
                        platform = (string)row["platform"],
                        platformURL = (string)row["platformURL"],
                        email = (string)row["email"],
                        lastContacted = Convert.ToString(row["lastContacted"]),
                        firstContacted = Convert.ToString(row["firstContacted"]),
                        priority = (int)row["priority"],
                        iduser = (int)row["iduser"]
                    });
                }
                System.Diagnostics.Debug.WriteLine("SUCCESSFUL DATABIND");
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine("ERROR IN DATABIND");
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            con.Close();
        }
    }
}