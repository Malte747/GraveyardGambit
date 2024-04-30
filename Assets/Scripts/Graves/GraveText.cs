using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveText : MonoBehaviour
{
    public Camera camera;

    void Start()
    {
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    void LateUpdate()
    {
        transform.LookAt(transform.position + camera.transform.forward);
    }


}
