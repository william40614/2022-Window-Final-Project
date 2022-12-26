using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickable
{
    GameObject gameObject { get; }
    void Pick();
    void Drop();
}