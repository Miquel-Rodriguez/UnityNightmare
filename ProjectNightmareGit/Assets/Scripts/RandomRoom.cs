﻿
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
    //public GameObject[] objectsMap;
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
                botDoor();
                break;
            case "L":
                leftDoor();
                break;
            case "R":
                rightDoor();
                break;
            case "TR":
                break;
            case "TB":
                topDoor();
                botDoor();
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

        GameObject instance = Instantiate(doorTile, new Vector3(plantilla.position.x+9f, plantilla.position.y+rows+0.5f, 0f), Quaternion.identity);
        instance.transform.SetParent(gameObject.transform);
    }
    public void botDoor()   
    {
        GameObject instance = Instantiate(doorTile, new Vector3(plantilla.position.x + 9f, plantilla.position.y + 1.5f, 0f), Quaternion.AngleAxis(180, Vector3.forward));
        instance.transform.SetParent(gameObject.transform);
    }
    public void leftDoor()
    {
        GameObject instance = Instantiate(doorTile, new Vector3(plantilla.position.x + 1.5f, plantilla.position.y +rows/2+ 1f, 0f), Quaternion.AngleAxis(90, Vector3.forward));
        instance.transform.SetParent(gameObject.transform);

    }
    public void rightDoor()
    {
        GameObject instance = Instantiate(doorTile, new Vector3(plantilla.position.x + 16.5f, plantilla.position.y + rows / 2 + 1f, 0f), Quaternion.AngleAxis(-90, Vector3.forward));
        instance.transform.SetParent(gameObject.transform);
    }

    public void SetupObjectsMap()
    {
        //GameObject instance = Instantiate(toInstantiate, new Vector3(8f, 0f, 0f), Quaternion.identity);
        //instance.transform.SetParent(boardHolder);
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
