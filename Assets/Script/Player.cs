using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public FixedJoystick joy;

    public Vector2 inputVec ;
    public float speed;
    public Scanner scanner;

    SpriteRenderer spriter;
    Animator anim;

    Rigidbody2D rigid;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        scanner = GetComponent<Scanner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.isLive)
            return;
   //     inputVec = new Vector2(js.Horizontal, js.Vertical);
    }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }

    void FixedUpdate()
    {
        float x = joy.Horizontal;
        float y = joy.Vertical;
        Debug.Log(x);
        Vector2 vec = new Vector2(x, y);
        vec.Normalize();
        if (!GameManager.instance.isLive)
            return;
        Vector2 nextVec = vec * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);

        //È¸Àü
        if (x != 0)
        {
            spriter.flipX = x < 0;
        }
    }

    void LateUpdate()
    {
        if (!GameManager.instance.isLive)
            return;
        if (!GameManager.instance.isLive)
        {
            return;
        }
        anim.SetFloat("Speed", inputVec.magnitude);

        if (inputVec.x != 0 )
        {
            spriter.flipX = inputVec.x < 0;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (!GameManager.instance.isLive)
            return;

        GameManager.instance.health -= Time.deltaTime * 30;

        if (GameManager.instance.health <= 0)
        {
            for(int i = 1; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
            anim.SetTrigger("Dead");
            GameManager.instance.GameOver();
        }
    }
}
