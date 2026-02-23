using UnityEngine;

///
/// Controls when thoughts become depressed and then removes them
/// 
public class DepressionHandler : MonoBehaviour
{
    [SerializeField] private float _TimeTillDepressed;
    [SerializeField] private float _TimeTillDestroyed;
    [SerializeField] private float _DepressionTimerMin;
    [SerializeField] private float _DepressionTimerMax;
    [SerializeField] private bool _IsDepressed;
    [SerializeField] internal bool _Hurt;
    [SerializeField] private Material _depressedMaterial;
    [SerializeField] private Rigidbody2D _rigidbody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        // starts all bools as false
        _IsDepressed = false;
        _Hurt = false;

        _TimeTillDepressed = Random.Range(_DepressionTimerMin, _DepressionTimerMax);
    }

    // Update is called once per frame
    void Update()
    {
        // Controls the depression timer
        if (!_IsDepressed)
        {
            // if the player has sorted incorrectly recently, the timer decreases twice as fast
            if (_Hurt)
            {
                _TimeTillDepressed -= Time.deltaTime * 2;
            }
            // decreases depression timer normally
            else
            {
                _TimeTillDepressed -= Time.deltaTime;
            }

            // if the timer reaches 0, then the object turns into depressed state
            if (_TimeTillDepressed < 0f)
            {
                // When depressed, the object needs to freeze, so the rigid body is removed
                _IsDepressed = true;
                GetComponent<SpriteRenderer> ().material = _depressedMaterial;
                Destroy(_rigidbody);
            }
        }
        // if this object is depressed already
        else
        {
            // controls the timer until the objcet is removed completely
            _TimeTillDestroyed -= Time.deltaTime;

            // Destroys the object when the timer finishes
            if (_TimeTillDestroyed < 0)
            {
                Destroy(gameObject);
            } 
        }
    }
}
