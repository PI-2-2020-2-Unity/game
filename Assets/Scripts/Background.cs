using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Background : MonoBehaviour
{
    public Transform player;
    public Tile tile;
    Tilemap tilemap;
    Grid grid;

    // Start is called before the first frame update
    void Start()
    {
        tilemap = GetComponentInChildren<Tilemap>();
        grid = GetComponent<Grid>();

        Bounds spriteBox = tile.sprite.bounds;

        Debug.Log(tile.sprite.bounds);

        grid.cellSize = spriteBox.size;

        tilemap.SetTile(Vector3Int.zero, tile);
    }

    // Update is called once per frame
    void Update()
    {
        // TODO Add and remove tiles when the player moves
        //tilemap.SetTile(Vector3Int.FloorToInt(player.position), tile);
    }
}

// vim: set expandtab:
