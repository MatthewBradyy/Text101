using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {
	public bool tiolet,sink,window;
	public Text text;
	private enum state
	{
		cell,
		locks,
		mirror,
		toilet,
		cell_mirror,
		toilet_1,
		locks_1,
		endGame_0,
		endGame_1,
		Been_there
	}
	private state myState;
	// Use this for initialization
	void Start () {
		tiolet = false;
		sink = false;
		window = false;
		myState = state.cell;
	}
	
	// Update is called once per frame
	void Update () {
		print (myState);
		if (myState == state.cell) {
			state_cell();
		}else if (myState == state.locks) {
			state_locks();
		}else if (myState == state.mirror) {
			state_mirror();
		}else if (myState == state.toilet) {
			state_toilet();
		}else if ((myState == state.cell_mirror)&&(window == true)&&(sink == true)&&(tiolet == true)) {
			state_cell_mirror();
		}else if (myState == state.locks_1) {
			state_locks_1();
		}else if (myState == state.endGame_0) {
			state_endGmae_0();
		}else if (myState == state.endGame_1) {
			state_endGmae_1();
		}else if (myState == state.toilet_1) {
			state_toilet_1();
		}
		else{
		state_cell();
		} 	 	 	 			
	}
	//Cell state first screen
	void state_cell()
	{
		text.text = "You are in a prison because of false causes of course. You wouldn’t do anything " +
			"to get you here. The window is locked as well as the door. You look around and " +
				"see that there is a very public toilet with a grimy sink. There is a simple mirror " +
				"hanging above the sink. You might want see what all the places have to offer\n\n" +
				"Press L to look at the locks, M to veiw mirror, and T to veiw toilet";
		if (Input.GetKeyDown(KeyCode.L)) {
				myState = state.locks;
				window = true;	
		}else if (Input.GetKeyDown(KeyCode.M)) {
			myState = state.mirror;
			sink = true;	
		}else if (Input.GetKeyDown(KeyCode.T)) {
			myState = state.toilet;
			tiolet = true;	
		}
	}
	// Locks state before bobby pin is found
	void state_locks(){
		text.text = "The locks seem old and like an easy thing to pick if only you had something. " +
					"Through the window you can see that there is an easy way down to the ground " +
					"and a route right to the busy streets, a perfect way to escape this wretched " +
					"place. Though the door is a long hall with a flickering light right in front " +
					"of your cell. They might want to get someone to fix that. It is quite an annoyance.\n\n" +
					"Press R to return to roaming the cell";
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = state.cell_mirror; //Sends you to cell_mirror only after everything it visited	
		}
	}
	void state_mirror(){
		text.text = "You walk toward the mirror and see no reflection once you reach it you notice " +
					"that the mirror is covered in dust. There is cloth on the sink so using it " + 
					"and some water you clean off the mirror only to reveal your ugly mug. "+
					"However, when you place the cloth back you notice something jammed between " +
					"the sink and wall, it is a bobby pin " +
					"\n\nPress R to return to roaming the cell";
		
			if(Input.GetKeyDown(KeyCode.R)) {
			myState = state.cell_mirror;//Sends you to cell_mirror only after everything it visited	
		}
	}
	void state_toilet(){
		text.text = "You approach the toilet and find that there is a foul stench coming from it. " +
					"In further inspection you find that the former occupant has let a gift in " +
					"the toilet. Fortunately, there is some Febreze and you know how to flush." +
					"\n\nPress R to return to roaming the cell";
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = state.cell_mirror;//Sends you to cell_mirror only after everything it visited	
		}
	}
	void state_cell_mirror(){
		text.text = "Now you have found a bobby pin maybe there’s a way to use it to pick a lock. " +
					"But Should you really try to pick a lock with it. You shouldn’t have to wait " +
					"long the crime you are in for isn’t really a crime you committed there must " +
					"be some kind of mistake, RIGHT??? But then who knows how long you will be in " +
					"here hurt to try.\n\n" +
					"press L to pick a lock, Press T to the tiolet";
		if (Input.GetKeyDown(KeyCode.L)) {
			myState = state.locks_1;	
		}else if (Input.GetKeyDown(KeyCode.T)) {
			myState = state.toilet_1;	
		}
	}
	void state_locks_1(){
		text.text = "Ok good you smartened up let’s get pick one of the locks with the pin, "+
					"but you only have one so choose wisely. You can ether choose the window "+
					"where you can see freedom but can’t smell the great senses from outside "+
					"because of the glass that is locked shut. Or you could choose the door "+
					"which give you a way to get away from that annoying light that keeps flashing." +
					"\n\nPress W for window, D for Door";
		if (Input.GetKeyDown(KeyCode.W)) {
			myState = state.endGame_0;	
		}else if (Input.GetKeyDown(KeyCode.D)) {
			myState = state.endGame_1;	
		}
	}
	void state_toilet_1(){
		text.text = "You go back to the toilet this time it is smelling a lot better the flush "+
					"and Fra breeze did the trick. Even thought the cell is growing on you "+
					"still might want to use that key that was left for you."+
					"\n\n Press R to return";
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = state.cell_mirror;	
		}
	}
	void state_endGmae_0(){
		text.text = "Great choose you picked to use the bobby pin on the window. " +
					"After a few minite of wiggling and hold that is will work you heard the "+
					"best sound. The sound of a click in the lock did this really work. " +
					"You push the window and it opens…"+
					"\nThat was a great choose now you cell has fresh air flowing in. inside "+
					"of just having the view you get it all the small of the outside air that you "+
					"love and you can hear the city come to life. This will help pass the time well "+
					"you serve out you sentence."+
					"\n\nPress space to restart";

		if (Input.GetKeyDown(KeyCode.Space)) {
			Start();	
		}
	}
	void state_endGmae_1(){
		text.text = "Oh the door I hope you know what you are doing. You look to make sure "+
					"no one is looking or coming and get to work. The lock is easy to pick "+
					"the the bobby pin brakes well you are trying to pick it but the door is "+
					"unlock better not get cought out you walk down the hall and find exactly "+
					"what you wanted to….."+
					"\nA ladder and a new light you go back to you cell with the ladder and "+
					"replace the blinking light that’s a lot better good thing everyone is "+
					"asleep and not one is around this gives you the time you need to put the "+
					"ladder back and slip back in to you cell but close the door quietly you "+
					"don’t want people to know."+
					"\n\nPress space to restart";

		
		if (Input.GetKeyDown(KeyCode.Space)) {
			Start();	
		}
	}
	
}
