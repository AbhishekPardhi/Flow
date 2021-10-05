using UnityEngine;

public class LightCorner : MonoBehaviour
{
    void Update() {
        transform.position += Vector3.left * Time.deltaTime * GameManage.x_Velocity;
        if(transform.position.x < GameManage.fixedKillDistance)
            Destroy(gameObject);
    }
}
