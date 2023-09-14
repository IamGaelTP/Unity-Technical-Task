using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class BuildingPlacer : MonoBehaviour
{
    public BuildableItem ActiveBuildable { get; private set; }
    [SerializeField] private float maxBuildingDistance = 3f;
    [SerializeField] private ConstructionLayer constructionLayer;
    [SerializeField] private PreviewLayer previewLayer;
    private PlayerController controller;
    private int buildsLeft = 0;


    private void Awake()
    {
        controller = GetComponent<PlayerController>();
    }

    private void OnEnable()
    {
        BuildableItemPreview.onBuildingBought += ActiveBuildMode;
    }

    private void OnDisable()
    {
        BuildableItemPreview.onBuildingBought -= ActiveBuildMode;
    }

    private void ActiveBuildMode(BuildableItem item, int quantity)
    {
        ActiveBuildable = item;
        buildsLeft = quantity;
    }

    private void Update()
    {
        if (!isMouseWithinBuildableRange() || ActiveBuildable == null)
        {
            previewLayer.ClearPreview();
            return;
        }

        previewLayer.ShowPreview(ActiveBuildable, controller.pointerDirection, constructionLayer.IsEmpty(controller.pointerDirection));

        if(controller.IsMouseButtonPressed(eMouseButton.LEFT) && ActiveBuildable != null && constructionLayer != null && constructionLayer.IsEmpty(controller.pointerDirection))
        {
            constructionLayer.Build(controller.pointerDirection, ActiveBuildable);
            buildsLeft--;
            if (buildsLeft <= 0) ActiveBuildable = null;
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
