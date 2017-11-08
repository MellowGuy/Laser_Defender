using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	//Loads level based on string passed in.
	public void LoadLevel(string name)
	{
		SceneManager.LoadScene(name);
		Debug.Log("New Level load: " + name);
		
		//Application.LoadLevel(name);
	}

	//Quits application
	public void QuitRequest()
	{
		Debug.Log("Quit requested");
		Application.Quit();
	}

}
