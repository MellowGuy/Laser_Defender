using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
	public int score = 0;
	private Text myText;

	//Initializes the score
	private void Start()
	{
		myText = GetComponent<Text>();
		Score(0);
	}

	//add to score function
	public void Score(int points)
	{
		score += points;
		myText.text = "Game Score: " + score.ToString();	
	}

	////not currently used
	//public void Reset()
	//{
	//	score = 0;
	//}
}
