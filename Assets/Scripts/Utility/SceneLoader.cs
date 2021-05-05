using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
	private const string MAIN_MENU = "Menu";
	private const string GAME_OVER = "";
	private const string CREDITS = "";
	private const string FIRST_LEVEL = "";

	public static void LoadFirstLevel()
	{
		SceneManager.LoadScene(FIRST_LEVEL);
	}

	public static void LoadNextLevel()
	{
		int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(currentLevelIndex + 1);
	}

	public static void LoadMenu()
	{
		SceneManager.LoadScene(MAIN_MENU);
	}

	public static void LoadGameOver()
	{
		SceneManager.LoadScene(GAME_OVER);
	}

	public static void LoadCredits()
	{
		SceneManager.LoadScene(CREDITS);
	}

	public static void QuitGame()
	{
		Application.Quit();
	}
}
