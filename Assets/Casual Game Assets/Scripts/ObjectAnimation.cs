using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObjectAnimation : MonoBehaviour
{
    public bool _canAnimation;
    [SerializeField] public float _Value;
    // [SerializeField] private Vector3 _Rotat;
    // [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
       Dwon();
    }
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0,90*Time.fixedDeltaTime,0));
    }
    
    private void Up()
    {
            transform.DOMoveY(transform.position.y +.7f,1.2f,false).OnComplete(delegate
            {
                if(!_canAnimation)
                    Dwon();
            });
        // transform.DORotate(new Vector3(0,360,0),1);
    }
    private void Dwon()
    {
            transform.DOMoveY(transform.position.y -.7f,1.2f,false).OnComplete(delegate{
                 if(!_canAnimation)
                    Up();
            });
        
    }
    
}
