using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class Commands : MonoBehaviour
{
    /*
     * Command To Move To Another Position
     * Command To Roate to diffrent Angle
     * Command to Change color
     * */

   public void MoveCommand(Robot robot,Vector3 posToMove,float Duration)
    {
        Debug.Log("About to move");
        StartCoroutine(robot.MovePosition(posToMove,Duration));
       
        
    }
   public void RotateCommand(Robot robot ,Vector3 rotation,float Duration)
    {
        StartCoroutine(robot.RotateAngle(rotation, Duration));
    }
    public void ChangeColorCommand(Robot robot,Color newColor,float Duration)
    {
        StartCoroutine(robot.ChangeColor(newColor, Duration));
    }
}
