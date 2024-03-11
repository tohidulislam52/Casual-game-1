using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeUIManager : MonoBehaviour
{
    [SerializeField] private GameObject _homePanel;
    [SerializeField] private GameObject _shopePanel;
    [SerializeField] private GameObject[] _Playersss;
    // Start is called before the first frame update
    void Start()
    {
        UpdateCharacter();
    }
    void OnEnable()
    {
        ShopManager.onSelectSkin +=UpdateCharacter;
    }
    void OnDisable()
    {
        ShopManager.onSelectSkin -=UpdateCharacter;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void UpdateCharacter()
    {
        for (int i = 0; i < _Playersss.Length; i++)
        {
            _Playersss[i].gameObject.SetActive(false);
            if(PlayerPrefs.GetInt("Player",0) == i)
            {
                _Playersss[i].gameObject.SetActive(true);
                Debug.Log("dkfald");
            }
            
        }
    }
    public void ShowShopPanel()
    {
        _homePanel.SetActive(false);
        _shopePanel.SetActive(true);

    }
    public void HideShopPanel()
    {
        _homePanel.SetActive(true);
        _shopePanel.SetActive(false);
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }




}
