using UnityEngine;
using System.Collections;
using Windows.Kinect;
using UnityEngine.UI;
public class Game : MonoBehaviour
{
    KinectConnection conn;
	private Text scoreText;
	int score = 0;
    void Start()
    {
        conn = GameObject.Find("KinnectConnection").GetComponent<KinectConnection>();
		scoreText = GameObject.Find ("ScoreText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = conn.GetRightWristPosition();
		
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