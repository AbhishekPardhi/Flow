using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpaqueObstacleMovement : MonoBehaviour
{
    [SerializeField] private float omega = 2f;

    void Start() {
        omega = Random.Range(2f, 4f);
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
