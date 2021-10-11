using UnityEngine;

public class Photon : MonoBehaviour
{
    void Update()
    {
        transform.position += Vector3.left * GameManage.x_Velocity * Time.deltaTime;

        if(transform.position.x < GameManage.fixedKillDistance)
            Destroy(gameObject);
    }
}
