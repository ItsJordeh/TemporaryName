using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	private const string MAIN_MENU = "Menu";
	private GameObject pauseMenu;

	private void Start()
	{
		pauseMenu = transform.GetChild(0).gameObject;
	}

	private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
		{
			togglePause();	
		}
    }


	private void togglePause()
	{
		pauseMenu.SetActive(!pauseMenu.activeSelf);
		Time.timeScale = pauseMenu.activeSelf == true ? 0 : 1;
	}

	public void ResumeGame()
	{
		togglePause();
	}

	public void QuitToMenu()
	{
		SceneLoader.LoadMenu();
	}
}
