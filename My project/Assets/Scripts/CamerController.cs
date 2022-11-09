using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerController : MonoBehaviour
{

    public GameObject Player;
    public Camera MainCamera;
    public float ZoomSpeed;



    // Start is called before the first frame update
    void Start()
    {

        ZoomSpeed = 2f;
        
    }

    private void Awake()
    {
        MainCamera = GetComponent<Camera>();
    }


    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, transform.position.z);
        if (MainCamera.orthographic)
        {
            MainCamera.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * ZoomSpeed;
        }


        if (MainCamera.orthographicSize >= 14)
        {
            ZoomSpeed = 4f;
        }

        if (MainCamera.orthographicSize >= 30)
        {
            ZoomSpeed = 10f;
        }

        if (MainCamera.orthographicSize <= 14)
        {
            ZoomSpeed = 2f;
        }
        /*if(Input.mouseScrollDelta.y > 0)
        {
            PlayerCamera.orthographicSize += ZoomSpeed * 1;
        }

        if (Input.mouseScrollDelta.y < 0)
        {
            PlayerCamera.orthographicSize -= ZoomSpeed * 1;
        }*/

    }
}
