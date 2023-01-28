using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissiveObject : MonoBehaviour
{
    private MeshRenderer _renderer;
    private Material _material;
    private void Awake()
    {
        //_material = GetComponent<MeshRenderer>().material;
    }

    private void Start()
    {
        if (_material == null)
        {
            Debug.Log("should be null then i guess" + _material);
        }
        Debug.Log("what the fuck is going on" + _material);
    }

    public void InitializeEmisiveObject()
    {
        _material = GetComponent<MeshRenderer>().sharedMaterial;
    }

    public void ChangeEmissiveColor(Color color)
    {
        _material.SetColor("_BaseColor", color);
        _material.SetColor("_EmissionColor", color);
    }
}
