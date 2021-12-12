using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthbarTest : MonoBehaviour
{

    public Healthbar healthbar;
    private float radians;

    // Start is called before the first frame update
    void Start()
    {
        radians = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //healthbar.DecreaseHealth(0.1f);
        radians = (radians + 0.02f) % (Mathf.PI * 2);
        healthbar.SetHealth(50 * Mathf.Sin(radians) + 50);
    }
}
