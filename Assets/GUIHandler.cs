using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GUIHandler : MonoBehaviour
{   
    [SerializeField] private GameObject Shop_UI;
    [SerializeField] private GameObject Shop_Buttons;
    [SerializeField] private GameObject Heroes_UI;
    [SerializeField] private GameObject Weapons_UI;
    [SerializeField] public GameObject currentlyActiveUI;

    private void Start() {
        currentlyActiveUI = null;
    }
    public void showHeroShop()
    {
        if (!Heroes_UI.activeSelf) // Check if UI is active or not
        {
            disableActiveUI();
            Debug.Log("activated ui");
            Heroes_UI.SetActive(true);
            Shop_Buttons.transform.position = Shop_Buttons.transform.position + new Vector3(0,250,0);
            currentlyActiveUI = GameObject.Find("UI_Heroes_Shop");
        }
        else // Hide the shop if pressed again
        {
            Debug.Log("disabled ui");
            Heroes_UI.SetActive(false);
            Shop_Buttons.transform.position = Shop_Buttons.transform.position + new Vector3(0,-250,0);
            currentlyActiveUI = null;
        }
    }

    public void showWeaponsShop()
    {
        if (!Weapons_UI.activeSelf) // Check if UI is active or not
        {
            disableActiveUI();
            Weapons_UI.SetActive(true);
            Shop_Buttons.transform.position = Shop_Buttons.transform.position + new Vector3(0,250,0);
            currentlyActiveUI = GameObject.Find("UI_Weapons_Shop");
        }
        else // Hide the shop if pressed again
        {
            Weapons_UI.SetActive(false);
            Shop_Buttons.transform.position = Shop_Buttons.transform.position + new Vector3(0,-250,0);
            currentlyActiveUI = null;
        }
    }

    public void disableActiveUI()
    {
        Debug.Log("Test");
        if (currentlyActiveUI == null)
        {
            Debug.Log("active ui is null");
        }
        else
        {
            Debug.Log("disabled active ui");
            currentlyActiveUI.SetActive(false);
            Shop_Buttons.transform.position = Shop_Buttons.transform.position + new Vector3(0,-250,0);
        }
    }
}
