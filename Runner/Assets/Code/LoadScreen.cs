using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScreen : MonoBehaviour
{
    public static int sceneID; // ID загрузочной сцены
    public Slider loadSlider; // Загрузачная полоса

    private void Start()
    {
        StartCoroutine(LoadNextScene());
    }

    // Загрузка следующей сцены
    IEnumerator LoadNextScene()
    {
        AsyncOperation oper = SceneManager.LoadSceneAsync(sceneID);
        while (!oper.isDone)
        {
            float progress = oper.progress / 0.9f;
            loadSlider.value = progress;
            yield return null;
        }
    }
}
