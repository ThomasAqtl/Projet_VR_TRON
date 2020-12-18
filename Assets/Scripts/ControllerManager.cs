﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour
{
    public KeyCode forwardKey, leftKey, rightKey;
    public float tilt;
    private float _fwd, _lateralDirection, _right, _left;
    public float Fwd{   
        get { return _fwd;}
    }
    public float LateralDirection{
        get { return _lateralDirection; }
    }

    public void Start(){
        _fwd = 0;
        _right = 0;
        _left = 0;
    }

    public void FixedUpdate(){
        // _fwd and _lateralDirection kind of simulates default horizontal and vertical axis values
        _fwd += Input.GetKey(forwardKey) ? (_fwd < 1 ? 0.1f : 0) : (_fwd > 0 ? (_fwd < 0.01f ? -_fwd : -0.1f) : 0);
        
        // moto can't turn if not moving forward
        _right += Input.GetKey(rightKey) & _fwd != 0 ? (_right < 1 ? 0.1f : 0) : (_right > 0 ? (_right < 0.1f ? -_right : -0.1f) : -_right);

        _left += Input.GetKey(leftKey) & _fwd != 0  ? (_left > -1 ? -0.1f : 0) : (_left < 0 ? (_left > 0.1f ? -_left : 0.1f) : -_left);

        _lateralDirection = _left + _right;
    }
}