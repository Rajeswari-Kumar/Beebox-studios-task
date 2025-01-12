using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Button_navigation : MonoBehaviour
{
    public GameObject canvas;
    public GameObject Help_canvas;
    public GameObject OtherSettingscanvas;
    public TMP_Text Number;
    public GameObject[] cubePrefabs;
    public Transform cubeContainer;
    public GameObject Canvas_at_play;
    public GameObject resultCanvas;
    public int number_of_cubes = 0;
    public List<GameObject> cubes = new List<GameObject>();
    private int currentPrefabIndex = 0; 

    void Start()
    {
        Time.timeScale = 0;
        Number.text = number_of_cubes.ToString();
    }

    public void Play()
    {
        Time.timeScale = 1;
        canvas.SetActive(false);
        Canvas_at_play.SetActive(true);
        UpdateCubes();
    }

    public void GoToCanvas()
    {
        Time.timeScale = 0;
        canvas.SetActive(true);
        Canvas_at_play.SetActive(false);
        Help_canvas.SetActive(false);
        OtherSettingscanvas.SetActive(false);
        resultCanvas.SetActive(false);
    }

    public void Help()
    {
        Help_canvas.SetActive(true);
        canvas.SetActive(false);
        Canvas_at_play.SetActive(false);
    }

    public void others()
    {
        OtherSettingscanvas.SetActive(true);
        canvas.SetActive(false);
        Canvas_at_play.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Increment()
    {
        number_of_cubes++;
        Number.text = number_of_cubes.ToString();

        UpdateCubes();
    }

    public void Decrement()
    {
        if (number_of_cubes > 0)
        {
            number_of_cubes--;
            Number.text = number_of_cubes.ToString();

            UpdateCubes();
        }
    }

    public void UpdateCubes()
    {
        while (cubes.Count < number_of_cubes)
        {
            GameObject newCube = Instantiate(cubePrefabs[currentPrefabIndex], cubeContainer);
            newCube.SetActive(true);
            cubes.Add(newCube);
            currentPrefabIndex = (currentPrefabIndex + 1) % cubePrefabs.Length;
        }

        while (cubes.Count > number_of_cubes)
        {
            GameObject cubeToRemove = cubes[cubes.Count - 1];
            cubes.RemoveAt(cubes.Count - 1);
            Destroy(cubeToRemove);
        }
    }
}
