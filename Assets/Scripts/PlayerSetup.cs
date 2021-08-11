using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class PlayerSetup : MonoBehaviourPunCallbacks
{
    [SerializeField]
    GameObject fpsCamera;

    [SerializeField]
    TextMeshProUGUI playerNameText;
    // Start is called before the first frame update
    void Start()
    {
        if (photonView.IsMine)
        {
            transform.GetComponent<MovementControl>().enabled = true;
            fpsCamera.GetComponent<Camera>().enabled = true;
            
        }
        else
        {
            transform.GetComponent<MovementControl>().enabled = false;
            fpsCamera.GetComponent<Camera>().enabled = false;
        }

        SetPlayerUI();
    }

    void SetPlayerUI()
    {
        if (playerNameText != null)
        {
            playerNameText.text = photonView.Owner.NickName;
        }
    }
}
