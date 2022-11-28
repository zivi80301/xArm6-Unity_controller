using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.Messages;        

public class PosPublisher : MonoBehaviour
{
    ROSConnection ros;
    public string topicName = "pos_rot";

    // The game object
    public GameObject cube;

    // Publish the cube's position and rotation every N seconds
    public float publishMessageFrequency = 0.5f;

    // Used to determine how much time has elapsed since the last message was published
    private float timeElapsed;

    //connect to ros and start pose publisher
    void Start()
    {
        ros = ROSConnection.GetOrCreateInstance();
        ros.RegisterPublisher<PosRotMsg>(topicName);
    }

    //publish object position and orientation to pos_rot topic every 0.5 seconds as long as mode of operation is not disabled (code 0)
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > publishMessageFrequency)
        {

            PosRotMsg cubePos = new PosRotMsg(        
                cube.transform.position.x,
                cube.transform.position.y,
                cube.transform.position.z,
                cube.transform.rotation.x,
                cube.transform.rotation.y,
                cube.transform.rotation.z,
                cube.transform.rotation.w
            );

            if (GameObject.Find("Code").GetComponent<CodeManager>().code != 0)
            {
                ros.Publish(topicName, cubePos);
            }
            timeElapsed = 0;
        }
    }
}