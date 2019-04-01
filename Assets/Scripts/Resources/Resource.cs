using System;
using System.Collections.Generic;

namespace Resources
{
    public enum Resource
    {
        Gold,
        Wood,
        Steel
    }

    public interface IResourceTracker
    {
        void Register(IResourceObserver observer);
        void UnRegister(IResourceObserver observer);
        void NotifyObservers(Resource resourceType);
    }

    public interface IResourceObserver
    {
        void UpdateResource(Resource resourceType, float Value);
    }

    public class ResourceManager:IResourceTracker
    {
        public Dictionary<Resource, float> AvailableResources = new Dictionary<Resource, float>()
        {
            {Resource.Gold, 200 },
            {Resource.Wood, 200 },
            {Resource.Steel, 200 },
        };

        public List<IResourceObserver> ResourceObservers = new List<IResourceObserver>();

        public void Register(IResourceObserver observer)
        {
            ResourceObservers.Add(observer);
        }

        public void UnRegister(IResourceObserver observer)
        {
            ResourceObservers.Remove(observer);
        }

        public void NotifyObservers(Resource resourceType)
        {
            foreach (var observer in ResourceObservers)
            {
                observer.UpdateResource(resourceType, AvailableResources[resourceType]);
            }
        }

        public void NotifyObservers()
        {
            foreach (Resource source in (Resource[])Enum.GetValues(typeof(Resource)))
            {
                NotifyObservers(source);
            }
        }

        public void IncreaseResource(Resource resourceType, float resourceAddedValue)
        {
            AvailableResources[resourceType] += resourceAddedValue;
            NotifyObservers(resourceType);
        }

        public void IncreaseResource( Dictionary<Resource, float> cost )
        {
            foreach( var resource in cost )
            {
                IncreaseResource( resource.Key,resource.Value );
            }
        }

        public void DecreaseResource(Resource resourceType, float resourceAddedValue)
        {
            AvailableResources[resourceType] -= resourceAddedValue;
            NotifyObservers(resourceType);
        }

        public void DecreaseResource(Dictionary<Resource, float> cost)
        {
            foreach (var resource in cost)
            {
                DecreaseResource(resource.Key, resource.Value);
            }
        }

        public bool CanAfford( Dictionary<Resource, float> cost )
        {
            foreach( var resource in cost )
            {
                if( resource.Value > AvailableResources[ resource.Key ] )
                {
                    return false;
                }
            }

            return true;
        }
    }
}
