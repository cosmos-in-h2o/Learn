/*
 * 代码作用：
 * 加载下一个场景并显示进度
 * 挂载：加载场景的空物体上
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    public GameObject load_screen;
    public Slider slider;
    public Text text;

    //加载下一个场景函数
    public void loadNextLevel()
    {
        StartCoroutine(loadLevel());
    }

    //加载场景函数
    IEnumerator loadLevel()
    {
        load_screen.SetActive(true);

        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex+1);

        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            slider.value = operation.progress;

            yield return null;

            text.text = operation.progress * 100 + "%";

            if (operation.progress>=0.9f)
            {
                slider.value = 1;

                text.text = "100%";

                operation.allowSceneActivation=true;
            }
        }
    }
}
