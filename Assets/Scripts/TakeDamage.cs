using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class TakeDamage : MonoBehaviour
{

    public float health;
    // Start is called before the first frame update
    void Start()
    {
        health = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [PunRPC]
    public void DamageTake(float _damage)
    {
        health -= _damage;
        Debug.Log(health);
    }
}
