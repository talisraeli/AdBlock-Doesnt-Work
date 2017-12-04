using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour {

    [SerializeField]
    private GameObject click;

    public static List<float> clicksInTheLast2Second = new List<float>();

    private void Start()
    {
        clicksInTheLast2Second = new List<float>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            // Click sound effect
            var sfx = Instantiate(click, transform);
            Destroy(sfx, 1f);
        }

        // Removing old clicks
        while(clicksInTheLast2Second.Count > 0 && clicksInTheLast2Second[0] < Time.timeSinceLevelLoad - 2f)
        {
            clicksInTheLast2Second.RemoveAt(0);
        }
    }

    public static void AddCloseClick()
    {
        // Adding click's time to the list
        clicksInTheLast2Second.Add(Time.timeSinceLevelLoad);
    }

}
