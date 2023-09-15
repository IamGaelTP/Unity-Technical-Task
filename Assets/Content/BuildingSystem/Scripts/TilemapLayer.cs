using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps; 

[RequireComponent(typeof(Tilemap))]
public class TilemapLayer : MonoBehaviour
{
    protected Tilemap tilemap { get; private set; }

    protected void Awake()
    {
        tilemap = GetComponent<Tilemap>();
    }
}
