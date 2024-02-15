using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextDistance : MonoBehaviour
{
    [SerializeField] private GameObject _tergetRuner;
    [SerializeField] private TextMeshPro _text;
    void Start()
    {
        _tergetRuner = GameObject.FindWithTag("Player");
        _text = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position,_tergetRuner.transform.position) <= 1)
        {
            _text.color = Color.white;
            Debug.Log("text");
            
        }
    }
}
