using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertManager : MonoBehaviour
{
    [SerializeField] private GameObject cannotBuildPanel;

    private void OnEnable()
    {
        BuildingPlacer.onCannotBuild += OnCannotBuild;
    }

    private void OnDisable()
    {
        BuildingPlacer.onCannotBuild -= OnCannotBuild;
    }

    private void OnCannotBuild()
    {
        cannotBuildPanel.SetActive(true);
    }
}
