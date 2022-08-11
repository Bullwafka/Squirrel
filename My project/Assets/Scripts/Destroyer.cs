using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private FireMover _fireMover;
    private KillScript _killScript;
    
    private void Start()
    {
        _fireMover = GameObject.Find("Fire").GetComponent<FireMover>();
        _killScript = GameObject.Find("PlayerObject").GetComponent<KillScript>();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<LevelGeneratingObject>(out LevelGeneratingObject levelObject))
        {
            levelObject.DisableObject();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Squirrel"))
        {
            _fireMover.StopFire();
            _killScript.Kill();
        }
    }
}
