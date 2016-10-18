using UnityEngine;

using System.Collections;
using Windows.Kinect;
public class Fishes : MonoBehaviour
{
	GameObject sphereFish ;
	void Start () {
		sphereFish = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		sphereFish.GetComponent<Renderer>().enabled = false;
		sphereFish.GetComponent<Collider>().enabled = false;
		sphereFish.tag = "fish";
		Invoke("generate",0);
	}
	
	
	void generate()
	{
		GameObject fish = (GameObject) Instantiate (sphereFish, new Vector3 (UnityEngine.Random.Range (-2.22f, 2.22f), UnityEngine.Random.Range (3.8f, 4.8f)), Quaternion.identity);
		fish.GetComponent<Renderer>().enabled = true;
		fish.GetComponent<Collider>().enabled = true;
		Rigidbody rb = fish.AddComponent<Rigidbody>(); // Add the rigidbody.
		rb.useGravity = false;
		rb.velocity = new Vector3(2, 0, 0);
		rb.useGravity = false;
		//Destroy(fish, 4);
		Invoke("generate",4);
	}
	void OnDrawGizmosSelected() {
		    Camera camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        Vector3 p1 = camera.ViewportToWorldPoint(new Vector3(0, 0, camera.nearClipPlane));
		Vector3 p2 = camera.ViewportToWorldPoint(new Vector3(0, 1, camera.nearClipPlane));
		Vector3 p3 = camera.ViewportToWorldPoint(new Vector3(1, 0, camera.nearClipPlane));
		Vector3 p4 = camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane));
		Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(p1, 0.1F);
        Gizmos.DrawSphere(p2, 0.1F);
        Gizmos.DrawSphere(p3, 0.1F);
        Gizmos.DrawSphere(p4, 0.1F);
		Debug.Log("here");
	}
	
	void Update()
	{

	}
}