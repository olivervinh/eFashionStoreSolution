using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eFashionStore.Model.Models.Catalogs;
using eFashionStore.Model.Models.Others;
using eFashionStore.Model.Models.WareHouses;
using Microsoft.AspNetCore.Identity;
namespace eFashionStore.Model.Models.Users
{
    public class AppUser: IdentityUser
    {
        public string Address { get; set; }
        public string ImagePath { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<ProductLike> ProductLikes { get; set; }
        public virtual ICollection<ProductReview> ProductReviews { get; set; }
        public virtual ICollection<WareHouseBill> PhieuNhapHangs { get; set; }
        public virtual ICollection<UserChat> UserChats { get; set; }
        public virtual ICollection<CalendarToDo> Calendars { get; set; }
    }
}
