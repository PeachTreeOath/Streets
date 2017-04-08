using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Attach this to a cursor to navigate MenuSelectable elements. An offset can be
/// set by changing the local position of the cursor in the scene.
/// </summary>
public class MenuCursor : MonoBehaviour
{

    public MenuSelectable startingMenuItem;
    public MenuSelectable currentMenuItem { get; private set; }

    private Vector3 cursorOffset;

    // Use this for initialization
    void Start()
    {
        cursorOffset = transform.localPosition;
        MoveToItem(startingMenuItem);
    }

    public void MoveUp()
    {
        MenuSelectable nextItem = currentMenuItem.selectOnUp;
        if (nextItem != null)
        {
            MoveToItem(nextItem);
        }
    }

    public void MoveDown()
    {
        MenuSelectable nextItem = currentMenuItem.selectOnDown;
        if (nextItem != null)
        {
            MoveToItem(nextItem);
        }
    }

    public void MoveLeft()
    {
        MenuSelectable nextItem = currentMenuItem.selectOnLeft;
        if (nextItem != null)
        {
            MoveToItem(nextItem);
        }
    }

    public void MoveRight()
    {
        MenuSelectable nextItem = currentMenuItem.selectOnRight;
        if (nextItem != null)
        {
            MoveToItem(nextItem);
        }
    }

    private void MoveToItem(MenuSelectable nextItem)
    {
        transform.position = nextItem.transform.position + cursorOffset;
        currentMenuItem = nextItem;
    }

}
