using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform target;
    float tLX, tLY, bRX, bRY;
    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        transform.position = new Vector3(
           Mathf.Clamp(target.position.x,tLX,bRX),
           Mathf.Clamp(target.position.y, bRY, tLY),
            transform.position.z);
    }

    public void SetBounds(GameObject map)
    {
        float mapY = 10;
        float mapX = 17;
        float cameraSize = Camera.main.orthographicSize;

        tLX = map.transform.position.x + 4 +cameraSize;
        tLY = map.transform.position.y + cameraSize;
        bRX = map.transform.position.x + 14 - cameraSize;
        bRY = map.transform.position.y + 10 - cameraSize;
    }

}
