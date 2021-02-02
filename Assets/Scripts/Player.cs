using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool _isGrounded;
    public bool IsGrounded
    {
        get { return _isGrounded; }
    }
    public bool collisionExitsGame;
    private CapsuleCollider _collider;
    private BoxCollider _colliderBox;
    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<CapsuleCollider>();
        _colliderBox = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        //print(_isGrounded);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        // to ensure collision with the ground is not considered.
        if (collision.gameObject.name == "Cube")
        {
            if (collision.collider.GetType() == typeof(BoxCollider))
            {
                //print("Collision avec la BOX détéctée !");
                Physics.IgnoreCollision(this._colliderBox, collision.gameObject.GetComponent<Collider>());
            }
            else
            {
                UnityEditor.EditorApplication.isPlaying = !collisionExitsGame;
                //print("Collision détéctée !");
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        _isGrounded = false;
    }

    private void OnCollisionStay(Collision collision)
    {
        _isGrounded = collision.gameObject.tag == "Ground";
    }
}
