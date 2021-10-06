using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject blackBg;
    public GameManage blackBg1;
    public float closeTime = 0.4f;
    public bool closeIn = false;
    public bool closOut = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(closeIn && !closOut)
        {
            blackBg.transform.position += new Vector3(0, (float)(-0.2 * Time.deltaTime * Time.deltaTime / (closeTime * closeTime)), 0);
            blackBg1.transform.position += new Vector3(0, (float)(0.2 * Time.deltaTime * Time.deltaTime / (closeTime * closeTime)), 0);
        }
        else if(!closeIn && closOut)
        {
            blackBg.transform.position += new Vector3(0, (float)(0.2 * Time.deltaTime * Time.deltaTime / (closeTime * closeTime)), 0);
            blackBg1.transform.position += new Vector3(0, (float)(-0.2 * Time.deltaTime * Time.deltaTime / (closeTime * closeTime)), 0);
        }
    }
}
