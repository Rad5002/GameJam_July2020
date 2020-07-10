using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Keybinding Data", menuName = "Keybinding Data")]
public class KeybindingData : ScriptableObject
{
    [System.Serializable]
    public class Keybinding
    {
        public KeybindingActions Action;
        public KeyCode PositiveKeyCode;
        public KeyCode NegativeKeyCode = KeyCode.None;
    }

    public Keybinding[] Keybindings = new Keybinding[Enum.GetNames(typeof(KeybindingActions)).Length];
}