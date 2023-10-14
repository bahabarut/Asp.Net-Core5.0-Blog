using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class BlogRating
    {
        [Key]
        public int BlogRatingID { get; set; }
        public int BLogID { get; set; }
        public int BLogTotalScore { get; set; }
        public int BLogRatingCount { get; set; }
    }
}
