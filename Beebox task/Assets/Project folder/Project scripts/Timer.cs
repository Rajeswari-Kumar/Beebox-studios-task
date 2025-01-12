using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText; 
    public float countdownTime = 60f;
    public GameObject LoserCanvas;
    public GameObject timercanvas;
    public GameObject cubes_count;
    public Button_navigation NumberOfCubes;
    void Start()
    {
        UpdateTimerDisplay();
    }

    void Update()
    {
        if (Time.timeScale == 1 && countdownTime > 0 && cubes_count.transform.childCount > 0)
        {
            Time.timeScale = 1;
            DisplayLoss(false);
            countdownTime -= Time.deltaTime; 
            if (countdownTime < 0)
            {
                countdownTime = 0; 
            }
            UpdateTimerDisplay();
        }

        if(countdownTime == 0)
        {

            ResetTimer();
            Debug.Log("sd");
            Time.timeScale = 0;
            DisplayLoss(true);
            //timercanvas.SetActive(false);
        }
    }

    private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(countdownTime / 60);
        int seconds = Mathf.FloorToInt(countdownTime % 60);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }

    public void DisplayLoss(bool a)
    {
        LoserCanvas.SetActive(a);
        LoserCanvas.GetComponentInChildren<TMP_Text>().text = "YOU LOST";
        LoserCanvas.GetComponentInChildren<TMP_Text>().color = Color.red;
    }

    public void ResetTimer()
    {
        countdownTime = 15f;
        NumberOfCubes.number_of_cubes = -1;
        NumberOfCubes.Number.text = "0";
        //NumberOfCubes.UpdateCubes();
    }
}
