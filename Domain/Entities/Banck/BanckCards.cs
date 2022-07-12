using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Banck
{
    public class BanckCards
    {
        [Key]
        public int Id { set; get; }
        public string bin { set; get; }
        public string? brand { set; get; }
        public string? type { set; get; }
        public string? category { set; get; }
        public string? issuer { set; get; }
        public string? alpha_2 { set; get; }
        public string? alpha_3 { set; get; }
        public string? country_name_x { set; get; }
        public string? country_name_y { set; get; }
        public string? banck_phone { set; get; }
        public string?banck_url { set; get; }
        public string? Notes { set; get; }
    }
}
