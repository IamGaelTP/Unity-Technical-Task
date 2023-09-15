using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum eBuildingLayer
{
    CONSTRUCTION,
    GROUND_DECORATION
}

[RequireComponent(typeof(PlayerController))]
public class BuildingPlacer : MonoBehaviour
{
    private BuildableItem ActiveBuildable { get; set; }
    [SerializeField] private float maxBuildingDistance = 3f;

    [SerializeField] private ConstructionLayer constructionLayer;
    [SerializeField] private ConstructionLayer groundDecorationLayer;

    [SerializeField] private PreviewLayer previewLayer;
    private PlayerController controller;
    private int buildsLeft = 0;

    public static event Action<BuildableItem> onBuildablePlaced;
    public static event Action onCannotBuild;

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
    }

    private void OnEnable()
    {
        InventoryItemPreview.onBuildingUse += ActiveBuildMode;
        BuildableItemPreview.onBuildingBought += ActiveBuildMode;
    }

    private void OnDisable()
    {
        InventoryItemPreview.onBuildingUse -= ActiveBuildMode;
        BuildableItemPreview.onBuildingBought -= ActiveBuildMode;
    }

    private void ActiveBuildMode(BuildableItem item, int quantity)
    {
        if(GameManager.INSTANCE.currentGameState == eGameStates.GAME_HOUSE)
        {
            SetActiveBuildable(item);
            buildsLeft = quantity;
        }
        else
        {
            onCannotBuild?.Invoke();
        }
    }

    private void Update()
    {
        if (!isMouseWithinBuildableRange() || ActiveBuildable == null)
        {
            if(previewLayer != null)
            {
                previewLayer.ClearPreview();
            }
            return;
        }

        if(ActiveBuildable != null && ActiveBuildable.layer == eBuildingLayer.CONSTRUCTION)
        {
            if (previewLayer != null)
            {
                previewLayer.ShowPreview(ActiveBuildable, controller.pointerDirection, constructionLayer.IsEmpty(controller.pointerDirection));
            }
            
            if (controller.IsMouseButtonPressed(eMouseButton.LEFT) && ActiveBuildable != null && constructionLayer != null && constructionLayer.IsEmpty(controller.pointerDirection))
            {
                constructionLayer.Build(controller.pointerDirection, ActiveBuildable);
                buildsLeft--;
                onBuildablePlaced?.Invoke(ActiveBuildable);
                if (buildsLeft <= 0) ActiveBuildable = null;
            }
        }
        else if (ActiveBuildable != null && ActiveBuildable.layer == eBuildingLayer.GROUND_DECORATION)
        {
            if (previewLayer != null)
            {
                previewLayer.ShowPreview(ActiveBuildable, controller.pointerDirection, groundDecorationLayer.IsEmpty(controller.pointerDirection));
            }
            
            if (controller.IsMouseButtonPressed(eMouseButton.LEFT) && ActiveBuildable != null && groundDecorationLayer != null && groundDecorationLayer.IsEmpty(controller.pointerDirection))
            {
                groundDecorationLayer.Build(controller.pointerDirection, ActiveBuildable);
                buildsLeft--;
                onBuildablePlaced?.Invoke(ActiveBuildable);
                if (buildsLeft <= 0) ActiveBuildable = null;
            }
        }

        
    }

    private bool isMouseWithinBuildableRange()
    {
        return Vector3.Distance(controller.pointerDirection, transform.position) <= maxBuildingDistance;
    }

    public void SetActiveBuildable(BuildableItem item)
    {
        ActiveBuildable = item;
    }

}
