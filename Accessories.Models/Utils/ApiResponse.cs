using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Accessories.Models.Utils;

public class ApiResponse
{
    public ApiResponse()
    {
        ErrorMessages = new List<string>();
    }
    public List<string> ErrorMessages { get; set; }
    public bool IsSuccess { get; set; } = true;
    public object Result { get; set; }
    public HttpStatusCode StatusCode { get; set; }
}
