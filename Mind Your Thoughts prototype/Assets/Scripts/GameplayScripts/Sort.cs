using UnityEngine;

public class Sort : MonoBehaviour
{
    [SerializeField] private string _IncorrectName;
    [SerializeField] private string _CorrectName;
    [SerializeField] private GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
  
    //Happens when thoughts enter the sorting area
    void OnTriggerEnter2D(Collider2D other)
    {
        // if the thought has been correctly sorted add 1 to the correct count
        if(other.CompareTag(_CorrectName))
        {
            gameManager.CorrectCount += 1;
            Destroy(other.gameObject);
        }
        // if the thought has been incorrectly sorted add 1 to the incorect count
       else if(other.CompareTag(_IncorrectName))
       {
        gameManager.IncorrectCount += 1;
        Destroy(other.gameObject);
       }
    }
}
