using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFashionStore.Model.Models.Systems
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }
        public string AttackedName { get; set; }
        public string TranType { get; set; }
    }
}
