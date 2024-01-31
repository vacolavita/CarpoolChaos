using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAssignment : MonoBehaviour
{


    public int num = 0;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        num = PlayerManagerManager.playernum;
        PlayerManagerManager.playernum++;
        GetComponent<PlayerInput>().notificationBehavior = PlayerNotifications.BroadcastMessages;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerManagerManager.players[num] != null) {
            PlayerManagerManager.players[num].transform.SetParent(gameObject.transform);
        }
    }
}
