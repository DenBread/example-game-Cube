using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
//using AppodealAds.Unity.Api;
//using AppodealAds.Unity.Common;

public class TapToPlay : MonoBehaviour {

	public GameObject coin;
	public GameObject spawnBox; // spawn box
	public GameObject gameOverPanal; // panal GameOver
	public GameObject panalScore; // panal Score
	public GameObject obj_score; // Obj score
	public Text score; // результат
	public Text bestScore; // лучший результат


	[Header("Time")]
	public float time; // секундомер
	public int maxTime; // максимальное время
	public bool timeBool = true; // проверка. Если игрок проигла, то время останавливаться

	[Header("Animation")]
	public Animator buttonGameOver;
	public Animator mainPanelAnim;
	public Animator scorePanel;

    //ачивки
    private const string achiv1 = "CgkIsNTHkKQdEAIQAQ";
	//private const string achiv2 = "CgkIsNTHkKQdEAIQAw";
	private const string achiv3 = "CgkIsNTHkKQdEAIQBA";
	private const string achiv4 = "CgkIsNTHkKQdEAIQBQ";
	private const string achiv5 = "CgkIsNTHkKQdEAIQBg";
    // таблица лидеров
    private const string leaderboard = "CgkIsNTHkKQdEAIQAg";

    //private const string appKey = "c5c0353385f1dc6264dc80fbe55fa8cd7112767d6375ccba";

	private void Start() {
        //IntAbs(); // запускаем рекламу (времено отлючена из-за тестирования)

        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate((bool success) =>
        {
            if (success) print("Удачно вошел!");
            else print("Неудачно вошел!");
        });

		if(!PlayerPrefs.HasKey("Score"))
		{
			maxTime = 0;
			PlayerPrefs.SetInt("Score", (int)maxTime);
		}

		else
		{
			maxTime = PlayerPrefs.GetInt("Score");
		}
		
	}
	private void LateUpdate() {
		CheckTime(timeBool);
	}

	// Проверка времени
	public void CheckTime(bool a)
	{
		if(a) // Когда игра запущена
		{
			time += 1*Time.deltaTime;	// секундомер
			score.text = time.ToString("f0");
		}

		if(!a) // Когда игрок проиграл
		{
			
			if(time > maxTime) // Если игрок сделал новый рекорд, то он записываеться
			{
				maxTime = (int)time;
				PlayerPrefs.SetInt("Score", (int)maxTime);
				bestScore.text = "Best score: \n" + PlayerPrefs.GetInt("Score");
                Social.ReportScore(maxTime, leaderboard, (bool success) =>
                {
                    if (success) print("Удачно добавлен в таблицу лидеров!");
                });
			}
			if(time < PlayerPrefs.GetInt("Score")) // иначе показываеться старый рекорд
			{
				bestScore.text = "Best score: \n" + PlayerPrefs.GetInt("Score"); 
			}
			
		}

		switch ((int)time)
		{
			case 100:
				print("Набрал 100");
				GetTheAchiv(achiv3);
				break;
			case 500:
				print("Набрал 500");
				GetTheAchiv(achiv4);
				break;	
			case 1000:
				print("Набрал 1000");
				GetTheAchiv(achiv5);
				break;
		}
	}

	// Когда нажали на "TapPlay"
	public void TapPlay()
	{
		timeBool = true;
		time = 0;
		coin.SetActive(true);
		obj_score.SetActive(true);
		spawnBox.SetActive(true);
		panalScore.SetActive(false);
		gameOverPanal.SetActive(false);

        GetTheAchiv(achiv1); // ачивка

		mainPanelAnim.SetBool("StartGame", true);
		scorePanel.SetBool("ScoreBack", false);
	}

	// Возрат на главную страницу
	public void Back()
	{
		spawnBox.SetActive(false);
		

		mainPanelAnim.SetBool("StartGame", false);
		scorePanel.SetBool("ScoreBack", true);
	}

	// Играть сново
	public void AganPlay()
	{
		coin.SetActive(true);
		timeBool = true;
		time = 0;
		obj_score.SetActive(true);
		spawnBox.SetActive(true);
		panalScore.SetActive(false);
		

		buttonGameOver.SetBool("BackAgan", true);
	}

    // Запуск ачивок
    private void GetTheAchiv(string id)
    {
        Social.ReportProgress(id, 100f, (bool success) =>
        {
            if (success) print("Получено достижение: " + id);
        });
    }

    // метод для открытия ачивок
    public void AchivBttn()
    {
        Social.ShowAchievementsUI();
        print("показывает ачивки");
    }

    // метод для открытия списка лидеров
    public void LearderBttn()
    {
        Social.ShowLeaderboardUI();
        print("показывает список");
    }

	// Иницализация рекламы
	//void IntAbs()
	//{
	//	Appodeal.initialize(appKey, Appodeal.BANNER | Appodeal.INTERSTITIAL);
	//}

	// Сама реклама
	//public void TestAdss()
	//{
	//	print("Tuch"); // Проверить в консоли, если кнопка была нажата
	//	Appodeal.show(Appodeal.INTERSTITIAL);
	//}
}
