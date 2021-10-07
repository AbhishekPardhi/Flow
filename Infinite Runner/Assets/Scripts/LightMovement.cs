using UnityEngine;
//using UnityEngine.Experimental.InputSystem;
using UnityEngine.InputSystem;

public class LightMovement : MonoBehaviour
{
    private float y_Input = 0.0f;
    
    [SerializeField] private float angle_D = 45f;
    [SerializeField] GameObject lightTailPrefab;
    [SerializeField] GameObject lightCornerPrefab;

    LightTail currentLightTail;

    void Start() {
        currentLightTail = Instantiate(lightTailPrefab, transform.position, Quaternion.identity).GetComponent<LightTail>();
        currentLightTail.setStartPoint(transform.position - new Vector3(15, 0, 0));
    }
    void Update() {
        currentLightTail.setEndPoint(transform.position);
        applyMovement();
        //if(Input.GetButtonDown(""))
    }

    void applyMovement() {
        float tmp_Input;
        if(Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.UpArrow)) {
            tmp_Input = 0;
        }
        else if(Input.GetKey(KeyCode.DownArrow)) {
            tmp_Input = -1;
        }
        else if(Input.GetKey(KeyCode.UpArrow)) {
            tmp_Input = 1;
        }
        else {
            tmp_Input = 0;
        }

        if(y_Input != tmp_Input) {
            y_Input = tmp_Input;
            createNewLightTail();
        }

        Vector3 y_Velocity = Vector3.up * y_Input * Time.deltaTime * GameManage.x_Velocity * Mathf.Tan (angle_D * Mathf.PI/180);

        transform.position += y_Velocity;
    }

    void createNewLightTail() {
        Instantiate(lightCornerPrefab, transform.position, Quaternion.identity);
        currentLightTail = Instantiate(lightTailPrefab, transform.position, Quaternion.identity).GetComponent<LightTail>();
        currentLightTail.setStartPoint(transform.position);
        currentLightTail.setEndPoint(transform.position);
    }
}
