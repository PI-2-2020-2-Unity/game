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
        tilemap.ClearAllTiles();
    }

    // Update is called once per frame
    void Update()
    {
        if(player)
        {
            Vector3Int grindPoint = WorldToGrid(player.position);

            for(int x = grindPoint.x-2; x < grindPoint.x+3; ++x)
            {
                for(int y = grindPoint.y-2; y < grindPoint.y+3; ++y)
                {
                    Vector3Int cell = new Vector3Int(x, y, 0);

                    if(
                        x > grindPoint.x-2 && x < grindPoint.x+2 &&
                        y > grindPoint.y-2 && y < grindPoint.y+2
                    ) // In 3x3
                    {
                        tilemap.SetTile(cell, tile);
                    }
                    else
                    {
                        tilemap.SetTile(cell, null);
                    }
                }
            }
        }
    }
}

// vim: set expandtab:
