namespace project.Models
{
    public class dispatch
    {
        public int Id { get; set; }                 
        public string To { get; set; }

        public string CustomerCellNo { get; set; }          //phone
        public string ItemType { get; set; }

        public string VehicleNumber { get; set; }

        public string QuantityWeight { get; set; }          //Weight

        public long PriceInFigures { get; set; }

        public string PriceInWords { get; set; }

        public string TruckNo { get; set; }
        public string LorryFreight { get; set; }

        public long AdvancePaid { get; set; }           //Amount

        public long BalancePayable { get; set; }        //Amount

        public decimal GrossWeight { get; set; }
        public decimal TareWeight { get; set; }              //Weight

        public decimal NetWeight { get; set; }              //Weight

        public string Camp { get; set; }

        public string DriverName { get; set; }
        public string DL_No { get; set; }                

        public string DriverCellNo { get; set; }           //phone
        public string Owner { get; set; }

    }
}
