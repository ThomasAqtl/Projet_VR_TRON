using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour
{
    public KeyCode forwardKey, leftKey, rightKey;
    private float _fwd, _lateralDirection, _right, _left;
    public const float _fwdmin = 0.3f;
    public const float _fwdmax = 1.0f;

    private Player _player;
    public float Fwd{   
        get { return _fwd;}
    }
    public float LateralDirection{
        get { return _lateralDirection; }
    }

    public void Start(){
        _fwd = _fwdmin;
        _right = 0;
        _left = 0;
        _player = GetComponent<Player>();
    }

    public void FixedUpdate(){

        // _fwd and _lateralDirection kind of simulates default horizontal and vertical axis values
        _fwd += Input.GetKey(forwardKey) & _player.IsGrounded ? (_fwd < 1 ? 0.01f : 0) : (_fwd > _fwdmin ? (_fwd < 0.01f ? -_fwd : -0.01f) : 0);
        //print(_player.IsGrounded);
        // moto can't turn if not moving forward
        _right += Input.GetKey(rightKey) ? (_right < 1 ? 0.1f : 0) : (_right > 0 ? (_right < 0.1f ? -_right : -0.1f) : -_right);

        _left += Input.GetKey(leftKey)  ? (_left > -1 ? -0.1f : 0) : (_left < 0 ? (_left > 0.1f ? -_left : 0.1f) : -_left);

        _lateralDirection = _left + _right;
        
    }
}
