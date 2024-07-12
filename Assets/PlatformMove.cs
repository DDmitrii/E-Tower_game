using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UIElements;
 
public class PlatformMove : MonoBehaviour
{
    private float x = 2.5f; // позииция самого верхнего (движущегося) блока по х
    // координата x или z зависит от того, из какой стороны выезжает блок
    private float z = 2.5f; // позиция z самого верхнего (движущегося) блока по z
    private float add_x = 2f; // скорость по x
    public float prev_size_x = 1; // размер предыдущего блока по x
    public float prev_size_z = 1; // размер предыдущего блока по z
    public float previous_x = 0; // позиция предыдущего блока по x
    public float previous_z = 0; // позиция предыдущего блока по z
 
    private float add_z = 2f; // скорость по z
    public GameObject obj; // префаб объект
 
    public GameObject cube; // то, что останется после объекта 
 
    public GameObject obj1; // самая первая платформа, которая всегда на месте
 
    private bool click = false; // переменная, ответственная за клик мыши, который стопит подвижную платформу
 
    public bool side = false; // переменная, отвечающая за сторону, из которой выезжает блок
    void Start()
    {
 
    }
    void Update()
    {
        if (!click)
        {
            ChangeDirection();
        }
 
        if (Input.GetMouseButtonDown(0))
        { // ЛКМ
            transform.position -= new Vector3(0, 0.2f, 0); // при нажатии мыши башня уходит ниже, чтобы оставаться всегда в кадре
            if (!click)
            {
                Cut(x, z);
                click = true; // обозначаем, что с верхней платформой мы провели действие и больше она нам не нужна
                if (!side)
                {
                    side = true;  // меняем сторону выезда следующей платформы
                    Instantiate(obj, new Vector3(previous_x, 0.2f, 2.5f), Quaternion.identity); // спавним платформу
                }
                else
                {
                    side = false; // меняем сторону
                    Instantiate(obj, new Vector3(2.5f, 0.2f, previous_z), Quaternion.identity); // спавним платформу
                }
                obj1.transform.position -= new Vector3(0, 0.2f, 0); // опускаем самую первую платформу ниже вместе с остальными
            }
        }
    }
 
    void ChangeDirection()
    {
        if (!side)
        {
            x += add_x * Time.deltaTime; // запоминаем координату х, движущейся платформы, чтобы применить ее в if
            transform.position += new Vector3(add_x * Time.deltaTime, 0, 0); // покадровое перемещение движущейся платформы по оси х
            if (x >= 2.3f)
            {
                add_x = -1; // меняем направление платформы на противоположное
            }
            else if (x <= -2.3f)
            {
                add_x = 1;  
            }
        }
        else
        {
            z += add_z * Time.deltaTime; // то же самое только для платформы катающейся по оси z
            transform.position += new Vector3(0, 0, add_z * Time.deltaTime);
            if (z >= 2.3f)
            {
                add_z = -1; // меняем направление платформы на противоположное
            }
            else if (z <= -2.3f)
            {
                add_z = 1;
            }
        }
        Debug.Log(x);
    }
 
    void Cut(float x, float z)
    {
        if (!side)
        {
            float size_x = 0;
            float right_down = previous_x + (prev_size_x / 2);
            float left_down = previous_x - (prev_size_x / 2);
            float right_up = x + (prev_size_x / 2);
            float left_up = x - (prev_size_x / 2);
            if (x >= previous_x)
            {
                size_x = right_down - left_up;
            } else
            {
                size_x = right_up - left_down;
                //Debug.Log(right_up + "=" + left_down);
            }
 
            //Debug.Log(size_x);
 
            if (size_x <= 0)
            {
                //закончить игру
            }
 
            if (x >= previous_x)
            {
                previous_x += (prev_size_x - size_x) / 2;
            }
            else
            {
                previous_x -= (prev_size_x - size_x) / 2;
            }
 
            prev_size_x = size_x;
 
            transform.localScale = new Vector3(prev_size_x, 0.2f, prev_size_z);
            transform.position = new Vector3(previous_x, 0, previous_z);
        }
        if (side)
        {
            float size_z = 0;
            float right_down = previous_z + (prev_size_z / 2);
            float left_down = previous_z - (prev_size_z / 2);
            float right_up = z + (prev_size_z / 2);
            float left_up = z - (prev_size_z / 2);
            if (z >= previous_z)
            {
                size_z = right_down - left_up;
            }
            else
            {
                size_z = right_up - left_down;
            }
 
            if (size_z <= 0)
            {
                //закончить игру
            }
 
            if (z >= previous_z)
            {
                previous_z += (prev_size_z - size_z) / 2;
            }
            else
            {
                previous_z -= (prev_size_z - size_z) / 2;
            }
 
            prev_size_z = size_z;
 
            transform.localScale = new Vector3(prev_size_x, 0.2f, prev_size_z);
            transform.position = new Vector3(previous_x, 0, previous_z);
        }
    }
}