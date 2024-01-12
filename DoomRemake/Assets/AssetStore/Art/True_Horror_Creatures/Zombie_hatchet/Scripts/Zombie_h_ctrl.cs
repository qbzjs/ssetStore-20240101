using UnityEngine;
using System.Collections;

public class Zombie_h_ctrl : MonoBehaviour {
	
	GameObject[] Weapon;
	Rigidbody rb;
	private Animator anim;
	private CharacterController controller;
	private int battle_state = 0;
	public float speed = 6.0f;
	public float runSpeed = 3.0f;
	public float turnSpeed = 60.0f;
	public float gravity = 20.0f;
	private Vector3 moveDirection = Vector3.zero;
	private float w_sp = 0.0f;
	private float r_sp = 0.0f;
	//private bool armed = true; 

	
	// Use this for initialization
	void Start () 
	{					
		Weapon = GameObject.FindGameObjectsWithTag ("Player_Weapon");
		anim = GetComponent<Animator>();
		controller = GetComponent<CharacterController> ();
		w_sp = speed; //read walk speed
		r_sp = runSpeed; //read run speed
		battle_state = 0;
		runSpeed = 1;
	}
	
	// Update is called once per frame
	void Update () 
	{		
		if (Input.GetKey ("1"))  // turn to still state
		{ 		
			anim.SetInteger ("battle", 0);
			battle_state = 0;
			runSpeed = 1;
		}
		if (Input.GetKey ("2")) // turn to another walk state
		{ 
			anim.SetInteger ("battle", 1);
			battle_state = 0;
			runSpeed = w_sp/1.5f;

		}
		if (Input.GetKey ("3")) // turn to battle state
		{ 
			anim.SetInteger ("battle", 2);
			battle_state = 1;
			runSpeed = r_sp;
		}
			
		if (Input.GetKey ("up")) 
		{
			anim.SetInteger ("moving", 1);//walk/run/moving
		}
		else 
			{
				anim.SetInteger ("moving", 0);
			}


		if (Input.GetKey ("down")&&(battle_state <=3)) 
		{
			anim.SetInteger ("moving", 2);//walk/run/moving
			runSpeed = w_sp;
		}
		if ((Input.GetKeyUp ("down"))&&((battle_state==1)||(battle_state==2))) 
		{
			runSpeed = r_sp;
		}

//----------------------------------------------------------------
		if (Input.GetMouseButtonDown (0)) { // attack1
			anim.SetInteger ("moving", 3);
		}
		if (Input.GetMouseButtonDown (1)) { // attack2
			anim.SetInteger ("moving", 4);
		}
		if (Input.GetMouseButtonDown (2)) { // attack3
			anim.SetInteger ("moving", 5);
		}
//----------------------------------------------------------------POWER HIT and loss of weapon 
		if (Input.GetKeyDown ("y"))
		{ 
			anim.SetInteger ("moving",6);
			anim.SetInteger ("battle", 2);
			battle_state = 2;
			runSpeed = r_sp;
			foreach (GameObject r in Weapon)
			{
				r.transform.parent =null;
				rb = r.GetComponent<Rigidbody>();
				rb.isKinematic =false;
			}
		}
//-------------------------------------------------------------FALLING
		if (Input.GetKeyDown ("i"))
		{ 
			anim.SetInteger ("moving",15);
			runSpeed = 0;
			foreach (GameObject r in Weapon)
			{
				r.transform.parent =null;
				rb = r.GetComponent<Rigidbody>();
				rb.isKinematic =false;
			}
		}
		if (Input.GetKeyDown ("k"))
		{ 
			anim.SetInteger ("battle",4);
			battle_state = 3;
			runSpeed = 0;
		}
		if (Input.GetKeyDown ("l"))  //RISE UP
		{ 
			anim.SetInteger ("moving",18);
			anim.SetInteger ("battle",2);
			battle_state = 2;
			runSpeed = r_sp;
		}

//----------------------------------------------- take damage

		
		if (Input.GetKeyDown ("u")) 
		{ 			  
			if (battle_state < 2)
			{
				int n = Random.Range (0, 2);
				if (n == 1) 
				{
					anim.SetInteger ("moving", 9);
				} 
				else 
				{
					anim.SetInteger ("moving", 10);
				}
				battle_state = 1;
				runSpeed = r_sp;
				anim.SetInteger ("battle", 1);
			}
			else if (battle_state == 2)
			{
				int n = Random.Range (0, 2);
				if (n == 1) 
				{
					anim.SetInteger ("moving", 11);
				} 
				else 
				{
					anim.SetInteger ("moving", 12);
				}
			}
			else if (battle_state == 3)
			{
				int n = Random.Range (0, 2);
				if (n == 1) 
				{
					anim.SetInteger ("moving", 13);
				} 
				else 
				{
					anim.SetInteger ("moving", 14);
				}
			}
		}

		//-------------------------------------------------------------OTHER ACTIONS
		if (Input.GetKeyDown ("p")) { // defence_start
			anim.SetInteger ("moving", 7);
		}
		if (Input.GetKeyUp ("p")) { // defence_end
			anim.SetInteger ("moving", 8);
		} 
		
		if (Input.GetKeyDown ("c")) { //roar/howl/
			anim.SetInteger ("moving", 18);
		}

		
		if (Input.GetKeyDown ("o") && (battle_state < 3)) 
		{
			anim.SetInteger ("moving", 16); //die
			foreach (GameObject r in Weapon)
			{
				r.transform.parent =null;
				rb = r.GetComponent<Rigidbody>();
				rb.isKinematic =false;
			}
		}
		if (Input.GetKeyDown ("o")&&(battle_state == 3)) anim.SetInteger ("moving", 17); //die
		

		if (controller.isGrounded) 
		{
			moveDirection=transform.forward * Input.GetAxis ("Vertical") * speed * runSpeed;
			float turn = Input.GetAxis("Horizontal");
			transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);						
		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move (moveDirection * Time.deltaTime);
		}
}



