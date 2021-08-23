using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ore : MonoBehaviour
{
    public bool Empty => _amount <= 0;

    private int _amount;

    internal void Mine(int amount)
    {
        _amount -= amount;
    }
}
