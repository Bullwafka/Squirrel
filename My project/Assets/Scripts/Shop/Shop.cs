using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    [SerializeField] private TMP_Text _description;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Image _sourceImage;
    [SerializeField] private Image[] _buttonImages;
    [SerializeField] private GameObject _shopItemDescriptionPanels, _noMoneyPanel;

    [SerializeField] private List<ShopItem> ItemsList;

    [SerializeField] private Score _score;

    private ShopItem[] randomItemsArray;
    private ShopItem _currentItem;
    private void Start()
    {
        RefreshShop();
    }
    public void OnShopButtonClick(ShopItem item)
    {
        _description.text = item.Description;
        _price.text = item.Price.ToString();
        _sourceImage.sprite = item.Sprite;
        _shopItemDescriptionPanels.SetActive(true);
    }
    public void OnButton1Click()
    {
        ShopItem item = randomItemsArray[0];
        OnShopButtonClick(item);
        _currentItem = item;
    }
    public void OnButton2Click()
    {
        ShopItem item = randomItemsArray[1];
        OnShopButtonClick(item);
        _currentItem = item;
    }
    public void OnButton3Click()
    {
        ShopItem item = randomItemsArray[2];
        OnShopButtonClick(item);
        _currentItem = item;
    }
    public void OnButton4Click()
    {
        ShopItem item = randomItemsArray[3];
        OnShopButtonClick(item);
        _currentItem = item;
    }

    public void RefreshShop()
    {
        randomItemsArray = new ShopItem[4];

        System.Random random = new System.Random();
        ItemsList = ItemsList.OrderBy(x => random.Next()).ToList();

        for (int i = 0; i < randomItemsArray.Length; i++)
        {
            randomItemsArray[i] = ItemsList[i];
        }
        for (int i = 0; i < randomItemsArray.Length; i++)
        {
            _buttonImages[i].sprite = randomItemsArray[i].Sprite;
        }
    }

    public void OnBuyBottonClick()
    {
        if (_score.OnBuyGoods(_currentItem.Price))
        {
            _currentItem.OnBuy();
            _shopItemDescriptionPanels.SetActive(false);
        }
        else
        {
            _noMoneyPanel.SetActive(true);
        }
    }

    public void OnDeclineBottonClick()
    {
        _shopItemDescriptionPanels.SetActive(false);
    }

    public void NotEnoughMoneyClose()
    {
        _noMoneyPanel.SetActive(false);
    }
}
//public class ShopManager : MonoBehaviour
//{
//    [SerializeField] private ShopItem[] ItemsArray;

//    private ShopItem[] randomItemsArray;

//    private void OnEnable()
//    {

//    }
//    public void RefreshShop()
//    {
//        //for (int i = 0; i < buttons.Length; i++)
//        //{
//        //    randomItemsArray[i] = ItemsArray[Random.Range(0, ItemsArray.Length)];
//        //}
//    }
// }