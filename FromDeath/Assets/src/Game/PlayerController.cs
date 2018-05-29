using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private Animator _animator; 

    private Rigidbody2D _rigidbody;

    private Vector2 _leftForce = new Vector2 (-100f, 200f);
    private Vector2 _rightForce = new Vector2(100f, 200f);

    private float _lastPos;
    private bool _onBlock; 

    private void Awake()
    {
        _lastPos = transform.position.y; 
        _rigidbody = GetComponent<Rigidbody2D>(); 
    }

    public void Frize()
    {
        _rigidbody.velocity = Vector2.zero; 
    }
	
	public void MoveLeft()
    {
        if (_onBlock)
        {
            Frize();
            _rigidbody.AddForce(_leftForce);
            _animator.SetTrigger("Up");
        }
    }

    public void MoveRight()
    {
        if (_onBlock)
        {
            Frize();
            _rigidbody.AddForce(_rightForce);
            _animator.SetTrigger("Up");
        }
    }

    public void Update()
    {
        if(_lastPos > transform.position.y)
        {
            _animator.SetTrigger("Down");
        }

        _lastPos = transform.position.y; 
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Block block = collision.gameObject.GetComponent<Block>();
        _onBlock = (block != null);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _onBlock = false; 
    }
}
