using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFix : MonoBehaviour
{
    public BallColor script;
    public Renderer EnemyRender;

    // Start is called before the first frame update
    void Start()
    {
        script = GameObject.Find("Bullet").GetComponent<BallColor>();
        EnemyRender = GetComponent<Renderer>();
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Renderer>().material.color = EnemyRender.material.color;





        }
    }
}
