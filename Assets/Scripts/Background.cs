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
        // TODO Remove tiles when the player moves
        if(player)
        {
            Vector3Int grindPoint = WorldToGrid(player.position);

            for(int x = grindPoint.x-1; x < grindPoint.x+2; ++x)
            {
                for(int y = grindPoint.y-1; y < grindPoint.y+2; ++y)
                {
                    tilemap.SetTile(new Vector3Int(x, y, 0), tile);
                }
            }
        }
    }
}

// vim: set expandtab:
