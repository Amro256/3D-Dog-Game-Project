using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    GameObject Checkpoint;
    public ParticleSystem checkpointEffect;
    public Renderer ren;
    public Material checkActive;
    public Material notActive;
    [SerializeField] private AudioSource cpSound;
    // Start is called before the first frame update
    void Start()
    {
       Checkpoint = transform.Find("Checkpoint").gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            cpSound.Play();
            ren.material = checkActive;
            Instantiate(checkpointEffect.gameObject, transform.position, transform.rotation);
            Manager.UpdateCheckPoints(gameObject);
            print("Checkpoint active");
        }
    }

   public  void disableCheckpoint()
    {
        ren.material = notActive;
    }
}
