using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Entities.Requests
{
    public class UploadFileRequest
    {
        [Required]
        //[AllowableFileTemplate(new string[] { 
        //    //"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", 
        //    "application/vnd.ms-excel"
        //})]
        public IFormFile File { get; set; }
    }
}
