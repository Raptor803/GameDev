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
    private float startTime;
    public enum Status
    {
        IDLE,
        PLAYING,
        GAMEOVER
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
            case Status.GAMEOVER:
                HandleGameOver();
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
            TriggerGameOver();
        }

    }

    public void TriggerGameOver()
    {
        status = Status.GAMEOVER;
        float finishTime = Time.time;
        print(finishTime - startTime + " seconds");
        cloudAnimator.SetTrigger("MoveIn");
        textAnimator.SetTrigger("FadeIn");
        lifeUIAnimator.SetTrigger("Disable");
        StartCoroutine(reloadScene());
    }

    IEnumerator reloadScene()
    {
        yield return new WaitForSeconds(1);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    void HandleGameOver()
    {
        if (Input.anyKeyDown)
        {
            status = Status.PLAYING;
            cloudAnimator.SetTrigger("MoveAway");
            textAnimator.SetTrigger("FadeOut");
            lifeUIAnimator.SetTrigger("Enable");
        }
    }
}   
