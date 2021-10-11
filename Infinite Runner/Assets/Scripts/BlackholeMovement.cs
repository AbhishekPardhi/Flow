using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackholeMovement : MonoBehaviour
{   
    private float maxSpeed = 15.0f;
    private float fracConstant = 0.7f;
    private int velDir = 1;

    private Animator m_Animator;

    void Start() {
        maxSpeed = Random.Range(5, 20);
        m_Animator = GetComponent<Animator>();
    }

    void Update() {
        if(!GameManage.playerDeath) {
            transform.position += Vector3.left * GameManage.x_Velocity*Time.deltaTime;
            oscillate();
        }

        if(GameManage.playerDeath) {
           m_Animator.SetFloat("animSpeed", 0);
        }

        if(transform.position.x < GameManage.fixedKillDistance)
            Destroy(gameObject);
    }

    void oscillate() {
        if(transform.position.y > GameManage.screenRoof && velDir == 1)
            velDir = -1;
        else if(transform.position.y < GameManage.screenFloor && velDir == -1)
            velDir = 1;
        
        float speed = maxSpeed - maxSpeed * fracConstant * Mathf.Abs(transform.position.y)/4f;
        transform.position += Vector3.up * speed * velDir * Time.deltaTime;
    }
}
