﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTest : MonoBehaviour
{
    public Material material1;
    public Material material2;
    public Material material3;

    public Transform cube1;
    public Transform cube2;

    [Range(0f, 1f)]
    public float value;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(cube1.position, cube2.position, value);
        transform.localScale = Vector3.Lerp(cube1.localScale, cube2.localScale, value);
        material3.color = Color.Lerp(material1.color, material2.color, value);
    }
}
