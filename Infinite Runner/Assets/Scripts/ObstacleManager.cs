using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] private GameObject opaquePrefab1;
    [SerializeField] private GameObject opaquePrefab2;
    [SerializeField] private GameObject opaquePrefab3;

    [SerializeField] private GameObject blackholePrefab;
    [SerializeField] private GameObject translucentPrefab1;
    [SerializeField] private GameObject translucentPrefab2;

    void Start() {
        InvokeRepeating("createObstacle", 2f, GameManage.spawnRate);
    }

    void Update() {
        if(GameManage.playerDeath)
            CancelInvoke("createObstacle");
    }

    void createObstacle() {
        int obstacle = Random.Range(0, 2);
        Vector3 pos = new Vector3(0, 0, 0);
        switch(obstacle) {
            case 0: int num = Random.Range(1, 3);
            for(int i = 0; i < num; i++) {
                pos.y = Random.Range(-4f, 4f);
                pos.x = Random.Range(18f, 20f);
                int type = Random.Range(0, 2);
                if(type == 0) {
                    int trType = Random.Range(0, 2);
                    switch(trType) {
                        case 0: Instantiate(translucentPrefab1, pos, Quaternion.Euler(0, 0, Random.Range(0,360)));
                        break;

                        case 1: Instantiate(translucentPrefab2, pos, Quaternion.Euler(0, 0, Random.Range(0,360)));
                        break;
                    }
                    
                }
                else {
                    int opType = Random.Range(0, 3);
                    switch(opType) {
                        case 0: Instantiate(opaquePrefab1, pos, Quaternion.Euler(0, 0, Random.Range(0,360)));
                        break;

                        case 1: Instantiate(opaquePrefab2, pos, Quaternion.Euler(0, 0, Random.Range(0,360)));
                        break;

                        case 2: Instantiate(opaquePrefab3, pos, Quaternion.Euler(0, 0, Random.Range(0,360)));
                        break;
                    }
                }
            }
            break;

            case 1: Instantiate(blackholePrefab, new Vector3(20, Random.Range(-3.8f, 3.8f), 0), Quaternion.identity);
            break; 
        }
    }

    public void changeDifficulty() {
        CancelInvoke("createObstacle");
        InvokeRepeating("createObstacle", 0f, GameManage.spawnRate);
    }
}
