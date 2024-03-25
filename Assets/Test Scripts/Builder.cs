using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{
    public Camera Camera;
    public GameObject CubePrefab;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
        Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameObject cube = Instantiate(CubePrefab);
                cube.transform.position = hit.point;
            }
            if (Input.GetMouseButtonDown(1))
            {
                Destroy(hit.collider.gameObject);
            }
        }
    }
}
