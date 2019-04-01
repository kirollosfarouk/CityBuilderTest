using System.Collections.Generic;
using System.Linq;
using Buildings;
using Resources;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        public readonly List<Building> Buildings = new List<Building>();

        public ResourceManager ResourceManager = new ResourceManager();

        public ProductionManager ProductionManager = new ProductionManager();

        public GridManager GridManager = new GridManager();

        public GameObject ResidenceGameObject;
        public GameObject WoodProductionBuildingGameObject;
        public GameObject SteelProductionBuildingGameObject;
        public GameObject TreeDecorationGameObject;
        public GameObject BenchGameObject;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        void Start()
        {
            ResourceManager.NotifyObservers();
        }

        void Update()
        {
            ProductionManager.UpdateProductionStates();
            startDummyProduction();
        }

        void DummyData()
        {
            //_buildings = new List<Building>()
            //{
            //    new Residence(),
            //    new Residence(),
            //    new WoodProductionBuilding(),
            //    new SteelProductionBuilding()
            //};

            //foreach (var building in _buildings)
            //{
            //    ProductionManager.AddToProduction(building.ProductionType);
            //}
        }

        void startDummyProduction()
        {
            //if( Input.GetKeyDown( KeyCode.X ) )
            //{
            //    _buildings[2].ProductionType.StartProduction();
            //}

            //if (Input.GetKeyDown(KeyCode.C))
            //{
            //    _buildings[3].ProductionType.StartProduction();
            //}
        }

        public void AddBuilding(BuildingType buildingType)
        {
            var metaData = BuildingDataFactory.GetMetaData( buildingType );
            if( !ResourceManager.CanAfford( metaData.BuildingCost ) )
            {
                return;
            }
            ResourceManager.DecreaseResource( metaData.BuildingCost );
            metaData.BuildingGameObject = CreateBuildingGameObject( buildingType );
            Buildings.Add( metaData);
            ProductionManager.AddToProduction( metaData.ProductionType );
        }

        public GameObject CreateBuildingGameObject(BuildingType buildingType)
        {
            switch (buildingType)
            {
                case BuildingType.Residence:
                   return Instantiate( ResidenceGameObject, new Vector3( 0, 0, 0 ), Quaternion.identity );
                case BuildingType.WoodProductionBuilding:
                    return Instantiate(WoodProductionBuildingGameObject, new Vector3(80, 0, 0), Quaternion.identity);
                case BuildingType.SteelProductionBuilding:
                    return Instantiate(SteelProductionBuildingGameObject, new Vector3(0, 0, -60), Quaternion.identity);
                case BuildingType.Tree:
                    return Instantiate(TreeDecorationGameObject, new Vector3(50, 0,-50), Quaternion.identity);
                case BuildingType.Bench:
                    return Instantiate(BenchGameObject, new Vector3(90, 0, -80), Quaternion.identity);
                default:
                    return null;
            }
        }

    }
}
