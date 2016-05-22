using UnityEngine;
using System.Collections;

public class enemyScript : MonoBehaviour {

	private Vector3 enemyPosition;
	private Quaternion enemyRotation;
	private float x;
	private float y;
	private float z;
	private float dz;
	private float speed;
	private int rotationX;
	private int rotationY;
	private int rotationZ;
	// Use this for initialization
	void Start () {
	
		speed = 5.0f;
		dz = 0;
		enemyPosition = new Vector3 (0, 0, 0);
		enemyRotation = Quaternion.identity;
	}
	
	// Update is called once per frame
	void Update () {
		x = Input.GetAxis("Horizontal");
		z = Input.GetAxis("Vertical");
		dz += z;
//		Debug.Log ("z = "+z);
		if (dz > 16)
			dz = 16;
		if (dz < -16)
			dz = -16;
		if (z == 0) {
			
			if (dz > 1)
				dz--;
			else if (-1 > dz)
				dz++;
			else
				dz = 0;
		}
		float rotationY = 90*x;
		enemyPosition = new Vector3 (x*speed, 0, dz*speed) * Time.deltaTime;
		Quaternion rot = transform.rotation * Quaternion.AngleAxis(x*speed*0.5f, Vector3.up);

//		enemyPosition = new Vector3 (Mathf.Sin(Time.time*Mathf.PI*0.5f)*speed, 0, Mathf.Cos(Time.time*Mathf.PI*0.5f)*speed) * Time.deltaTime;
		enemyRotation.eulerAngles = new Vector3(0, 0, 0);
		transform.position += enemyPosition;
		transform.localRotation = enemyRotation;
//		if (Mathf.DeltaAngle(transform.eulerAngles.y,newAngle.y) < -0.1f){
//			transform.Rotate (new Vector3 (0f, -5f*speed, 0f));
//		}
//		transform.rotation = rot;
		transform.rotation = rot;
//		transform.rotation = (new Quaternion(0, 0, 1, 0.5f));
//		transform.eulerAngles = new Vector3(0f, 0f, -x*dz*1f);
//		transform.rotation = new Quaternion(1,0,0,speed);
//		transform.Rotate(transform.forward, speed*5.0f);
//		transform.rotation = new Quaternion(0, 1, 0, x*speed*5.0f);
//		
	}
}
