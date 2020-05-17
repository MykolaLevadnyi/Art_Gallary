using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Art_Gallary.Controllers;
using Art_Gallary.Models;
using Moq;
using Xunit;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Art_Gallary.Tests
    
    
{
    public class BeadsControllerTests : Art_GallaryTestBase
    {
        [Fact]
        public async System.Threading.Tasks.Task DontShoulAddAllBeadsAsync()
        {
            BeadsController controller = new BeadsController(_context);
            Bead bead = new Bead {ColorId=1 ,BeadsTypeId=1 ,Num = "1111", Image = "dsfsd" };
            await controller.PostBead(bead);
            await controller.PostBead(bead);
            var query = new GetBeadsQuery(_context);
            var result = query.Execute();
            Assert.Equal(1, result.Count);
        }
        [Fact]
        public async System.Threading.Tasks.Task DontShoulPutAllBeadsAsync()
        {
            BeadsController controller = new BeadsController(_context);
            Bead bead = new Bead { ColorId = 1, BeadsTypeId = 1, Num = "1111", Image = "dsfsd" };
            Bead bead1 = new Bead { ColorId = 1, BeadsTypeId = 1, Num = "111", Image = "dsfs" };
            await controller.PostBead(bead);
            await controller.PostBead(bead1);
            Bead cbead= new Bead { Id=2,ColorId = 1, BeadsTypeId = 1, Num = "1111", Image = "dsfs" };
            await controller.PutBead(2, cbead);
            var query = new GetBeadsQuery(_context);
            var result = query.Execute();
            Assert.Equal("111", result[1].Num);
        }

    }
}
