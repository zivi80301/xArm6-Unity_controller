using UnityEngine;

public class FollowTrajectory : MonoBehaviour
{
    //declare variables
    public Transform target;

    public float step = 0.01f;

    bool active = false;

    //activates trajectory mode when the corresponding button is pressed
    public void ToggleActive()
    {
        active = true;
        Debug.Log("Button Pressed");
    }

    //moves object to trajectory target on button click
    void Update()
    {
        int code = GameObject.Find("Code").GetComponent<CodeManager>().code;

        if (active && code == 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
        if (Vector3.Distance(transform.position, target.position) < 0.001f)
        {
            active = false;
        }
    }
}