using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "integer", menuName = "integer", order = 0)]
public class Integer : ScriptableObject
{
    public int value;

    public static implicit operator int(Integer integer)
    {
        return integer.value;
    }
    public static Integer operator +(Integer a, int b)
    {
        a.value += b;
        return a;
    }public static Integer operator -(Integer a, int b)
    {
        a.value -= b;
        return a;
    }
    public static Integer operator *(Integer a, int b)
    {
        a.value *= b;
        return a;
    }public static Integer operator /(Integer a, int b)
    {
        a.value /= b;
        return a;
    }
}