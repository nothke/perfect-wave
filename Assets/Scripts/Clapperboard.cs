using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clapperboard : MonoBehaviour
{
    public static Clapperboard e;
    void Awake() { e = this; }

    public AudioClip klapClip;

    public TextMesh text;
    public Animator anim;

    public int takeNum = 1;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            StartClapper();
    }

    public void StartClapper()
    {
        text.text = "Take " + takeNum.ToString();

        anim.Play(0);

        AngryDriector.e.HideTryAgain();

        takeNum++;
    }

    public void Clap()
    {
        klapClip.PlayOnce(transform.position, 1, 1, 90, 1000);

        SenfController.e.senfticles.gameObject.SetActive(false);
        SenfController.e.senfticles.gameObject.SetActive(true);

        VirshlaCollision.e.Cleanup();
    }
}
