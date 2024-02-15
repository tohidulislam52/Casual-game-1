using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChange : MonoBehaviour
{
   [SerializeField] private GameObject _VFX;
   private PlayerMovement _PlayerMove;
   [SerializeField] private GameObject gameObjects;
    
    void Start()
    {
        _PlayerMove = GetComponent<PlayerMovement>();
        gameObjects = transform.GetChild(2).gameObject;
    }
    // void OnDestroy()
    // {
    //     UiManager.OnPlayerChange -= Playerchange;
    // }
    void OnEnable()
    {
        UiManager.OnPlayerChange += Playerchangeeee;
        
    }
    void OnDisable()
    {
        UiManager.OnPlayerChange -= Playerchangeeee;
        
    }

    
    void Update()
    {
        
    }
    private void Playerchangeeee(int lap)
    {
        if(lap == 1)
        {
        StartCoroutine(PlayerSkinChange(1));
        }
        else if(lap ==2)
        {
            StartCoroutine(PlayerSkinChange(2));
        }
    }

    IEnumerator PlayerSkinChange(int skinNum)
    {
        _PlayerMove._canMove = false;
        _VFX.SetActive(true);
        yield return new WaitForSeconds(1);
        for (int i = 0; i < _PlayerMove._playerss.Length; i++)
        {
            if(_PlayerMove._playerss[i].activeInHierarchy)
            {
                _PlayerMove._playerss[i].SetActive(false);
            }
        }
        // skin number
        transform.GetChild(0).GetChild(skinNum).gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        _PlayerMove._canMove = true;
        _VFX.SetActive(false);
    }

}
