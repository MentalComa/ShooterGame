using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalTransparency : MonoBehaviour
{
    public GameObject Crystal;
    public Renderer TransparencyCrystal;
    public Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        Crystal = GameObject.FindGameObjectWithTag("Grenade");
        Color newColor = new Color32(255, 255, 255, System.Convert.ToByte(Random.Range(1, 255)));
        TransparencyCrystal = GetComponent<Renderer>();
        TransparencyCrystal.material.color = newColor;
        renderer = GetComponent<Renderer>();
    }
    
    // Update is called once per frame
    void Update()
    {

        renderer.material.SetFloat("_Mode", 0);
    }
}
