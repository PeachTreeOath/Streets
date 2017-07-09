using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    private Weapon weapon;
    private Tool tool;
    private IInventoryItem spare1;
    private IInventoryItem spare2;

    public bool AddToInventory(IInventoryItem item)
    {
        InventoryType type = item.GetInventoryType();
        bool itemAdded = false;
        int itemAddedPosition = 0;
        switch (type)
        {
            case InventoryType.WEAPON:
                if (weapon == null)
                {
                    weapon = (Weapon)item;
                    itemAdded = true;
                    itemAddedPosition = 1;
                }
                else if (spare1 == null)
                {
                    spare1 = item;
                    itemAdded = true;
                    itemAddedPosition = 3;
                }
                else if (spare2 == null)
                {
                    spare2 = item;
                    itemAdded = true;
                    itemAddedPosition = 4;
                }
                break;
            case InventoryType.TOOL:
                if (tool == null)
                {
                    tool = (Tool)item;
                    itemAdded = true;
                    itemAddedPosition = 2;
                }
                else if (spare1 == null)
                {
                    spare1 = item;
                    itemAdded = true;
                    itemAddedPosition = 3;
                }
                else if (spare2 == null)
                {
                    spare2 = item;
                    itemAdded = true;
                    itemAddedPosition = 4;
                }
                break;
        }
        if (itemAdded)
        {
            EquipItem(item);
            UIManager.instance.UpdateInventoryImage(itemAddedPosition, item.GetItemSprite());
        }
        return itemAdded;
    }

    public void EquipItem(IInventoryItem newItem)
    {
        newItem.SetParent(transform);
    }

    public void SwapSpare1()
    {
        if(spare1 != null)
        {
            switch(spare1.GetInventoryType())
            {
                case InventoryType.WEAPON:
                    IInventoryItem oldWeaponTemp = weapon;
                    IInventoryItem newWeaponTemp = spare1;
                    weapon = null;
                    spare1 = null;
                    AddToInventory(newWeaponTemp);
                    AddToInventory(oldWeaponTemp);
                    break;
                case InventoryType.TOOL:
                    break;
            }
        }
    }

    public void SwapSpare2()
    {
        if (spare2 != null)
        {

        }

    }

    public Weapon GetWeapon()
    {
        return weapon;
    }

    public Tool GetTool()
    {
        return tool;
    }
}
