using UnityEngine;
using HelloInvestigation;

public class HelloWorld : MonoBehaviour
{
    private void Start()
    {
        Greeting greeting = new Greeting();
        greeting.Name = "Gateroller";
        Debug.Log(greeting.BuildMessage());
    }
}