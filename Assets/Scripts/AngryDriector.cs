using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class AngryDriector : MonoBehaviour
{
    public static AngryDriector e;
    void Awake() { e = this; }

    public Text dialogueText;
    public Transform panel;

    public Text tryAgainText;

    public AudioClip angryClip;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
            Say("Harder!");

        if (Input.GetKeyDown(KeyCode.H))
            EndSay();
    }

    float duration = 0.3f;

    float textDuration = 3;

    public IEnumerator EndTimer()
    {
        yield return new WaitForSeconds(textDuration);

        EndSay();
    }

    public IEnumerator TimeD(string whatToSay)
    {
        EndSay();
        yield return new WaitForSeconds(0.2f);

        panel.DOLocalMoveY(0, duration);

        angryClip.PlayOnce(Vector3.zero, 1, 1, 90, 1000);

        dialogueText.text = whatToSay;

        StartCoroutine(EndTimer());
    }

    public void Say(string whatToSay)
    {
        StartCoroutine(TimeD(whatToSay));
    }

    public void EndSay()
    {
        panel.DOLocalMoveY(-200, duration);
    }

    public void ShowTryAgain()
    {
        tryAgainText.gameObject.SetActive(true);
    }

    public void HideTryAgain()
    {
        tryAgainText.gameObject.SetActive(false);
    }
}