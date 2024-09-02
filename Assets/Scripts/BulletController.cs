using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] private float _speed;
    [SerializeField] private Animator _animator;
    public void Start()
    {
        _rb.velocity = new Vector2(_speed, 0);
    }
    //plays explosion animation
    public void ExplosionAnimation()
    {
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            _animator.SetBool("Explode", true);
            _rb.velocity = Vector2.zero;
        }
    }
}
