using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
	static MusicPlayer instance = null;

	public AudioClip startClip;
	public AudioClip gameClip;
	public AudioClip endClip;

	private AudioSource music;
	
	//Makes MusicPlayer persist between scenes. Checks if it already exists.
	void Start()
	{
		if (instance != null && instance != this)
		{
			Destroy(gameObject);
			print("Duplicate music player self-destructing!");
		}
		else
		{
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
			music = GetComponent<AudioSource>();
			music.clip = startClip;
			music.loop = true;
			music.Play();
		}
	}

	//Decides which AudioClip to play depending on level loaded. 
	private void OnLevelWasLoaded(int level)
	{
		Debug.Log("MusicPlayer: Level called: " + level.ToString());
		music.Stop();

		switch (level)
		{
			case 0:
				music.clip = startClip;
				break;
			case 1:
				music.clip = gameClip;
				break;
			case 2:
				music.clip = endClip;
				break;
			default:
				break;
		}
		music.loop = true;
		music.Play();
	}
}
