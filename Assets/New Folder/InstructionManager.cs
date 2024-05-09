
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InstructionManager : MonoBehaviour
{
    [SerializeField] Commands commands;
    private Queue<Action> firstRobotinstruction = new Queue<Action>();
    private Queue<Action> secondRobotinstruction = new Queue<Action>();
    [SerializeField] Robot robotOne;
    [SerializeField] Robot robotTwo;

    [SerializeField] Vector3 newPos;
    [SerializeField] Vector3 desiredAngle;
    [SerializeField] Color desiredColor;
    [SerializeField] float Duration;
    [SerializeField] float RotateDuration;
    [SerializeField] float ChangeColorDuration;
    
    // Start is called before the first frame update
    void Start()
    {
        

       InitRobotInstructions(firstRobotinstruction,robotOne,newPos,desiredAngle,desiredColor,Duration);
       InitRobotInstructions(secondRobotinstruction,robotTwo,-newPos,-desiredAngle,Color.red,Duration);
        

    }

    void InitRobotInstructions(Queue<Action> instructions,Robot robot,Vector3 NewPos,Vector3 newAngle,Color newColor,float duration)
    {
        instructions.Enqueue(() => commands.MoveCommand(robot, NewPos, duration));
        instructions.Enqueue(() => commands.RotateCommand(robot, newAngle, duration));
        instructions.Enqueue(() => commands.ChangeColorCommand(robot, newColor, duration));
        instructions.Enqueue(() => commands.MoveCommand(robot, new Vector3(32, 0, 33), duration));

    }
    
    // Update is called once per frame
    void Update()
    {
       if(firstRobotinstruction.Count > 0 && !robotOne.isDoingCommand)
        {
            Action currentAction = firstRobotinstruction.Dequeue();
            
            currentAction.Invoke();
        }
        if (secondRobotinstruction.Count>0 && !robotTwo.isDoingCommand)
        {
            Debug.Log("About to do an action");
            Action currentAction = secondRobotinstruction.Dequeue();

            currentAction.Invoke();
        }

    }
    
}
