using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private BallSettings ballSettings = null;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        GetComponent<Renderer>().material.color = ballSettings.ballColor;
        transform.localScale = ballSettings.ballScale;
    }

    void Update()
    {
        if (transform.position.y > 0.3f)
        {
            _rigidbody.MovePosition(new Vector3(transform.position.x, 0.3f, transform.position.z));
        }
    }
}
