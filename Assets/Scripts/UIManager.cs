using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text tiempo;
	private bool acabar = false;
	private float startTiempo;
	


    #region Singleton class: UIManager

    public static UIManager Instance;

	void Awake ()
	{
      
        if (Instance == null) {
			Instance = this;
		}
	}

	#endregion

	[Header ("Level Progress UI")]
	//sceneOffset: porque puede agregar otras escenas como (Menú principal, ...)
    [SerializeField] int sceneOffset;
    [SerializeField] Text nextLevelText;
	[SerializeField] Text currentLevelText;
	[SerializeField] Image progressFillImage;

	[Space]
	[SerializeField] Text levelCompletedText;

	[Space]
	//white fading panel at the start
	[SerializeField] Image fadePanel;

	void Start ()
	{
		startTiempo = Time.time;
		
		FadeAtStart ();

		//reset progress value
		progressFillImage.fillAmount = 0f;

		SetLevelProgressText ();
	}

	void SetLevelProgressText ()
	{
		int level = SceneManager.GetActiveScene ().buildIndex + sceneOffset - 1;
		currentLevelText.text = level.ToString ();
		nextLevelText.text = (level + 1).ToString ();
	}

	public void UpdateLevelProgress ()
	{
		float val = 1f - ((float)Level.Instance.objectsInScene / Level.Instance.totalObjects);
		//transition fill (0.4 seconds)
		progressFillImage.DOFillAmount (val, .4f);
	}

	//--------------------------------------
	public void ShowLevelCompletedUI ()
	{
		//fade in the text (from 0 to 1) with 0.6 seconds
		levelCompletedText.DOFade (1f, .6f).From (0f);
	}

	public void FadeAtStart ()
	{
		//fade out the panel (from 1 to 0) with 1.3 seconds
		fadePanel.DOFade (0f, 1.3f).From (1f);
	}
  

  
    private void Update()
    {
		if (acabar)
			return;

		float t = Time.time - startTiempo;
		string minutes = ((int)t / 60).ToString();
		string seconds = (t % 60).ToString("f1");

		tiempo.text = minutes + ":" + seconds;
    }
	public void Final()
	{
	   acabar = true;
	   tiempo.color = Color.red;
     
    }
	


}
