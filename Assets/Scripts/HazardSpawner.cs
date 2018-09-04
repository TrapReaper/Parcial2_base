using UnityEngine;

public static class SpawnerExtensions
{
    public static Vector3 GetPointInVolume(this Collider2D collider)
    {
        Vector3 result = Vector3.zero;
        result = new Vector3(Random.Range(collider.bounds.min.x, collider.bounds.max.x), collider.transform.position.y, 0F);

        return result;
    }
}

[RequireComponent(typeof(Collider2D))]
public class HazardSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject hazardTemplate;
    [SerializeField]
    private GameObject hazardTemplate1;
    [SerializeField]
    private GameObject hazardTemplate2;

    private Collider2D myCollider;

    

    [SerializeField]
    private float spawnFrequency = 1F;

    // Use this for initialization
    private void Start()
    {
        myCollider = GetComponent<Collider2D>();

        InvokeRepeating("SpawnEnemy", 0.2F, spawnFrequency);
        InvokeRepeating("SpawnEnemy1", 0.2F, spawnFrequency);
        InvokeRepeating("SpawnEnemy2", 0.2F, spawnFrequency);
    }

    private void SpawnEnemy()
    {
        if (hazardTemplate == null)
        {
            CancelInvoke();
        }
        else
        {
            Instantiate(hazardTemplate, myCollider.GetPointInVolume(), transform.rotation);
        }
    }
    private void SpawnEnemy1()
    {
        if (hazardTemplate1 == null)
        {
            CancelInvoke();
        }
        else
        {
            Instantiate(hazardTemplate1, myCollider.GetPointInVolume(), transform.rotation);
        }
    }
    private void SpawnEnemy2()
    {
        if (hazardTemplate2 == null)
        {
            CancelInvoke();
        }
        else
        {
            Instantiate(hazardTemplate2, myCollider.GetPointInVolume(), transform.rotation);
        }
    }
}