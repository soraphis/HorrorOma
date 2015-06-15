using UnityEngine;
using System.Collections;

public enum GameState{

	GameStart, SearchBox1, FoundBox1, DoorOpened, SearchBox2, FoundBox2, DoorLocked, 

}


public class StateMachine {

	private static StateMachine _instance;
	private GameState _state;

	public delegate void StateChangedHandler(GameState oldState, GameState newState);
	public event StateChangedHandler onStateChanged;

	public GameState state{
		get{ return _state; }
		set{ 
			onStateChanged(_state, value);
			_state = value;
		}
	}

	public static StateMachine instance{
		get{
			if(_instance == null)
				StateMachine._instance = new StateMachine();
			return StateMachine._instance;
		}
	}


	protected StateMachine(){}

}
