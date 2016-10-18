using UnityEngine;
using UnityEngine.UI;
using System;
using System.Threading;
using System.Text;
using UnityEngine.SceneManagement;

public class WorkspaceCalibration
{	
    //kinnect connection
	public KinectConnection conn;
    //workspace parameters
    public Vector3 scale, GameWorkspaceSize = Vector3.zero;
	//TODO offset
	public Vector3 offset = Vector3.zero;
    public bool CalibrationStarted = false;
    public bool CalibrationEnded = false;
    private Vector3 minRange,maxRange;



    public WorkspaceCalibration(KinectConnection conn,float GameWorkspaceSizeX = 6, float GameWorkspaceSizeY = 6, float GameWorkspaceSizeZ = 6)
    {
		offset = Vector3.zero;
		minRange = offset;
		maxRange = offset;
        this.conn = conn;
        scale = new Vector3(1,1,1);
		GameWorkspaceSize =  new Vector3(GameWorkspaceSizeX,GameWorkspaceSizeY,GameWorkspaceSizeZ);
    }
    public void StartCalibration()
	{
        CalibrationStarted = true;
    }
    public void EndCalibration()
    {
        CalibrationEnded = true;
        //calculate scales,//TODO take absolute value
        scale = (maxRange - minRange);
		//TODO add z calibration as well. Take the multiplier 2 off
		scale = new Vector3(2*GameWorkspaceSize.x/scale.x,2*GameWorkspaceSize.y/scale.y,1);
        Debug.Log("maxRange " + maxRange);
        Debug.Log("minRange " + minRange);
        Debug.Log("scale "+ scale);
    }
	
	public void SetOffset(Vector3 offset)
	{
		Debug.Log("Offset is "+offset);
		this.offset = offset;
	}
    public void UpdateWorkSpaceLimits(Vector3 position)
    {
        minRange = Vector3.Min(position, minRange);
        maxRange = Vector3.Max(position, maxRange);
    }

}
