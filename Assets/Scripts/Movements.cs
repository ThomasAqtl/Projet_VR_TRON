using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{
    public float tilt;
    public float speed;
    public float sensibility;
    private ControllerManager _controller;
    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<ControllerManager>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
         
        transform.Translate(Vector3.right * _controller.Fwd * speed * Time.deltaTime, Space.Self);
        transform.Rotate(Vector3.up * _controller.LateralDirection * sensibility * Time.deltaTime, Space.World);
    }


    void FixedUpdate()
    { /*
        float tiltAroundX = _controller.LateralDirection * -tilt;

        Quaternion target = Quaternion.Euler(tiltAroundX, 0, 0);

        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime*2f); */
    }
}
