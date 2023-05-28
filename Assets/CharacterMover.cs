using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] Rigidbody2D _rig;
    [SerializeField] Animator _animator;
    [SerializeField] SpriteRenderer _renderer;

    bool _isGround = false;

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal") * _speed;
        _rig.velocity = new Vector2(x, _rig.velocity.y);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && _isGround == true)
        {
            _rig.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
            _isGround = false;
        }

        if(_isGround == false)
        {
            _animator.SetBool("isJump", true);
            _animator.SetBool("isRun", false);
        }
        else if(_rig.velocity != Vector2.zero)
        {
            _animator.SetBool("isJump", false);
            _animator.SetBool("isRun", true);
        }
        else
        {
            _animator.SetBool("isJump", false);
            _animator.SetBool("isRun", false);
        }

        if(_rig.velocity.x < 0)
        {
            _renderer.flipX = true;
        }
        else
        {
            _renderer.flipX = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Ground"))
        {
            _isGround= true;
        }
    }
}
