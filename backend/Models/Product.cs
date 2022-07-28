namespace MarketPlace.Models{

    public class Product {
        public string Name {get;set;}
        public int ItemID {get;set;}
        public int Quantity {get;set;}
        public double Price {get;set;}

        public override string ToString(){
            // string price = Price.ToString();
            return $"({Name}, {ItemID}, {Quantity}, {Price}";
        }

    }

}


