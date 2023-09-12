using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingPiece : MonoBehaviour
{
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void ExplosionForce()
    {
        rb.isKinematic = false;
        rb.useGravity = true;
        rb.AddForce(transform.position+Vector3.up,ForceMode.Force);
        transform.parent = null;
        Destroy(gameObject, 2f);
    }
}
