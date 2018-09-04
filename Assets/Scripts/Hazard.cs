using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Hazard : MonoBehaviour
{
    private Collider2D myCollider;
    private object myRigidbody;

    [SerializeField]
    private int tipo;

    [SerializeField]
    private float resistance = 1F;

    private float spinTime = 1F;

    private bool giro;
    private float movspeed;

    // Use this for initialization
    protected void Start()
    {
        myCollider = GetComponent<Collider2D>();
        myRigidbody = GetComponent<Rigidbody2D>();
        if(tipo == 1)
        {
            giro = false;
        }
        if(tipo == 2)
        {
            giro = true;

        }
        if(tipo == 3)
        {
            movspeed = 2f;
            giro = false;
            InvokeRepeating("Alienmove", 0.8f, movspeed);
        }
    
    }
    private void Alienmove()
    {
        
    }
    private void Update()
    {
        if (giro)
        {
            transform.Rotate(0,0,Time.deltaTime*120);
        }
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Bullet>() != null)
        {

            if (tipo == 3)
            {

                resistance -= 1;

                if (resistance == 0)
                {
                    OnHazardDestroyed();
                }
            }
            else
            {

                //TODO: Make this to reduce damage using Bullet.damage attribute
                resistance -= 1;

                if (resistance == 0)
                {
                    OnHazardDestroyed();
                }
            }
        }
        if(collision.gameObject.GetComponent<Shelter>() != null)
        {
            Destroy(gameObject);
        }
    }

    protected void OnHazardDestroyed()
    {
        //TODO: GameObject should spin for 'spinTime' secs. then disappear
        Destroy(gameObject);
    }
}