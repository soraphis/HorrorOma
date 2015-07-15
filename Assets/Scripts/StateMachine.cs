using UnityEngine;
using System.Collections;

public enum GameState{

	GameStart, SearchBox1, FoundBox1, DoorOpened, SearchBox2, FoundBox2, DoorLocked, 

}


public class StateMachine {

	private static StateMachine _instance;
	private GameState _state;

	public delegate void StateChangedHandler(GameState oldState, GameState newState);
	public event StateChangedHandler OnStateChanged;

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
			if(_instance == null)
				StateMachine._instance = new StateMachine();
			return StateMachine._instance;
		}
	}


	protected StateMachine(){}

}
