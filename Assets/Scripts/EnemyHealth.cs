using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public float value = 100;

    public Animator animator;

    public Explosion explosionPrefab;

    public PlayerProgress playerProgress;
    public bool IsAlive()
    {
        return value > 0;
    }

    
    // Start is called before the first frame update
    void Start()
    {
        playerProgress = FindObjectOfType<PlayerProgress>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DealDamage(float damage)
    {
        playerProgress.AddExperience(damage);

        value -= damage;

        if (value <= 0)
        {
            EnemyDeath();
            //Destroy(gameObject);
        }
        else
        {
            animator.SetTrigger("Hit");
        }
    }
    private void EnemyDeath()
    {
        animator.SetTrigger("Death");
        GetComponent<EnemyAI>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
        MobExplosion();
    }
    private void MobExplosion()
    {
        if (explosionPrefab == null) return;
        var explosion = Instantiate(explosionPrefab);
        explosion.transform.position = transform.position;
    }
}
