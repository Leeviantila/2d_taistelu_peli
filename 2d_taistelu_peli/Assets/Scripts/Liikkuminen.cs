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
    
    public Animator _animator;
    
    Hp_Manager _Hp_Manger;
    


    void Start()
    {

        _Rb2D = GetComponent<Rigidbody2D>();
        _Hp_Manger = GetComponent<Hp_Manager>();
        _animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update(){
        
        if(!_Hp_Manger._ottaaVahinkoa){
            
            Hyppy();
            
        }
        
    }


    void FixedUpdate() {
        
        
        if(!_Hp_Manger._ottaaVahinkoa){
            
            Liiku();
            
        }
        
    }



    void Liiku(){


        if(_Hp_Manger._isDummy){

            return;
        }

        //Liikkuminen sivuille
        _horizontalMovement = Input.GetAxis("Horizontal");
        
        _Rb2D.velocity = new Vector2(_horizontalMovement * _nopeus, _Rb2D.velocity.y);
        
        // Liikkumisen animaatiot
        _animator.SetFloat("_nopeus_A", Mathf.Abs(_horizontalMovement));

    }

    void Hyppy(){


        if(_Hp_Manger._isDummy){

            return;
        }

        //Hyppääminen
        _horizontalMovement = Input.GetAxis("Horizontal");

        if(Input.GetButtonDown("Jump") && _jalat.IsTouchingLayers(_layerMask)){
        

            _Rb2D.AddForce(new Vector2(0f, _hyppyVoima), ForceMode2D.Impulse);
            _animator.SetTrigger("_hyppy_A");
            
            
        }


    }
}
