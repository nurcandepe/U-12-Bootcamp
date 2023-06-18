using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class State
{

   // public CharacterController character;
    public StateMachine stateMachine;

    public InputAction drawSwordAction;
    public InputAction attackAction;


    protected Vector2 input;

    /*public State(CharacterController _character, StateMachine _stateMachine)
    {
        character = _character;
        stateMachine = _stateMachine;

        drawSwordAction = character._input.actions["DrawSword"];

    }*/

    public virtual void Enter()
    {
        Debug.Log("enter state: " + this.ToString());
    }

    public virtual void HandleInput()
    {
    }

    public virtual void PhysicsUpdate()
    {
    }

    public virtual void Exit()
    {
    }
}
