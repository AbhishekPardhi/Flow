using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackBlackHole : MonoBehaviour
{
    private float blackholeSpeed = 4f;
    
    void Update()
    {
        float x_Pos = -6.39f * (GameManage.playerHealth/100.0f);
        if(transform.position.x < x_Pos)
            transform.position += Vector3.right * Time.deltaTime * blackholeSpeed;
        
        if(transform.position.x > x_Pos)
            transform.position += Vector3.left * Time.deltaTime * blackholeSpeed;
    }
}
