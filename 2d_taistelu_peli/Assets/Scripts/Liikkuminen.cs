using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liikkuminen : MonoBehaviour
{
    // Start is called before the first frame update
    
 
    // [SerializeField] on turvallisempi vaihtoehto
    [SerializeField]
    private float _nopeus = 5f;
    [SerializeField]
    private float _hyppyVoima = 7f;

    public Rigidbody2D _Rb2D;

    public CircleCollider2D _jalat;

    private float _horizontalMovement = 0f;
    
    public int _kohdeSuunta = 1;
    public LayerMask _layerMask;
    
    
    
    void Start()
    {
        
       // _Rb2D = .GetComponent<Rigidbody2D>;

    }

    // Update is called once per frame
    void Update(){
        
        Hyppy();
        
        
    }


    void FixedUpdate() {
        
        Liiku();
        
         
        
    }



    void Liiku(){

        //Liikkuminen sivuille
        _horizontalMovement = Input.GetAxis("Horizontal");
        _Rb2D.velocity = new Vector2(_horizontalMovement * _nopeus, _Rb2D.velocity.y);

    }

    void Hyppy(){

        //Hyppääminen
        _horizontalMovement = Input.GetAxis("Horizontal");

        if(Input.GetButtonDown("Jump") && _jalat.IsTouchingLayers(_layerMask)){

            _Rb2D.AddForce(new Vector2(0f, _hyppyVoima), ForceMode2D.Impulse);



        }


    }
}
