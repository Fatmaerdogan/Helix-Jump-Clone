using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class Ring : MonoBehaviour
{
    [SerializeField] private List<RingPiece> Pieces;
    private Transform player; 
    private void Start()
    {
        player = GameObject.Find("Ball").transform;
        PiecesAdd();
    }
    private void Update()
    {
        if (transform.position.y-0.5f > player.position.y)
        {
            Pieces.ForEach(x =>
            {
                x.ExplosionForce();
            });
            this.enabled = false;
        }          
        
    }
    void PiecesAdd()
    {
        foreach (Transform child in transform)
        {
            if (child.GetComponent<RingPiece>() != null) Pieces.Add(child.GetComponent<RingPiece>());
        }
    }
}