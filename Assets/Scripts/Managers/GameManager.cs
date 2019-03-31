using System.Collections.Generic;
using Buildings;
using Resources;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        private List<Building> _buildings;
        private List<IProduction> _onGoingProductions;
        public static GameManager Instant;

        public ResourceManager ResourceManager;

        // Start is called before the first frame update
        void Start()
        {
            if (Instant == null)
            {
                Instant = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        // Update is called once per frame
        void Update()
        {
            UpdateProductionStates();
        }

        private void UpdateProductionStates()
        {
            foreach (var production in _onGoingProductions)
            {
                production.UpdateProduction(Time.deltaTime);
            }
        }
    }
}
