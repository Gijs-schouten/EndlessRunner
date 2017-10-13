using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float moveSpeed;
    public float jumpForce;

    public static float playerScore = 0;

    public static bool playerAlive = true;

    private Rigidbody2D _rigidbody;
    private Transform _transform;
    private Animator _animator;
    private Collider2D _collider;

    public bool grounded;
    public LayerMask ground;
    
	void Start () {
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
        _transform = GetComponent<Transform>();
        _animator = GetComponent<Animator>();
	}
	
	void Update () {
        _transform.Translate(Vector3.right * (Time.deltaTime * moveSpeed));
        if(playerAlive && grounded && Input.GetButton("Jump")){
            _animator.Play("jump");
            StartCoroutine("Jump");
        }

        StartCoroutine("isTouching");
    
	}

    private IEnumerator Jump() {
        float maxHeight = 3f + _transform.position.y;
        while (Input.GetButton("Jump") && _transform.position.y < maxHeight) {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpForce);
            yield return null;
        }
    }

    private IEnumerator isTouching() {
        grounded = Physics2D.IsTouchingLayers(_collider, ground);
        yield return new WaitForSeconds(0.1f);
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if(coll.gameObject.tag == "Flame") {
            playerAlive = !playerAlive;
            moveSpeed = 0;
            _animator.Play("playerdie");
        }

        if(coll.gameObject.tag == "Collectable") {
            playerScore += 5;
            Debug.Log("collected");
            Destroy(coll.gameObject);
        }
    }
}
