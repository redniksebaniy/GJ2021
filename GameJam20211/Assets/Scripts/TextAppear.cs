using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAppear : MonoBehaviour
{
    public bool existance = true; //М: Тут помечаем существует ли объект на данный момент
    public GameObject target; //М: Что будет пропадать

    public void dissapear()
    {
        if (existance) //М: Если он есть
        {
            target.SetActive(false);
            existance = false; //М: Выключаем объект и меняем bool
        }
        else
        {
            target.SetActive(true);
            existance = true; //М: Если нет то включаем его соответсвенно
        }
    }
} //!ВАЖНО! *****.SetActive(true) просто ставит галочку у объекта в инспекторе, если мы вырубим объект со скриптами то все его скрипты тоже рубануться

//М: Скрипт цепляем объекту с которым надо взаимодействовать чтобы объект target пропал
