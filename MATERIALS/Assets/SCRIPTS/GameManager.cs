using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	bool GameHasEnded=false;
	public float restartDelay=1f;
	public GameObject completeLevelUI;
	
	public void CompleteLevel()
	{
		completeLevelUI.SetActive(true);
	}
	
	
    // Start is called before the first frame update
    public void EndGame()
    {
    	if (GameHasEnded==false)
    	{
    		GameHasEnded=true;
    		Debug.Log("GameOver");
    		Invoke("Restart",restartDelay);
    	}
    }
    void Restart()
    {
    	SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}