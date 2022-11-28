using UnityEngine;

public class CameraController : MonoBehaviour
{
    //declaring variables
    public Transform target;
    public float scale;

    float camera_target_distance = 2.5f;
    float horizontalInput;
    float verticalInput;

    void Update()
    {
        //saving w,a,s,d/arrow keys input to variables
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //moving object in the direction of inputs
        transform.Translate(Vector3.right * horizontalInput * scale);
        transform.Translate(Vector3.up * verticalInput * scale);

        //allows moving obect towards/away from target. In the camera this effecively zooms in or out of the scene. The minimum distance to 
        //the target object is 1.5 meters
        if (camera_target_distance >= 1.5f)
        {
            camera_target_distance += Input.mouseScrollDelta.y * scale;
        }

        else
        {
            camera_target_distance = 1.5f;
        }

        //turn object towards target
        transform.LookAt(target);

        //if distance between target and object is not within tolerance, adjust distance
        float distance = Vector3.Distance(target.position, transform.position) - camera_target_distance;

        if (distance - camera_target_distance > 0.0001f || distance - camera_target_distance < 0.0001f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, distance);
        }
    }
}