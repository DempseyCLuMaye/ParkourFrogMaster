using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour, IGameManager {
	public ManagerStatus status {get; private set;}

	
    public TextMeshProUGUI WinText;

	public int scorePlayer1 {get; private set;}
	public int scorePlayer2 {get; private set;}

	public void Startup() {
		Debug.Log("Score manager starting...");


		// any long-running startup tasks go here, and set status to 'Initializing' until those tasks are complete
		status = ManagerStatus.Started;
	}

	public void CheckWin(int scorePlayer1, int scorePlayer2)
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
}