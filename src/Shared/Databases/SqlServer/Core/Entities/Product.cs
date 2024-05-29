
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Api.Write.Core.Entities
{
    public class Product
    {

        public int Id { get; set; }

        //public string Details { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }

        public int Stock { get; set; }

        public int Price { get; set; }




    }
}
