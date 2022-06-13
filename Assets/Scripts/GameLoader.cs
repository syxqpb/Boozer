using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
    public const int GAME_SCENE = 1;

    private float timeToLoad = 2f;

    private AsyncOperation scene;

    private void Start()
    {
        scene = SceneManager.LoadSceneAsync(GAME_SCENE);
        scene.allowSceneActivation = false;
    }

    private IEnumerator StartGame()
    {
        yield return new WaitForSeconds(timeToLoad);
        scene.allowSceneActivation = true;
    }
}
