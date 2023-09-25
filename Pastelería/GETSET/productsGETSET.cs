using System;

namespace Pastelería.GETSET
{
    class productsGETSET
    {
        //Getters and Setters for Product Module
        public int product_id { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public decimal rate { get; set; }
        public decimal qty { get; set; }
        public DateTime added_date { get; set; }
        public int added_by { get; set; }

    }
}
