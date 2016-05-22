using UnityEngine;
using System.Collections;

public class TargetEnemy : MonoBehaviour {
	[SerializeField]
	GameObject deadEffectPrefab;
	void Start(){
		TargetEnemies.insntace.Add(gameObject);
	}
	void OnDestroy(){
		if(deadEffectPrefab){
			var eff = Instantiate(deadEffectPrefab);
			eff.transform.position = this.transform.position;
		}
	}
}