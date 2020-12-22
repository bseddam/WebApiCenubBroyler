using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiCenubBroyler.Models
{
    public class MobilResult
    {
        public bool Result { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }
    }
}