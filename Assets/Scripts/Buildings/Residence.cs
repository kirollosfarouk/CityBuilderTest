using System.Collections.Generic;
using Resources;

namespace Buildings
{
    public class Residence : Building
    {
        public Residence()
        {
            BuildingName = "Residence";
            CurrentBuildingState = BuildingStates.Operational;
            BuildingCost = new Dictionary<Resource, float>()
            {
                {Resource.Gold,100}
            };

            ProductionType = new AutomaticProduction(10, 100, Resource.Gold);
        }
    }
}
