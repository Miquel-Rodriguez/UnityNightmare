using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class MainCamera : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    private float tLX, tLY, bRX, bRY;
    /*
    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        
    }
    
    public void SetBounds(GameObject map)
    {
        float cameraSize = Camera.main.orthographicSize;

        tLX = map.transform.position.x + 4 +cameraSize;
        tLY = map.transform.position.y + cameraSize;
        bRX = map.transform.position.x + 14 - cameraSize;
        bRY = map.transform.position.y + 10 - cameraSize;

        transform.position = new Vector3(
          Mathf.Clamp(target.position.x, tLX, bRX),
          Mathf.Clamp(target.position.y, bRY, tLY),
           transform.position.z);
    }
    */
   
    public  void SetConfiner(CompositeCollider2D limits)
    {
        var virtualCamera = GameObject.FindGameObjectWithTag("VirtualCamera");
        print(virtualCamera.tag);
        print(limits.tag);
        var confiner = virtualCamera.GetComponent<CinemachineConfiner>();
        confiner.InvalidatePathCache();  
        confiner.m_BoundingShape2D = limits;
    }

}
