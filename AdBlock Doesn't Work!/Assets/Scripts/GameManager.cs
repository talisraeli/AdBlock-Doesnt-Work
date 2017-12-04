using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static uint Score { get; set; }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
