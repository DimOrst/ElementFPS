using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingStageUIController : MonoBehaviour
{
    public GameObject TeammatePanel;
    public GameObject TeammateCard;

    public Text HP;
    public Text MaxEnergy;
    public Text TimerDisplay;

    public Image ElementSkillIcon;
    public Image ElementBurstIcon;

    public GameObject CharacterDisplayPanel;

    public Dropdown WeaponOne;
    public Dropdown WeaponTwo;
    public Dropdown WeaponThree;

    public Dropdown WeaponOneElement;
    public Dropdown WeaponTwoElement;
    public Dropdown WeaponThreeElement;

    public Dropdown RuneOne;
    public Dropdown RuneTwo;
    public Dropdown RuneThree;

    private void Start()
    {
        WeaponOne.onValueChanged.AddListener(WeaponOneChanged);
        WeaponTwo.onValueChanged.AddListener(WeaponTwoChanged);
        WeaponThree.onValueChanged.AddListener(WeaponThreeChanged);
        WeaponOneElement.onValueChanged.AddListener(WeaponOneElementChanged);
        WeaponTwoElement.onValueChanged.AddListener(WeaponTwoElementChanged);
        WeaponThreeElement.onValueChanged.AddListener(WeaponThreeElementChanged);
    }

    //dropdown value changing
    #region
    public void WeaponOneChanged(int a)
    {
        //do sth
    }

    public void WeaponTwoChanged(int a)
    {
        //do sth
    }

    public void WeaponThreeChanged(int a)
    {
        //do sth
    }

    public void WeaponOneElementChanged(int a)
    {
        //do sth
    }

    public void WeaponTwoElementChanged(int a)
    {
        //do sth
    }

    public void WeaponThreeElementChanged(int a)
    {
        //do sth
    }
    #endregion
}
