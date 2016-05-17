using UnityEngine;
using System.Collections;
using System;
using UnityStandardAssets.Characters.ThirdPerson;

public class RotationController : MonoBehaviour {

    bool f = false;             //回転フラグ
    bool f0 = false;            //座標固定フラグ
    bool f1 = false;            //ワープ位置あわせ
    double z;                   //Math.Acosがdoubleしか受け付けないからdouble

    AudioSource audioSource;
    ThirdPersonCharacter TPC;
    Rigidbody rigid;
    
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        TPC = GetComponent<ThirdPersonCharacter>();
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {

        //回転処理
        if (f)
        {
            z = Math.Acos(1 - 0.02 * transform.position.y) * 180 / Math.PI;
            if (!double.IsNaN(z))
            {
                transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, (float)z);

            }
        }
        
        
        if(f0)
        {
            TPC.enabled = false;       //X,Z座標固定
            rigid.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
        }
        if(f1)
        {
            rigid.velocity = new Vector3(0, 0, 0);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "UpperPlane" || collision.gameObject.name == "LowerPlane")
        {
            f = false;          //回転止め
            f0 = false;         //X,Z座標固定解除
            TPC.enabled = true;        //X,Z座標固定解除
            rigid.constraints = RigidbodyConstraints.None;
            rigid.constraints = RigidbodyConstraints.FreezeRotationX    //ThirdPersonCharacterの設定の復元
                | RigidbodyConstraints.FreezeRotationY 
                | RigidbodyConstraints.FreezeRotationZ;
        }

        if(collision.gameObject.name=="UpperPlane")
        {
            transform.rotation = Quaternion.Euler(0, transform.rotation.y, 180);
        }
        else if (collision.gameObject.name == "LowerPlane")
        {
            transform.rotation = Quaternion.Euler(0, transform.rotation.y, 0);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "LowerWarp" || other.gameObject.name == "UpperWarp")
        {
            f1 = true;                          //ワープ位置合わせ
        }
    }


    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "LowerWarp" || other.gameObject.name == "UpperWarp")
        {
            //回転開始・X,Z座標固定フラグ
            if (Input.GetKey(KeyCode.Space))
            {
                audioSource.Play();
                f1 = false;
                f = true;
                f0 = true;
            }
        }
    }
}
