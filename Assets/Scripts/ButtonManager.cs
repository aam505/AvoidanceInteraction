using Leap.Unity.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour

{
    private Transform[] Cubes = new Transform[9], Spheres = new Transform[9];
    public static Transform LastPressed;
    public int[] Matrix = new int [9];
    public static int MatrixSize=9;
    private float startTrialTime;
    /**
     * 1 is square 
     * 2 is circle
     * 3 is target that is square
     * 6 target circle
     * make 3 circles and rest squares
     **/
    private void generateMatrix()
    {
   
        for(int i = 0; i < MatrixSize; i++)
        {
            Matrix[i] = 1;
        }

        int circles = 0;
        while (circles < 3)
        {
            int pos = Random.Range(0, MatrixSize);
            if (Matrix[pos] == 1)
            {
                Matrix[pos] = 2;
                circles++;
            }
        }

        //Finally pick a target. 3 if it is square and 6 if it is circle
        Matrix[Random.Range(0, MatrixSize)] *=3;
    }

    private string GetMatrixString()
    {
        string matrixString = "";
        for (int i=0; i< MatrixSize; i++)
        {
            if (i != 0 && i % 3 == 0)
                matrixString += "\n" + Matrix[i] +" ";
            else
                matrixString += Matrix[i] + " ";
        }

        return matrixString;
    }
    // Start is called before the first frame update
    void Start()
    {

        LastPressed = transform;
        for(int i=0; i< MatrixSize; i++)
        {
            Cubes[i] = transform.GetChild(1).GetChild(i);
            Spheres[i] = transform.GetChild(2).GetChild(i).transform;
        }
        RestartTrial();
    }

    private void ApplyMatrix()
    {
        for (int i=0; i<MatrixSize; i++)
        {
            switch (Matrix[i]) {
                case 1: //cube is active
                    Spheres[i].gameObject.SetActive(false);
                    Cubes[i].gameObject.SetActive(true);
                    Cubes[i].GetComponent<InteractionButton>().ignoreContact = true;
                    Cubes[i].GetChild(0).GetComponent<Renderer>().material.SetColor("_Color", Color.white);
                    break;
                case 2: //sphere is active
                    Cubes[i].gameObject.SetActive(false);
                    Spheres[i].gameObject.SetActive(true);
                    Spheres[i].GetComponent<InteractionButton>().ignoreContact = true;
                    Spheres[i].GetChild(0).GetComponent<Renderer>().material.SetColor("_Color", Color.white);
                    break;
                case 3: //cube is active and target
                    Cubes[i].gameObject.SetActive(true);
                    Spheres[i].gameObject.SetActive(false);
                    Cubes[i].GetComponent<InteractionButton>().ignoreContact = false;
                    Cubes[i].GetChild(0).GetComponent<Renderer>().material.SetColor("_Color", Color.green);
                    break;
                case 6: //sphere is active and target
                    Cubes[i].gameObject.SetActive(false);
                    Spheres[i].gameObject.SetActive(true);
                    Spheres[i].GetComponent<InteractionButton>().ignoreContact = false;
                    Spheres[i].GetChild(0).GetComponent<Renderer>().material.SetColor("_Color", Color.green);
                    break;
            }
             
        }
    }

    public void RestartTrial()
    {
        generateMatrix();
        Debug.Log(GetMatrixString());
        ApplyMatrix();
        startTrialTime = Time.time;
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTrialTime > 5)
            RestartTrial();
       Debug.Log(LastPressed.name);
    }
}
