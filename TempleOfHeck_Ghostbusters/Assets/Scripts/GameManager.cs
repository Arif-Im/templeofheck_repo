using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] float deathTime = 10.0f;
    [SerializeField] Text timer;
    [SerializeField] float loadTime = 1;

    public UnityEvent firstScene;
    public UnityEvent levelComplete;
    public UnityEvent timesUp;
    public UnityEvent finalScene;
    private bool levelWin = false;

    private void OnEnable()
    {
        // Freeze Game and show menu if it is the first scene of the game
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (firstScene != null)
                firstScene.Invoke();
        }
        else
        {
            StartTimer();
        }
        if (timer != null)
            timer.text = deathTime.ToString();
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(0);
    }

    public IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(loadTime);
        if((SceneManager.GetActiveScene().buildIndex + 1) > 2)
        {
            if(finalScene != null)
            {
                finalScene.Invoke();
            }
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    public void LevelWon()
    {
        levelWin = true;
        if (levelComplete != null)
            levelComplete.Invoke();
        StartCoroutine("LoadNextScene");
    }

    public void StartTimer()
    {
        StartCoroutine("DeathTimer");
    }

    IEnumerator DeathTimer()
    {
        while(deathTime > 0 && !levelWin)
        {
            deathTime -= Time.deltaTime;
            if (deathTime <= 0)
            {
                if (timesUp != null)
                    timesUp.Invoke();
            }
            else if (timer != null)
            {
                timer.text = deathTime.ToString();
            }
            yield return null;
        }
    }
}
