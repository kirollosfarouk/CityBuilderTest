using System.Collections.Generic;
using Buildings;
using Resources;

namespace Assets.Scripts.Buildings
{
    public class TreeDecoration : Building
    {
        public TreeDecoration()
        {
            BuildingName = "TreeDecoration";
            CurrentBuildingState = BuildingStates.Operational;
            BuildingCost = new Dictionary<Resource, float>()
            {
                { Resource.Gold, 50 },
                { Resource.Wood, 200 }
            };

            ProductionType = new Decoration();
        }
    }
}
