using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FPT_BOOKSHOP.Models.DTO
{
    public class Status
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}