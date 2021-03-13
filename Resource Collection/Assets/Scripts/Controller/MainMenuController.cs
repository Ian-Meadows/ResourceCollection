using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void deleteSave()
    {

        SaveAndLoad.Delete();

        FindObjectOfType<Load>().justDeletedSave();
    }

    public void Exit()
    {
        Application.Quit();
    }



}
