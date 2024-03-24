using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCast : MonoBehaviour
{
    public Bullet bulletPrefab;
    public Transform bulletSourceTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bulletPrefab, bulletSourceTransform.position, bulletSourceTransform.rotation);
        }
    }
}
