using UnityEngine;
using System.Collections;
using Windows.Kinect;
public class Game : MonoBehaviour
{
    KinectConnection conn;
    void Start()
    {
        conn = GameObject.Find("KinnectConnection").GetComponent<KinectConnection>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = conn.GetRightWristPosition();
		
    }


}