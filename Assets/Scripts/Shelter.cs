using UnityEngine;

public class Shelter : MonoBehaviour
{
    [SerializeField]
    private int maxResistance = 5;
    public int Resistance;
    [SerializeField]
    private float regentime;
    private float count;
    private float timer;
    private bool Actregen;

    private void Start()
    {
        regentime = 5f;
        Resistance = maxResistance;
        Actregen = false;
    }

    public int GetResistance()
    {
        return Resistance;
    }
    public int MaxResistance
    {
        get
        {
            return maxResistance;
        }
        protected set
        {
            maxResistance = value;
        }
    }

    public void Damage(int damage)
    {
        Resistance -= damage;
        count = timer;
        Actregen = true;
    }

    public void RegenResistance()
    {
        if(Resistance <= 0)
        {
            Debug.Log("Shelter dead");
        }
        else
        {
            if (Resistance < maxResistance)
            {
                Resistance += 1;
                Debug.Log("Regenero");
            }
            else
            {
                Resistance = maxResistance;
                Debug.Log("Regenero al maximo");
            }
        }
        
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Hazard>() != null)
        {
            Damage(1);
            
            Debug.Log("hit");
        }
        

    }

    public void Update()
    {
        timer += Time.deltaTime;
        if (Actregen)
        {
            if(timer-count >= regentime)
            {
                RegenResistance();
            }
        }
        if (Resistance <= 0)
        {
            Destroy(this);
            Debug.Log("Shelter dead");
            Time.timeScale = 0F;
            print("Game Over");
        }
    }
}