using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class RandomClientViewModel
    {
        public Record Record { get; set; }
        public List<Client> Client { get; set; }
    }
}