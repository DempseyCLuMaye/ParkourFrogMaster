using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger : MonoBehaviour
{
    public string playerTag = "Player";  // Set the player tag in the Unity Editor
    public int scorePlayer1 = 0;
    public int scorePlayer2 = 0;

    private bool FroggartScorable = true;

    private bool FrogathyScorable = true;

    public GameObject Froggart;
    public GameObject Frogathy;



    void Start()
    {
        Froggart = GameObject.FindGameObjectWithTag("Froggart");
        Frogathy = GameObject.FindGameObjectWithTag("Frogathy");
    }



    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            // Player has jumped over the trigger area
            // Debug.Log("Player jumped over!");

            // Tally scores

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
    }

    IEnumerator FroggartScore()
    {
        FroggartScorable = false;
        scorePlayer1++;
        Debug.Log("Player 1 Score: " + scorePlayer1);
        yield return new WaitForSeconds(2);
        FroggartScorable = true;

    }

    IEnumerator FrogathyScore()
    {
        FrogathyScorable = false;
        scorePlayer2++;
        Debug.Log("Player 2 Score: " + scorePlayer2);
        yield return new WaitForSeconds(2);
        FrogathyScorable = true;

    }
}