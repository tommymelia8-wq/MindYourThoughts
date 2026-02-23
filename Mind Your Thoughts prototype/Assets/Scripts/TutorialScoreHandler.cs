using UnityEngine;

public class TutorialScoreHandler : MonoBehaviour
{
    [SerializeField] private int _Score;
    [SerializeField] private string _IncorrectName;
    [SerializeField] private string _CorrectName;
    [SerializeField] private TutorialHandler tutorialHandler;
    
     void OnTriggerEnter2D(Collider2D other)
    {
        // if the thought has been correctly sorted add 1 to the correct count
        if(other.CompareTag(_CorrectName))
        {
            _Score = 10;
        tutorialHandler.Score(_Score);
            Destroy(other.gameObject);
        }
        // if the thought has been incorrectly sorted add 1 to the incorect count
       else if(other.CompareTag(_IncorrectName))
       {
        _Score = -5;
        tutorialHandler.Score(_Score);
            Destroy(other.gameObject);
       }
    }
}
