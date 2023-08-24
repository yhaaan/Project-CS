using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;

    Rigidbody2D rigid;
    SpriteRenderer spriter;
    
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
    }



    private void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }
    private void FixedUpdate()
    {
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);

    }

    private void LateUpdate()
    { 
        if (inputVec.x != 0)
        {
            spriter.flipX = inputVec.x < 0;
        }
    }

    public void ChangeColor(Color color)
    {
        spriter.color = color;
    }

    public void MixColor(Color color)
    {
        spriter.color = new Vector4((spriter.color.r+color.r)/2, (spriter.color.g + color.g) / 2, (spriter.color.b + color.b) / 2, 1);

    }

   

}
