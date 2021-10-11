using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackholeMovement : MonoBehaviour
{   
    private float speed = 5.0f;
    void Update() {
        transform.position += Vector3.left * GameManage.x_Velocity*Time.deltaTime;
        transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time * speed, 8) - 4, 0);

        if (transform.position.x < GameManage.fixedKillDistance)
        {
            Destroy(gameObject);
            Debug.Log("destroy");
        }
    }
}
