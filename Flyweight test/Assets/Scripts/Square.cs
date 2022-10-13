using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    public List<Vector3> dataOne;
    public List<Vector3> dataTwo;
    public List<Vector3> dataThree;

    public void SetRandomPos()
    {
        transform.position = new Vector2(Random.Range(-9.00f, 9.00f), Random.Range(-5.00f, 5.00f));
    }

    public void SetRandomColor()
    {
        int rand = Random.Range(0, 5);
        switch (rand)
        {
            case 0:
                GetComponent<SpriteRenderer>().color = Color.red;
                break;
            case 1:
                GetComponent<SpriteRenderer>().color = Color.blue;
                break;
            case 2:
                GetComponent<SpriteRenderer>().color = Color.green;
                break;
            case 3:
                GetComponent<SpriteRenderer>().color = Color.yellow;
                break;
            case 4:
                GetComponent<SpriteRenderer>().color = Color.magenta;
                break;
        }
    }
}
