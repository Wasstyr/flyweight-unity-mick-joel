using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.UI;

public class Flyweight : MonoBehaviour
{
    public Square square;
    public Text memoryText;

    //The list that stores all squares
    List<Square> allSquares = new List<Square>();

    List<Vector3> firstData;
    List<Vector3> secondData;
    List<Vector3> thirdData;

    ProfilerRecorder systemMemoryRecorder;

    bool hasStarted = false;

    public void SpawnSquares()
    {
        systemMemoryRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "Total Used Memory");

        //List used when flyweight is enabled
        firstData = GetRandomData();
        secondData = GetRandomData();
        thirdData = GetRandomData();

        //Create all squares
        for (int i = 0; i < 10000; i++)
        {
            Square newSquare = Instantiate(square, Vector2.zero, Quaternion.identity).GetComponent<Square>();

            newSquare.SetRandomPos();
            newSquare.SetRandomColor();

            //Without flyweight
            //newSquare.dataOne = GetRandomData();
            //newSquare.dataThree = GetRandomData();
            //newSquare.dataTwo = GetRandomData();

            //With flyweight
            newSquare.dataOne = firstData;
            newSquare.dataThree = secondData;
            newSquare.dataTwo = thirdData;

            allSquares.Add(newSquare);
        }

        hasStarted = true;
    }

    private void Update()
    {
        if (hasStarted)
        {
            float x = systemMemoryRecorder.CurrentValue;
            string gigs = (x / 1000000000).ToString("F2");
            memoryText.text = "Total Used Memory WITH flyweight: " + systemMemoryRecorder.CurrentValue + " Bytes (" + gigs + " GB)";
        }
    }

    //Generate a list with data
    List<Vector3> GetRandomData()
    {
        //Create a new list
        List<Vector3> randomData = new List<Vector3>();

        //Add data to the list
        for (int i = 0; i < 1000; i++)
        {
            randomData.Add(new Vector3());
        }

        return randomData;
    }
}
