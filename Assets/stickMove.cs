using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using zFrame.UI;

public class stickMove : MonoBehaviour
{
    public float speed = 5f;
    [SerializeField] Joystick joystick;
    void Start()
    {
        joystick.OnValueChanged.AddListener(v =>
        {
            if (v.magnitude != 0)
            {
                // 计算当前一小段时间内的移动
                Vector3 movement = speed * Time.deltaTime * new Vector3(v.x, v.y, 0);
                transform.position += movement;

                //根据位移确定角度
                float angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;

                //根据角度改变人物朝向
                if (90 + angle > 0 && 90 + angle < 180)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                    transform.rotation = Quaternion.Euler(0, 0, angle);
                }
                else
                {
                    transform.localScale = new Vector3(1, 1, 1);
                    transform.rotation = Quaternion.Euler(0, 0, 180 + angle);
                }
                

                


                //transform.position += speed * Time.deltaTime * new Vector3(v.x, v.y, 0);
                //transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg);
                //Rigidbody2D rb = transform.GetComponent<Rigidbody2D>();
                //rb.velocity = new Vector2(v.x * speed, v.y * speed);
                //transform.Translate(v.x * speed, 0, v.y * speed, Space.World);
                //transform.rotation = Quaternion.LookRotation(new Vector3(v.x, 0, v.y));
            }
        });
    }
}
