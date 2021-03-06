using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taisteleminen : MonoBehaviour
{
    public int _lyontiVahinko = 2;
    public int _potkuVahinko = 3;

    public bool _onkoSuojaus = false;

    public Transform _lyonticheck;
    public Transform _potkucheck;       

    public float _kantama = 1.7f;
    public float _coolDown = 0.25f;

    public LayerMask _vihollinenLayer;

    private float _coolDownTimer;

    private bool _hyokkays = false;
    private bool _osuma = false;

    public Animator _animator;
    
    
    Hp_Manager _Hp_Manger;

    



    // Start is called before the first frame update
    void Start()
    {
        
        _Hp_Manger = GetComponent<Hp_Manager>();
        _animator = GetComponent<Animator>();



    }

    // Update is called once per frame
    void Update()
    {

        if(_Hp_Manger._onElossa == false){
            return;
        }
        
        if(_Hp_Manger._ottaaVahinkoa){
            return;
        }

        if(!_onkoSuojaus && !_hyokkays && _coolDownTimer <= 0){
            
            if(_Hp_Manger._isDummy){

                return;
            }


            if(Input.GetButtonDown("Fire1")){


                if(Random.Range(0, 2) == 0){

                    _animator.SetTrigger("_löyntiVasemmalle_A");               
                    Lyonti();

                }
                else{
                    _animator.SetTrigger("_lyöntiOikea_A");               
                    Lyonti();

                }



            }
            
            if(Input.GetButtonDown("Fire2")){


                if(Random.Range(0, 2) == 0){

                    _animator.SetTrigger("_potkuVasen_A");               
                    Potku();
                }
                else{
                    _animator.SetTrigger("_potkuOikea_A");               
                    Potku();


                }

            }

        }

        if(Input.GetButtonDown("Fire3")){


            if(_Hp_Manger._isDummy){

                return;
            }

            Suojaus_alku();
            
        }

        if(Input.GetButtonDown("Fire3")){

            if(_Hp_Manger._isDummy){

                return;
            }            
            
            Suojaus_loppu();
            
        }    
        
        if(_hyokkays){ // Huono tapa !!! coroutine parempi
            
            if(_coolDownTimer > 0){
                
                _coolDownTimer -= Time.deltaTime;
            }

            else{
                _hyokkays = false;
            }
        }
        
    }

    void Hyokkays(Transform _check, int _vahinko){
        
        Collider2D[] _enemyHit = Physics2D.OverlapCircleAll(_check.position, _kantama, _vihollinenLayer);
        
        if(_enemyHit != null){
            
            foreach (Collider2D enemy in _enemyHit){
                
                if(_osuma == false){
                    if(enemy.gameObject != this.gameObject){
                        enemy.GetComponent<Hp_Manager>().VahingonOtto(_vahinko);

                    }
                }
            }

            _osuma = false;
            
        }
        
        _hyokkays = true;
        _coolDownTimer = _coolDown;
        
    }

    private void Lyonti(){
        
        // Animaatiot

        Hyokkays(_lyonticheck, _lyontiVahinko);
        
    }

    private void Potku(){
        
        // Animaatiot

        Hyokkays(_potkucheck, _potkuVahinko);
        
    }


    private void Suojaus_alku(){
    
        // Animaatiot

        _onkoSuojaus = true;    
    }

    private void Suojaus_loppu(){
    
        // Animaatiot

        _onkoSuojaus = false;    
    }



    void OnDrawGizmos() {
        
        Gizmos.DrawWireSphere(_lyonticheck.position, _kantama);
        Gizmos.DrawWireSphere(_potkucheck.position, _kantama);

    }





}
