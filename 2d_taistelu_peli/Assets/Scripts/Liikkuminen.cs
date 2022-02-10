using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liikkuminen : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField]
    // [SerializeField] on turvallisempi vaihtoehto

    private float _nopeus = 5f;
    private float _hyppyVoima = 7f;

    public Rigidbody2D _Rb2D;

    public CircleCollider2D _jalat;

    private float _horizontalMovement = 0f;
    
    public int _kohdeSuunta = 1;
    
    
    
    void Start()
    {
        
       // _Rb2D = .GetComponent<Rigidbody2D>;

    }

    // Update is called once per frame
    void Update()
    {
        
        
        
        
    }


    void FixedUpdate() {
        
        _horizontalMovement = Input.GetAxis("Horizontal");
        _Rb2D.velocity = new Vector2(_horizontalMovement * _nopeus, _Rb2D.velocity.y);
        
        
    }
}
