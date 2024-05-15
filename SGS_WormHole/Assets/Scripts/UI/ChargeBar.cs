using UnityEngine;
using UnityEngine.UI;

public class ChargeBar : MonoBehaviour
{
    [SerializeField] private Image firstCharge;
    [SerializeField] private Image secondCharge;
    [SerializeField] private Image thirdCharge;
    [SerializeField] private ChargeSystem playerCharges;

    private int chargesCount;
    private int chargesCountOld;

    void Start()
    {
        chargesCount = playerCharges.CountCharge;
        chargesCountOld = chargesCount;
        SetChargesActive(playerCharges.CountCharge);
    }

    void Update()
    {
        chargesCount = playerCharges.CountCharge;

        if(chargesCount != chargesCountOld)
        {
            SetChargesActive(chargesCount);
            chargesCountOld = chargesCount;
        }
    }

    private void SetChargesActive(int chargesCount)
    {
        switch(chargesCount)
        {
            case 0:
                firstCharge.enabled = false;
                secondCharge.enabled = false;
                thirdCharge.enabled = false;
                break;
            case 1:
                firstCharge.enabled = false;
                secondCharge.enabled = false;
                thirdCharge.enabled = true;
                break;
            case 2:
                firstCharge.enabled = false;
                secondCharge.enabled = true;
                thirdCharge.enabled = true;
                break;
            case 3:
                firstCharge.enabled = true;
                secondCharge.enabled = true;
                thirdCharge.enabled = true;
                break;
            default:
                firstCharge.enabled = false;
                secondCharge.enabled = false;
                thirdCharge.enabled = false;
                break;
        }
    }
}
