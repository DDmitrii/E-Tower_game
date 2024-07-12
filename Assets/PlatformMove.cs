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
    private float add_x = 1f; // скорость по x
    public float prev_size_x = 1; // размер предыдущего блока по x
    public float prev_size_z = 1; // размер предыдущего блока по z
    public float previous_x = 0; // позиция предыдущего блока по x
    public float previous_z = 0; // позиция предыдущего блока по z
 
    private float add_z = 1f; // скорость по z
    public GameObject obj; // префаб объект
 
    public GameObject cube; // то, что останется после объекта 
 
    public GameObject obj1; // самая первая платформа, которая всегда на месте
 
    private bool click = false; // переменная, ответственная за клик мыши, который стопит подвижную платформу
 
    public bool side = false; // переменная, отвечающая за сторону, из которой выезжает блок

    private ButtonController buttonController;

    void Start()
    {
        buttonController = FindObjectOfType<ButtonController>();
        Debug.Log(buttonController.PlatformSpeedCoef);
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
                Cut(x, z); // Обрезаем блок до нужных размеров
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
            x += add_x * buttonController.PlatformSpeedCoef * Time.deltaTime; // запоминаем координату х, движущейся платформы, чтобы применить ее в if
            transform.position += new Vector3(add_x * buttonController.PlatformSpeedCoef * Time.deltaTime, 0, 0); // покадровое перемещение движущейся платформы по оси х
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
            z += add_z * buttonController.PlatformSpeedCoef * Time.deltaTime; // то же самое только для платформы катающейся по оси z
            transform.position += new Vector3(0, 0, add_z * buttonController.PlatformSpeedCoef * Time.deltaTime);
            if (z >= 2.3f)
            {
                add_z = -1; // меняем направление платформы на противоположное
            }
            else if (z <= -2.3f)
            {
                add_z = 1;
            }
        }
    }
 
    void Cut(float x, float z)
    {
        if (!side)
        {
            float size_x; // новый размер блока по x
            float right_down = previous_x + (prev_size_x / 2); // координата правого ребра предыдущего блока по x
            float left_down = previous_x - (prev_size_x / 2); // координата левого ребра предыдущего блока по x
            float right_up = x + (prev_size_x / 2); // координата правого ребра нового блока по x
            float left_up = x - (prev_size_x / 2); // координата левого ребра нового блока по x
            
            // находим размер нового блока
            if (x >= previous_x)
            {
                size_x = right_down - left_up;
            } else
            {
                size_x = right_up - left_down;
            }
 
            // если размер блока < 0, то заканчиваем игру
            if (size_x <= 0)
            {
                // TO DO: закончить игру
            }
 
            // находим позицию изменённого блока и записываем его как предыдущий
            if (x >= previous_x)
            {
                previous_x += (prev_size_x - size_x) / 2;
            }
            else
            {
                previous_x -= (prev_size_x - size_x) / 2;
            }
 
            // записываем размер нового блока как предыдущий
            prev_size_x = size_x;
 
            // обновляем размер и позицию
            transform.localScale = new Vector3(prev_size_x, 0.2f, prev_size_z);
            transform.position = new Vector3(previous_x, 0, previous_z);
        }
        if (side)
        {
            float size_z; // новый размер блока по z
            float right_down = previous_z + (prev_size_z / 2); // координата правого ребра предыдущего блока по z
            float left_down = previous_z - (prev_size_z / 2); // координата левого ребра предыдущего блока по z
            float right_up = z + (prev_size_z / 2); // координата правого ребра нового блока по z
            float left_up = z - (prev_size_z / 2); // координата левого ребра нового блока по z
 
            // находим размер нового блока
            if (z >= previous_z)
            {
                size_z = right_down - left_up;
            }
            else
            {
                size_z = right_up - left_down;
            }
 
            // если размер блока < 0, то заканчиваем игру
            if (size_z <= 0)
            {
                // TO DO: закончить игру
            }
 
            // находим позицию изменённого блока и записываем его как предыдущий
            if (z >= previous_z)
            {
                previous_z += (prev_size_z - size_z) / 2;
            }
            else
            {
                previous_z -= (prev_size_z - size_z) / 2;
            }
 
            // записываем размер нового блока как предыдущий
            prev_size_z = size_z;
 
            // обновляем размер и позицию
            transform.localScale = new Vector3(prev_size_x, 0.2f, prev_size_z);
            transform.position = new Vector3(previous_x, 0, previous_z);
        }
    }
}