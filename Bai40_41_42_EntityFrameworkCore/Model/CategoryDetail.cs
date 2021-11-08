using System;

namespace ef{
    public class CategoryDetail 
    {
        public int CategoryDetailId {get;set;}
        public int UserId {get;set;}
        public DateTime Create {get ;set;}

        public DateTime Updated {get ;set;}
        public int CountProduct {get;set;}
        public Category category {get;set;}
    }
}