using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionBilling.Domain.Entities
{
    public class GoodsDetails
    {
        public int SNo{ get; set; }
        public string DescriptionOfGoods{ get; set; }
        public int  hsnsac {get;set; }
        public int Quantity { get; set; }
        public decimal Rate { get; set; }
        public string Per { get; set; }
        public decimal Amount { get; set; }

    }
}
