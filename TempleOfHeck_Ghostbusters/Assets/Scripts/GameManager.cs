using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] float loadTime = 1;

    public UnityEvent firstScene;

    private void OnEnable()
    {
        // Freeze Game and show menu if it is the first scene of the game
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (firstScene != null)
                firstScene.Invoke();
        }
    }



    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(loadTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
