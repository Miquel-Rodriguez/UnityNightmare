
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
    private GameObject[] floorTiles;
    [SerializeField]
    private GameObject[] wallTiles;
    [SerializeField]
    private GameObject[] outTiles;
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
        SetupObjectsMap();
        boardHolder.SetParent(Room.transform);
        boardHolder.Translate(new Vector3(Room.transform.position.x, Room.transform.position.y, 0f));
    }

    public void SetupObjectsMap()
    { 
        GameObject toInstantiate = objectsMap[0];
        int repeats = Random.Range(2, 5);
        for (int i = 0; i < repeats; i++)
        {
            GameObject instance = Instantiate(toInstantiate, new Vector3(plantilla.position.x + Random.Range(3, 14), plantilla.position.y + Random.Range(3, 9), 0f), Quaternion.identity);
            instance.transform.SetParent(Room.transform);
        }
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
