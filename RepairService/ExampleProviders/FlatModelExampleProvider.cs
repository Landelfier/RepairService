using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepairService.Models
{
    public class FlatModelExampleProvider: IExamplesProvider<FlatModel>
    {
        public FlatModel GetExamples() => new FlatModel()
        {
             login="admin",
             square=25,
             roomNumber=1,
             doorNumber=1,
             height=2,
             address="test address",
             rooms= new RoomSettings 
             {
             WallsID=1,
             DoorsID=3,
             FloorID=6,
             BaseboardID=8,
             PowerSocketsID=10
            },
            bathroomID=1,
            kitchenID=4,
            additionalsID = new int[] {4,5}
        };

    }
}
