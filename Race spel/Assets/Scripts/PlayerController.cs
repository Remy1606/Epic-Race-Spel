using UnityEngine;
using TMPro;

public class NewMonoBehaviourScript : MonoBehaviour


{
    public float speed = 20f;
    public float turnSpeed;
    public float forwardAcceleration = 0.0f;
    public float maxAcceleration;
    private float horizontalInput;
    public float forwardInput;
    public float slowDownRate;
    public TextMeshProUGUI toerenText;
    public TextMeshProUGUI GearText;
    public TextMeshProUGUI Warning;
    public float toerenPerMinuut;
    public int currentGear = 1;
    public int inputToRpm;
    public int maxRPM = 8000;
    public int minRPM = 900;
    public int RPMFactor;
    public float strengh;
    public bool drivable = true;
    public int maxGear = 5;
    public string warningText;

    void SetText()
    {
        toerenText.text = toerenPerMinuut.ToString("0");
        GearText.text = currentGear.ToString();
        Warning.text = warningText;
    }

    void Start()
    {
        SetText();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (drivable)
        {
            forwardInput = Input.GetAxis("Vertical");        
        } else
        {
            if (Input.GetAxis("Vertical") < 0)
            {
                forwardInput = Input.GetAxis("Vertical"); 
            } else
            {
                drivable = false;
            }
        }

        slowDownRate = (float)(0.5 * (forwardAcceleration * forwardAcceleration));
        RPMFactor = maxRPM- minRPM;

        if (Input.GetKeyDown(KeyCode.Period) && currentGear != maxGear)
        {
            currentGear += 1;
        }

        if (Input.GetKeyDown(KeyCode.Comma) && currentGear != 1)
        {
            currentGear -= 1;
        }

        if (!drivable)
        {
            warningText = "Too slow, shift to a lower gear!";
        } else
        {
            warningText = "";
        }

        
        forwardAcceleration = SnelheidUpdate();
        turnSpeed = SturenSnelheidUpdate();
        toerenPerMinuut = GearConfig();
        drivable = Drivability();

        SetText();
        // foward based on user input
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardAcceleration);
        // rotate based on user input
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
    }

    float GearConfig()
    {
        if (toerenPerMinuut == maxRPM)
        {
            toerenPerMinuut = maxRPM;
        }


        if (currentGear != 0)
        { 
            strengh = (float)(maxGear / currentGear);
            inputToRpm = RPMFactor / currentGear;
            maxAcceleration = currentGear;
        }
        else
        {
            strengh = 0;
            inputToRpm = RPMFactor;
            maxAcceleration = 1;
        }

        toerenPerMinuut = forwardAcceleration * inputToRpm + minRPM;       

        return toerenPerMinuut;
    }

    float SnelheidUpdate()
    {

        forwardAcceleration += forwardInput * Time.deltaTime;   

        if (forwardInput == 0)
        {
            forwardAcceleration -= slowDownRate * Time.deltaTime;
        }

        if (forwardInput < 0 && forwardAcceleration <= 0)
        {
            forwardAcceleration = 0;
        }

        if (forwardAcceleration >= maxAcceleration)
        {
            forwardAcceleration = maxAcceleration;
        }
        
        if (forwardAcceleration < 0.15 && forwardInput == 0)
        {
            forwardAcceleration = 0;
        }

        return forwardAcceleration;
    }

    float SturenSnelheidUpdate()
    {
        if (forwardAcceleration == 0)
        {
            turnSpeed = 0;
        }
        else
        {
            turnSpeed = 80- forwardAcceleration;
        }
        return turnSpeed;
    }

    // optimaliseren: kan niet remmen in hogere versnelling want drivable wordt false
    bool Drivability()
    {
        drivable = false;

        if (strengh > maxAcceleration)
        {
            drivable = true;
        } else if (forwardAcceleration > maxAcceleration / 3)
        {
            drivable = true;
        }

        return drivable;
    }

}
