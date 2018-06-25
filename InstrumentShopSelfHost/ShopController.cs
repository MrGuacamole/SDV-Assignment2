using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentShopSelfHost
{
    public class ShopController : System.Web.Http.ApiController
    {
        public List<string> GetCategoryNames()
        {
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT CategoryName FROM Category", null);
            List<string> lcNames = new List<string>();
            foreach (DataRow dr in lcResult.Rows)
                lcNames.Add((string)dr[0]);
            return lcNames;
        }
        public List<int> GetOrders()
        {
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT OrderID FROM Orders", null);
            List<int> lcOrders = new List<int>();
            foreach (DataRow dr in lcResult.Rows)
                lcOrders.Add((int)dr[0]);
            return lcOrders;
        }

        public clsOrders GetOrderDetails(int OrderID)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            par.Add("OrderID", OrderID);
            DataTable lcResult =
            clsDbConnection.GetDataTable("SELECT Orders.*, Instrument.Brand, Instrument.InstrumentName, Instrument.[Type] FROM Orders INNER JOIN Instrument ON Orders.InstrumentID = Instrument.InstrumentID WHERE OrderID = @OrderID", par);
            if (lcResult.Rows.Count > 0)
                return new clsOrders()
                {
                    OrderID = (int)lcResult.Rows[0]["OrderID"],
                    InstrumentID = (int)lcResult.Rows[0]["InstrumentID"],
                    Quantity = (int)lcResult.Rows[0]["Quantity"],
                    OrderPrice = (double)lcResult.Rows[0]["OrderPrice"],
                    OrderDate = (string)lcResult.Rows[0]["OrderDate"],
                    CustomerName = (string)lcResult.Rows[0]["CustomerName"],
                    CustomerCity = (string)lcResult.Rows[0]["CustomerCity"],
                    InstrumentName = (string)lcResult.Rows[0]["InstrumentName"],
                    Brand = (string)lcResult.Rows[0]["Brand"],
                    Type = (string)lcResult.Rows[0]["Type"],
                    //OrdersList = GetOrders(OrderID)
                };
            else
                return null;
        }
        //private List<clsOrders> GetOrders(int OrderID)
        //{
        //    Dictionary<string, object> par = new Dictionary<string, object>(1);
        //    par.Add("OrderID", OrderID);
        //    DataTable lcResult = clsDbConnection.GetDataTable("SELECT * FROM Orders WHERE OrderID = @OrderID", par);
        //    List<clsOrders> lcOrders = new List<clsOrders>();
        //    foreach (DataRow dr in lcResult.Rows)
        //        lcOrders.Add(dataRow2Orders(dr));
        //    return lcOrders;
        //}
        //public string PutQuantity(clsAllInstrument prInstrument)
        //{ // update
        //    try
        //    {
        //        int lcRecCount = clsDbConnection.Execute(
        //       "UPDATE Order SET Quantity = @Quantity WHERE InstrumentID = @InstrumentID",
        //       prepareInstrumentParameters(prInstrument));
        //        if (lcRecCount == 1)
        //            return "One instrument updated";
        //        else
        //            return "Unexpected instrument update count: " + lcRecCount;
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.GetBaseException().Message;
        //    }
        //}
        public string PutInstrument(clsAllInstrument prInstrument)
        { // update
            try
            {
                int lcRecCount = clsDbConnection.Execute(
               "UPDATE Instrument SET Brand = @Brand, Description = @Description, InstrumentPrice = @InstrumentPrice, Quantity = @Quantity, ModifyTime = GETDATE(), [Condition] = @Condition, DateOfReturn = @DateOfReturn, WarrantyPeriod = @WarrantyPeriod, ImportDate = @ImportDate WHERE InstrumentID = @InstrumentID",
               prepareInstrumentParameters(prInstrument));
                if (lcRecCount == 1)
                    return "One instrument updated";
                else
                    return "Unexpected instrument update count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        public string PostInstrument(clsAllInstrument prInstrument)
        { // insert
            try
            {
                int lcRecCount = clsDbConnection.Execute(
               "INSERT INTO Instrument (CategoryName, InstrumentName, Brand, Description, Type, InstrumentPrice, Quantity, ModifyTime, Condition, DateOfReturn, WarrantyPeriod, ImportDate) VALUES (@CategoryName, @InstrumentName, @Brand, @Description, @Type, @InstrumentPrice, @Quantity, GETDATE(), @Condition, @DateOfReturn, @WarrantyPeriod, @ImportDate)",
               prepareInstrumentParameters(prInstrument));
                if (lcRecCount == 1)
                    return "One instrument added";
                else
                    return "Unexpected instrument count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }
        public string PostOrder(clsOrders prOrder)
        { // insert
            try
            {
                int lcRecCount = clsDbConnection.Execute(
               "INSERT INTO Orders VALUES (@InstrumentID, @Quantity, @Price, @Date, @CustomerName, @CustomerCity)",
               prepareOrderParameters(prOrder));
                if (lcRecCount == 1)
                    return "Your order has been placed";
                else
                    return "Unexpected order count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }
        private Dictionary<string, object> prepareOrderParameters(clsOrders prOrder)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(3);
            par.Add("InstrumentID", prOrder.InstrumentID);
            par.Add("Quantity", prOrder.Quantity);
            par.Add("Price", prOrder.OrderPrice);
            par.Add("Date", prOrder.OrderDate);
            par.Add("CustomerName", prOrder.CustomerName);
            par.Add("CustomerCity", prOrder.CustomerCity);
            return par;
        }
        private Dictionary<string, object> prepareInstrumentParameters(clsAllInstrument prInstrument)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(3);
            par.Add("CategoryName", prInstrument.CategoryName);
            par.Add("InstrumentID", prInstrument.InstrumentID);
            par.Add("InstrumentName", prInstrument.InstrumentName);
            par.Add("Description", prInstrument.Description);
            par.Add("Brand", prInstrument.Brand);
            par.Add("Type", prInstrument.Type);
            par.Add("InstrumentPrice", prInstrument.InstrumentPrice);
            par.Add("Quantity", prInstrument.Quantity);
            //par.Add("ModifyTime", prInstrument.ModifyTime);
            par.Add("Condition", prInstrument.Condition);
            par.Add("DateOfReturn", prInstrument.DateOfReturn);
            par.Add("WarrantyPeriod", prInstrument.WarrantyPeriod);
            par.Add("ImportDate", prInstrument.ImportDate);
            return par;
        }
        public string DeleteInstrument(int prInstrumentID)
        { // delete
            try
            {
                Dictionary<string, object> par = new Dictionary<string, object>(1);
                par.Add("prInstrumentID", prInstrumentID);
                int lcRecCount = clsDbConnection.Execute(
               "DELETE FROM Instrument WHERE InstrumentID = @prInstrumentID", par);
                //prepareInstrumentParameters(prInstrumentID));
            
                if (lcRecCount == 1)
                    return "One instrument deleted";
                else
                    return "Unexpected instrument delete count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }



        public string DeleteOrder(int prOrderID)
        { // delete
            try
            {
                Dictionary<string, object> par = new Dictionary<string, object>(1);
                par.Add("prOrderID", prOrderID);
                int lcRecCount = clsDbConnection.Execute(
               "DELETE FROM Orders WHERE OrderID = @prOrderID", par);
                //prepareInstrumentParameters(prInstrumentID));

                if (lcRecCount == 1)
                    return "One order deleted";
                else
                    return "Unexpected order delete count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        //public clsAllInstrument GetInstruments(string pCategoryName)
        //{
        //    Dictionary<string, object> par = new Dictionary<string, object>(1);
        //    par.Add("CategoryName", pCategoryName);
        //    DataTable lcResult =
        //    clsDbConnection.GetDataTable("SELECT * FROM Instrument WHERE CategoryName = @CategoryName", par);
        //    if (lcResult.Rows.Count > 0)


        //    else
        //        return null;
        //}

        public clsCategory GetCategoryInstruments(string Name)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            par.Add("Name", Name);
            DataTable lcResult =
           clsDbConnection.GetDataTable("SELECT * FROM Category WHERE CategoryName = @Name", par);
            if (lcResult.Rows.Count > 0)
                return new clsCategory()
                {
                    Name = (string)lcResult.Rows[0]["CategoryName"],
                    Description = (string)lcResult.Rows[0]["CategoryDescription"],
                    InstrumentList = GetInstruments(Name)
                };
            else
                return null;
        }

        public double GetTotalOrderPrice()
        {
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT Sum(OrderPrice) FROM Orders", null);
            DataRow dr = lcResult.Rows[0];
            double lcOrderPrice = (double)dr[0];
            //foreach (DataRow dr in lcResult.Rows)
            //    lcOrderPrice.Add((double)dr[0]);
            return lcOrderPrice;
        }

        public string GetInstrumentName(string Name, string Type)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            par.Add("Name", Name);
            par.Add("Type", Type);
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT InstrumentName FROM Instrument WHERE InstrumentName = @Name AND Type = @Type", par);
            string lcName;
            if (lcResult.Rows.Count > 0)
            {
                DataRow dr = lcResult.Rows[0];
                lcName = (string)dr[0];
                
            }
            else
            {
                lcName = null; 
            }
           
            return lcName;
        }


        private List<clsAllInstrument> GetInstruments(string Name)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            par.Add("Name", Name);
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT * FROM Instrument WHERE CategoryName = @Name", par);
            List<clsAllInstrument> lcInstruments = new List<clsAllInstrument>();
            foreach (DataRow dr in lcResult.Rows)
                lcInstruments.Add(dataRow2AllInstrument(dr));
            return lcInstruments;
        }

        //private clsOrders dataRow2Orders(DataRow dr)
        //{
        //    return new clsOrders()
        //    {
        //        OrderID = Convert.ToInt16(dr["OrderID"]),
        //        CustomerName = Convert.ToString(dr["CustomerName"]),
        //        CategoryName = Convert.ToString(dr["CategoryName"]),
        //        Brand = Convert.ToString(dr["Brand"]),
        //        Description = Convert.ToString(dr["Description"]),
        //        Type = Convert.ToString(dr["Type"]),
        //        InstrumentPrice = Convert.ToDouble(dr["InstrumentPrice"]),
        //        Quantity = Convert.ToInt16(dr["Quantity"]),
        //        ModifyTime = Convert.ToDateTime(dr["ModifyTime"]),
        //        Condition = dr["Condition"] is DBNull ? (string)null : Convert.ToString(dr["Condition"]),
        //        DateOfReturn = dr["DateOfReturn"] is DBNull ? (string)null : Convert.ToString(dr["DateOfReturn"]),
        //        WarrantyPeriod = dr["WarrantyPeriod"] is DBNull ? (string)null : Convert.ToString(dr["WarrantyPeriod"]),
        //        ImportDate = dr["ImportDate"] is DBNull ? (string)null : Convert.ToString(dr["ImportDate"])
        //    };
        //}

        private clsAllInstrument dataRow2AllInstrument(DataRow dr)
        {
            return new clsAllInstrument()
            {
                InstrumentID = Convert.ToInt16(dr["InstrumentID"]),
                InstrumentName = Convert.ToString(dr["InstrumentName"]),
                CategoryName = Convert.ToString(dr["CategoryName"]),
                Brand = Convert.ToString(dr["Brand"]),
                Description = Convert.ToString(dr["Description"]),
                Type = Convert.ToString(dr["Type"]),
                InstrumentPrice = Convert.ToDouble(dr["InstrumentPrice"]),
                Quantity = Convert.ToInt16(dr["Quantity"]),
                ModifyTime = Convert.ToDateTime(dr["ModifyTime"]),
                Condition = dr["Condition"] is DBNull ? (string)null : Convert.ToString(dr["Condition"]),
                DateOfReturn = dr["DateOfReturn"] is DBNull ? (string)null : Convert.ToString(dr["DateOfReturn"]),
                WarrantyPeriod = dr["WarrantyPeriod"] is DBNull ? (string)null : Convert.ToString(dr["WarrantyPeriod"]),
                ImportDate = dr["ImportDate"] is DBNull ? (string)null : Convert.ToString(dr["ImportDate"])
            };
        }
    }
}
