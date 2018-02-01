using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Daifuku.SampleWeb.Models
{
    public class HomeSendToken
    {
        public string Name { get; set; }

        [DisplayName("Magic token")]
        [Required(ErrorMessage = "Magic token is required.")]
        public string Token { get; set; }
    }
}