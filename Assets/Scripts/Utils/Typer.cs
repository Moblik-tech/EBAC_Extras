using System.Collections;
using UnityEngine;
using TMPro;

public class Typer : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public float timeBetweenLetters = 0.1f;

    [TextArea(3, 10)] public string phrase;

    private void Awake()
    {
        textMeshPro.text = "";
    }

    [NaughtyAttributes.Button]
    public void StartTyping()
    {
        StartCoroutine(Type(phrase));
    }

    IEnumerator Type(string s)
    {
        textMeshPro.text = "";
        foreach (char l in s.ToCharArray())
        {
            textMeshPro.text += l;
            yield return new WaitForSeconds(timeBetweenLetters);
        }
    }
}