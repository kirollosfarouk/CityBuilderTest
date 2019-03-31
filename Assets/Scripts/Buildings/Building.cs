using System.Collections.Generic;
using Resources;
using UnityEngine;


namespace Buildings
{
    public enum BuildingStates
    {
        Construction,
        Operational
    }

    public abstract class Building
    {
        public string BuildingName;
        public GameObject BuildingGameObject;
        public BuildingStates CurrentBuildingState;
        public Dictionary<Resource,float> BuildingCost;
        public IProduction ProductionType;

        public Vector2 PositionOnGrid;
        public Vector2 BuildingSize;
    }
}
