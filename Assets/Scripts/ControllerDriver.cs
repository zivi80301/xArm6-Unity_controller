using UnityEngine;

public class ControllerDriver : MonoBehaviour
{
    //declaring variables
    public Transform target;
    public Transform first_joint;

    public float speakerLength = 0.2f;
    public float maxRange = 0.6f;

    Vector3 mOffset;
    float mZCoord;

    float radius;

    Vector3 initialPosition;
    Quaternion initialRotation;

    //set 3d coordinate from cursor projected onto collidor
    private void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    }

    //get point in 3d space from cursor position on screen
    Vector3 GetMouseAsWorldPoint()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    //move collidor object to point from mouse curser
    private void OnMouseDrag()
    {
        transform.position = GetMouseAsWorldPoint() + mOffset;
        
        if (OutOfRange(first_joint.position, target.position, transform.position, speakerLength, maxRange))
        {
            transform.position = Vector3.MoveTowards(transform.position, first_joint.position, Vector3.Distance(transform.position, first_joint.position) - maxRange);
        }

        transform.position = Vector3.MoveTowards(transform.position, target.position, Vector3.Distance(transform.position, target.position) - radius);
    }

    //allows changing radius around which the speaker orbits. Called from radius input field
    public void SetRadius(string radiusInput)
    {
        if (!float.TryParse(radiusInput, out radius)) radius = 1.0f;
    }

    //reset object position to initial position. Called from reset button
    public void resetPosition()
    {
        transform.SetPositionAndRotation(initialPosition, initialRotation);
    }

    //reterns whether endeffectortwin is placed outside the range of the xarm
    bool OutOfRange(Vector3 first_joint, Vector3 target, Vector3 controller, float speakerLength, float maxRange)
    {
        Vector3 endeffector = Vector3.MoveTowards(target, controller, radius + speakerLength);
        return Vector3.Distance(first_joint,endeffector) > maxRange;
    }

    //sets initial radius to 1 meter and sets initial transform of object
    private void Start()
    {
        radius = target.localScale.x / 2;
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    //turns and sticks object towards target sphere and makes sure it does not exit the range of the xarm. changing radius using the input field
    //allows a constant offset to the sphere
    void Update()
    {
        if (OutOfRange(first_joint.position, target.position, transform.position, speakerLength, maxRange))
        {
            transform.position = Vector3.MoveTowards(transform.position, first_joint.position, Vector3.Distance(transform.position, first_joint.position) - maxRange);
        }

        transform.position = Vector3.MoveTowards(transform.position, target.position, Vector3.Distance(transform.position, target.position) - radius);

        transform.LookAt(target, Vector3.back);
        transform.Rotate(90, 0, 180);
    }
}