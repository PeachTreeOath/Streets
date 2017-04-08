using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Attach this to menu elements that need to be hooked up together for navigation.
/// </summary>
public class MenuSelectable : MonoBehaviour {

    public MenuSelectable selectOnUp;
    public MenuSelectable selectOnDown;
    public MenuSelectable selectOnLeft;
    public MenuSelectable selectOnRight;

}
