namespace MarketPlace.Models{

    public class Product {
        public int ItemID {get;set;}
        public string Name {get;set;}
        public int Quantity {get;set;}
        public double Price {get;set;}
        public string Image {get;set;}

        public override string ToString(){
            return $"({Name}, {ItemID}, {Quantity}, {Price}";
        }

    }

}


