using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LockOn : MonoBehaviour {
	[SerializeField]
	Canvas targetCanvas;

	[SerializeField]
	GameObject targetPrefab;

	[SerializeField]
	List<GameObject> targetingObjects = new List<GameObject>();

	[SerializeField]
	List<GameObject> targetingMarkers = new List<GameObject>();
	Leap.Controller controller;
	void Start(){
		controller = new Leap.Controller();
	}
	// Update is called once per frame
	void Update () {
		if(controller.Frame().Hands.Count==2){
			var enemy = TargetEnemies.insntace.get();
			if(!enemy){
				return;
			}
			targetingObjects.Add(enemy);
			var targetMarker = Object.Instantiate(targetPrefab).GetComponent<UIFollowTarget>();
			targetMarker.setTarget(enemy.transform);
			targetMarker.transform.SetParent(  targetCanvas.transform);
			targetingMarkers.Add(targetMarker.gameObject);
		} else {
			if(targetingObjects.Count > 0){
				for( int i = 0; i < targetingObjects.Count;i++){
					Destroy(targetingObjects[i]);
				}
				for( int i = 0; i < targetingMarkers.Count;i++){
					Destroy(targetingMarkers[i]);
				}
				targetingObjects.Clear();
				targetingMarkers.Clear();
			}
		}
			
	
	}
}
