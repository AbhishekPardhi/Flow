using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] private GameObject opaquePrefab;
    [SerializeField] private GameObject blackholePrefab;
    [SerializeField] private GameObject translucentPrefab;

    void Start() {
        InvokeRepeating("createObstacle", 2f, 0.75f);
    }

    void Update() {
        
    }

    void createObstacle() {
        int obstacle = Random.Range(0, 2);
        Vector3 pos = new Vector3(0, 0, 0);
        switch(obstacle) {
            case 0: int num = Random.Range(1, 3);
            for(int i = 0; i < num; i++) {
                pos.y = Random.Range(-4f, 4f);
                pos.x = Random.Range(18f, 20f);
                Instantiate(translucentPrefab, pos, Quaternion.Euler(0, 0, Random.Range(0,360)));
            }
            break;

            case 1: Instantiate(blackholePrefab, new Vector3(20, Random.Range(-4f, 4f), 0), Quaternion.identity);
            break; 
        }
    }
}
