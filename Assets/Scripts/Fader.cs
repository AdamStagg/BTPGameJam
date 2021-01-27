using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Fader : MonoBehaviour
{

    [SerializeField] Image faderImage;
    Animator anim;
    int currentLevelIndex = 0;

    public static Fader instance;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        instance = this;
        anim = faderImage.GetComponent<Animator>();
        DontDestroyOnLoad(anim.transform.parent);
    }

    public void FadeToNextScene()
    {
        StartCoroutine(FadeToScene(currentLevelIndex + 1));
    }

    public void FadeTo(int sceneIndex)
    {
        StartCoroutine(FadeToScene(sceneIndex));
    }

    IEnumerator FadeToScene(int sceneIndex)
    {
        anim.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1.2f);
        
        AsyncOperation load = SceneManager.LoadSceneAsync(sceneIndex);
        currentLevelIndex = sceneIndex;

        while (!load.isDone)
        {
            yield return null;
        }


        anim.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1.2f);
    }

}
