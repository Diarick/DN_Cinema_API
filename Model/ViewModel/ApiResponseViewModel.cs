using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class ApiResponseViewModel
    {
        public int statusCode { get; set; }
        public bool status { get; set; }
        public string message { get; set; }
    }
}
