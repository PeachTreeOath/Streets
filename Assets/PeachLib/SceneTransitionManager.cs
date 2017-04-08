﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This scene manager handles scene loading when there is a persistent scene used.
/// A temporary scene swap is needed because you can't load scenes additively and
/// set active scene on the same frame, so a buffer scene must be used and then
/// merged after frame 1.
/// </summary>
public class SceneTransitionManager : Singleton<SceneTransitionManager>
{
    private Scene tempScene;
    private string tempSceneName = "TempScene";

    public void ShowTitleScreen()
    {
        string nextSceneName = "Title";
        SceneManager.LoadScene(nextSceneName, LoadSceneMode.Additive);
    }

    public void StartGame()
    {
        string nextSceneName = "Game";
        SceneManager.UnloadSceneAsync("Title");

        tempScene = SceneManager.CreateScene(tempSceneName);
        SceneManager.SetActiveScene(tempScene);
        SceneManager.LoadScene(nextSceneName, LoadSceneMode.Additive);
        StartCoroutine(SetActive(SceneManager.GetSceneByName(nextSceneName), true));
    }

    public void GoToScore()
    {
        string nextSceneName = "Score";
        SceneManager.UnloadSceneAsync("Game");

        SceneManager.LoadScene(nextSceneName, LoadSceneMode.Additive);
        StartCoroutine(SetActive(SceneManager.GetSceneByName(nextSceneName), false));
    }

    public void GoToGame()
    {
        string nextSceneName = "Game";
        SceneManager.UnloadSceneAsync("Score");

        tempScene = SceneManager.CreateScene(tempSceneName);
        SceneManager.SetActiveScene(tempScene);
        SceneManager.LoadScene(nextSceneName, LoadSceneMode.Additive);
        StartCoroutine(SetActive(SceneManager.GetSceneByName(nextSceneName), true));
    }

    // You only need to use mergeTempScene if you are potentially
    // instantiating objects on the first frame of scene startup
    public IEnumerator SetActive(Scene scene, bool mergeTempScene)
    {
        int i = 0;
        while (i == 0)
        {
            i++;
            yield return null;
        }
        SceneManager.SetActiveScene(scene);
        SceneManager.MergeScenes(tempScene, scene);

        yield break;
    }
}