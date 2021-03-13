using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemPanel : MonoBehaviour {

    public ItemAmount itemAmount;

    public ItemImageHolder itemHolder;

    public Text nameText;
    public Text totalText;
    public Text requredText;

    public UnityEngine.UI.Image image;

    // Use this for initialization
    void Start () {

        setImage();
        setName();
        setRequired();
    }
	
	// Update is called once per frame
	void Update () {
        setTotal();
    }

    void setTotal()
    {
        totalText.text = ""+itemAmount.total;
    }

    void setImage()
    {
        Image img = itemHolder.getImage(itemAmount.ItemType);

        image.sprite = img.sprite;
        image.color = img.color;

    }

    void setName()
    {
        Item item = itemHolder.getItem(itemAmount.ItemType);

        nameText.text = item.name;

    }

    void setRequired()
    {

        requredText.text = ""+itemAmount.needed;
    }

}
