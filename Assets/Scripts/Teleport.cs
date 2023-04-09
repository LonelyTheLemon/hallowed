using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    void OnTriggerEnter(Collider Col){
        Col.transform.position = new Vector3 (Random.Range (-5.0f, 5.0f), Col.transform.position.y, Random.Range(-5.0f, 5.0f));
        //overides the position of charcter controller
        Physics.SyncTransforms();
    }
}
