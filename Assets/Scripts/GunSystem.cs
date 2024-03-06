using UnityEngine;
using TMPro;

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

    //Graphics
    //public GameObject muzzleFlash, bulletHoleGraphic;
    ////public CamShake camShake;
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
        Debug.Log("Test");
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
            Debug.Log("Test2");
            Debug.Log(rayHit.collider.name);

            // TODO: Look into fix for this
            //if (rayHit.collider.CompareTag("Enemy"))
            //{
            //    rayHit.collider.GetComponent<ShootingAi>().TakeDamage(damage);
            //}
        }

        // Shake Camera -
        // TODO: Develop CamShake class
        //camShake.Shake(camShakeDuration, camShakeMagnitude);

        // Graphics
        //Instantiate(bulletHoleGraphic, rayHit.point, Quaternion.Euler(0, 180, 0));
        //Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);

        bulletsLeft--;
        bulletsShot--;

        Invoke("ResetShot", timeBetweenShooting);

        if (bulletsShot > 0 && bulletsLeft > 0)
        {
            Invoke("Shoot", timeBetweenShots);
        }
    }

    private void ResetShot()
    {
        readytoShoot = true;

    }
    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }

    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }
}
