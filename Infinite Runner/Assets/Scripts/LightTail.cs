using UnityEngine;

public class LightTail : MonoBehaviour
{
    private LineRenderer lr;
    [SerializeField] private Vector3 startPoint;
    [SerializeField] private Vector3 endPoint;

    void Start() {
        lr = GetComponent<LineRenderer>();
        lr.startWidth = 0.4f;
        lr.endWidth = 0.4f;
    }

    void Update() {
        applyVelocity();
        destroyTail();
        lr.SetPosition(0, startPoint);
        lr.SetPosition(1, endPoint);
    }

    public void setEndPoint(Vector3 endPoint) {
        this.endPoint = endPoint;
    }

    public void setStartPoint(Vector3 startPoint) {
        this.startPoint = startPoint;
    }

    void applyVelocity() {
        startPoint = startPoint + Vector3.left * GameManage.x_Velocity*Time.deltaTime;
        endPoint = endPoint + Vector3.left * GameManage.x_Velocity*Time.deltaTime;
    }

    void destroyTail() {
        if(startPoint.x < GameManage.fixedKillDistance && endPoint.x < GameManage.fixedKillDistance)
            Destroy(gameObject);
    }
}
