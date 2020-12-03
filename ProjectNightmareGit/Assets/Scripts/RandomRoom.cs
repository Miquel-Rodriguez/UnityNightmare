
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRoom : MonoBehaviour
{



    public int columns;
    public int rows;
    public GameObject[] floorTiles;
    public GameObject[] wallTiles;
    public GameObject[] outTiles;
    public GameObject Room;
    public GameObject objectsMap;
    public string doors;
    public GameObject doorTile;

    public Transform plantilla;

    private Transform boardHolder;
    private List<Vector3> gridPositions = new List<Vector3>();

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

    void BoardSetup()
    {
        boardHolder = new GameObject("Board").transform;
        GameObject toInstantiate;
        GameObject instance;

        for (int x = -1; x < columns + 1; x++)
        {
            for (int y = -1; y < rows + 1; y++)
            {
               
                if(y==-1 || x == -1 || y == rows || x == columns)
                {
                     toInstantiate = outTiles[Random.Range(0, floorTiles.Length)];
                     instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity);
                }
                else if(y == 0 || x == 0 || y==rows-1|| x==columns-1)
                {
                    toInstantiate = wallTiles[Random.Range(0, floorTiles.Length)];
                    instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity);
                }
                else
                {
                     toInstantiate = floorTiles[Random.Range(0, floorTiles.Length)];
                     instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity);
                }
                instance.transform.SetParent(boardHolder);
            }
        }
        SetupDoors(doors);
        SetupObjectsMap();
        boardHolder.SetParent(Room.transform);
        boardHolder.Translate(new Vector3(Room.transform.position.x, Room.transform.position.y, 0f));
    }

    public void SetupDoors(string doors)
    {
        switch (doors)
        {
            case "T":
                topDoor();
                break;
            case "B":
                break;
            case "L":
                break;
            case "R":
                break;
            case "TR":
                break;
            case "TB":
                break;
            case "TL":
                break;
            case "BL":
                break;
            case "BR":
                break;
            case "LR":
                break;
            case "3T":
                break;
            case "3B":
                break;
            case "3R":
                break;
            case "3L":
                break;
            case "A":
                break;
        }
    }

    public void topDoor()
    {
        
        Instantiate(doorTile, new Vector3(plantilla.position.x+9+0.5f, plantilla.position.y+rows+0.5f, 0f), Quaternion.identity);
        
    }
    public void botDoor()   
    {
        Instantiate(doorTile, new Vector3(9,  0, 0f), Quaternion.identity);
    }
    public void leftDoor()
    {
        Instantiate(doorTile, new Vector3(5, 0, 0f), Quaternion.identity);
    }
    public void rightDoor()
    {
        Instantiate(doorTile, new Vector3(columns-1, 0, 0f), Quaternion.identity);
    }


    public void SetupObjectsMap()
    {
        GameObject toInstantiate = objectsMap;
        GameObject instance = Instantiate(toInstantiate, new Vector3(8f, 0f, 0f), Quaternion.identity);
        instance.transform.SetParent(boardHolder);
    }
    
    
    void Start()
    {
        BoardSetup();
        InitialiseList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
