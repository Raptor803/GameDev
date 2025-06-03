using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Animator cloudAnimator;
    private float startTime;
    private enum STATUS
    {
        IDLE,
        PLAYING,
        GAMEOVER
    }
    private STATUS status;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        status = STATUS.IDLE;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            switch (status)
            {
                case STATUS.IDLE:
                case STATUS.GAMEOVER:
                    StartGame();
                    status = STATUS.PLAYING;
                    break;
                case STATUS.PLAYING:
                    //GameOver();
                    status = STATUS.GAMEOVER;
                    break;
            }
        }
    }

    void GameOver()
    {
        float finishTime = Time.time;
        print(finishTime - startTime + " seconds");
        cloudAnimator.SetTrigger("MoveIn");
    }

    void StartGame()
    {
        startTime = Time.time;
        print("Starting");
        cloudAnimator.SetTrigger("MoveAway");
    }
}   
