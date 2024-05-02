using UnityEngine;
using TMPro;
using System.Collections;

public class GunSystem : MonoBehaviour
{
    // Gun stats
    public int damage;
    public float timeBetweenShooting, spread, range, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    int bulletsLeft, bulletsShot;

    bool shooting, readytoShoot, reloading;

    public Camera fpscam;
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;
    [SerializeField] private AudioSource gunshot;
    [SerializeField] private AudioSource reload;

    //Graphics
    public GameObject muzzleFlash; 
    //public GameObject bulletHoleGraphic;
    //public CamShake camShake;
    //public float camShakeMagnitude, camShakeDuration;

    public TextMeshProUGUI text;
    private void Awake()
    {
        bulletsLeft = magazineSize;
        readytoShoot = true;
    }
    public void Update()
    {
        MyInput();

        // Set Text
        text.SetText("Ammo: " + bulletsLeft + " / " + magazineSize);
    }

    public void MyInput()
    {
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading) Reload();

        // Shoot
        if(readytoShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = bulletsPerTap;
            Shoot();
        }
    }
    private void Shoot()
    {
        readytoShoot = false;

        // Spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //Calculate Direction with spread
        Vector3 direction = fpscam.transform.forward + new Vector3(x, y, 0);
        gunshot.Play();

        // RayCast
        if (Physics.Raycast(fpscam.transform.position, direction, out rayHit, range, whatIsEnemy))
        {

            if (rayHit.collider.CompareTag("Zombie"))
            {
                rayHit.collider.GetComponent<DamageController>().TakeDamage(damage);
            }
        }

        // Shake Camera -
        // TODO: Develop CamShake class
        //camShake.Shake(camShakeDuration, camShakeMagnitude);

        // Graphics
        GameObject flashInstance = Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);
        StartCoroutine(DestroyAfterDelay(flashInstance, 0.2f));

        bulletsLeft--;
        bulletsShot--;

        Invoke("ResetShot", timeBetweenShooting);

        if (bulletsShot > 0 && bulletsLeft > 0)
        {
            Invoke("Shoot", timeBetweenShots);
        }
    }

    private IEnumerator DestroyAfterDelay(GameObject objectToDestroy, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(objectToDestroy);
    }
    private void ResetShot()
    {
        readytoShoot = true;

    }
    private void Reload()
    {
        reload.Play();
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }

    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }
}
