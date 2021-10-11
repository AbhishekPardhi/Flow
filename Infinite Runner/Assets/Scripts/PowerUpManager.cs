using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    [SerializeField] private GameObject shieldPrefab;
    [SerializeField] private GameObject photonPrefab;

    [SerializeField] private float shieldProbability = 0.01f;

    [SerializeField] private float photonProbability = 0.2f;

    void Start() {
        //InvokeRepeating("spawnShield", 0f, 1f);
        InvokeRepeating("spawnPhoton", 0f, 1f);
    }
    void Update() {
        
    }

    void spawnShield() {
        float f = Random.Range(0f, 1f);
        if(f < shieldProbability)
            Instantiate(shieldPrefab, new Vector3(20, Random.Range(-4f, 4f), 0), Quaternion.identity);
    }

    void spawnPhoton() {
        float f = Random.Range(0f, 1f);
        if(f < photonProbability)
            Instantiate(photonPrefab, new Vector3(20, Random.Range(-4f, 4f), 0), Quaternion.identity);
    }
}
