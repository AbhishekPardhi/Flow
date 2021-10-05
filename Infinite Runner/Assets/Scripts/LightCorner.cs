using UnityEngine;

public class LightCorner : MonoBehaviour
{
    void Update() {
        transform.position += Vector3.left * Time.deltaTime * GameManage.x_Velocity;
        transform.localScale = new Vector3(3 + GameManage.width*5, 3 + GameManage.width*5, 0);
        if(transform.position.x < GameManage.fixedKillDistance)
            Destroy(gameObject);
    }
}
