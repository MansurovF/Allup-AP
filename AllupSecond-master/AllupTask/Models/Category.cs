﻿using System.Data.SqlTypes;

namespace AllupTask.Models
{
    public class Category:BaseEntity
    {
        public string Name  { get; set; }
        public string Image  { get; set; }
        public bool IsMain  { get; set; }
        public Nullable<int> ParentId{ get; set; }
        public Category Parent  { get; set; }
        public IEnumerable<Category> Children{ get; set; }

        public IEnumerable<Product>Products { get; set; }
    }
}
