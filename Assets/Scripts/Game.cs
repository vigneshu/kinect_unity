using UnityEngine;
using System.Collections;
using Windows.Kinect;
using UnityEngine.UI;
public class Game : MonoBehaviour
{
    KinectConnection conn;
	private Text scoreText;
	GameObject PlayerLeftWrist;
	int score = 0;
    void Start()
    {
        conn = GameObject.Find("KinnectConnection").GetComponent<KinectConnection>();
		PlayerLeftWrist = GameObject.Find("PlayerLeftWrist");
		
		try{
			scoreText = GameObject.Find ("ScoreText").GetComponent<Text>();
		}
		catch{
			Debug.Log("No score text found");
		}
    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.transform.position = conn.GetRightWristPosition();
		gameObject.transform.position = conn.GetJointPosition(JointType.WristRight);
		PlayerLeftWrist.transform.position = conn.GetJointPosition(JointType.WristLeft);
		
    }
	void OnCollisionEnter (Collision collision)
	{
		  if(collision.collider.tag == "fish")
		  {	
			Destroy(collision.collider.gameObject);
			score++;
			scoreText.text = "Score: " + score.ToString(); //set score text every frame
		  }
    }	

}