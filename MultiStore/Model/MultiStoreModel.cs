namespace MultiStore.Models
{
    public class MultiStoreModel
    {
        public int RowID { get; set; }
        public string OrderID { get; set; }
        public int OrderDate { get; set; }
        public int ShipDate { get; set; }
        public string ShipMode { get; set; }
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public int CustomerAge { get; set; }
        public string CustomerBirthday { get; set; }
        public string CustomerState { get; set; }
        public string Segment { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string RegionalManagerID { get; set; }
        public string RegionalManager { get; set; }
        public int PostalCode { get; set; }
        public string Region { get; set; }
        public string ProductID { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string ProductName { get; set; }
        public decimal Sales { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
        public decimal Profit { get; set; }
    }
    public class ImportLog
    {
        public int Id { get; set; }
        public string OriginalFileName { get; set; }
        public string CurrentFileName { get; set; }
        public DateTime ImportDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
