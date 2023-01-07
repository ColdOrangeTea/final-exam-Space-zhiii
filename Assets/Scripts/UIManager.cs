using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text TextScore;
    public Image first, second, third;
    int life = 3;
    public int score; // 改成public

    public void GetScore(int amount)
    {
        string zero = "00000";
        score += amount;
        TextScore.text = "SCORE:" + zero.Substring(0, zero.Length - score.ToString().Length) + score;
    }

    public void TakeDamage()
    {
        life--;
        Debug.Log("life: " + life);
        Debug.Log(first.enabled);
        if (life == 3)
        {
            first.enabled = true;
            second.enabled = true;
            third.enabled = true;
        }
        else if (life == 2)
        {
            first.enabled = true;
            second.enabled = true;
            third.enabled = false;
        }
        else if (life == 1)
        {
            first.enabled = true;
            second.enabled = false;
            third.enabled = false;
        }
        else
        {
            first.enabled = false;
            second.enabled = false;
            third.enabled = false;

            FindObjectOfType<GameManager>().GameOver();
        }
    }

}
