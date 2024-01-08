using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WorlmapManager : MonoBehaviour {

    // Use this for initialization
    public Text PercentText;
    Globalvariable gv;
    public List<GameObject> MapList = new List<GameObject>();
    //ending 50조
    //0.00005
    //default Color
    //r = 0.66
    //g = 0.156
    //b = 0.156
    Color defaultColor = new Color();
    Color RecoverColor = new Color();
    double endingMeht = 0.00005;

    //double endingMeht = 0.0000000005;

    //green
    //r = 0.156
    //g = 0.66
    //b = 0.235  
    float factor_1 = 0.0017f;
    float factor_2 = 5.2f;    
    float percentFactor = 6.25f;
    private void Awake()
    {
        gv = Globalvariable.Instance;
        defaultColor.r = 0.66f; defaultColor.g = 0.156f; defaultColor.b = 0.156f; defaultColor.a = 1;
        RecoverColor.r = 0.156f; RecoverColor.g = 0.66f; RecoverColor.b = 0.235f; RecoverColor.a = 1;   
    }
    private void OnEnable()
    {
        for(int i =0; i< MapList.Count;i++)
        {
            MapList[i].GetComponent<Image>().color = defaultColor;
        }
        SetData();
        StartCoroutine(SetDataRutine());
    }
    private void OnDisable()
    {
        StopCoroutine(SetDataRutine());
    }
    IEnumerator SetDataRutine()
    {
        yield return new WaitForSeconds(0.3f);
        SetData();
        StartCoroutine(SetDataRutine());
    }
    double exp;
    void SetData()
    {
        exp = Mathf.Pow(factor_1 * Mathf.Exp(7), ((gv.iMapPrograss + 2) * factor_2));
        double percent = GetPercent();
        int iPercent = gv.iMapPrograss + 1;
        if (percent > 100)
        {            
            percent = iPercent * percentFactor;
            gv.iMapPrograss++;
            gv.SaveiMapPrograss();
            Debug.Log("HOOOOOOOOit");
        }
        else
        {
            double percentAdd = (iPercent-1) * percentFactor;
            //double tempPercent = 100 - percent;
            percent = (percentFactor) * (percent / 100);
            percent = percentAdd + percent;
        }
        PercentText.text = percent.ToString("N3") +"%";
 
        for(int i=0; i< 17; i++)
        {
            if(i < gv.iMapPrograss)
            {
                MapList[i].GetComponent<Image>().color = RecoverColor;
            }            
        }

    }
    double GetPercent()
    {
        return (gv.endingMeht / (exp*gv.scaleFactor)) *100;
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
    }
}
