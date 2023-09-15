using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ExtensionMethodsMono : MonoBehaviour
{

    public static event Action onHideObject;

    // TO DO -> ADD ALL THE ExtensionMethods.cs METHODS


    public void DestroyObject()
    {
        this.gameObject.DestroyObject();
    }

    public void HideDirectParent()
    {
        onHideObject?.Invoke();
    }

}
