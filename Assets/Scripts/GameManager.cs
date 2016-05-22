using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {
	/// <summary>
	/// インスタンス。シングルトン
	/// </summary>
	static private GameManager instance_ = null;
	public bool gameEnd = false;
	public int cnt=0;
	static public GameManager instance
	{
		get
		{
			return instance_ = instance_ ?? new GameObject("GameManager").AddComponent<GameManager>();
		}
	}
	/// 初期化
	/// </summary>
	void Awake()
	{
		if (Application.isPlaying) {
			DontDestroyOnLoad (gameObject);
		}
	}

	public void ToResult(){
		gameEnd=true;
		SceneManager.LoadScene("ResultScene");
	}

}
