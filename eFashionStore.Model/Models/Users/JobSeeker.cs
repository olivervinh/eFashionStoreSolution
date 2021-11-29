using eFashionStore.Model.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFashionStore.Model.Models.Users
{
    public class JobSeeker
    {
        [Key]
        public int Id { get; set; }
        public string? FkAppUserId { get; set; }
        [ForeignKey("FkAppUserId")]
        public virtual AppUser AppUser { get; set; }
        public string Location { get; set; }
    }
}
