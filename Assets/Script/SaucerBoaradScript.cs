using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaucerBoaradScript : MonoBehaviour
{
    void OnTriggerEnter(Collider other){//バグ対策
        Destroy(other.gameObject);
        Debug.Log("HIT");
    }
}
