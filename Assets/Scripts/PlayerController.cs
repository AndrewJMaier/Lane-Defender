using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //Input variables
    [SerializeField] private PlayerInput _playerInput;
    private bool moving;
    private InputAction move;
    private InputAction shoot;
    private InputAction restart;
    private float moveDirection;
    //GameObjects
    [SerializeField] private GameObject _playerBullet;
    [SerializeField] private Transform _bulletSpawn;
    //floats
    [SerializeField] private float _speed;
    //other Variables
    [SerializeField] private Rigidbody2D _rb;


    // Start is called before the first frame update
    void Start()
    {
        _playerInput.currentActionMap.Enable();
        move = _playerInput.currentActionMap.FindAction("Move");
        move.started += Move_started;
        move.canceled += Move_canceled;

        shoot = _playerInput.currentActionMap.FindAction("Shoot");
        shoot.started += Shoot_started;
        shoot.canceled += Shoot_canceled;
    }

    private void Shoot_canceled(InputAction.CallbackContext obj)
    {
        StopAllCoroutines();
    }

    private void Shoot_started(InputAction.CallbackContext obj)
    {
        StartCoroutine(Shooting());
    }

    private void Move_canceled(InputAction.CallbackContext obj)
    {
        moving = false;
    }

    private void Move_started(InputAction.CallbackContext obj)
    {
        moving = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            moveDirection = move.ReadValue<float>();
            _rb.velocity = new Vector2(0, _speed * moveDirection);
        }
        else
        {
            _rb.velocity = Vector2.zero;
        }
    }
    

    /*private void OnShoot()
    {
        Instantiate(_playerBullet);
    }
    */
    private IEnumerator Shooting()
    {
        GameObject bulletInstance = Instantiate(_playerBullet, _bulletSpawn.position, _bulletSpawn.rotation);
        yield return new WaitForSeconds(1);
    }
        
}
