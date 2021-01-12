using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailColorHandler : MonoBehaviour
{
    private TrailRenderer _trail;
    private ControllerManager _cm;
    // Start is called before the first frame update
    void Start()
    {
        _trail = GetComponent<TrailRenderer>();
        _cm = GetComponentInParent<ControllerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_cm.Fwd >= 0.7f)
        {
            _trail.startColor = Color.white;
        }
        else
        {
            _trail.startColor = Color.cyan;
        }
    }
}
