using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score e;
    void Awake() { e = this; }

    public TextMesh spentText;
    public TextMesh filmText;
    public TextMesh profitText;

    public float lastPlayTime;

    public void Display()
    {
        float senf = SenfController.totalSenfSpent / 100.0f;
        float film = Time.time - lastPlayTime;

        spentText.text = Mathf.RoundToInt(senf) + "l";
        filmText.text = "" + Mathf.RoundToInt(film) + "s";

        float profit = film * senf - 1000;

        profitText.text = Mathf.RoundToInt(profit).ToString();
    }

    public void Reset()
    {
        SenfController.totalSenfSpent = 0;
        lastPlayTime = 0;
    }
}
