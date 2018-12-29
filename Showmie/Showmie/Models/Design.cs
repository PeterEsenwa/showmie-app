using System;
using System.Collections.Generic;
using System.Text;

namespace Showmie.Models
{
    public class Design
    {
        public int? Id { get; set; }
        public string Details { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public int? UserId { get; set; }
        public int? Likes { get; set; }
        public int? Comments { get; set; }
        public int? IsForSale { get; set; }
        public int? Requests { get; set; }
        public string CreatedAt { get; set; }
        public string Status { get; set; }
        public string ChallengeCode { get; set; }
    }

    public class DesignGroup
    {
        public Design Design { get; set; }
        public User Creator { get; set; }
    }
}
