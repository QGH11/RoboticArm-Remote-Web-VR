using UnityEngine;
using UnityEngine.UI;
using System;

public class RotateHinge : MonoBehaviour
{
    public GameObject hinge;
    public GameObject _slider;
    private HingeJoint servoHinge;
    private JointMotor hingeMotor;
    private Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        servoHinge = hinge.GetComponent<HingeJoint>();
        slider = _slider.GetComponent<Slider>();
        hingeMotor = servoHinge.motor;


    }

    private void Update()
    {

        slider.onValueChanged.AddListener((value) =>
        {
            if (servoHinge.angle < slider.value)
            {
                hingeMotor.targetVelocity = 30;
            }
            else if (servoHinge.angle > slider.value)
            {
                hingeMotor.targetVelocity = -30;
            }
            servoHinge.motor = hingeMotor;
        });


        if ((int)Math.Round(servoHinge.angle) == slider.value)
        {
            hingeMotor.targetVelocity = 0;
        }
        if (servoHinge.angle < slider.value)
        {
            hingeMotor.targetVelocity = 30;
        }
        else
        {
            hingeMotor.targetVelocity = -30;
        }
        servoHinge.motor = hingeMotor;

    }
}
