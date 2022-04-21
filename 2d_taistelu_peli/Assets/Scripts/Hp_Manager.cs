using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hp_Manager : MonoBehaviour
{

    [SerializeField]
    public int _maxHp = 100;
    
    [SerializeField]
    public int _hp;

    [SerializeField]
    private float _osumaAika = 0.15f;

    public bool _ottaaVahinkoa = false;
    private Rigidbody2D _RB;
    public float _knockBackX = -2.5f;
    public float _knockBackY = 2.5f;

    public bool _isDummy;

    Liikkuminen _liikkuminenScript;

    Taisteleminen _taisteleminenScript;

    // Start is called before the first frame update
    void Start()
    {
        _RB =  GetComponent<Rigidbody2D>();
        _liikkuminenScript = GetComponent<Liikkuminen>();
        _taisteleminenScript = GetComponent<Taisteleminen>();

        _hp = _maxHp;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VahingonOtto(int _vahingonMaara){

        if(!_ottaaVahinkoa){

            if(_taisteleminenScript._onkoSuojaus){
                
                _hp -= _vahingonMaara/2;
            }

            else{
                _hp -= _vahingonMaara;
                StartCoroutine(VahinkoAjastin());
            }
            
            Debug.Log(_hp);
        }


        if(_hp <= 0){
            Kuole();

        }

    }





    private void Kuole()
    {
        throw new NotImplementedException(); // Tyhjän funktion alustaminen ns. Python return tyhjässä funktiossa
        // Kuoleminen
    }






    IEnumerator VahinkoAjastin(){
        
        //Käskyt välittömästi
        _ottaaVahinkoa = true;

        // Knockback
        _RB.velocity = new Vector2(_liikkuminenScript._kohdeSuunta * _knockBackX, _knockBackY);

        //Laskuri - PAKOLLINEN OSUUS
        yield return new WaitForSeconds(_osumaAika);
        
        //Ajastimen jälkeen tapahtuvat käskyt
        _ottaaVahinkoa = false;
        
        
    }





}
