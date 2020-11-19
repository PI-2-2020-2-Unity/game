using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Background : MonoBehaviour
{
    public Transform player;
    public Tile tile;
    Tilemap tilemap;

    // Start is called before the first frame update
    void Start()
    {
        tilemap = GetComponentInChildren<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        // TODO Add and remove tiles when the player moves
    }
}

// vim: set expandtab:
