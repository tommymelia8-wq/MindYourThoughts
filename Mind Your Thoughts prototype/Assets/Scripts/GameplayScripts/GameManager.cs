using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] internal int IncorrectCount;
    [SerializeField] internal int CorrectCount;
    [SerializeField] private int _LastCount;
    [SerializeField] private GameObject[] _GoodThoughts;
    [SerializeField] private GameObject[] _BadThoughts;
    [SerializeField] private ThoughtSpawnController _thoughtSpawnController;
    [SerializeField] private float _SelfHarmTimer;
    [SerializeField] private bool _IsTimerOn;
    [SerializeField] internal int _Score;    
    [SerializeField] private float _GameTimer;
    [SerializeField] private float _GameLength;


    // Update is called once per frame
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Update()
    {
        if (!_IsTimerOn)
        {
            //Handles self-harm activation
            //checks if is a multiple of 5
            if (IncorrectCount % 5 == 0 && IncorrectCount != _LastCount)
            {
                //makes sure self harm doesn't happen multiple times for the same thing
                _LastCount = IncorrectCount;

                //Self-harm methods
                SelfHarm();
            }
        }
        // SelfHarm Timer
        else
        {
            //Increases the timer
            _SelfHarmTimer += Time.deltaTime;
            // when the timer is finished
            if (_SelfHarmTimer > 5f)
            {
                //Resets the timer ready for next time
                _SelfHarmTimer = 0f;
                _IsTimerOn = false;

                //Sets the spawntime back to default
                _thoughtSpawnController._SpawnTime *=2;

                DepressionHandler[] thoughts = FindObjectsOfType<DepressionHandler>();

                 // makes all the thoughts that are on screen depressed 
                foreach (DepressionHandler thought in thoughts)
                {  
                    thought._Hurt = false;
                }
            } 
        }

        if (_GameTimer < _GameLength)
        {
            _GameTimer += Time.deltaTime;
        }
        else
        {
            SceneManager.LoadScene("ScoringMenu");
            Scoring();
        }
    }

    void Scoring()
    {
        _Score = (CorrectCount * 10) - ((IncorrectCount * 10) / 2);   
    }

    void SelfHarm()
    {
        _IsTimerOn = true;
        // increases how often thoughts spawn
        _thoughtSpawnController._SpawnTime /= 2;

        // finds all the thoughts, they are the game objects with this component
        DepressionHandler[] thoughts = FindObjectsOfType<DepressionHandler>();

        // makes all the thoughts that are on screen depressed 
        foreach (DepressionHandler thought in thoughts)
        {
            thought._Hurt = true;
        }
    }
}
