using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletIndoor : MonoBehaviourPun
{
    public float speed = 10;
    public float destroyTime = 2f;
    public bool shootLeft = false;
    public bool shootUp = false;
    public bool shootDown = false;
    public float BulletDamage;
    
    IEnumerator destroyBullete()
    {
        yield return new WaitForSeconds(destroyTime);
        this.GetComponent<PhotonView>().RPC("destroy",RpcTarget.AllBuffered);
    }

    void Update()
    {
        if(shootLeft)
        transform.Translate(Vector2.left*Time.deltaTime*speed);
        else if(shootUp)
        {
            transform.Translate(Vector2.up* Time.deltaTime* speed);
        }
        else if(shootDown)
        {
            transform.Translate(Vector2.down* Time.deltaTime* speed);
        }
        else
        {
            transform.Translate(Vector2.right* Time.deltaTime* speed);
        }
    }

    [PunRPC]
    public void destroy()
    {
        Destroy(this.gameObject);
    }

    [PunRPC]
    public void changeDirectionLeft()
    {
        shootLeft = true;
    }

    [PunRPC]
    public void changeDirectionUp()
    {
        shootUp = true;
    }

    [PunRPC]
    public void changeDirectionDown()
    {
        shootDown = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PhotonView myPhotonView = (PhotonView)this.GetComponent<PhotonView>();
        if(!myPhotonView.IsMine)
            return;
        
        PhotonView target = collision.gameObject.GetComponent<PhotonView>();

        if(target!=null&&(!target.IsMine || target.IsRoomView))
        {
            if(target.tag == "Player")
            {
                target.RPC("ReduceHealth", Photon.Pun.RpcTarget.AllBuffered, BulletDamage);
            }

            this.GetComponent<PhotonView>().RPC("destroy", Photon.Pun.RpcTarget.AllBuffered);
        }
    }
}
