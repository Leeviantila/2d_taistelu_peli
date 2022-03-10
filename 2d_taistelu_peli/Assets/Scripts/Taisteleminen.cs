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

    private int _animationIndex;

    Hp_Manager _Hp_Manger;


    // Start is called before the first frame update
    void Start()
    {
        
        _Hp_Manger = GetComponent<Hp_Manager>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Hyokkays(Transform _check, int _vahinko){
        
        Collider2D[] _enemyHit = Physics2D.OverlapCircleAll(_check.position, _kantama, _vihollinenLayer);
        
        if(_enemyHit != null){
            
            foreach (Collider2D enemy in _enemyHit){
                
                if(enemy.gameObject != this.gameObject){
                    enemy.GetComponent<Hp_Manager>().VahingonOtto(_vahinko);


                }
                
            }
            
        }
        
        
        
    }







    void OnDrawGizmos() {
        
        Gizmos.DrawWireSphere(_lyonticheck.position, _kantama);
        Gizmos.DrawWireSphere(_potkucheck.position, _kantama);

    }





}
