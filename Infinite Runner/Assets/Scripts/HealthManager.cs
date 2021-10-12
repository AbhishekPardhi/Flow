using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(transform.position);
        transform.position =new Vector3(-3.7f + GameManage.playerHealth*1.5f / 100.0f,4f,0f);
    }
}
