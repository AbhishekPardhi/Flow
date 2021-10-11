using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslucentObstacle : MonoBehaviour
{
    [SerializeField] private float omega = 2f;

    void Start() {
        omega = Random.Range(0.5f, 1.5f);
    }

    void Update() {
        if(!GameManage.playerDeath) {
            Quaternion smallDisp = Quaternion.AngleAxis(omega, Vector3.forward);
            transform.rotation = smallDisp * transform.rotation;

            transform.position += Vector3.left * GameManage.x_Velocity*Time.deltaTime;
        }

        if(transform.position.x < GameManage.fixedKillDistance)
            Destroy(gameObject);
    }
}
