using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltHandler : MonoBehaviour
{
    [SerializeField] private float _maxTiltAngle;
    [SerializeField] private float _tiltSpeed;

    private float _tiltMultiplier;

    private GameObject parent;

    private ControllerManager _controller;
    // Start is called before the first frame update
    void Start()
    {
        parent = GameObject.Find("Player");
        _controller = parent.GetComponent<ControllerManager>();

        transform.rotation.eulerAngles.Set(0f, 0f, 0f); // ensure the moto is vertical at start
    }

    // Update is called once per frame
    void Update()
    {
        _tiltMultiplier = _controller.LateralDirection;

        if (_tiltMultiplier != 0){
            if (transform.eulerAngles.x >= 360 - _maxTiltAngle ^ transform.eulerAngles.x <= _maxTiltAngle){
                transform.Rotate(-_tiltMultiplier, 0f, 0f);
            }

            // case when angles boundaries are accidentally
            else {
                if (_tiltMultiplier > 0){
                    transform.localEulerAngles = new Vector3(- _maxTiltAngle, 0f, 0f);
                }
                
                else if (_tiltMultiplier < 0){
                    transform.localEulerAngles = new Vector3(_maxTiltAngle, 0f, 0f);
                }
            }
        }
        // lateral direction == 0 ie moto is not turning
        else {
            transform.rotation = Quaternion.Slerp(transform.rotation, parent.transform.rotation, Time.deltaTime*_tiltSpeed);
        }   
    }
}
