using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Dorr : MonoBehaviour
{
    private enum DorrType {PlasPoint,MinasPoint};
    [Header("Component")]
    [SerializeField] public SpriteRenderer _leftSprite;
    // [SerializeField] private Color _pointPlasColor;
    [SerializeField] public SpriteRenderer _rightSprite;
    // [SerializeField] private Color _pointMinasColor;


    // [SerializeField] private DorrType _leftDorType;
    [SerializeField] public int _leftDorPoint;
    // [SerializeField] private DorrType _rightDorType;
    [SerializeField] public int _rightDorPoint;

    
void Update()
{
}


    // private void ConfigerDorr()
    // {
    //     switch (_rightDorType)
    //     {
    //         case DorrType.PlasPoint:
    //         _rightSprite.color = _pointPlasColor;
    //         break;
    //         case DorrType.MinasPoint:
    //         _rightSprite.color = _pointMinasColor;
    //         break;           
    //     }

    //     switch (_leftDorType)
    //     {
    //         case DorrType.PlasPoint:
    //         _leftSprite.color = _pointPlasColor;
    //         break;
    //         case DorrType.MinasPoint:
    //         _leftSprite.color = _pointMinasColor;
    //         break;           
    //     }
    // }
    public void DoorAnim()
    {
        transform.DOMoveY(-13,4,false);
    }



}
