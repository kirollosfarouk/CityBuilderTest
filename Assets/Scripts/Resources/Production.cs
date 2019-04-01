using System.Collections.Generic;
using Managers;
using UnityEngine;

namespace Resources
{
    public interface IProduction
    {
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
        public float ProductionTime;
        public float ProductionQuantity;
        public Resource ProductionResource;
        public ProductionStates CurrentProductionStates;
        private float _currentProductionTime;

        public float ProductionProgress
        {
            get
            {
               return _currentProductionTime / ProductionTime;
            }
        }

        public AutomaticProduction(float productionTime, float productionQuantity, Resource productionResource)
        {
            ProductionTime = productionTime;
            ProductionQuantity = productionQuantity;
            ProductionResource = productionResource;
            CurrentProductionStates = ProductionStates.Idle;
        }

        public void StartProduction()
        {
            _currentProductionTime = 0;

        }

        public void UpdateProduction(float deltaTime)
        {
            _currentProductionTime += deltaTime;

            if (_currentProductionTime > ProductionTime)
            {
                GameManager.Instant.ResourceManager.UpdateResource(ProductionResource,ProductionQuantity);
                _currentProductionTime = 0;
                CurrentProductionStates = ProductionStates.Idle;
            }
        }

    }

    public class ManualProduction : IProduction
    {
        public void StartProduction()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateProduction(float deltaTime)
        {
            throw new System.NotImplementedException();
        }
    }

    public class Decoration : IProduction
    {
        public void StartProduction()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateProduction(float deltaTime)
        {
            throw new System.NotImplementedException();
        }
    }

    public class ProductionManager
    {
        private readonly List<IProduction> _onGoingProductions = new List<IProduction>();

        public void UpdateProductionStates()
        {
            foreach (var production in _onGoingProductions)
            {
                production.UpdateProduction(Time.deltaTime);
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
