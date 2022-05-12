using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{



    public static GameManager _Instance{get; set;}
    public GameObject _pelaaja1;

    public GameObject _pelaaja2;

    void Awake() {
        
        if(_Instance != null && _Instance != this){
            
            Destroy(this.gameObject);
            
        }
        else{
            _Instance = this;
        }
        
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
