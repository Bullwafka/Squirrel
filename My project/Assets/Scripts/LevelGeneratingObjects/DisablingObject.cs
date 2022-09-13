using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DisablingObject : MonoBehaviour
{
    public void DisableObject()
    {
        gameObject.SetActive(false);
    }
}
