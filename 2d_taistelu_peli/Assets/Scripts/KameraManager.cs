using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class KameraManager : MonoBehaviour
{

    public void SetCamera(GameObject _p1, GameObject _p2){
        
        GetComponent<CinemachineTargetGroup>().AddMember(_p1.transform, 1, 0);
        GetComponent<CinemachineTargetGroup>().AddMember(_p2.transform, 1, 0);
        
    }


}
