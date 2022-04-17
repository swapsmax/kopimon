using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerNoCam : MonoBehaviour
{
    public float moveSpeed;

    public LayerMask solidObjectsLayer;
    //public LayerMask PlayerLayer;

    private bool isMoving;
    private Vector2 input;

    PhotonView view;

    public GameObject bulletePrefab;
    public Transform bulleteSpawnRight;
    public Transform bulleteSpawnLeft;
    public Transform bulleteSpawnUp;
    public Transform bulleteSpawnDown;
    //private Animator animator;

    private void Awake()
    {
        view = GetComponent<PhotonView>();
    //    animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (view.IsMine)
        {
            if (!isMoving)
            {
                input.x = Input.GetAxisRaw("Horizontal");
                input.y = Input.GetAxisRaw("Vertical");

                // remove diagonal movement
                if (input.x != 0) input.y = 0;

                if (input != Vector2.zero)
                {
                    //animator.SetFloat("moveX", input.x);
                    //animator.SetFloat("moveY", input.y);

                    var targetPos = transform.position;
                    targetPos.x += input.x;
                    targetPos.y += input.y;

                    if (IsWalkable(targetPos))
                        StartCoroutine(Move(targetPos));
                }

                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    ShootUp();
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    ShootLeft();
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    ShootDown();
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    ShootRight();
                }
            }
        }
    
        //animator.SetBool("isMoving", isMoving);
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;

        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = targetPos;

        isMoving = false;
    }

    public void ShootRight()
    {
        GameObject bullete = PhotonNetwork.Instantiate(bulletePrefab.name, bulleteSpawnRight.position, Quaternion.identity);
    }

    public void ShootLeft()
    {
        GameObject bullete = PhotonNetwork.Instantiate(bulletePrefab.name, bulleteSpawnLeft.position, Quaternion.identity);
        bullete.GetComponent<PhotonView>().RPC("changeDirectionLeft", RpcTarget.AllBuffered);
    }

    public void ShootUp()
    {
        GameObject bullete = PhotonNetwork.Instantiate(bulletePrefab.name, bulleteSpawnUp.position, Quaternion.identity);
        bullete.GetComponent<PhotonView>().RPC("changeDirectionUp", RpcTarget.AllBuffered);
    }

    public void ShootDown()
    {
        GameObject bullete = PhotonNetwork.Instantiate(bulletePrefab.name, bulleteSpawnDown.position, Quaternion.identity);
        bullete.GetComponent<PhotonView>().RPC("changeDirectionDown", RpcTarget.AllBuffered);

    }

    private bool IsWalkable(Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, 0.3f, solidObjectsLayer)!= null)
        {
            return false;
        }
        return true;
    }

}
