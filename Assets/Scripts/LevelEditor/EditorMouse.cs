using Dogelix;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorMouse : MonoBehaviour
{
    public BlockType[] _allTypes;
    public BlockType _selectedType;

    private void Awake()
    {
        
    }

    private void FixedUpdate()
    {
        if(_selectedType != null )
        {
            Block.Create(_selectedType, Vector3.up);
            _selectedType = null;
        }
    }
}
