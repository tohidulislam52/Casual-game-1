using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using DG.Tweening;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [Header("Components")]
   [SerializeField] private CharacterController _ChaContrler;
   [SerializeField] private Joystick _joystick;
   [SerializeField] private Animator _anim;
   [SerializeField] public GameObject[] _playerss;
   [SerializeField] private Text NumberText;


    [Header("Veriables")]
    private Vector3 _move;
    public bool _canMove,_DontMove;
    public Vector2 minimax;
    [SerializeField] private float _speed,_vectorvelocity,_leftRight;

    void Start()
    {
            // _anim.SetInteger("anim",2);
            // StartCoroutine(StratGame());
        
    }

   void Update()
    {
        
        
        if(Input.GetMouseButtonDown(0) && !_canMove && !_DontMove)
        {
            _canMove = true;
            // _anim.SetInteger("anim",1);
            // _anim.SetBool("b",true);
        }
            
        if(_canMove)
            Playermove();

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minimax.x, minimax.y),
                           transform.position.y, transform.position.z);
    }

    private void Playermove()
    {

        _move = Vector3.zero;
        _move = Vector3.forward;

        _move.Normalize();
        _move *= _speed;
        _move.x = _joystick.Horizontal * _leftRight;
        _move.y = _vectorvelocity;
        // if(Input.GetMouseButton(0))
        _ChaContrler.Move(_move * Time.deltaTime);
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.tag == "Object")
        {
            hit.gameObject.GetComponent<ObjectAnimation>()._canAnimation = true;
            UiManager.instance._helth += hit.gameObject.GetComponent<ObjectAnimation>()._Value; 
            // Destroy(hit.gameObject);
            hit.gameObject.SetActive(false);
        }
        if(hit.transform.tag == "Door")
        {
            if(transform.position.x > 0)
            {
                Debug.Log("Right");
                hit.gameObject.GetComponent<Dorr>()._rightSprite.enabled = false;
                hit.gameObject.GetComponent<Dorr>().DoorAnim();
                UiManager.instance._helth += hit.gameObject.GetComponent<Dorr>()._rightDorPoint;
            }
            if(transform.position.x < 0)
            {
                Debug.Log("Left");
                hit.gameObject.GetComponent<Dorr>().DoorAnim();
                hit.gameObject.GetComponent<Dorr>()._leftSprite.enabled = false;
                UiManager.instance._helth += hit.gameObject.GetComponent<Dorr>()._leftDorPoint;
            }
            hit.gameObject.GetComponent<Collider>().enabled = false;
        }

        if(hit.gameObject.tag == "Traps")
        {
            for (int i = 0; i < _playerss.Length; i++)
            {
                if(_playerss[i].activeInHierarchy)
                {
                    _anim = _playerss[i].GetComponent<Animator>();
                }
            }
            _canMove = false;
            _DontMove = true;
            _anim.SetInteger("anim",2);
            transform.DOMoveZ(transform.position.z -13,.5f,false).OnComplete(delegate
            {
                _anim.SetInteger("anim",1);
                Invoke("AnimationAfterMove",3.8f);
            });
            
        }
        
        
    }
    private void AnimationAfterMove()
    {
        // if(_anim.GetCurrentAnimatorStateInfo(0).IsName("Jogging"))
        // {
        _DontMove =false;
        _canMove = true;
        Debug.Log("UP");
        // }
    }
    IEnumerator StratGame()
    {
        NumberText.text = 3.ToString();
        NumberText.color = Random.ColorHSV(0,1,.5f,1,1,1);
        yield return new WaitForSeconds(1);
        NumberText.text = 2.ToString();
        NumberText.color = Random.ColorHSV(0,1,.5f,1,1,1);
        yield return new WaitForSeconds(1);
        NumberText.text = 1.ToString();
        NumberText.color = Random.ColorHSV(0,1,.5f,1,1,1);
        yield return new WaitForSeconds(1);
        NumberText.text = "Go!";
        NumberText.color = Random.ColorHSV(0,1,.5f,1,1,1);
        _canMove =true;
        yield return new WaitForSeconds(.5f);
        NumberText.gameObject.SetActive(false);

    }
    






}
