using UnityEngine;

using System.Collections;
using Windows.Kinect;
public class Fish : MonoBehaviour
{
	  void Start(){
		  GameObject[]   objs = GameObject.FindGameObjectsWithTag("fish");
		  foreach (GameObject obj in objs) 
		  {
			  Physics.IgnoreCollision(obj.GetComponent<Collider>(), GetComponent<Collider>());
		  }
	  }
}