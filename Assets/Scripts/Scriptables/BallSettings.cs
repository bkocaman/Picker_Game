using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSettings : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private BallType ballType = null;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        GetComponent<Renderer>().material.color = ballType.ballColor;
        transform.localScale = ballType.ballScale;
    }

    void Update()
    {
        if (transform.position.y > 0.3f)
        {
            _rb.MovePosition(new Vector3(transform.position.x, 0.3f, transform.position.z));
        }
    }
}
