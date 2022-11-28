using RosMessageTypes.Messages;
using UnityEngine;
using Unity.Robotics.ROSTCPConnector;

public class ResetService : MonoBehaviour
{
    //declaring variables
    ROSConnection ros;

    public string serviceName = "reset_srv";

    //connect to ROS and register ROS service caller 
    private void Start()
    {
        ros = ROSConnection.GetOrCreateInstance();
        ros.RegisterRosService<EmptyRequest, EmptyResponse>(serviceName);
    }

    //call service reset_srv on button click and print "Service Called" to console
    public void OnButtonPress()
    {
        EmptyRequest positionServiceRequest = new EmptyRequest();
        ros.SendServiceMessage<EmptyResponse>(serviceName, positionServiceRequest, Callback);
        Debug.Log("Service Called");
    }

    //print "Resetting xArm" to console on callback
    void Callback(EmptyResponse response)
    {
        Debug.Log("Resetting xArm");
    }
}