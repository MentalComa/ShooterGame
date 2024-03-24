using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallColor : MonoBehaviour
{
    public int RandomNumber;
    public Transform[] ParticleSystemLocation;
    public GameObject objectToSpawn;
    public Renderer PaintColor;
    public Renderer StuffBall;
    public GameObject Ball;
    public Renderer ColorBall;
    public static float NumberOfBalls;
    public Renderer EnemyRender;

    // Start is called before the first frame update
    void Start()
    {
        Ball = GameObject.FindGameObjectWithTag("Bullet");
        Color newColor = new Color32(System.Convert.ToByte(Random.Range(0, 255)), System.Convert.ToByte(Random.Range(0, 255)), System.Convert.ToByte(Random.Range(0, 255)), 255);
        ColorBall = GetComponent<Renderer>();
        ColorBall.material.color = newColor;
        
        
        

    }




    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {

        if (!collision.gameObject.CompareTag("Terrain") && !collision.gameObject.CompareTag("Player")  && !collision.gameObject.CompareTag("Bullet") && !collision.gameObject.CompareTag("NoPainting"))
        {
            collision.gameObject.GetComponent<Renderer>().material.color = ColorBall.material.color;

            



        }


    }

}
