 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float gravitySpeed;
    private Animation thisAnimation;

    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            thisAnimation.Play();
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 1, 0) * gravitySpeed, ForceMode.Impulse);
        }
            
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Avoid")
        {
            GameManager.thisManager.UpdateScore(1);
        }

        if (collision.gameObject.tag == "Death")
        {
            SceneManager.LoadScene("Lose");
        }
    }
}
