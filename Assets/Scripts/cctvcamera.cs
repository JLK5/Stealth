using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cctvcamera : MonoBehaviour
{

    Transform cameraLens;
    // Start is called before the first frame update
    void Start()
    {
        Transform cameraPosition = transform.Find("Camera");
        cameraLens = cameraPosition.Find("cctv");
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, Mathf.PingPong(Time.time, 9) * 10 - 45, 0));
    }

}
