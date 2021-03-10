using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    #region cam
    private GameObject cam;

    [SerializeField] private float MaxView = 75;

    private float angleY;
    private float angleX;
    #endregion
    #region mov
    private CharacterController CC;
    #endregion
    #region PlayerSettings
    [SerializeField] float speed = 1;
    [SerializeField] float sencivity;
    [SerializeField] KeyCode ShootKey;
    #endregion
    #region teapots
    private int teapots = 0;
    [SerializeField] private Text scoreTable;
    #endregion
    #region kunai
    private bool kunai = false;
    [SerializeField] GameObject Kunai;
    private GameObject gg;
    [SerializeField] private float force;
    #endregion
    bool exit = false;
    void Start()
    {
        cam = gameObject.transform.GetChild(0).gameObject;
        Cursor.lockState = CursorLockMode.Locked;
        CC = GetComponent<CharacterController>();
    }
    void Update()
    {
        #region camera
        var mouseX = Input.GetAxis("Mouse X") * sencivity;
        var mouseY = Input.GetAxis("Mouse Y") * sencivity;

        angleY += mouseX;
        angleX -= mouseY;

        angleX = Mathf.Clamp(angleX, -MaxView, MaxView);

        gameObject.transform.localRotation = Quaternion.Euler(0, angleY, 0);
        cam.transform.localRotation = Quaternion.Euler(angleX, 0, 0);
        #endregion
        #region move
        float X = Input.GetAxis("Horizontal");
        float Z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * X + transform.forward * Z;
        if (!Input.GetKey(KeyCode.LeftShift))
            CC.Move(move * speed * Time.deltaTime);
        else
            CC.Move(move * speed * Time.deltaTime * 1.5f);
        #endregion
        if (kunai&&Input.GetKeyDown(ShootKey))
        {
            gg = Instantiate(Kunai, gameObject.transform.position, gameObject.transform.rotation);
            gg.transform.Rotate(0, 180, 0);
            gg.GetComponent<Rigidbody>().AddForce(-gg.transform.forward*force, ForceMode.Impulse);
            gg = null;
        }
        if (exit)
            Application.Quit();
    }
    public void NumNum(string tag)
    {

        if (tag == "teapot")
            teapots++;
        if (tag == "Kunai")
            kunai = true;
        if (tag == "exit")
            exit = true;
        scoreTable.text = teapots.ToString();
    }
}
