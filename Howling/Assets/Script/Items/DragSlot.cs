using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragSlot : MonoBehaviour
{
    //Àü¿ª º¯¼ö·Î ¼±¾ð(½Ì±ÛÅæ)
    static public DragSlot _instance;
    public Slot _dragSlot;

    [SerializeField]
    private Image imageItem;

    private void Start()
    {
        _instance = this;
    }

    public void DragSetImage(Image _itemImage)
    {
        imageItem.sprite = _itemImage.sprite;
        SetColor(1);
    }    

    public void SetColor(float _alpha)
    {
        Color color = imageItem.color;
        color.a = _alpha;
        imageItem.color = color;
    }
}
