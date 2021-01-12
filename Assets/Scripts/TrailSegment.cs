using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailSegment : MonoBehaviour
{
    public bool trailVisible;

    private const float _yscale = 1.0f;
    private const float _zscale = 0.01f;

    private float _length = 1.0f; // x scale is horizontal length, may changes
    public float Length
    {
        get { return _length; }
    }

    // relative to object that shapes a segment of the trail.
    private BoxCollider _collider; 
    private GameObject _block;
    private Renderer _renderer;

    // to access some variables (speed and lateral direction)
    private ControllerManager _cm;
    private Movements _mv;


    // Start is called before the first frame update
    void Start()
    {
        _mv = GetComponent<Movements>();
        _cm = GetComponent<ControllerManager>();

        _block = GameObject.CreatePrimitive(PrimitiveType.Cube);
        _block.transform.localScale = new Vector3(_length, _yscale, _zscale);
        _block.transform.position = new Vector3(transform.position.x - 2f, transform.position.y + 0.5f, transform.position.z);

        _renderer = _block.GetComponent<Renderer>();
        _renderer.enabled = trailVisible;
    }

    // Update is called once per frame
    void Update()
    {
        if (_cm.LateralDirection == 0)
        {
            _block.transform.localScale += Vector3.right * Time.deltaTime * _mv.speed * _cm.Fwd;
            _block.transform.position += (transform.right * Time.deltaTime * _mv.speed * _cm.Fwd) / 2;
        }

        else
        {
            _block = GameObject.CreatePrimitive(PrimitiveType.Cube);
            _block.transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, 0f);
            _block.transform.localScale = new Vector3(_length*(1.05f - Mathf.Abs(_cm.LateralDirection)), _yscale, _zscale);
            _block.transform.position = transform.position - transform.right*2f + 0.5f*Vector3.up;

            // handles visibility
            _renderer = _block.GetComponent<Renderer>();
            _renderer.enabled = trailVisible;
        }
    }
}
