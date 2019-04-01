using System.Collections.Generic;
using Buildings;
using Resources;

namespace Assets.Scripts.Buildings
{
    public class Bench : Building
    {
        public Bench()
        {
            BuildingName = "Bench";
            CurrentBuildingState = BuildingStates.Operational;
            BuildingCost = new Dictionary<Resource, float>()
            {
                {Resource.Gold,150},
                {Resource.Steel,50 }
            };

            ProductionType = new Decoration();
        }
    }
}
