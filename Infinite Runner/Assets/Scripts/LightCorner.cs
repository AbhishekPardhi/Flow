using UnityEngine;

public class LightCorner : MonoBehaviour
{
    private float pulsate_width = 3.0f;

    void Update() {
        transform.position += Vector3.left * Time.deltaTime * GameManage.x_Velocity;
        transform.localScale = new Vector3(2.5f + GameManage.width*pulsate_width, 2.5f + GameManage.width*pulsate_width, 0);
        if(transform.position.x < GameManage.fixedKillDistance)
            Destroy(gameObject);
    }
}
