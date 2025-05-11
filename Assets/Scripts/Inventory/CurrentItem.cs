using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CurrentItem : MonoBehaviour, IPointerClickHandler
{

    private int itemNum;
    [HideInInspector]
    public int index;

    GameObject invObject;
    InventoryManager inventory;

    void Start ()
    {
        invObject = GameObject.FindGameObjectWithTag("Player");
        inventory = invObject.GetComponent<InventoryManager>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
      //if (eventData.button == PointerEventData.InputButton.Right)
      //  {
      //      if (inventory.item[index].id != 0 )
      //      {
      //          GameObject dropped = Instantiate(Resources.Load<GameObject>(inventory.item[index].pathPrefab));
      //          dropped.transform.position = invObject.transform.position * 1.2f;

      //          if (inventory.item[index].countItem > 1)
      //          { inventory.item[index].countItem--; }
      //          else { inventory.item[index] = new Item(); }
      //          inventory.DisplayItem();
      //      }
      //  }
    }


    //Item currentItem
    //{
    //    //get { return Inventory.instanceInventory.item[ItemNum]; }
    //    //set { Inventory.instanceInventory.item[ItemNum] = value; }
    //}

    //public int ItemNum
    //{
    //    get { return itemNum; }
    //    set { itemNum = value; }
    //}

    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    if (eventData.button == PointerEventData.InputButton.Left)
    //    {
    //    //    UseConsumableItem();
    //    //    RemoveItem();
    //    }

    //    if (eventData.button == PointerEventData.InputButton.Right)
    //    {
    //        //DropedItem();
    //        //RemoveItem();
    //    }
    //}

    //void UseConsumableItem()
    //{
    //    try
    //    {
    //        Item item = currentItem;
    //        ConsumableItem consumableItem = (ConsumableItem)item;
    //        SliderBar sliderBarObj = Inventory.instanceInventory.parametersManager.sliderBarManager;
    //        ShowSliderBar(consumableItem, sliderBarObj);

    //        TextBar textBarObj = Inventory.instanceInventory.parametersManager.textBarManager;
    //        ShowTextBar(consumableItem, textBarObj);
    //    }
    //    catch (System.Exception)
    //    {
    //        Debug.Log("UnusableItem");
    //    }
    //}

    //void ShowSliderBar(ConsumableItem consumableItem, SliderBar sliderBarObj)
    //{
    //    if (sliderBarObj)
    //    {
    //        UISliderBar[] sliderBars = Inventory.instanceInventory.parametersManager.sliderBarManager.sliderBars;
    //        for (int i = 0; i < sliderBars.Length; i++)
    //        {
    //            if (consumableItem.ExistParam(sliderBars[i].parameter))
    //            {
    //                float currentValue = consumableItem.ChangeParamValue(sliderBars[i].CurrentValue);

    //                float minValue = sliderBars[i].MinValue();
    //                float maxValue = sliderBars[i].MaxValue();

    //                sliderBars[i].CurrentValue = currentValue;

    //                if (isMaxValue(currentValue, maxValue))
    //                {
    //                    sliderBars[i].CurrentValue = maxValue;
    //                }

    //                if (isMinValue(currentValue, minValue))
    //                {
    //                    sliderBars[i].CurrentValue = minValue;
    //                }
    //            }
    //        }
    //    }
    //}

    //void ShowTextBar(ConsumableItem consumableItem, TextBar textBarObj)
    //{
    //    if (textBarObj)
    //    {
    //        UITextBar[] textBar = Inventory.instanceInventory.parametersManager.textBarManager.textBars;

    //        for (int i = 0; i < textBar.Length; i++)
    //        {
    //            if (consumableItem.ExistParam(textBar[i].parameter))
    //            {
    //                float currentValue = consumableItem.ChangeParamValue(textBar[i].currentValue);

    //                float minValue = textBar[i].minValue;
    //                float maxValue = textBar[i].maxValue;

    //                string textFormat = textBar[i].textFormat;

    //                textBar[i].currentValue = currentValue;

    //                if (isMaxValue(currentValue, maxValue))
    //                {
    //                    textBar[i].currentValue = maxValue;
    //                }

    //                if (isMinValue(currentValue, minValue))
    //                {
    //                    textBar[i].currentValue = minValue;
    //                }

    //                textBar[i].SetText(textFormat, textBar[i].currentValue.ToString(),
    //                        minValue.ToString(), maxValue.ToString());
    //            }
    //        }
    //    }
    //}

    bool isMinValue(float currentValue, float minValue)
    {
        if (currentValue < minValue)
        {
            return true;
        }
        return false;
    }

    bool isMaxValue(float currentValue, float maxValue)
    {
        if (currentValue > maxValue)
        {
            return true;
        }
        return false;
    }

  

    //void RemoveItem()
    //{
    //    if (currentItem.countItem > 1)
    //    {
    //        currentItem.countItem--;
    //    }
    //    else
    //    {
    //        currentItem = Inventory.instanceInventory.EmptySlot();
    //    }
    //    Inventory.instanceInventory.DisplayItems();
    //}

    //void DropedItem()
    //{
    //    if (currentItem.pathPrefab != null)
    //    {
    //        GameObject obj = Instantiate(Resources.Load<GameObject>(currentItem.pathPrefab));
    //        obj.transform.position = Camera.main.transform.position + transform.forward;
    //    }
    //}
}
