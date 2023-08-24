using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Vector3 startVec = new Vector3(0, 0, 0);
    Vector3 endVec = new Vector3(0, 24, 0);
    Vector3 tempVec;
    private float t = 0;
    private float elapsedTime = 0f;
    public float moveDuration = 5f;

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        t = Mathf.Clamp01(elapsedTime / moveDuration);
        transform.position = Vector3.Lerp(startVec,endVec,t);
        if (t >= 1)
        {
            t = 0;
            elapsedTime = 0;
            tempVec = startVec;
            startVec = endVec;
            endVec = tempVec;
        }
    }
}
