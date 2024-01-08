using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
public class LevelLoader : MonoBehaviour
{

    //public GameObject LoadingScreen;
    //public Slider slider;
    public GameObject Logo;
    
    public Text progrssText;
    public GameObject PrograssTextObj;
    public GameObject TouchText;
    public GameObject LogoPanel;
    public Image LogoImage;
    public Image LogImageTItle;
    bool start = false;
    public float couSpeed;
    public float speed;
    private void Awake()
    {

    }
    private void Start()
    {

        StartCoroutine(StartLogoInit());
    }
    IEnumerator StartLogoInit()
    {
        yield return new WaitForSeconds(1.1f);
        StartCoroutine(StartLogo());
    }
    IEnumerator StartLogo()
    {        
        yield return new WaitForSeconds(couSpeed);
        Color temp = LogoImage.color;
        temp.a -= speed;
        LogoImage.color= temp;
        temp = LogImageTItle.color;
        temp.a -= speed;
        LogImageTItle.color = temp;
        if (temp.a >0.2f)
            StartCoroutine(StartLogo());
        else
        {
            LogoPanel.SetActive(false);
            Logo.SetActive(true);
            Logo.GetComponent<DOTweenAnimation>().DOPlay();
        }
            
       

    }
    public void LoadSecen()
    {
        LoadLevel("VaccineMaster");
        PrograssTextObj.SetActive(true);
        TouchText.SetActive(false);
    }

    public void LoadLevel(string nameScene)
    {
        if (start == false)
        {
            //LoadingScreen.SetActive(true);
            TouchText.SetActive(false);

            StartCoroutine(LoadAsynchronously(nameScene));
            start = true;
        }
    }


    IEnumerator LoadAsynchronously(string nameScen)
    {
        yield return new WaitForSeconds(0.1f);
        AsyncOperation opertation = SceneManager.LoadSceneAsync(nameScen);
        //AsyncOperation opertation =  Application.LoadLevelAsync(0);

        while (!opertation.isDone)
        {
            float progress = Mathf.Clamp01(opertation.progress / .9f);

            if (progress * 100f > 100)
            {
                progrssText.text = 100.ToString("N2") + "%";
            }
            else
            {
                float temp = progress * 100f;
                progrssText.text = temp.ToString("N2") + "%";

            }
            yield return null;
        }
    }

    float GetResolution(int width, int height)
    {
        float scRatio = (float)width / (float)height;
        float scRound = Mathf.Round(scRatio * 100.0f);
        scRound = scRound / 100f;
        return scRound;
    }
}
