using UnityEngine;
using System.Collections;

using Pose = Thalmic.Myo.Pose;
using VibrationType = Thalmic.Myo.VibrationType;

// Change the material when certain poses are made with the Myo armband.
// Vibrate the Myo armband when a fist pose is made.
public class ElementPower : MonoBehaviour
{
	public Rigidbody rock; //stored rock asset
	public Rigidbody flame; //stored fire asset
	public Rigidbody spray; //stored water asset

	public float WalkSpeed; //walk speed of the player

	CharacterController controller; //character controller
	Vector3 playerLoc; //will store position of player

	public int speed = 20; //speed of projectiles

	GameObject player; //The actual player

	int selectedElement = 0; //will switch between elements. Default fire.

	// Myo game object to connect with.
	// This object must have a ThalmicMyo script attached.
	public GameObject myo = null;
	
	// Materials to change to when poses are made.
	public bool fire = true;
	public bool water = false;
	public bool air = false;
	public bool earth = false;
	
	// The pose from the last update. This is used to determine if the pose has changed
	// so that actions are only performed upon making them rather than every frame during
	// which they are active.
	private Pose _lastPose = Pose.Unknown;

	void Awake()
	{ 
		player = GameObject.FindGameObjectWithTag ("Player"); //finds the player
		controller = player.GetComponent<CharacterController> (); //gets the character controller of the player
	}

	//throws a boulder forward from the characters position
	void rockThrow() 
	{
		Rigidbody rockClone = Instantiate (rock, transform.position, transform.rotation) as Rigidbody;
		rockClone.velocity = transform.forward * speed;
	}

	//shoots fire from the player's hand
	void FireFlame() 
	{
		Rigidbody fireClone = Instantiate (flame, transform.position, transform.rotation) as Rigidbody;
		fireClone.velocity = transform.forward * speed;
	}

	//fires water from the player's hand
	void waterBeam() 
	{
		Rigidbody waterClone = Instantiate (spray, transform.position, transform.rotation) as Rigidbody;
		waterClone.velocity = transform.forward * speed;
	}

	//forces the player up into the air (They can fly!)
	void airFly() 
	{
		playerLoc = new Vector3 (player.transform.position.x, player.transform.position.y + 3000, player.transform.position.z);
		controller.Move (playerLoc * Time.deltaTime);

	}
	
	// Update is called once per frame.
	void Update ()
	{
		//hotkey for earth
		if (Input.GetKeyDown ("z")) 
		{
			rockThrow ();
		} 

		//hotkey for fire
		else if (Input.GetKeyDown ("f")) 
		{
			FireFlame ();
     	}

		//stores the myo component
		ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo> ();

		//makes sure that poses do not repetitively loop (Only happen once)
		if (thalmicMyo.pose != _lastPose) 
		{
			_lastPose = thalmicMyo.pose; //stores last pose


			//will decrement the selected element at a wave left
			if (thalmicMyo.pose == Pose.WaveIn || Input.GetKeyDown(KeyCode.LeftArrow)) 
			{

				//creates circular loop for changing elements
				if (selectedElement == 0) 
				{
					selectedElement = 3;
				}

				//changes the selected element
				else 
				{
					selectedElement--;
				}
			}

			//will increment the selected element at a wave right
			else if (thalmicMyo.pose == Pose.WaveOut || Input.GetKeyDown(KeyCode.RightArrow)) 
			{

				//creates circular loop for changing elements
				if (selectedElement == 3)
				{
					selectedElement = 0;
				}

				//changes the selected element
				else
				{
					selectedElement++;
				}
 			}

			//activates the ability
			if (thalmicMyo.pose == Pose.FingersSpread) 
			{
				//checks the switched element
				switch (selectedElement) 
				{

					//fire
					case 0:
						FireFlame();
						break;

					//water
					case 1:
						waterBeam();
						break;

					//earth
					case 2:
						rockThrow();
						break;

					//air
					case 3:
						airFly();
						break;
				}
			}
		}
	}
}