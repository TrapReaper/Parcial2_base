using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;

    private Collider2D myCollider;
    private Rigidbody2D myRigidbody;

    [SerializeField]
    private float force = 10F;

    [SerializeField]
    private float autoDestroyTime = 5F;

    [SerializeField]
    private int tipo;

    // Use this for initialization
    private void Start()
    {
        myCollider = GetComponent<Collider2D>();
        myRigidbody = GetComponent<Rigidbody2D>();

        myRigidbody.AddForce(transform.up * force, ForceMode2D.Impulse);

        Invoke("AutoDestroy", autoDestroyTime);
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if(tipo == 2)
        {
            if (collision.gameObject.GetComponent<Hazard>() != null)
            {
                Debug.Log("Paso hazard");
            }
        }
        else
        {
            AutoDestroy();
        }
    }

    private void AutoDestroy()
    {
        Destroy(gameObject);
        Destroy(gameObject);
    }
}