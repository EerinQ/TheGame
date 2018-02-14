using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour {

	void Update () {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        Vector3 loodDir = mousePos - transform.position;
        loodDir = loodDir.normalized;
        transform.up = loodDir;
    }
}
