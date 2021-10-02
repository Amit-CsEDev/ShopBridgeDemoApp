using DATA.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DATA.Tables
{
    [Table("tbl_Items")]
    public class Items : BaseModel<int>
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Kindly Enter Item Name")]
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public string ItemCategory { get; set; }
        [Required(ErrorMessage = "Kindly Enter Quantity")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Kindly Enter Item Price")]
        public int Price { get; set; }
        public int BuyPrice { get; set; }
        public int DefaultSellPrice { get; set; }
        public bool isItemSale { get; set; }
        public int SalePrice { get; set; }
    }
}
