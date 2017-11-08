using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{

	// Displays "Final Score: " on text component. Pulls static score property from ScoreKeeper.
	void Start()
	{
		Text myText = GetComponent<Text>();
		myText.text = "Final Score: " + ScoreKeeper.score.ToString();
		ScoreKeeper.Reset();
	}
}
