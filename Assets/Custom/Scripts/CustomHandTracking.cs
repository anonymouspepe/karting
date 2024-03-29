using NRKernal;
using NRKernal.NRExamples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomHandTracking : MonoBehaviour
{
    public ItemsCollector itemsCollector;
    public HandModelsManager handModelsManager;

    private void Start()
    {
        NRInput.RaycastersActive = false;
    }

    public void StartHandTracking()
    {
        Debug.Log("HandTrackingExample: StartHandTracking");
        NRInput.SetInputSource(InputSourceEnum.Hands);
    }

    public void StopHandTracking()
    {
        Debug.Log("HandTrackingExample: StopHandTracking");
        NRInput.SetInputSource(InputSourceEnum.Controller);
    }

    public void ResetItems()
    {
        Debug.LogWarning("HandTrackingExample: ResetItems");
        itemsCollector.ResetItems();
    }

    private void OnDestroy()
    {
        StopHandTracking();
    }
}
