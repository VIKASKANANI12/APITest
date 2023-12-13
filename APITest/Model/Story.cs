
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace APITest.Model
{
    public class Story
    {
        public string? Title { get; set; }
        [Display(Name = "Uri")]
        public string? Url { get; set; }

        [Display(Name = "PostedBy")]
        public string? By { get; set; }
        public double Time { get; set; }
        public int Score { get; set; }
        public int CommentCount { get; set; }
    }
}
