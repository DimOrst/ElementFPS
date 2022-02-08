using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyUIController : MonoBehaviour
{
    public GameObject RoomListPanel;
    public GameObject RoomCard;

    public Button JoinRoomBtn;
    public Button CreateRoomBtn;

    public GameObject PartyOnePanel;
    public GameObject PartyTwoPanel;
    public GameObject PlayerCard;

    public Button ChangePartyBtn;
    public Button ReadyBtn;
    public Button ExitRoomBtn;

    private void Start()
    {
        JoinRoomBtn.onClick.AddListener(JoinRoom);
        CreateRoomBtn.onClick.AddListener(CreateAndJoinRoom);
        ChangePartyBtn.onClick.AddListener(ChangeParty);
        ReadyBtn.onClick.AddListener(ReadyForGame);
        ExitRoomBtn.onClick.AddListener(ExitRoom);
    }

    /// <summary>
    /// 接收房间按钮按下的信息，并从服务器读取房间信息
    /// </summary>
    /// <param name="RC"></param>
    public void RoomSelected(RoomCard RC)
    {
        //do sth
    }

    //btn events
    #region
    public void JoinRoom()
    {
        //do sth
    }

    public void CreateAndJoinRoom()
    {
        //do sth
    }

    public void ReadyForGame()
    {
        //do sth
    }

    public void ChangeParty()
    {
        //do sth
    }

    public void ExitRoom()
    {
        //do sth
    }
    #endregion
}
