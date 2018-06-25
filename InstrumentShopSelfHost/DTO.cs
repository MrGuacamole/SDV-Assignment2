using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentShopSelfHost
{
    public class clsCategory
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<clsAllInstrument> InstrumentList { get; set; }
    }

    public class clsOrders
    {
        public int OrderID { get; set; }
        public int InstrumentID { get; set; }
        public int Quantity { get; set; }
        public double OrderPrice { get; set; }
        public string OrderDate { get; set; }
        public string CustomerName { get; set; }
        public string CustomerCity { get; set; }
        public string InstrumentName { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }

        //public List<clsOrders> OrdersList { get; set; }
        //public List<clsAllInstrument> InstrumenList { get; set; }
    }
    public class clsAllInstrument
    {
        public int InstrumentID { get; set; }
        public string CategoryName { get; set; }
        public string InstrumentName { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public double InstrumentPrice { get; set; }
        public int Quantity { get; set; }
        public DateTime ModifyTime { get; set; }
        public string Condition { get; set; }
        public string DateOfReturn { get; set; }
        public string WarrantyPeriod { get; set; }
        public string ImportDate { get; set; }

        //public List<clsAllInstrument> InstrumenList { get; set; }
    }
}

