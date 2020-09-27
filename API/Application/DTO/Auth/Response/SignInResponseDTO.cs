using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.API {
    public class SignInResponseDTO {

        public string uuid {get; set; }
        public string username { get; set; }
        public string token { get; set; }

    }
}
