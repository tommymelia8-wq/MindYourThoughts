using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
///
/// Controls the current state of the tutorial and handles progression through the tutorial
/// 
public class TutorialHandler : MonoBehaviour
{
    [SerializeField] private GameObject _GoodThought;
    [SerializeField] private GameObject _BadThought;
    [SerializeField] private GameObject _Flippers;
    [SerializeField] private GameObject _FirstArea;
    [SerializeField] private GameObject _SecondArea;
    [SerializeField] private GameObject _ThirdArea;
    [SerializeField] private Transform _GoodSpawnButton;
    [SerializeField] private int _TutorialStep = 0;
    [SerializeField] private int x = 0;
    [SerializeField] private int y = 0;
    [SerializeField] private int z = 0;
    [SerializeField] private int _Score = 0;
    [SerializeField] private TMP_Text _ScoreText;

    // Progresses the tutorial to the next part
    public void Next()
    {
        // iterates through the stages of the tutorial
        _TutorialStep += 1;
        switch (_TutorialStep)
        {
            // the second step in the tutorial, adds the second colour
            case 1:
                _GoodSpawnButton.position = new Vector3(x,y,z);
                break;
            // the third step, adds flippers for the player to interact with
            case 2:
                _Flippers.SetActive(true);
                break;
                // the fourth step, activates the second stage which includes the good and a bad area
            case 3:
                _SecondArea.SetActive(true);
                _FirstArea.SetActive(false);
                break; 
                // the fith step, teaches the player about the depression mechanic
            case 4:
                _SecondArea.SetActive(false);
                _ThirdArea.SetActive(true);
                break;
                // returns to the main menu after tutorial is completed 
            case 5:
                SceneManager.LoadScene("MainMenu");
                break;
        }
    }
    
    // allows the player to spawn new good objects
    public void GoodSpawn()
    {
        Instantiate(_GoodThought);
    }

    // allows the player to spawn new good objects
    public void BadSpawn()
    {
        Instantiate(_BadThought);
    }

    // controls the displaying of the score to the player
    public void Score(int _Newscore)
    {
        _Score += _Newscore;
        _ScoreText.text = "Score: " + _Score.ToString();
    }

}
