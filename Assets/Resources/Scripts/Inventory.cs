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

        switch (type)
        {
            case InventoryType.WEAPON:
                if (weapon == null)
                {
                    weapon = (Weapon)item;
                    itemAdded = true;
                }
                else if (spare1 == null)
                {
                    spare1 = item;
                    itemAdded = true;
                }
                else if (spare2 == null)
                {
                    spare2 = item;
                    itemAdded = true;
                }
                break;
            case InventoryType.TOOL:
                if (tool == null)
                {
                    tool = (Tool)item;
                    itemAdded = true;
                }
                else if (spare1 == null)
                {
                    spare1 = item;
                    itemAdded = true;
                }
                else if (spare2 == null)
                {
                    spare2 = item;
                    itemAdded = true;
                }
                break;
        }
        return itemAdded;
    }

    public void EquipNewWeapon(Weapon newWeapon)
    {
        Destroy(weapon.gameObject);
        EquipWeapon(newWeapon);
    }

    public void EquipWeapon(Weapon newWeapon)
    {
        newWeapon.transform.SetParent(transform);
        weapon = newWeapon;
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
