using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class Movements : MonoBehaviour
{
    public int tilt;
    public float speed;
    public float sensibility;
    private ControllerManager _controller;
    private Player _player;
    private Rigidbody _rigidbody;
    private bool _forceSubie;

    private Vector3 _forceajoutee;
    private int _TEMPCOUNT;

    //public const bool _debuug = true;
    //public debuug(arg argument) {if (_debuug == true){print(arg);}}

    public IEnumerator Jump(Vector3 _forceajoutee)
    {
        _rigidbody.AddForce(_forceajoutee); //Vector3.right * _controller.Fwd * speed);
        print(_forceajoutee);
        yield return new WaitUntil(() => _player.IsGrounded == true);
        _forceSubie = false;
        _rigidbody.velocity = Vector3.zero;
    }

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<ControllerManager>();
        _player = GetComponent<Player>();
        _rigidbody = GetComponent<Rigidbody>();

        _forceSubie = false;
        _forceajoutee = Vector3.right;
        _TEMPCOUNT = 0;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //print(Vector3.right * _controller.Fwd * speed);

        if (_player.IsGrounded)
        {
            transform.Translate(Vector3.right * _controller.Fwd * speed * Time.deltaTime, Space.Self);
            transform.Rotate(Vector3.up * _controller.LateralDirection * sensibility * Time.deltaTime, Space.World);

            float tiltAroundX = -tilt * _controller.LateralDirection;
            transform.Rotate(tiltAroundX, 0, 0, Space.Self);
            transform.eulerAngles = new Vector3(tiltAroundX, transform.eulerAngles.y, transform.eulerAngles.z);
        }
        else
        {
            if (!_forceSubie)
            {
                _forceSubie = true;
                StartCoroutine(Jump(Vector3.right * _controller.Fwd * speed * 0.3f / Time.deltaTime)); // fonction dont la boucle est indépendante de la boucle de jeu.

                _TEMPCOUNT++;
                //print("FORCE : "+ _TEMPCOUNT);
            }
        }
    }


    void FixedUpdate()
    { 
        //float tiltAroundX = Mathf.Floor(_controller.LateralDirection )* -tilt;
        //print(tiltAroundX);
        ////Quaternion target = Quaternion.Euler(0, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        //Quaternion target = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);

        //transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime*2f); 
    }
}
