/**
* GameManager.cs
* 
* This script handles the status of the Game, 
* opening and closing animations and 
* victory/gameover sound effects.
* There are only two statuses:
* - IDLE
* - PLAYING
*/


using System.Collections;
using GameUtils.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] public Animator cloudAnimator;
    [SerializeField] public Animator textAnimator;
    [SerializeField] public Animator lifeUIAnimator;
    [SerializeField] public GameObject mouse, cat;
    [SerializeField] public AudioClip victorySound;
    [SerializeField] public AudioClip gameOverSound;
    private float startTime;
    public enum Status
    {
        IDLE,
        PLAYING
    }
    private Status status;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        status = Status.IDLE;
    }

    // Update is called once per frame
    void Update()
    {
        switch (status)
        {
            case Status.IDLE:
                HandleIdle();
                break;
            case Status.PLAYING:
                HandlePlaying();
                break;
        }
    }

    void HandleIdle()
    {
        if (Input.anyKeyDown)
        {
            status = Status.PLAYING;
            startTime = Time.time;
            cloudAnimator.SetTrigger("MoveAway");
            textAnimator.SetTrigger("FadeOut");
            lifeUIAnimator.SetTrigger("Enable");
        }
    }

    void HandlePlaying()
    {
        if (cat.GetComponent<DamageHandler>().CurrentHealth == 0 ||
            mouse.GetComponent<DamageHandler>().CurrentHealth == 0 ||
            Input.GetKeyDown(KeyCode.Escape)) // force game over
        {
            TriggerGameOver(false);
        }

    }

    public void TriggerGameOver(bool isVictory)
    {
        status = Status.IDLE;
        float finishTime = Time.time;
        print((isVictory ? "VICTORY!" : "GAME OVER!") + " Elapsed Time: " + (finishTime - startTime) + " seconds");
        cloudAnimator.SetTrigger("MoveIn");
        textAnimator.SetTrigger("FadeIn");
        lifeUIAnimator.SetTrigger("Disable");

        StartCoroutine(triggerFinish(isVictory));
    }

    IEnumerator triggerFinish(bool isVictory)
    {
        float time = triggerSound(isVictory);
        yield return new WaitForSeconds(time);
        reloadScene();
        yield return true;
    }

    private float triggerSound(bool isVictory)
    {
        AudioSource audio = GetComponent<AudioSource>();
        if (isVictory)
        {
            audio.PlayOneShot(victorySound);
            return victorySound.length;
        }
        else
        {
            audio.PlayOneShot(gameOverSound);
            return gameOverSound.length;
        }
    }

    private void reloadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}   
