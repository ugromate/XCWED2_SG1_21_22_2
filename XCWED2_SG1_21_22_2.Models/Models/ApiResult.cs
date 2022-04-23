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

        // messages

        public ApiResult()
        {
        }

        public ApiResult(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }
    }
}
