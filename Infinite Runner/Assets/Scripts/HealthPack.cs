using UnityEngine;

public class HealthPack : MonoBehaviour
{
    void Update()
    {
        transform.position += Vector3.left * GameManage.x_Velocity * Time.deltaTime;
    }
}
