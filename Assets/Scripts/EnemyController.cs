using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private GameObject _enemyObjective;
    [SerializeField] private int _enemyHealth;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rb.velocity = new Vector2(_speed, 0);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            _enemyHealth--;
            if ( _enemyHealth <= 0)
            {
                EnemyDeath();
            }
        }
    }

    public void EnemyDeath()
    {
        Destroy(gameObject);
    }
}
