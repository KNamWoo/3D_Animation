using UnityEngine;

public class DadMove : MonoBehaviour
{
    Animator anim;
    public float v, speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Motion();
    }

    void Move()
    {
        Vector3 curPos = transform.position;
        Vector3 nextPos = new Vector3(0, 0, v) * speed * Time.deltaTime;

        transform.position = curPos + nextPos;
    }

    void Motion()
    {
        if (v > 0)
        {
            anim.Play("DadWalk");
        }
        else
        {
            anim.Play("DadIdle");
        }
    }
}
