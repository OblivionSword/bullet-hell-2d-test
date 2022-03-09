using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBoundary : MonoBehaviour
{
    // destroy player bullet when it hit (rather exit) the shots boundary
    private void OnTriggerExit2D(Collider2D other)
    {
        Destroy(other.gameObject.transform.parent.gameObject);
    }
}
