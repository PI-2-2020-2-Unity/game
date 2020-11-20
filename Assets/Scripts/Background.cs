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

    Vector3Int WorldToGrid(Vector3 position)
    {
        Vector3Int res = tilemap.WorldToCell(position);

        res.z = 0;

        return res;
    }

    // Start is called before the first frame update
    void Start()
    {
        tilemap = GetComponentInChildren<Tilemap>();
        grid = GetComponent<Grid>();

        grid.cellSize = tile.sprite.bounds.size;
        //tilemap.SetTile(Vector3Int.zero, tile);
    }

    // Update is called once per frame
    void Update()
    {
        // TODO Add and remove tiles when the player moves
        if(player)
            tilemap.SetTile(WorldToGrid(player.position), tile);
    }
}

// vim: set expandtab:
