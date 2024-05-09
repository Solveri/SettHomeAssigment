using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{

    public MeshRenderer render;
    public bool isDoingCommand = false;
  
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {

       
        
        
    }
    public IEnumerator MovePosition(Vector3 posToMove, float duration)
    {
        isDoingCommand = true;
        float timer = 0;
        Vector3 startPos = transform.position;
        while (timer < duration)
        {

            timer += Time.deltaTime;
            float t = timer / duration;
            transform.position = Vector3.Lerp(startPos, posToMove, t);

            Debug.Log(timer);
            yield return null;

        }
        isDoingCommand = false;
        Debug.Log("Finished Moving");



    }
    public IEnumerator RotateAngle( Vector3 endRotation, float duration)
    {
        Quaternion startRot = transform.rotation;
        Quaternion endRot = Quaternion.Euler(endRotation.x, endRotation.y, endRotation.z);

        float timer = 0;
        Debug.Log("About to execute");
        isDoingCommand = true;
        while (timer < duration)
        {
            timer += Time.deltaTime;
            float t = timer / duration;
            transform.rotation = Quaternion.Lerp(startRot, endRot, t);


            yield return null;

        }
        isDoingCommand = false;
        Debug.Log("Rotated");
    }

    public IEnumerator ChangeColor(Color newColor, float duration)
    {
        Color initColor = render.material.color;
       isDoingCommand = true;
        Debug.Log("Color Changed");
        float timer = 0;
        while (timer < duration)
        {
            timer += Time.deltaTime;
            float t = timer / duration;
            render.material.color = Color.Lerp(initColor, newColor, t);

            yield return null;
        }
        isDoingCommand = false;
    }
}
