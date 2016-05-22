using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIFollowTarget : MonoBehaviour 
{
	RectTransform rectTransform = null;
	[SerializeField] Transform target = null;
	public void setTarget(Transform t){
		this.target = t;
	}
	void Awake()
	{
		rectTransform = GetComponent<RectTransform> ();
	}
	void Start(){
		rectTransform.position = RectTransformUtility.WorldToScreenPoint (Camera.main, target.position);
	}

	void Update()
	{
		rectTransform.position = RectTransformUtility.WorldToScreenPoint (Camera.main, target.position);
	}
}