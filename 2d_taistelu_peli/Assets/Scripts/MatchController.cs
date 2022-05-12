using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchController : MonoBehaviour
{
    public Transform _p1Spawn, _p2Spawn;
    public KameraManager _KameraManger;

    GameObject _pelaaja1, _pelaaja2;


    // Start is called before the first frame update
    void Start()
    {
        _pelaaja1 = GameManager._Instance._pelaaja1;
        _pelaaja2 = GameManager._Instance._pelaaja2;
        LuoPelaajat();
        
        
    }

    public void LuoPelaajat(){
        
        _pelaaja1 = Instantiate(_pelaaja1, _p1Spawn.position, Quaternion.identity);
        _pelaaja2 = Instantiate(_pelaaja2, _p2Spawn.position, Quaternion.identity);
    
        _pelaaja1.GetComponent<Liikkuminen>()._vihollinenSijainti = _pelaaja2.transform;
        _pelaaja2.GetComponent<Liikkuminen>()._vihollinenSijainti = _pelaaja1.transform;
        _KameraManger.SetCamera(_pelaaja1, _pelaaja2);
    }

}
