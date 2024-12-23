using UnityEngine;
using Unity.Mathematics;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    public Animator anim;
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        body.velocity = new Vector2(horizontalInput * speed ,body.velocity.y);

        //หันหน้าซ้ายขวาตอนขยับ
        if(horizontalInput > 0.01f)
            transform.localScale = Vector3.one * 3;
        if(horizontalInput < 0.01f)
            transform.localScale = new Vector3(-3, 3, 3);

     

        if(Input.GetKey(KeyCode.Space))
            body.velocity = new Vector2(body.velocity.x , speed);

        anim.SetFloat("Speed" , Mathf.Abs(horizontalInput));
    }

}
