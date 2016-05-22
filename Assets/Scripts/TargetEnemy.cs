using UnityEngine;
using System.Collections;

public class TargetEnemy : MonoBehaviour {
	[SerializeField]
	GameObject deadEffectPrefab;
	UIFollowTarget target;
	void Start(){
		TargetEnemies.insntace.Add(gameObject);
		target = (Instantiate(Resources.Load("TargetMarker")) as GameObject).GetComponent<UIFollowTarget>();
		target.setTarget(this.transform);
		target.transform.parent = GameObject.FindObjectOfType<Canvas>().transform;
	}

	public void FireLockon(){
		target.Lockon();
	}
	void OnDestroy(){
		if(deadEffectPrefab){
			var eff = Instantiate(deadEffectPrefab);
			eff.transform.position = this.transform.position;
		}
	}
}