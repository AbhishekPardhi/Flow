using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    [SerializeField] private GameObject shieldPrefab;
    [SerializeField] private GameObject something;

    [SerializeField] private float shieldProbability = 0.01f;

    void Start() {
        InvokeRepeating("spawnShield", 0f, 1f);
    }
    void Update() {
        //spawnShield();
    }

    void spawnShield() {
        float f = Random.Range(0f, 1f);
        if(f < shieldProbability)
            Instantiate(shieldPrefab, new Vector3(20, Random.Range(-4f, 4f), 0), Quaternion.identity);
    }
}
