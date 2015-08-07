using UnityEngine;
using System.Collections;

public enum GameState{
	FindBox01,
    FindBoxAgain02,
    FindeWerkzeuge03,
    WaterBoiler04,
	WaterRises05,
	WaterDrops06
}


public class StateMachine {

	private static StateMachine _instance;
	private GameState _state;

	public delegate void StateChangedHandler(GameState oldState, GameState newState);
	public event StateChangedHandler OnStateChanged;

    	// true on first box pickup
    public bool State1_BoxFound = false;
    public bool State1_BoxAtFrontDoor = false;
    	// true on first box pickup after replacement
    public bool State2_BoxFound = false;



	public GameState State{
		get{ return _state; }
		set{
            if (OnStateChanged != null) { 
			    OnStateChanged(_state, value);
            }
			_state = value;
		}
	}

	public static StateMachine Instance{
		get{
			if(_instance == null) {
			    StateMachine._instance = new StateMachine {State = GameState.FindBox01};
			}
            return StateMachine._instance;
		}
	}


	protected StateMachine(){}

}
