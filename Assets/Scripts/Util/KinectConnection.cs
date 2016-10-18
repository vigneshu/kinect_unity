using UnityEngine;
using System.Collections;
using Windows.Kinect;
public class KinectConnection : MonoBehaviour {


	public GameObject BodySrcManager;
	public JointType TrackedJoint;
    public float multiplier = 10f;
    private BodySourceManager BodyManager;
    private Body[] bodies;
	Vector3 pos;
	public bool isVirtual = false;
	private float zPos = 1.4f;
	WorkspaceCalibration CalibrationObject = null;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this.gameObject);
		CalibrationObject = new WorkspaceCalibration(this.GetComponent<KinectConnection>());
        Debug.Log("startt");
		pos = Vector3.zero;
        if (BodySrcManager == null)
        {
            Debug.Log("Assign object with bodysrcmanager");
        }
        else
        {
            BodyManager = BodySrcManager.GetComponent<BodySourceManager>();
        }
	}
    public Vector3 GetRightWristPosition()
    {
        if(!isVirtual)
		{
			if (BodyManager == null)
				return pos;
			bodies = BodyManager.GetData();
			if (bodies == null)
				return pos;
			foreach (var body in bodies)
			{

				if (body == null)
				{
					Debug.Log("null");
					continue;

				}
				if (body.IsTracked)
				{

					var pos_temp = body.Joints[TrackedJoint].Position;
					pos = new Vector3(pos_temp.X, pos_temp.Y, pos_temp.Z);
				}
			}
		}
		pos -= CalibrationObject.offset;
		pos = Vector3.Scale(pos, CalibrationObject.scale);
        return pos;
    }
    // Update is called once per frame
    void Update () {
		if(isVirtual)
		{
			Ray ray = Camera.main.ScreenPointToRay (new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
			
			zPos += (Input.GetAxis ("Vertical"));
			zPos += (Input.GetAxis ("Horizontal"));
			zPos += Input.GetAxis ("Mouse ScrollWheel");
			pos = new Vector3 (ray.GetPoint (zPos).x, ray.GetPoint (zPos).y, zPos);
		}
		
		//If calibration
		if (CalibrationObject.CalibrationStarted && !CalibrationObject.CalibrationEnded)
        {
			CalibrationObject.UpdateWorkSpaceLimits(GetRightWristPosition());
        }
	}
	public void ChangeScene()
	{
		Application.LoadLevel(1);
	}
	public void SetOffset()
	{
		CalibrationObject.SetOffset(pos);
	}
	public void StartCalibration()
    {
        CalibrationObject.StartCalibration();
    }
    public void EndCalibration()
    {
        CalibrationObject.EndCalibration();
		ChangeScene();
		
    }
	


}
