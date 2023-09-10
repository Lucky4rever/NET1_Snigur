﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET.Variant13.NET3
{
    class SupplierListItem
    {
        public Material Material;
        public int MaxCount;
        public decimal PriceForSet;

        public SupplierListItem(Material material, int count, int price)
        {
            this.Material = material;
            this.MaxCount = count;
            this.PriceForSet = price;
        }

        public override string ToString()
        {
            return $"{this.Material} for {this.PriceForSet} for 1 set and with max count {this.MaxCount}";
        }
    }
}
