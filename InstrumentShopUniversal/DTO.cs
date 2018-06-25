using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentShopUniversal
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

        public override string ToString()
        {
            return OrderID + "\t" + CustomerName;
        }

        public List<clsOrders> OrdersList { get; set; }

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

        public override string ToString()
        {
            return InstrumentName + "\t" + Brand + "\t" + Type + "\t" + InstrumentPrice;
        }

        public static readonly string FACTORY_PROMPT = "Enter 'New' for New Instrument or 'Used' for Used Instrument";


        public static clsAllInstrument CheckType(string prChoice)
        {
            return new clsAllInstrument() { Type = prChoice };

        }

        //public List<clsAllInstrument> InstrumenList { get; set; }
    }
}
