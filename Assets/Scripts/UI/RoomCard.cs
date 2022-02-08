using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomCard : MonoBehaviour
{
    public Text RoomName;
    public Image RoomPic;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(RoomCardClicked);
    }

    public void RoomCardClicked()
    {
        SendMessageUpwards("RoomSelected",this);
    }
}
