
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRoom : MonoBehaviour
{
    [SerializeField]
    private int columns;
    [SerializeField]
    private int rows;
    [SerializeField]
    private GameObject floorTiles;
    [SerializeField]
    private GameObject wallTiles;
    [SerializeField]
    private GameObject CornerWallTile;
    [SerializeField]
    private GameObject chairTiles;
    [SerializeField]
    private GameObject cornerOutWalls;
    [SerializeField]
    private GameObject floorDegradedTiles;
    [SerializeField]
    private GameObject floorCornerDegradedTiles;

    private float[] angle;

    [SerializeField]
    private GameObject Room;
    [SerializeField]
    private GameObject[] objectsMap;
    //public string doors;
    //public GameObject doorTile;
    [SerializeField]
    private Transform plantilla;

    private Transform boardHolder;
    private List<Vector3> gridPositions = new List<Vector3>();

    /*
    void InitialiseList()
    {
        gridPositions.Clear();
        for (int x = 1; x < columns - 1; x++)
        {
            for (int y = 1; y < columns - 1; y++)
            {
                gridPositions.Add(new Vector3(x, y, 0f));
            }

        }

    }
    */
    void Start()
    {
        angle = new float[] { 0, 90, 180, 270 };
        BoardSetup();
        // InitialiseList();
    }
    void BoardSetup()
    {
        boardHolder = new GameObject("Board").transform;
        GameObject toInstantiate;
        GameObject instance;

        for (int x = -1; x < columns + 1; x++)
        {
            for (int y = -1; y < rows + 1; y++)
            {
                //chairs Wall Tiles
                if (y == rows && x >= 1 && x <= columns-2)
                {
                    toInstantiate = chairTiles;
                    instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.Euler(0, 0, 0));
                }
                else if (y == -1 && x >= 1 && x <= columns-2)
                {
                    toInstantiate = chairTiles;
                    instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.Euler(0, 0, 180));
                }
                else if (x == columns && y <= rows-2 && y >= 1)
                {
                    toInstantiate = chairTiles;
                    instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.Euler(0, 0, 270));
                }
                else if (x == -1 && y <= rows-2 && y >= 1)
                {
                    toInstantiate = chairTiles;
                    instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.Euler(0, 0, 90));
                }

                //wallTiles
                else if (y == rows-1 && x >= 1 && x <= columns-2)
                {
                    toInstantiate = wallTiles;
                    instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.Euler(0, 0, 0));
                }
                else if (x == 0 && y >= 1 && y <= rows-2)
                {
                    toInstantiate = wallTiles;
                    instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.Euler(0, 0, 90));
                }
                else if (y == 0 && x >= 1 && x <= columns-2)
                {
                    toInstantiate = wallTiles;
                    instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.Euler(0, 0, 180));
                }
                else if (x == columns-1 && y >= 1 && y <= rows-2)
                {
                    toInstantiate = wallTiles;
                    instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.Euler(0, 0, 270));
                }
                //CornerTiles
                else if (y == rows-1 && x == 0)
                {
                    toInstantiate = CornerWallTile;
                    instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.Euler(0, 0, 0));
                }
                else if (y == rows-1 && x == columns-1)
                {
                    toInstantiate = CornerWallTile;
                    instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.Euler(0, 0, 270));
                }
                else if (y == 0 && x == 0)
                {
                    toInstantiate = CornerWallTile;
                    instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.Euler(0, 0, 90));
                }
                else if (y == 0 && x == columns-1)
                {
                    toInstantiate = CornerWallTile;
                    instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.Euler(0, 0, 180));
                }
                //corner Out Walls
                else if (y == rows && x == -1 || y == -1 && x == -1 || y == -1 && x == columns || y == rows && x == columns)
                {
                    toInstantiate = cornerOutWalls;
                    instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.Euler(0, 0, 0));
                }
                else if (y == rows-1 && x == -1 || y == 0 && x == -1) {
                    toInstantiate = cornerOutWalls;
                    instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.Euler(0, 0, 0));
                }
                else if (y == rows && x == 0 || y == rows && x == columns-1)
                {
                    toInstantiate = cornerOutWalls;
                    instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.Euler(0, 0, 270));
                }
                else if (y == -1 && x == 0 || y == -1 && x == columns-1)
                {
                    toInstantiate = cornerOutWalls;
                    instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.Euler(0, 0, 90));
                }
                else if (y == rows-1 && x == columns || y == 0 && x == 1)
                {
                    toInstantiate = cornerOutWalls;
                    instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.Euler(0, 0, 180));
                }


                //floor degread
                else if (y == rows-2 && x >= 2 && x <= columns-3)
                {
                    toInstantiate = floorDegradedTiles;
                    instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.Euler(0, 0, 270));
                }
                else if (y == 1 && x >= 2 && x <= columns-3)
                {
                    toInstantiate = floorDegradedTiles;
                    instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.Euler(0, 0, 90));
                }
                else if (x == 1 && y >= 2 && y <= rows-3)
                {
                    toInstantiate = floorDegradedTiles;
                    instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.Euler(0, 0, 0));
                }
                else if (x == columns-2 && y >= 2 && y <= rows-3)
                {
                    toInstantiate = floorDegradedTiles;
                    instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.Euler(0, 0, 180));
                }

                //Corner floor degread
                else if (y == rows-2 && x == 1)
                {
                    toInstantiate = floorCornerDegradedTiles;
                    instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.Euler(0, 0, 0));
                }
                else if (y == rows-2 && x == columns-2)
                {
                    toInstantiate = floorCornerDegradedTiles;
                    instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.Euler(0, 0, 270));
                }
                else if (y == 1 && x == 1)
                {
                    toInstantiate = floorCornerDegradedTiles;
                    instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.Euler(0, 0, 90));
                }
                else if (y == 1 && x == columns-2)
                {
                    toInstantiate = floorCornerDegradedTiles;
                    instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.Euler(0, 0, 180));
                }

                else
                {
                    toInstantiate = floorTiles;
                    instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.Euler(0, 0, angle[Random.Range(0,4)]));
                }

                instance.transform.SetParent(boardHolder);
                
            }
        }
        SetupObjectsMap();
        boardHolder.SetParent(Room.transform);
        boardHolder.Translate(new Vector3(Room.transform.position.x, Room.transform.position.y, 0f));
    }

    public void SetupObjectsMap()
    {
        if (objectsMap.Length>0)
        {
         GameObject toInstantiate = objectsMap[0];
                int repeats = Random.Range(2, 5);
                for (int i = 0; i < repeats; i++)
                {
                    GameObject instance = Instantiate(toInstantiate, new Vector3(plantilla.position.x + Random.Range(3, 14), plantilla.position.y + Random.Range(3, 9), 0f), Quaternion.identity);
                    instance.transform.SetParent(Room.transform);
                }
        }
       
    }
}
