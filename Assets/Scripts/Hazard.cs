using UnityEngine;

 
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Hazard : MonoBehaviour
{
    private Collider2D myCollider;
    private object myRigidbody;

    [SerializeField]
    private Rigidbody2D rb;
    
    private int tipo;

    [SerializeField]
    private float resistance = 1F;

    private float spinTime = 1F;

    private bool giro;
    private float movspeed;
    private float move;

    private Vector2 v2;
    //private int ran;

    // Use this for initialization
    protected void Start()
    {
        tipo = Random.Range(1, 4);
        //tipo = 3;
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
            move = 3f;
            movspeed = 1f;
            giro = false;
            InvokeRepeating("Alienmove", 2f, movspeed);
        }
    
    }
    private void Alienmove()
    {
        rb.velocity = Vector2.zero;
        move = move * -1;
        v2 = new Vector2(move, 0);
        rb.AddForce(v2, ForceMode2D.Impulse);
        
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
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Destroy(gameObject);
        }

    }

    public void OnHazardDestroyed()
    {
        //TODO: GameObject should spin for 'spinTime' secs. then disappear
        Destroy(gameObject);
        PlayerPrefs.SetInt("Hazards", PlayerPrefs.GetInt("Hazards") + 1);
    }
}