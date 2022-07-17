using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw
{

    public Throw(int min, int max, int throwValue)
    {
        this.min = min;
        this.max = max;
        this.throwValue = throwValue;
    }
    private int max;
    private int min;
    private int throwValue;

    public int GetMax()
    {
        return max;
    }

    public int GetMin()
    {
        return min;
    }

    public int GetThrow()
    {
        return throwValue;
    }

}
