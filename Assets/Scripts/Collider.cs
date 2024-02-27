using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JumpTrigger : MonoBehaviour
{
    private bool FroggartScorable = true;

    private bool FrogathyScorable = true;

    public GameObject Froggart;
    public GameObject Frogathy;

    public int scorePlayer1 = 0;
    public int scorePlayer2 = 0;

    public TextMeshProUGUI ScoreTextP1;
    public TextMeshProUGUI ScoreTextP2;
    public TextMeshProUGUI WinText;

    void Start()
    {
        Froggart = GameObject.FindGameObjectWithTag("Froggart");
        Frogathy = GameObject.FindGameObjectWithTag("Frogathy");
    }

    void Update()
    {

        if (scorePlayer1 >= 5)
        {
            WinText.text = "Player 1 Wins!";
        }
        else if (scorePlayer2 >= 5)
        {
            WinText.text = "Player 2 Wins!";
        }

    }


    void OnTriggerEnter(Collider other)
    {



        if (other.gameObject.name == "Froggart" && FroggartScorable == true)
        {
            P1PlayerController playerController = other.GetComponent<P1PlayerController>();

            if (playerController != null && playerController.CanScoreP1())
            {
                StartCoroutine(FroggartScore());
            }
        }
        else if (other.gameObject.name == "Frogathy" && FrogathyScorable == true)
        {
            P2PlayerController playerController = other.GetComponent<P2PlayerController>();

            if (playerController != null && playerController.CanScoreP2())
            {
                StartCoroutine(FrogathyScore());
            }
        }

    }


    IEnumerator FroggartScore()
    {
        FroggartScorable = false;
        scorePlayer1++;
        ScoreTextP1.text = "Player 1: " + scorePlayer1;
        yield return new WaitForSeconds(1);
        FroggartScorable = true;

    }

    IEnumerator FrogathyScore()
    {
        FrogathyScorable = false;
        scorePlayer2++;
        ScoreTextP2.text = "\nPlayer 2: " + scorePlayer2;
        yield return new WaitForSeconds(1);
        FrogathyScorable = true;

    }
}