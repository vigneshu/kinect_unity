using UnityEngine;

using System.Collections;
using Windows.Kinect;
public class DestroyFishes : MonoBehaviour
{
	void Start () {
	}
	
	  void OnCollisionEnter(Collision collision){
		  if(collision.collider.tag == "fish")
          Destroy(collision.collider.gameObject);
          }
}