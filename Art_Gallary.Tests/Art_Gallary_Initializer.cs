using System;
using System.Collections.Generic;
using System.Text;
using Art_Gallary.Models;

namespace Art_Gallary.Tests
{
    public static class Art_Gallary_Initializer
    {
        public static void Initialize(ShopContext context)
        {
            Color color = new Color { Name = "red" };
            context.Colors.Add(color);
            context.SaveChanges();
            BeadsType type = new BeadsType { Name = "frosted" };
            context.BeadsTypes.Add(type);
            context.SaveChanges();/*
            var beads = new[]
            {
                new Bead{ ColorId=1 , BeadsTypeId=1 , Num="1111",Image="dsfsd"},
                new Bead{ ColorId=1 , BeadsTypeId=1 , Num="1112",Image="dsfsd"},
            };
            context.Beads.AddRange(beads);
            context.SaveChanges();*/
        }

    }
}
