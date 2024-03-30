using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeScatterer : MonoBehaviour
{
    public Grenade grenadePrefab;
    public float forceMin = 50;
    public float forceMax = 700;
    public float delayMin = 1;
    public float delayMax = 3;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnGrenade", Random.Range(delayMin, delayMax));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SpawnGrenade()
    {
        var grenade = Instantiate(grenadePrefab);
        grenade.transform.position = transform.position;

        var direction = Random.onUnitSphere;
        grenade.GetComponent<Rigidbody>().AddForce(direction * Random.Range(forceMin, forceMax));
        Invoke("SpawnGrenade", Random.Range(delayMin, delayMax));
    }
}
