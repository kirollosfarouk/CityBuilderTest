using System.Collections.Generic;
using Buildings;
using Resources;

namespace Buildings
{
    public class WoodProductionBuilding : Building
    {
        public WoodProductionBuilding()
        {
            BuildingName = "Wood Production";
            CurrentBuildingState = BuildingStates.Operational;
            BuildingCost = new Dictionary<Resource, float>()
            {
                {Resource.Gold,150}
            };

            ProductionType = new ManualProduction( 10, 50, Resource.Wood );
        }
    }
}
