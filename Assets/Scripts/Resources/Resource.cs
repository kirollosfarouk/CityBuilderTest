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
        public Dictionary<Resource, float> AvailableResources;

        public List<IResourceObserver> ResourceObservers;

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

        public void UpdateResource(Resource resourceType, float resourceAddedValue)
        {
            AvailableResources[resourceType] += resourceAddedValue;
            NotifyObservers(resourceType);
        }
    }
}
