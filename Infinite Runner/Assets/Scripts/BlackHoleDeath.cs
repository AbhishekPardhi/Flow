using UnityEngine;

public class BlackHoleDeath : MonoBehaviour
{
    Vector3 blackholeCenter;
    private Rigidbody2D rb;
    private bool isSucking = false;
    private float blackholeRotationSuck = 0.7f;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "blackhole") {
            GetComponent<LightMovement>().enabled = false;
            blackholeCenter = other.gameObject.transform.position;
            GameManage.x_Velocity = 0;
            isSucking = true;
        }
    }

    void Update() {
        if(isSucking) {
            Vector3 direc = transform.position - blackholeCenter;

            //Transform around spiral
            Quaternion smallDisp = Quaternion.AngleAxis(blackholeRotationSuck, Vector3.forward);
            direc = smallDisp * direc;
            rb.transform.position = blackholeCenter + direc * (1 - Time.deltaTime/1);
            
            //Rotate around blackhole
            float angle = Mathf.Atan2(direc.y, direc.x) * Mathf.Rad2Deg;
            Quaternion lookTowards = Quaternion.AngleAxis(angle, Vector3.forward);
            rb.transform.rotation = lookTowards;
            
            //Scale around blackhole
            transform.localScale = transform.localScale * (1 - Time.deltaTime/1);

            //Destroy once small
            if(transform.localScale.x < 0.04)
                Destroy(gameObject);

            //Accelerate falling in
            blackholeRotationSuck += Time.deltaTime/2;
        }
    }
}
