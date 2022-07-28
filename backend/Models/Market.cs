namespace MarketPlace.Models{

    public class Product {
        public string Name {get;set;}
        public string ItemID{get;set;}
        public string Quantity {get;set;}
        public string Price {get;set;}

        public override string ToString(){
            // string price = Price.ToString();
            return $"({Name}, {ItemID}, {Quantity}, {Price}";
        }


    }

}


