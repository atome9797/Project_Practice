using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonBehavior<GameManager>
{

/*	void Start()
	{
		StartCoroutine(LoadSceneAsync());
	}

	IEnumerator LoadSceneAsync()
	{
		
		AsyncOperation AsyncLoad = SceneManager.LoadSceneAsync("PlayerScene");

		while (!AsyncLoad.isDone)
		{
			yield return null;
		}
	}*/
}
