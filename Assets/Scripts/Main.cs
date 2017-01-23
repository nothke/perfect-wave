using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

    public GameObject startScreen;
    public GameObject game;
    public GameObject endWorld;



    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        StartCoroutine(SkipFrame());
    }

    IEnumerator SkipFrame()
    {
        yield return null;

        startScreen.SetActive(true);
        game.SetActive(false);
        endWorld.SetActive(false);

        AngryDriector.e.enabled = false;
        SenfController.e.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (startScreen.activeSelf)
                StartGame();

            if (endWorld.activeSelf)
                StartGame();

            if (VirshlaCollision.e.isPerfect)
                EndGame();
        }
    }

    void EndGame()
    {
        AngryDriector.e.enabled = false;
        SenfController.e.enabled = false;

        startScreen.SetActive(false);
        endWorld.SetActive(true);
        game.SetActive(false);

        Score.e.Display();
    }

    void StartGame()
    {
        AngryDriector.e.enabled = true;
        SenfController.e.enabled = true;

        VirshlaCollision.e.isPerfect = false;
        Clapperboard.e.takeNum = 1;

        Score.e.Reset();

        startScreen.SetActive(false);
        endWorld.SetActive(false);

        game.SetActive(true);

        Score.e.lastPlayTime = Time.time;

        Clapperboard.e.StartClapper();
    }
}
