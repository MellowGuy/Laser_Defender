using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour
{
	public void LoadLevel(string name)
	{
		SceneManager.LoadScene(name);
		Debug.Log("New Level load: " + name);
		
		//Application.LoadLevel(name);
	}

	public void QuitRequest()
	{
		Debug.Log("Quit requested");
		Application.Quit();
	}

}
