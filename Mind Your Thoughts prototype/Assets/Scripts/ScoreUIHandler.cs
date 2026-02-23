using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

///
/// Handles displaying game scores and the UI buttons in the scoreing menu
/// 
public class ScoreUIHandler : MonoBehaviour
{
    //Initialising variables
    [SerializeField] private TMP_Text _ScoreText;
    [SerializeField] private TMP_Text _CorrectCountText;
    [SerializeField] private TMP_Text _IncorrectCountText;
    [SerializeField] private int _ScoreInt;
    [SerializeField] private int _CorrectCountInt;
    [SerializeField] private int _IncorrectCountInt;

    // handles score, done in awake so it can destroy the gamemanager object ASAP
    void Awake()
    {
        // collects results from gamemanager
        GameManager[] ScoreFinder = FindObjectsOfType<GameManager>();
        if (ScoreFinder[0] != null)
        {    
        // retrives the results from the game
        _ScoreInt = ScoreFinder[0]._Score;
        _CorrectCountInt = ScoreFinder[0].CorrectCount;
        _IncorrectCountInt = ScoreFinder[0].IncorrectCount;

        // Displays the results
        _ScoreText.text += _ScoreInt.ToString();
        _CorrectCountText.text += _CorrectCountInt.ToString();
        _IncorrectCountText.text += _IncorrectCountInt.ToString();

        //Destroys gamemanager script so it can't load the score scene again and so that a new gamemanager script can be created when the game scene is loaded
        Destroy(ScoreFinder[0].gameObject);
        }
    }
    
    // loads the mainmenu scene when the button is clicked
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // loads the game scene again when the button is clicked
    public void PlayAgain()
    {
        SceneManager.LoadScene("GameScene");
    }

    // closes the game
    public void Quit()
    {
        Application.Quit();
    }
}
