using UnityEngine;
using UnityEngine.UI;

public class ToggleScript : MonoBehaviour
{
    public GameObject bean;
    public GameObject teddy;
    public GameObject car;
    public GameObject granny;
    public GameObject toggleLeft;
    public GameObject toggleRight;
    public GameObject characterImage;
    public Sprite[] characterSprites;
    public GameObject sizeSlider;
    public GameObject rotationSlider;

    public void ToggleBean(bool value)
    {
        bean.SetActive(value);
        toggleLeft.GetComponent<Toggle>().interactable = value;
        toggleRight.GetComponent<Toggle>().interactable = value;
    }
/*
    public void ToLeft()
    {
        bean.transform.localScale = new Vector2(1, 1);
    }

    public void ToRight()
    {
        bean.transform.localScale = new Vector2(-1, 1);
    }
*/
    // Realizēt ToggleFlip metodi, kas apvieno ToLeft un ToRight
    public void ToggleFlip(int x)
    {
        bean.transform.localScale = new Vector2(x, 1);
    }

    public void ToggleTeddy(bool value)
    {
        teddy.SetActive(value);
    }

    public void ToggleCar(bool value)
    {
        car.SetActive(value);
    }

    public void ToggleGranny(bool value)
    {
        granny.SetActive(value);
    }

    public void ChangeCharacterImage(int index)
    {
        characterImage.GetComponent<Image>().sprite = characterSprites[index];
    }

    public void ChangeRotation()
    {
        float rotationValue = rotationSlider.GetComponent<Slider>().value;
        characterImage.transform.localRotation = 
                            Quaternion.Euler(0, 0, 360 * rotationValue);
    }

    public void ChangeSize()
    {
        float sizeValue = sizeSlider.GetComponent<Slider>().value;
        characterImage.transform.localScale = 
                            new Vector2(1f * sizeValue, 1f * sizeValue);
    }
}
