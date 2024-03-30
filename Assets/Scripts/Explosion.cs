using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float maxSize = 5;
    public float speed = 1;
    public float damage = 50;
    public Renderer coloring;
    // Start is called before the first frame update
    void Start()
    {
        Color newColor = new Color32(255, 255, 255, 128);
        coloring = GetComponent<Renderer>();
        coloring.material.color = newColor;
        transform.localScale = Vector3.zero;

       
    }

    // Update is called once per frame
    void Update()
    {

        transform.localScale += Vector3.one * Time.deltaTime * speed;
        if (transform.localScale.x > maxSize)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Terrain") && !other.gameObject.CompareTag("Player") && !other.gameObject.CompareTag("Bullet") && !other.gameObject.CompareTag("NoPainting"))
        {

            other.gameObject.GetComponent<Renderer>().material.color = coloring.material.color;
        }



            var playerHealth = other.GetComponent<PlayerHealth>();
        if (playerHealth !=null)
        {
            playerHealth.DealDamage(damage);
        }

        var enemyHealth = other.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.DealDamage(damage);
        }


    }
   
}
