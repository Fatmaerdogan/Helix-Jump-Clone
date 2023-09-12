using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody rb;
    TrailRenderer trailRenderer;
    Color myColor;
    [SerializeField] private float bounceForce;
    public GameObject splitPrefab;
    private void Start()
    {
        trailRenderer = GetComponent<TrailRenderer>();
        myColor= GetComponent<MeshRenderer>().material.color;
        rb = GetComponent<Rigidbody>();
        TrailColorSet();
    }
    private void OnCollisionEnter(Collision other)
    {
        rb.velocity = new Vector3(rb.velocity.x, bounceForce * Time.deltaTime, rb.velocity.z);

        SplitSet(other.transform);

        string materialName = other.transform.GetComponent<MeshRenderer>().material.name;

        GameControl(materialName);
    }
    void SplitSet(Transform other)
    {
        GameObject newsplit = Instantiate(splitPrefab, new Vector3(transform.position.x, other.transform.position.y - 0.4f, transform.position.z), transform.rotation);
        newsplit.transform.localScale = Vector3.one * Random.Range(0.1f, 0.3f);
        newsplit.transform.parent = other.transform;

        newsplit.GetComponent<MeshRenderer>().material.color = myColor;
    }
    void GameControl(string materialName)
    {
        if (materialName == "UnSafe (Instance)")
        {
            bounceForce = 0;
            GameManager.instance.GameEndActive(false);
        }
        if (materialName == "Ground (Instance)")
        {
            GameManager.instance.GameEndActive(true);
        }
    }
    void TrailColorSet()
    {
        trailRenderer.startColor = myColor;
        trailRenderer.endColor = new Color(myColor.r,myColor.g, myColor.b, 0);
    }
}

