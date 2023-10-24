using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Vector2 inputMovment;
    Vector2 minBounds;
    Vector2 maxBounds;

    [SerializeField] float speed=10;
    [SerializeField] float paddingL ;
    [SerializeField] float paddingR ;
    [SerializeField] float paddingT ;
    [SerializeField] float paddingB ;

    Shooter shooter;
    void Awake()
    {
        shooter=GetComponent<Shooter>();    
    }
    // Start is called before the first frame update
    void Start()
    {
        InitBounds();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();   
    }
    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0,0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    private void OnMove(InputValue input)
    {
        inputMovment= input.Get<Vector2>();

    }
    private void OnFire(InputValue input)
    {
        if (shooter != null)
        {
            shooter.setIsFiring(input.isPressed);
        }
    }
    private void PlayerMovement()
    {
        Vector3 v3= inputMovment*Time.deltaTime*speed;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + v3.x, minBounds.x+paddingL, maxBounds.x-paddingR);
        newPos.y = Mathf.Clamp(transform.position.y + v3.y, minBounds.y+paddingB, maxBounds.y-paddingT);
        transform.position = newPos;
    }
}
