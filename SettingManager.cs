using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingManager : MonoBehaviour {

	public GameObject mainMenuHolder;
	public GameObject optinsMenuHolder;

	public Slider[] volumeSliders;
	public Toggle[] resolutionToggles;
	public int[] screenWidths;
	int activeScreenResIndex;

	public void NewGame()
	{
		SceneManager.LoadScene ("level1");
	}

	public void MainMenu()
	{
		mainMenuHolder.SetActive (true);
		optinsMenuHolder.SetActive (false);
	}

	public void Options()
	{
		mainMenuHolder.SetActive (false);
		optinsMenuHolder.SetActive (true);	
	}

	public void Quit()
	{
		Application.Quit ();
	}

	public void SetScreenResolution (int i)
	{
		if (resolutionToggles [i].isOn) {
			activeScreenResIndex = i;
			float aspectRatio = 16 / 9f;
			Screen.SetResolution ( screenWidths [i], (int)(screenWidths [i] / aspectRatio), false);
		}
	}
	public void SetFullscreen (bool isFullscreen)
	{
		for (int i =0; i <= resolutionToggles.Length; i++)
		{
			resolutionToggles [i].interactable = !isFullscreen;
		}
		if (isFullscreen) {
			Resolution[] allResolutions = Screen.resolutions;
			Resolution maxResolution = allResolutions [allResolutions.Length - 1];
			Screen.SetResolution (maxResolution.width, maxResolution.height, true);
		} else {
			SetScreenResolution (activeScreenResIndex);
		}
	}

	public void SetMusicVolume(float value)
	{
		
	}
	
	public void  SetSfxVolume(float value)
	{
	
	}

}