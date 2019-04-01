using System.Collections.Generic;
using Assets.Scripts.Buildings;
using Resources;
using UnityEngine;


namespace Buildings
{
    public enum BuildingStates
    {
        Construction,
        Operational
    }

    public enum BuildingType
    {
        Residence = 0,
        WoodProductionBuilding = 1,
        SteelProductionBuilding = 2,
        Tree = 3,
        Bench = 4
    }

    public static class BuildingDataFactory
    {
        public static Building GetMetaData(BuildingType buildingType)
        {  
            switch (buildingType)
            {
                case BuildingType.Residence:
                    return new Residence();
                case BuildingType.WoodProductionBuilding:
                    return new WoodProductionBuilding();
                case BuildingType.SteelProductionBuilding:
                    return new SteelProductionBuilding();
                case BuildingType.Tree:
                    return new TreeDecoration();
                case BuildingType.Bench:
                    return new Bench();
                default:
                    return null;
            }
        }

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
