using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;


public class FinishlineSystem : MonoBehaviour
{
    [SerializeField] private CharacterController _charactercon;
    [SerializeField] private Animator _anim;
    private float _animationTime;
    private float _animLenght;
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _gate;
    [SerializeField] private GameObject _hasban;
    [SerializeField] private ParticleSystem[] _partical;
    private bool _gateOpen;
    private bool _gameOver;
    void Start()
    {
        _gate = GameObject.FindWithTag("Gate");
        _hasban = GameObject.Find("Husban");
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position,_gate.transform.position) < 5 && !_gateOpen)
        {
            Debug.Log("Gate");
            _gate.GetComponent<Animator>().SetTrigger("open");
            _gateOpen = true;
            LastMove();
        }
        
    }
    private void LastMove()
    {
        transform.DOMoveZ(transform.position.z + 27.5f,6,false).OnComplete(delegate
        {
            _anim =GetComponent<PlayerMovement>()._anim;
            // GetComponent<PlayerMovement>()._anim.SetTrigger("idel");
            _anim.SetTrigger("idel");
            transform.DOMoveX(-1,1,false);
            Camera.main.GetComponent<CinemachineBrain>().enabled = false;
            // transform.eulerAngles = new Vector3(0,180,0);
            Camera.main.transform.DOMove(new Vector3(.3f,5,Camera.main.transform.position.z +1),1,false);
            Camera.main.transform.DORotate(new Vector3(13.2f,0,0),1);
            transform.DORotate(new Vector3(0,-180,0),1);
            Invoke("Dance",1);
            Invoke("PlayVFX",1);
            Invoke("gameFinish",2.5f);
           

        });
    }
    private void gameFinish()
    {
        UiManager.instance.GameFinishUI();
    }
    private void Dance()
    {
        // _anim.SetInteger("Dance",Random.Range(1,4));
        _anim.SetInteger("Dance",Random.Range(1,9));
        _hasban.GetComponent<Animator>().SetInteger("Dance",Random.Range(1,7));
    }
    public void ChangeDance()
    {
        _anim.SetInteger("Dance",0);
        _hasban.GetComponent<Animator>().SetInteger("Dance",0);
        Invoke("Dance",.7f);

    }

    public void PlayVFX()
    {
        for (int i = 0; i < _partical.Length; i++)
        {
            _partical[i].Play();
        }
    }

     void OnControllerColliderHit(ControllerColliderHit hit) 
    {
        if(hit.gameObject.tag == "Finish")
        {
            GetComponent<PlayerMovement>()._canMove = false;
            GetComponent<PlayerMovement>()._DontMove = true;
            UiManager.instance._ingamePanel.SetActive(false);
            // Debug.Log("Suuuuui");
            transform.DOMoveX(0,.6f,false).OnComplete(delegate
            {
                
            });
            hit.transform.GetComponent<Collider>().enabled = false;
            // hit.gameObject.SetActive(false);
            FinishAnimation(UiManager.instance._helth,UiManager.instance._lap);
            // Debug.Log("nani");
        }
        
        
    }
    



    private void FinishAnimation(float _helth , int _lap)
    {
        if(_lap == 0)
        {
            // _animLenght = Random.Range(7,15);
            // _animationTime = Random.Range(3,4);
            //_animLenght = 75;
            // _animLenght = 13;
            // _animationTime = 4;
            LenghtandTime(13,4);
        }
        else if(_lap == 1)
        {
            
            LenghtandTime(Random.Range(20,30),6);
        }
        else if(_lap == 2)
        {
            // UiManager.instance._helth >=80 && UiManager.instance._helth >= 60? LenghtandTime(75,10):LenghtandTime(55,10);
            
            switch (UiManager.instance._helth)
            {
                case <=20:
                LenghtandTime(Random.Range(35,40),7);
                break;
                case <=50:
                LenghtandTime(Random.Range(45,50),7);
                break;
                case <80:
                LenghtandTime(Random.Range(55,62),7);
                break;
                case >= 80:
                LenghtandTime(75,10);
                _gameOver = true;
                break;
                
            }
            
        }
        

        transform.DOMoveZ(transform.position.z + _animLenght,_animationTime,false).OnComplete(delegate
        {
            if(!_gameOver)
            {
                UiManager.instance.GameOverUI();
            }
        });
          
        
    }
    private void LenghtandTime(float LengthNum,float time)
    {
        _animLenght = LengthNum;
        _animationTime = time;
    }





}
