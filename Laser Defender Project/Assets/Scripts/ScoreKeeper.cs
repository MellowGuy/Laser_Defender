using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
	public static int score = 0;
	private Text myText;

	//Initializes the score
	private void Start()
	{
		myText = GetComponent<Text>();
		Reset();
	}

	//add to score function
	public void Score(int points)
	{
		score += points;
		myText.text = "Game Score: " + score.ToString();	
	}

	//sets score to 0
	public static void Reset()
	{
		score = 0;
	}
}
