using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Bhaskara : MonoBehaviour
{    
    private bool Touch, Calculate, Impossible;
    private float Delta, DeltaRoot, XOne, XTwo;

    public InputField ValueA, ValueB, ValueC;
    public Text DeltaText, DeltaRootText, XOneText, XTwoText;
    public Animator ResultsAnimator;

    void Awake()
    {
        Touch = true;
        Calculate = false;
        Impossible = false;
    }
    void Update()
    {    
        if (Calculate == true) {

            float A = float.Parse(ValueA.text);
            float B = float.Parse(ValueB.text);
            float C = float.Parse(ValueC.text);

            Delta = ((B * B) - (4 * A * C));
            DeltaRoot = Mathf.Sqrt(Delta);

            if (Delta < 0) {
                Impossible = true;
            } else {
                Impossible = false;
            }
            
            if (Impossible == false) {
                XOne = ((-B + DeltaRoot) / (2 * A));
                XTwo = ((-B - DeltaRoot) / (2 * A));               
            }
            
            Calculate = false;
        }
    }
    
    public void CalculateButton ()
    {
        if (Touch == true)
        {
            if (ValueA.text != "" && ValueB.text != "" && ValueC.text != "")
            {
                ResultsAnimator.Play("ResultsPossible", -1, Time.deltaTime);
                Calculate = true;              
                StartCoroutine("ResultsShow");
            }

            if (ValueA.text == "" || ValueB.text == "" || ValueC.text == "")
            {
                ResultsAnimator.Play("ResultsImpossible", -1, Time.deltaTime);
                Calculate = false;                                

                DeltaText.text = "Δ = ?";
                DeltaRootText.text = "√Δ = ?";
                XOneText.text = "X' = ?";
                XTwoText.text = "X'' = ?";
            }
            StartCoroutine("TouchTimer");
            Touch = false;
        }        
    }

    IEnumerator ResultsShow()
    {
        yield return new WaitForSecondsRealtime(0.5f);

        if (Impossible == true) {

            if (Delta.ToString().Contains("."))
            {
                DeltaText.text = "Δ = " + Delta.ToString("F6") + "...";
            }
            else
            {
                DeltaText.text = "Δ = " + Delta.ToString();
            }

            if (Delta.ToString().Length >= 8)
            {
                DeltaText.text = "Δ = " + Mathf.Pow(Delta, 5).ToString();
            }

            DeltaRootText.text = "√Δ = INEXISTENTE";
            XOneText.text = "X' = INEXISTENTE";
            XTwoText.text = "X'' = INEXISTENTE";

        } else {

            if (Delta.ToString().Contains("."))
            {
                DeltaText.text = "Δ = " + Delta.ToString("F6") + "...";
            }
            else
            {
                DeltaText.text = "Δ = " + Delta.ToString();
            }

            if (DeltaRoot.ToString().Contains("."))
            {
                DeltaRootText.text = "√Δ = " + DeltaRoot.ToString("F6") + "...";
            }
            else
            {
                DeltaRootText.text = "√Δ = " + DeltaRoot.ToString();
            }

            if (XOne.ToString().Contains("."))
            {
                XOneText.text = "X' = " + XOne.ToString("F6") + "...";
            }
            else
            {
                XOneText.text = "X' = " + XOne.ToString();
            }

            if (XTwo.ToString().Contains("."))
            {
                XTwoText.text = "X'' = " + XTwo.ToString("F6") + "...";
            }
            else
            {
                XTwoText.text = "X'' = " + XTwo.ToString();
            }

            if(Delta > 100000)
            {
                DeltaText.text = "Δ = " + Mathf.Pow(Delta, 5).ToString();
            }

            if (DeltaRoot > 100000)
            {
                DeltaRootText.text = "√Δ = " + Mathf.Pow(DeltaRoot, 5).ToString();
            }

            if (XOne > 100000)
            {
                XOneText.text = "X' = " + Mathf.Pow(XOne, 5).ToString();
            }

            if (XTwo > 100000)
            {
                XTwoText.text = "X'' = " + Mathf.Pow(XTwo, 5).ToString();
            }            
        }

        if (DeltaText.text == "Δ = Infinity")
        {
            DeltaText.text = "Δ = Infinito";
        }
        if (DeltaText.text == "Δ = -Infinity")
        {
            DeltaText.text = "Δ = -Infinito";
        }

        if (DeltaRootText.text == "√Δ = Infinity")
        {
            DeltaRootText.text = "√Δ = Infinito";
        }
        if (DeltaRootText.text == "√Δ = -Infinity")
        {
            DeltaRootText.text = "√Δ = -Infinito";
        }

        if (XOneText.text == "X' = Infinity")
        {
            XOneText.text = "X' = Infinito";
        }
        if (XOneText.text == "X' = -Infinity")
        {
            XOneText.text = "X' = -Infinito";
        }

        if (XTwoText.text == "X'' = Infinity")
        {
            XTwoText.text = "X'' = Infinito";
        }
        if (XTwoText.text == "X'' = -Infinity")
        {
            XTwoText.text = "X'' = -Infinito";
        }

        StopCoroutine("ResultsShow");
    }

    IEnumerator TouchTimer ()
    {
        yield return new WaitForSecondsRealtime(0.50f);
        Touch = true;
        StopCoroutine("TouchTimer");
    }
}