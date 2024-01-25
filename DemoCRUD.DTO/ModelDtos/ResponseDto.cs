using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCRUD.DTO.ModelDtos
{
    public class ResponseDto
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int ResponseCode { get; set; }
        public object Data { get; set; }
    }
}
