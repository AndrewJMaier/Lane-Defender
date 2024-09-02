using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D _rb;
    //[SerializeField] private GameObject _enemyObjective;
    [SerializeField] private int _enemyHealth;
    [SerializeField] private GameManager _gm;
    private bool stunned;
    [SerializeField] private int _stunDuration;
    [SerializeField] private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _gm = FindObjectOfType<GameManager>();
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!stunned)
        {
            _rb.velocity = new Vector2(_speed, 0);
        }
        else 
        {
            _rb.velocity = new Vector2(0,0);
        }
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == ("Player")) 
            {
                _gm.LifeLost();
                Destroy(gameObject);
            }
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            _enemyHealth--;
            stunned = true;
            StartCoroutine(Stunned());
            _animator.SetBool("Hit", true);
            _animator.SetBool("Walk", false);
            if ( _enemyHealth <= 0)
            {
                _animator.SetBool("Dead", true);
                //EnemyDeath();
            }
        }
    }

    public void EnemyDeath()
    {
        Destroy(gameObject);
    }

    IEnumerator Stunned()
    {
        yield return new WaitForSeconds(_stunDuration);
        stunned = false;
        _animator.SetBool("Hit", false);
        _animator.SetBool("Walk", true);
    }
}
