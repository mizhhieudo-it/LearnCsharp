namespace Sanpham {
    public partial class Product{
        public Manufatory manufatory {set;get;}
        public class Manufatory{
            public string name {set;get;}
            public string addr {set;get;}
        }
        public string description {get;set;}
    }
}