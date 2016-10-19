using UnityEngine;

using System.Collections;
using Windows.Kinect;
public class GenerateFishes : MonoBehaviour
{
	float gameSpaceSize;
	GameObject sphereFish ;
	void Start () {
		gameSpaceSize = 6.0f - 1.0f ;
		sphereFish = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		sphereFish.GetComponent<Renderer>().enabled = false;
		sphereFish.GetComponent<Collider>().enabled = false;
		sphereFish.tag = "fish";
		Invoke("generate",0);
	}
	
	void generate()
	{
		int rand1 = ((UnityEngine.Random.Range(0.0f,1.0f)>0.5)?0:1) * 2 - 1;
		int rand2 = ((UnityEngine.Random.Range(0.0f,1.0f)>0.5)?0:1) * 2 - 1;
		float spawnPosition = gameSpaceSize*rand1;
		float pos1 = gameSpaceSize*rand1;
		float pos2 = gameSpaceSize*UnityEngine.Random.Range(0.0f,1.0f);
		Vector3 spawnPos = Vector3.zero;
		if(UnityEngine.Random.Range(0.0f,1.0f)>0.5)
			spawnPos = new Vector3 (pos1,pos2,0);
		else
			spawnPos = new Vector3 (pos2,pos1,0);
		//GameObject fish = (GameObject) Instantiate (sphereFish, new Vector3 (spawnPosition, spawnPosition,0), Quaternion.identity);
		GameObject fish = (GameObject) Instantiate (sphereFish,spawnPos, Quaternion.identity);
		 fish.AddComponent<Fish>();
		fish.GetComponent<Renderer>().enabled = true;
		fish.GetComponent<Collider>().enabled = true;
		Rigidbody rb = fish.AddComponent<Rigidbody>(); // Add the rigidbody.
		//rb.isKinematic = true;
		//rb.velocity = new Vector3(2, 0, 0);
		rb.velocity = -2.0f *spawnPos.normalized;
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
	}

		  
	void Update()
	{

	}
}