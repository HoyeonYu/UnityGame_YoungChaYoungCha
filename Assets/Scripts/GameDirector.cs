using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    static public GameObject MyAssetsCanvasFold, MyAssetsCanvasFull;
    public GameObject MyHealthCanvas, BankCanvas, RealEstateCanvas,CoinCanvas, CoinDealCanvas,
        SuperMarketCanvas, CarRepairShopCanvas, CarShopCanvas, GameOverCanvas;

    static public bool isPlayerFixed;

    void Start()
    {
        MyAssetsCanvasFold = GameObject.Find("MyAssetsCanvasFold");
        MyAssetsCanvasFold.SetActive(true);

        MyAssetsCanvasFull = GameObject.Find("MyAssetsCanvasFull");
        MyAssetsCanvasFull.SetActive(false);

        MyHealthCanvas = GameObject.Find("MyHealthCanvas");
        MyHealthCanvas.SetActive(true);

        BankCanvas = GameObject.Find("BankCanvas");
        BankCanvas.SetActive(false);

        RealEstateCanvas = GameObject.Find("RealEstateCanvas");
        RealEstateCanvas.SetActive(false);

        CoinCanvas = GameObject.Find("CoinCanvas");
        CoinCanvas.SetActive(false);

        CoinDealCanvas = GameObject.Find("CoinDealCanvas");
        CoinDealCanvas.SetActive(false);

        SuperMarketCanvas = GameObject.Find("SuperMarketCanvas");
        SuperMarketCanvas.SetActive(false);

        CarRepairShopCanvas = GameObject.Find("CarRepairShopCanvas");
        CarRepairShopCanvas.SetActive(false);

        CarShopCanvas = GameObject.Find("CarShopCanvas");
        CarShopCanvas.SetActive(false);

        GameOverCanvas = GameObject.Find("GameOverCanvas");
        GameOverCanvas.SetActive(false);

        isPlayerFixed = false;
    }

    void Update()
    {
        MyAssetsCanvasFold.SetActive(!(BankCanvas.active || RealEstateCanvas.active
            || CoinCanvas.active || CoinDealCanvas.active || MyAssetsCanvasFull.active
            || SuperMarketCanvas.active || CarRepairShopCanvas.active || CarShopCanvas.active));

        MyAssetsCanvasFull.SetActive(!(BankCanvas.active || RealEstateCanvas.active 
            || CoinCanvas.active || CoinDealCanvas.active || MyAssetsCanvasFold.active
            || SuperMarketCanvas.active || CarRepairShopCanvas.active || CarShopCanvas.active));

        MyHealthCanvas.SetActive(!(BankCanvas.active || RealEstateCanvas.active
            || CoinCanvas.active || CoinDealCanvas.active
            || SuperMarketCanvas.active || CarRepairShopCanvas.active || CarShopCanvas.active));

        if (MyHealthController.isGameEnd)
        {
            MyAssetsCanvasFold.SetActive(false);
            MyAssetsCanvasFull.SetActive(false);
            MyHealthCanvas.SetActive(false);
            GameOverCanvas.SetActive(true);
            isPlayerFixed = true;
        }
    }

    public void OnBankCanvasCloseClick()
    {
        BankCanvas.SetActive(false);
        isPlayerFixed = false;
    }

    public void OnRealEstateCanvasOpenClick()
    {
        RealEstateCanvas.SetActive(true);
        BankCanvas.SetActive(false);
        isPlayerFixed = true;
    }

    public void OnRealEstateCanvasCloseClick()
    {
        RealEstateCanvas.SetActive(false);
        isPlayerFixed = false;
    }

    public void OnCoinCanvasOpenClick()
    {
        CoinCanvas.SetActive(true);
        BankCanvas.SetActive(false);
        isPlayerFixed = true;
    }

    public void OnCoinCanvasCloseClick()
    {
        CoinCanvas.SetActive(false);
        isPlayerFixed = false;
    }

    public void OnCoinDealCanvasOpenClick()
    {
        CoinCanvas.SetActive(false);
        CoinDealCanvas.SetActive(true);
        isPlayerFixed = true;
    }

    public void OnCoinDealCanvasCloseClick()
    {
        CoinDealCanvas.SetActive(false);
        isPlayerFixed = false;
    }

    public void OnCoinGetFullAssetsCanvasClick()
    {
        MyAssetsCanvasFold.SetActive(false);
        MyAssetsCanvasFull.SetActive(true);
        isPlayerFixed = false;
    }

    public void OnCoinGetFoldAssetsCanvasClick()
    {
        MyAssetsCanvasFull.SetActive(false);
        MyAssetsCanvasFold.SetActive(true);
        isPlayerFixed = false;
    }

    public void OnSuperMarketCanvasCloseClick()
    {
        SuperMarketCanvas.SetActive(false);
        MyAssetsCanvasFold.SetActive(true);
        isPlayerFixed = false;
    }

    public void OnSuperMarketCanvasBuyClick()
    {
        SuperMarketCanvas.SetActive(false);
        MyAssetsCanvasFold.SetActive(true);
        isPlayerFixed = false;
    }

    public void OnGameOverAgainClick()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnGameOverExitClick()
    {
        Application.Quit();
    }
}
