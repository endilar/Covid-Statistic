using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Entities.Requests
{
    public class PaginationRequest
    {
        [FromQuery(Name = "limit")]
        public int Limit { get; set; } = 15;

        [FromQuery(Name = "offset")]
        public int Offset { get; set; } = 0;

        [FromQuery(Name = "query")]
        public string Query { get; set; } = "";

        [FromQuery(Name = "sortField")]
        public string SortField { get; set; } = "FirstName";

        [FromQuery(Name = "sortType")]
        public string SortType { get; set; } = "asc";
    }
}
