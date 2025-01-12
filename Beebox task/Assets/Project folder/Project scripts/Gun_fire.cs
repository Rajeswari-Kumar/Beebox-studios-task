using System.Collections;
using TMPro;
using Unity.XR.CoreUtils;
using UnityEngine;

public class Gun_fire : MonoBehaviour
{
    public GameObject bullet;
    public GameObject firePoint; 
    public float fireForce; 
    public GameObject muzzleFlash; 
    public AudioSource fireSound;
    private bool isFiring = false;
    public GameObject winnerCanvas;
    public GameObject cubes_count;
    public Timer timer;
    public Button_navigation numberOfCubes;
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isFiring)
        {
            StartCoroutine(FireGun());
        }


        if (cubes_count.transform.childCount == 0 && Time.timeScale == 1)
        {
            winnerCanvas.SetActive(true);
            winnerCanvas.GetComponentInChildren<TMP_Text>().text = "YOU WON!!!";
            winnerCanvas.GetComponentInChildren<TMP_Text>().color = Color.green;
            //numberOfCubes.UpdateCubes();
            timer.ResetTimer();
            Debug.Log("Won!");
            Time.timeScale = 0;
        }
    }

    private IEnumerator FireGun()
    {
        isFiring = true;
        fireSound.Play();
        GameObject muzzleFlashSpawn = Instantiate(muzzleFlash, firePoint.transform.position, firePoint.transform.rotation);
        Destroy(muzzleFlashSpawn, 1f);

        GameObject bulletSpawn = Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
        bulletSpawn.GetComponent<Rigidbody>().AddForce(firePoint.transform.forward * fireForce);



        yield return new WaitForSeconds(1f);

       
        fireSound.Stop();
        isFiring = false;
    }


}
