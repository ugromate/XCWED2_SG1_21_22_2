using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCWED2_SG1_21_22_2.Models.Models
{
    public class ApiResult
    {
        public bool IsSuccess { get; set; }

        public List<string> Messages { get; set; }

        public ApiResult()
        {
        }

        public ApiResult(bool isSuccess, List<string> messages = null)
        {
            IsSuccess = isSuccess;
            Messages = messages;
        }
    }
}
