using UnityEngine;

/// <summary>
/// Creates new thoughts and decides whether thoughts are positive or negative
/// </summary>
public class ThoughtSpawnController : MonoBehaviour
{
    //[SerializeField] private GameObject _BaseThought;
    [SerializeField] private GameObject _GoodThought;
    [SerializeField] private GameObject _BadThought;
    [SerializeField] internal float _SpawnTime;
    [SerializeField] private float _TimeSinceLastSpawn;
    [SerializeField] private int _Chance;
    [SerializeField] private int _ThoughtType;
    
    // spawns the new thoughts
    public void SpawnThought()
    {
        //random
        _ThoughtType = Random.Range(0, _Chance);
        //Duplicates thoughts
        if (_ThoughtType == 0)
        {
            Instantiate(_GoodThought);
        }
        else if (_ThoughtType == 1)
        {
             Instantiate(_BadThought);
        }
    }

    void Update()
    {
        // timer until new thought spawns
        if (_TimeSinceLastSpawn > _SpawnTime)
        {
            SpawnThought();
            _TimeSinceLastSpawn = 0f;
        }
        else
        {
            // increases float to measure timer
            _TimeSinceLastSpawn += Time.deltaTime;
        }
    }
}
