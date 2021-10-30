using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAppearPenta : MonoBehaviour
{
    static public bool existanceP = true; //М: Тут помечаем существует ли объект на данный момент
    public GameObject target; //М: Что будет пропадать

    void Start()
    {
        if (existanceP == false) target.SetActive(false);
    }

    public void dissapear()
    {
        if (existanceP) //М: Если он есть
        {
            target.SetActive(false);
            existanceP = false; //М: Выключаем объект и меняем bool
        }
        else
        {
            target.SetActive(true);
            existanceP = true; //М: Если нет то включаем его соответсвенно
        }
    }
} //!ВАЖНО! *****.SetActive(true) просто ставит галочку у объекта в инспекторе, если мы вырубим объект со скриптами то все его скрипты тоже рубануться
