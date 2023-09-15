using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController), typeof(BuildingPlacer))]
public class BuildingSelector : MonoBehaviour
{
    [SerializeField] private List<BuildableItem> buildables;
    private BuildingPlacer buildingPlacer;
    private PlayerController controller;
    private string activeBuildableId;

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
        buildingPlacer = GetComponent<BuildingPlacer>();
    }

    public void SelectItem(string newBuildableId)
    {
        foreach (var buildable in buildables)
        {
            if(buildable.Id == newBuildableId)
            {
                activeBuildableId = newBuildableId;
                buildingPlacer.SetActiveBuildable(buildable);
            }
        }
    }

}
