using TMPro;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI scoreDisplay;

    GameManager gameManager;
    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    private void OnGUI()
    {
        scoreDisplay.text = ("Score: ") + gameManager.ScoreDisplay();
    }
}
