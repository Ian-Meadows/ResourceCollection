using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LeaveButton : MonoBehaviour {

    public GameController gameController;

    bool hasSaved = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (!gameController.leaveOption)
        {
            Destroy(gameObject);
        }

	}

    public void Leave()
    {
        if (!hasSaved)
        {
            SaveAndLoad.Save(gameController, FindObjectOfType<RecipeHolder>(), FindObjectOfType<ItemImageHolder>(), FindObjectsOfType<AssemblyBuilding>()
                , FindObjectsOfType<Drone>(), FindObjectOfType<Player>());
            hasSaved = true;
        }

        SceneManager.LoadScene("Main Menu");
    }
}
