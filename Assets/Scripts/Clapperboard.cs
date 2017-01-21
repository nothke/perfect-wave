using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clapperboard : MonoBehaviour
{


    public TextMesh text;
    public Animator anim;

    int takeNum = 1;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            StartClapper();
    }

    public void StartClapper()
    {
        text.text = "Take " + takeNum.ToString();

        anim.Play(0);

        takeNum++;
    }

    public void Clap()
    {
        SenfController.e.senfticles.gameObject.SetActive(false);
        SenfController.e.senfticles.gameObject.SetActive(true);
    }
}
