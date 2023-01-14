using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackByMyDuck.Application.Models.Authentication
{
    public class SocialLoginRequest
    {
        
        public string? Email { get; set; }

        [Required] 
        public string? Provider { get; set; }

        [Required] 
        public string? AccessToken { get; set; }
        
        [Required]
        public string? Name { get; set; }
        public int FacebookId { get; set; }
    }
}
