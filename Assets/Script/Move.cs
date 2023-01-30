using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class Move : MonoBehaviour
{
    public float speed = 0.4f;
    Vector3 dest = Vector3.zero;
    private int indexInMoveList;
    [SerializeField]
    //private GameObject camera;
    private bool turnUnit = false;
    private bool moveUnit = true;
    [SerializeField]
    private int moveSteps = 3;
    static private GameObject[] UnitProperties;
    void Start()
    {
        dest = transform.position;
        indexInMoveList = GlobalVariables.AddNew(gameObject);
        UnitProperties = GameObject.FindGameObjectsWithTag("UnitProperties");
    }

    private void FixedUpdate()
    {
        Vector3 p = Vector3.MoveTowards(transform.position, dest, speed);
        GetComponent<Rigidbody>().MovePosition(p);
    }

    private void Update()
    {

        //Are i move ?
        if (indexInMoveList == GlobalVariables.ListIndex)
        {
            foreach (var item in UnitProperties)
            {
                var text = item.GetComponent<Text>();
                text.text = moveSteps.ToString();
                //Debug.Log(item.tag);
                //var text = item.GetComponent("Text");
                //MoveTurn[ListIndex]
                //gameObject
                //text.font.material.color 
                //"RGBA(1.000, 1.000, 1.000, 1.000)"
                //         Debug.Log(text.text); 
            }
            if (turnUnit)
            {
                GlobalVariables.Next();
                turnUnit = false;
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Tab))
                    turnUnit = true;
            }
            MoveUnit(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            if (Input.GetKeyUp(KeyCode.W))
                if (moveSteps != 0)
                {
                    moveUnit = true;
                    moveSteps -= 1;
                }
            if (Input.GetKeyUp(KeyCode.S))
                if (moveSteps != 0)
                {
                    moveUnit = true;
                    moveSteps -= 1;
                }
            if (Input.GetKeyUp(KeyCode.A))
                if (moveSteps != 0)
                {
                    moveUnit = true;
                    moveSteps -= 1;
                }
            if (Input.GetKeyUp(KeyCode.D))
                if (moveSteps != 0)
                {
                    moveUnit = true;
                    moveSteps -= 1;
                }
            // Check for Input if not moving
            //if ((Vector3)transform.position == dest)
            //{
            //    if (Input.GetKey(KeyCode.UpArrow) && valid(Vector3.up))
            //        dest = (Vector3)transform.position + Vector3.up;
            //    if (Input.GetKey(KeyCode.RightArrow) && valid(Vector3.right))
            //        dest = (Vector3)transform.position + Vector3.right;
            //    if (Input.GetKey(KeyCode.DownArrow) && valid(-Vector3.up))
            //        dest = (Vector3)transform.position - Vector3.up;
            //    if (Input.GetKey(KeyCode.LeftArrow) && valid(-Vector3.right))
            //        dest = (Vector3)transform.position - Vector3.right;
            //}
        }
        // Animation Parameters
        //Vector3 dir = dest - (Vector3)transform.position;
        //GetComponent<Animator>().SetFloat("DirX", dir.x);
        //GetComponent<Animator>().SetFloat("DirY", dir.y);
    }

    //bool valid(Vector3 dir)
    //{
    //    // Cast Line from 'next to Pac-Man' to 'Pac-Man'
    //    //Vector3 pos = transform.position;
    //    //RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
    //    //return (hit.collider == GetComponent<Collider2D>());
    //    return true;
    //}


    void MoveUnit(float x, float y)
    {
        if (y > 0)
            if (moveUnit)
            {
                dest = (Vector3)transform.position + Vector3.up;
                moveUnit = false;
            }
        if (y < 0)
            if (moveUnit)
            {
                dest = (Vector3)transform.position + Vector3.down;
                moveUnit = false;
            }
        if (x < 0)
            if (moveUnit)
            {
                dest = (Vector3)transform.position + Vector3.left;
                moveUnit = false;
            }
        if (x > 0)
            if (moveUnit)
            {
                dest = (Vector3)transform.position + Vector3.right;
                moveUnit = false;
            }
        //if (!Input.anyKeyDown)
        //    moveUnit = true;
        //Vector3 movementAmount = new Vector3(x, y, 0f) * speed * Time.deltaTime;
        //transform.Translate(movementAmount);
    }

}
