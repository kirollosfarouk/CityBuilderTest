using System.Collections.Generic;
using Buildings;
using Resources;

namespace Buildings
{
    public class SteelProductionBuilding : Building
    {
        public SteelProductionBuilding()
        {
            BuildingName = "Steel Production";
            CurrentBuildingState = BuildingStates.Operational;
            BuildingCost = new Dictionary<Resource, float>()
            {
                {Resource.Gold,150},
                {Resource.Wood,100 }
            };

            ProductionType = new ManualProduction(1, 50, Resource.Steel);
        }
    }
}
