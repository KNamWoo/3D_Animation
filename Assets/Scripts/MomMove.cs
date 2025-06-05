using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UIElements;

public class MomMove : MonoBehaviour
{
    Vector3 moveVec;
    public float speed;

    public float h, v;
    public bool moving;

    public Animator anim;
    public Rigidbody rbody;

    public void Awake()
    {
        anim = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody>();
    }
    public void Start()
    {
        moving = false;
    }

    public void Update()
    {
        Move();
        Motion();
    }

    public void Motion()
    {
        if (moving == true)
        {
            anim.Play("MomWalk");
        }
        else
        {
            anim.Play("MomGreet");
        }
    }

    public void Move()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        if (h != 0 || v != 0)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }
        Vector3 curPos = transform.position;
        Vector3 nextPos = new Vector3(h, 0, v) * speed * Time.deltaTime;

        transform.position = curPos + nextPos;
        moveVec = new Vector3(h, 0, v).normalized;

        transform.LookAt(transform.position + moveVec);
    }
}
