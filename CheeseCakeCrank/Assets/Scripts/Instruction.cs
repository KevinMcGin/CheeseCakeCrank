using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Instruction : MonoBehaviour {

    public Text cookingText;

	// Use this for initialization
	void Start ()
    {
        Blend();
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}
    
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
}
