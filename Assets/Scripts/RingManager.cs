using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEditor;
using UnityEngine;

public class RingManager : MonoBehaviour
{
    public GameObject[] Rings;
    public GameObject RingParent;
    public int no0fRings = 10;
    public float ringDistance = 5f;
    float yPos;
    private void Start()
    {
        for (int i = 0; i < no0fRings; i++)
        {
            if (i == 0)
            {
                SpawnRings(0);
            }
            else
            {
                SpawnRings(Random.Range(1, Rings.Length - 1));
            }

        }
        SpawnRings(Rings.Length-1);
    }
    void SpawnRings(int index)
    {
        GameObject newRing = Instantiate(Rings[index], new Vector3(transform.position.x, yPos, transform.position.z), Quaternion.identity);
        yPos -= ringDistance;
        newRing.transform.parent = RingParent.transform;
    }
}