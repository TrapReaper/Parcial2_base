using System.Collections;
using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Collider2D))]
public class PlayerController : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    [SerializeField]
    private float speed;

    private float movementFactor;
    private bool canFire = true;
    private float coolDownTime = 0.5F;
    private Collider2D myCollider;
    private float pcooldown;
    private bool pactive;
    private bool shield;

    [SerializeField]
    private Object bulletGO;

    [SerializeField]
    private Object bulletAP;

    protected bool InsideCamera(bool positive)
    {
        float direction = positive ? 1F : -1F;
        Vector3 cameraPoint = Camera.main.WorldToViewportPoint(
            new Vector3(
                myCollider.bounds.center.x + myCollider.bounds.extents.x * direction,
                0F,
                0F));
        return cameraPoint.x >= 0F && cameraPoint.x <= 1F;
    }

    private void Start()
    {
        pcooldown = 10f;
        pactive = false;
        myCollider = GetComponent<Collider2D>();

        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectpool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                if (bulletGO != null && Input.GetMouseButtonDown(0) && canFire)
                {

                    GameObject obj = Instantiate(pool.prefab);
                    obj.SetActive(false);
                    objectpool.Enqueue(obj);

                }

                poolDictionary.Add(pool.tag, objectpool);
            }
        }
    }

    // Update is called once per frame
    private void Update()
    {
                
       
        pcooldown -= Time.deltaTime;
        
        movementFactor = Input.GetAxis("Horizontal");

        if (InsideCamera(movementFactor > 0F) && movementFactor != 0F)
        {
            transform.position += new Vector3(movementFactor * speed * Time.deltaTime, 0F, 0F);
        }

        if (bulletGO != null && Input.GetAxis("Fire1") != 0 && canFire)
        {
            Instantiate(bulletGO, transform.position + (transform.up * 0.5F), Quaternion.identity);
            print("Fiyah!");
            StartCoroutine("FireCR");
        }
        if (bulletAP != null && Input.GetAxis("Fire2") != 0 && canFire)
        {
            Instantiate(bulletAP, transform.position + (transform.up * 0.5F), Quaternion.identity);
            print("Fiyah 2!");
            StartCoroutine("FireCR");
        }
        if(Input.GetKeyDown(KeyCode.Keypad0))
        {
            if (pcooldown <= 0)
            {
                // Profe aca tuvimos problemas no fuimos capaz.
                //GameObject haz = GameObject.Find("Hazard");
                //haz.GetComponent <Hazard>().OnHazardDestroyed();
                //Debug.Log("Hazards deben morir");
            }
        }
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            shield = true;
        }
        if (Input.GetKeyUp(KeyCode.Keypad1))
        {
            shield = false;
        }



    }

    private void OnDestroy()
    {
        StopCoroutine("FireCR");
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (shield)
        {
            Debug.Log("Shield Active");
        }
        else
        {
            if (collision.gameObject.GetComponent<Hazard>() != null)
            {
                Time.timeScale = 0F;
                print("Game Over");
            }
        }
        
    }

    private IEnumerator FireCR()
    {
        canFire = false;
        yield return new WaitForSeconds(coolDownTime);
        canFire = true;
    }
}