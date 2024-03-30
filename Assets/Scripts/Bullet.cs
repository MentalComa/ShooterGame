using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime;
    public float Speed;
    public float Timer;
    public float damage = 10;

    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyBullet", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        transform.position += transform.forward * Speed * Time.fixedDeltaTime;
    }
    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        DamageEnemy(collision);



        DestroyBullet();

        if (!collision.gameObject.CompareTag("Player") && !collision.gameObject.CompareTag("Bullet"))
        {
            DestroyBullet();
        }

       

    }
    private void DamageEnemy(Collision collision)
    {
        var enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.DealDamage(damage);
        }

    }
}
