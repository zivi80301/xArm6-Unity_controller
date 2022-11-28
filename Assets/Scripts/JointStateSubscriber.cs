using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using JointStates = RosMessageTypes.Messages.JointStatesMsg;

public class JointStateSubscriber : MonoBehaviour
{
    //declaring variables
    public int angle1 = 0;
    public int angle2 = 0;
    public int angle3 = 0;
    public int angle4 = 0;
    public int angle5 = 0;

    public Transform joint1;
    public Transform joint2;
    public Transform joint3;
    public Transform joint4;
    public Transform joint5;

    //register ros subscriber
    void Start()
    {
        ROSConnection.GetOrCreateInstance().Subscribe<JointStates>("joint_states", MirrorJoints);
    }

    //get joint angles from joint_states topic and rotate bones accordingly
    void MirrorJoints(JointStates jointMessage)
    {
        angle1 = jointMessage.j1;
        angle2 = jointMessage.j2;
        angle3 = jointMessage.j3;
        angle4 = jointMessage.j4;
        angle5 = jointMessage.j5;

        joint1.rotation = Quaternion.Euler(0, 180 - angle1, 0);
        joint2.rotation = joint1.rotation * Quaternion.Euler(0, 0, 10 + angle2);
        joint3.rotation = joint2.rotation * Quaternion.Euler(0, 0, 145 + angle3);
        joint4.rotation = joint3.rotation * Quaternion.Euler(0, 0, 25) * Quaternion.Euler(0, -angle4, 0);
        joint5.rotation = joint4.rotation * Quaternion.Euler(0, 0, -38 + angle5);
    }
}