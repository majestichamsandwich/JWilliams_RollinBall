using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region

    public static GameManager Instance;



    public void Awake()
    {
        if (Instance == null) Instance = this;
    }


    #endregion

    public float currentScore = 0f;
    public float restartDelay = 1f;

    public bool isPlaying = true;
    bool gameHasEnded = false;
    

    public string ScoreDisplay()
    {
        return Mathf.RoundToInt(currentScore).ToString();
    }


    private void Update()
    {
        if (isPlaying == true)
        {
            currentScore += Time.deltaTime;
        }


    }

    public void GameOver()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("GAME OVER");
            Invoke("Restart", restartDelay);
        }
        
    }

    void Restart ()
    {
        SceneManager.LoadScene("Scene_Main");
    }

}
