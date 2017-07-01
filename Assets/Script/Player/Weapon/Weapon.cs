using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Weapon : MonoBehaviour {


    //bulletes per each Magazine 
    public int bulletePreMag = 30;
//    // total bulletes we have 
   public int bulletesLefet;
//    //the current bullets in our Magazine 
    public int  currentBulletes;
    public Text bulletsText;
   public Text currentBulletesText;
    private  RaycastHit hit;
//    //
    public float fireRate = 0.1f;
//    //
  float fireTimer;
//
    public float range = 100;
    public Transform shootPoint;
//
  Animator anim;
//
//
    public ParticleSystem buzzleFlash;


    private AudioSource audio;
    public  AudioClip audioClip;



    //
    public GameObject hitParticaler;
    public GameObject bulletsImpact;


    public enum ShootMode{Auto,Semi }

    public ShootMode shootingMode;
    private bool shootInput;

//    //
//
    public float damage = 100;

    //


    private Vector3 originPostion;
    public Vector3 aimPostion;
    public float loadSpeed;

  
    void Start () {
        anim = GetComponent<Animator>();
        currentBulletes=  bulletePreMag ;
       audio = GetComponent<AudioSource>();
     originPostion = transform.localPosition;

      
    }
//
//
//
//    // Update is called once per frame
    void Update()
    {

        switch (shootingMode)
        {
        case ShootMode.Auto:
            shootInput = Input.GetButton("Fire1");
            break;

        case ShootMode.Semi:
            shootInput = Input.GetButtonDown("Fire1");
            break;




        }



        if (shootInput)
        {
            if (currentBulletes > 0)
            { Fire();

            }
            else if(bulletesLefet>0)
            {

            Reload();
             bulletsText.text = "Bulletes : " + bulletesLefet;
            }
            if (bulletesLefet <= 0) {
            
                SceneManager.LoadScene ("GameOver");
            }
        }
        if (fireTimer < fireRate)
        {
            fireTimer += Time.deltaTime;

        }
 AimSight();
    }
//
    private void AimSight()
    {
        if (Input.GetButton("Fire2"))
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, aimPostion, Time.deltaTime * loadSpeed);


        }
        else

        {

            transform.localPosition = Vector3.Lerp(transform.localPosition, originPostion, Time.deltaTime * loadSpeed);
        }
    }

    void FixedUpdate()
    {
        AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);





    }
    private void Fire()
    {
        if (fireTimer < fireRate||currentBulletes<=0) return;


        if (Physics.Raycast(shootPoint.position, shootPoint.transform.forward, out hit, range))
        {
          




            MakeAHitEffect();

//            if(hit.transform.CompareTag("Enemy")){
//
//                GameObject hitParticalerEffect = (GameObject)Instantiate(bulletsImpact, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
//                // hitParticalerEffect.transform.SetParent(hit.transform);
//                // GameObject BulletsImpact = (GameObject)Instantiate(bulletsImpact, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
//                Destroy(hitParticalerEffect, 4f);
//
//            }

            // 










        }

        currentBulletes--;
        fireTimer = 0.0f;// rest fire timer
   anim.CrossFadeInFixedTime("Fire", 0.1f);// play a fire animation

      currentBulletesText.text = "  currentBulletes : " + currentBulletes;
      

      buzzleFlash.Play();
       PlayShootSound();

    }

    private void MakeAHitEffect()
    {
        GameObject hitParticalerEffect = (GameObject)Instantiate(hitParticaler, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
        // hitParticalerEffect.transform.SetParent(hit.transform);
       GameObject BulletsImpact = (GameObject)Instantiate(bulletsImpact, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
        Destroy(hitParticalerEffect, 2f);
    Destroy(BulletsImpact, 2f);

    }
//
    private void PlayShootSound()
    {// no cut the audio one by one 
        audio.PlayOneShot(audioClip);
//      



    }

//
//
    private void Reload() {
        if (bulletesLefet <= 0) return;
        int bulletesToLoad = bulletePreMag - currentBulletes;
        int bulletesToDecuted = (bulletesLefet >= bulletesToLoad) ? bulletesToLoad : bulletesLefet;
        bulletesLefet -= bulletesToDecuted;
        currentBulletes += bulletesToDecuted;



    }

}
