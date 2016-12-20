using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Instruction : MonoBehaviour {

    public Text cookingText;
    public Text distraciontText;

	// Use this for initialization
	void Start ()
    {
        Blend();
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}
    
    //Cooking Instructions
    public void Blend()
    {
        cookingText.text = "Blend biscuits";
    }
    public void BakeBiscuit()
    {
        cookingText.text = "Bake biscuits in oven";
    }
    public void TakeBiscuitOut()
    {
        cookingText.text = "Take biscuits out of the oven";
    }
    public void DropBiscuit()
    {
        cookingText.text = "Drop biscuits";
    }
    public void GetWisk()
    {
        cookingText.text = "Get wisk";
    }
    public void WiskCheese()
    {
        cookingText.text = "Wisk cheese in the mortar";
    }
    public void CheeseOnCake()
    {
        cookingText.text = "Put cheese on the baked biscuit";
    }
    public void BakeCheese()
    {
        cookingText.text = "Bake cake again";
    }
    public void TakeCheeseOut()
    {
        cookingText.text = "Take cake out of the oven";
    }
    public void DropCheese()
    {
        cookingText.text = "Drop cheese";
    }
    public void GetLemon()
    {
        cookingText.text = "Get lemon";
    }
    public void FryLemon()
    {
        cookingText.text = "Fry lemon in pan";
    }
    public void LemonOnCake()
    {
        cookingText.text = "Put lemon on cake";
    }
    public void DropCoolCake()
    {
        cookingText.text = "Drop cake to cool";
    }
    public void GetCake()
    {
        cookingText.text = "Eat cooled cake";
    }

    //Distractions Instructions
    public void GetPhone()
    {
        distraciontText.GetComponent<Text>().text = "Answer phone";
    }
    public void GetDoor()
    {
        distraciontText.GetComponent<Text>().text = "Answer door";
    }
    public void PickUpDogShit()
    {
        distraciontText.GetComponent<Text>().text = "Pick up dog poo";
    }
    public void DogPooSink()
    {
        distraciontText.GetComponent<Text>().text = "Put dog poo in sink";
    }
    public void Police()
    {
        distraciontText.GetComponent<Text>().text = "Police are here";
    }
}
