using System.Collections.Generic;
using Buildings;
using Resources;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instant;

        private List<Building> _buildings;

        public ResourceManager ResourceManager;

        public ProductionManager ProductionManager;

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
            ProductionManager.UpdateProductionStates();
        }

    }
}
