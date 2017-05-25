using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public PlayerInventoryDisplay playerInventoryDisplay;
    private int totalStars = 0;

	private Rigidbody2D myRigidbody;

	private Animator myAnimator;

	[SerializeField]
	private float movementSpeed;

	private bool attack;

	private bool slide;

	private bool facingRigt;

	[SerializeField]
	private Transform[] groundPoints;

	[SerializeField]
	private float groundRadius;

	[SerializeField]
	private LayerMask whatIsGround;

	private bool isGrounded;

	private bool jump;

	[SerializeField]
	private bool airControl;

	[SerializeField]
	private float jumpForce;

	// Use this for initialization
	void Start () {

		facingRigt = true;
		myRigidbody = GetComponent<Rigidbody2D>();
		myAnimator = GetComponent<Animator>();
		playerInventoryDisplay = GetComponent<PlayerInventoryDisplay>();

	}

	void Update(){

		HandleInput();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float horizontal = Input.GetAxis("Horizontal");

		isGrounded = IsGrounded();

		HandleMovement(horizontal);

		Flip(horizontal);

		HandleAttacks();

		ResetValues();

	}

	private void HandleMovement(float horizontal){
//slide & attack
		if (!myAnimator.GetBool("slide") && !this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Attack") && (isGrounded || airControl)){
			
			myRigidbody.velocity = new Vector2(horizontal * movementSpeed, myRigidbody.velocity.y);
	
		}
// slide
		if (slide && !this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Slide")){
			
			myAnimator.SetBool("slide", true);

		}else if (!this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Slide")){
			
			myAnimator.SetBool("slide", false);

		}
 
		if (isGrounded && jump){
			isGrounded = false;
			myRigidbody.AddForce(new Vector2(0,jumpForce));
		}
 

	
		myAnimator.SetFloat("speed", Mathf.Abs(horizontal));
	}

	private void HandleAttacks(){

		if (attack && !this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Attack")){
			myAnimator.SetTrigger("attack");
			myRigidbody.velocity = Vector2.zero;
		}

	}
//keyboard input
	private void HandleInput(){

		if (Input.GetKeyDown(KeyCode.LeftShift)){
			attack = true;
		}

		if (Input.GetKeyDown(KeyCode.LeftControl)){
			slide = true;
		}

		if(Input.GetKeyDown(KeyCode.Space)){
			jump = true;
		}
	
	}
//perubahan arah x karakter / kanan kiri
	private void Flip(float horizontal){
		if(horizontal > 0 && !facingRigt || horizontal < 0 && facingRigt ){
			facingRigt = !facingRigt;

			Vector3 theScale = transform.localScale;

			theScale.x *= -1;

			transform.localScale = theScale;
		}
	}

	private void ResetValues(){

		attack = false;
		slide = false;
		jump = false;

	}

	private bool IsGrounded(){
		if(myRigidbody.velocity.y <= 0){
			foreach(Transform point in groundPoints){

				Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);

				for(int i = 0; i < colliders.Length; i++){

					if(colliders[i].gameObject != gameObject){
						return true;
					}
					 
				}
			}
		}
		return false;
	}

	void OnTriggerEnter2D(Collider2D hit) {
        if (hit.CompareTag("Star")) {
            totalStars++;
            playerInventoryDisplay.OnChangeStarTotal(totalStars);
            Destroy(hit.gameObject);
        }
    }
	 
}
