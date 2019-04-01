using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Buildings;
using Managers;
using Resources;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour,IResourceObserver
{
    public Text GoldResource;
    public Text WoodResource;
    public Text IronResource;

    public GameObject BuildMenuPanel;
    public GameObject SelectedBuildingPanel;
    public Building SelectedBuilding;
    public Scrollbar ProductionProgressBar;
    public TextMeshProUGUI BuildingName;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.ResourceManager.Register( this );
    }
    // Update is called once per frame
    void Update()
    {
        if( SelectedBuilding != null && SelectedBuilding.ProductionType.CurrentProductionStates!=ProductionStates.Idle)
        {
            ProductionProgressBar.size = SelectedBuilding.ProductionType.ProductionProgress;
        }

        checkForSelection();
    }

    void checkForSelection()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f,LayerMask.GetMask( "Building" )))
            {
                if (hit.transform != null)
                {
                   SelectedBuilding =  GameManager.Instance.Buildings.FirstOrDefault(
                        x => x.BuildingGameObject.transform == hit.transform );

                    OnBuildingSelected();
                }
            }
        }
    }


    public void UpdateResource( Resource resourceType, float Value )
    {
        switch (resourceType)
        {
            case Resource.Gold:
                GoldResource.text = Value.ToString();
                break;
            case Resource.Wood:
                WoodResource.text = Value.ToString();
                break;
            case Resource.Steel:
                IronResource.text = Value.ToString();
                break;
        }
    }

    public void BuildModeClick()
    {
        BuildMenuPanel.SetActive( true );
        SelectedBuilding = null;
        SelectedBuildingPanel.SetActive( false );
    }

    public void RegularModeClick()
    {
        BuildMenuPanel.SetActive(false);
    }

    public void OnBuildingSelected()
    {
        BuildMenuPanel.SetActive( false );
        SelectedBuildingPanel.SetActive( true );
        BuildingName.text = SelectedBuilding.BuildingName;
        ProductionProgressBar.size = 0;
    }

    public void StartSelectedProduction()
    {
        if( SelectedBuildingPanel != null )
        {
            SelectedBuilding.ProductionType.StartProduction();
        }
    }

    public void OnButtonClick( int buildingType )
    {
       GameManager.Instance.AddBuilding( (BuildingType)buildingType );
    }
}
