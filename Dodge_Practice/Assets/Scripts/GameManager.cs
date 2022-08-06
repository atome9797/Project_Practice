using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonBehavior<GameManager>
{

    private void Start()
    {
        SceneManager.LoadScene("PlayerScene", LoadSceneMode.Additive);
    }

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
