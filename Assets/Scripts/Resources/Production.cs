using System.Collections.Generic;
using Managers;
using UnityEngine;

namespace Resources
{
    public interface IProduction
    {
        float ProductionTime { get; set; }
        float ProductionQuantity { get; set; }
        Resource ProductionResource { get; set; }
        ProductionStates CurrentProductionStates { get; set; }
        float CurrentProductionTime { get; set; }
        float ProductionProgress { get; }
        void StartProduction();
        void UpdateProduction(float deltaTime);
    }

    public enum ProductionStates
    {
        Idle,
        Production
    }

    public class AutomaticProduction : IProduction
    {
        public float ProductionTime { get; set; }
        public float ProductionQuantity { get; set; }
        public Resource ProductionResource { get; set; }
        public ProductionStates CurrentProductionStates { get; set; }
        public float CurrentProductionTime { get; set; }
        float IProduction.ProductionProgress
        {
            get
            {
                return CurrentProductionTime / ProductionTime;
            } 
        }

        public AutomaticProduction(float productionTime, float productionQuantity, Resource productionResource)
        {
            ProductionTime = productionTime;
            ProductionQuantity = productionQuantity;
            ProductionResource = productionResource;
            CurrentProductionStates = ProductionStates.Production;
        }

      

        public void StartProduction()
        {
            CurrentProductionStates = 0;
        }

        public void UpdateProduction(float deltaTime)
        {
            CurrentProductionTime += deltaTime;

            if (CurrentProductionTime > ProductionTime)
            {
                GameManager.Instance.ResourceManager.IncreaseResource(ProductionResource,ProductionQuantity);
                CurrentProductionTime = 0;
            }
        }

    }

    public class ManualProduction : IProduction
    {

        public float ProductionTime { get; set; }
        public float ProductionQuantity { get; set; }
        public Resource ProductionResource { get; set; }
        public ProductionStates CurrentProductionStates { get; set; }
        public float CurrentProductionTime { get; set; }
        public float ProductionProgress
        {
            get
            {
                return CurrentProductionTime / ProductionTime;
            }
        }

        public ManualProduction(float productionTime, float productionQuantity, Resource productionResource)
        {
            ProductionTime = productionTime;
            ProductionQuantity = productionQuantity;
            ProductionResource = productionResource;
            CurrentProductionStates = ProductionStates.Idle;
        }

      

        public void StartProduction()
        {
            if( CurrentProductionStates == ProductionStates.Production )
            {
                return;
            }

            CurrentProductionStates = ProductionStates.Production;
            CurrentProductionTime = 0;
            GameManager.Instance.ProductionManager.AddToProduction(this);
        }

        public void UpdateProduction(float deltaTime)
        {
            if (CurrentProductionStates == ProductionStates.Idle)
            {
                GameManager.Instance.ProductionManager.RemoveFromProduction(this);
                return;
            }

            CurrentProductionTime += deltaTime;

            if(CurrentProductionTime >= ProductionTime )
            {
                GameManager.Instance.ResourceManager.IncreaseResource( ProductionResource, ProductionQuantity );
                CurrentProductionStates = ProductionStates.Idle;
                GameManager.Instance.ProductionManager.RemoveFromProduction( this );
            }
        }
    }

    public class Decoration : IProduction
    {
        public float ProductionTime { get; set; }
        public float ProductionQuantity { get; set; }
        public Resource ProductionResource { get; set; }
        public ProductionStates CurrentProductionStates { get; set; }
        public float CurrentProductionTime { get; set; }
        public float ProductionProgress { get; set; }

        public void StartProduction()
        {
           Debug.Log( "i'm a dummy object i do nothing" );
        }

        public void UpdateProduction(float deltaTime)
        {
            Debug.Log("i'm a dummy object i do nothing");
        }
    }

    public class ProductionManager
    {
        private readonly List<IProduction> _onGoingProductions = new List<IProduction>();

        public void UpdateProductionStates()
        {
            for( int i = 0; i < _onGoingProductions.Count; i++ )
            {
                _onGoingProductions[i].UpdateProduction( Time.deltaTime );
            }
        }

        public void AddToProduction( IProduction production )
        {
            _onGoingProductions.Add( production );
        }

        public void RemoveFromProduction( IProduction production )
        {
            _onGoingProductions.Remove( production );
        }
    }
}
