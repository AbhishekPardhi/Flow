using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackBlackHole : MonoBehaviour
{
    private float blackholeSpeed = 1f;
    
    void Update()
    {
        float x_Pos = -8.5f * (GameManage.playerHealth/100.0f);
        if(transform.position.x < x_Pos)
            transform.position += Vector3.right * Time.deltaTime * blackholeSpeed;
    }
}
