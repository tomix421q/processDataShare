using processDataShare.Models;
using System.Dynamic;

namespace processDataShare.Services
{
    public class UDTopelTransferToList
    {
        public List<dynamic> ProcessUDTValues(OpelArmrestFront_model model, List<dynamic> udtValues)
        {

            int actualStep = model.actualStep;

            if (actualStep == 2)
            {
                dynamic shotParams = new ExpandoObject();

                shotParams.tempLeftUp = model.tempLeftUp;
                shotParams.tempRightUp = model.tempRightUp;
                shotParams.tempRightDown = model.tempRightDown;
                shotParams.tempLeftDown = model.tempLeftDown;
                shotParams.tempRightUp = model.tempRightDown;
                shotParams.heatingTime = model.heatingTime;
                shotParams.heatingSetPointMax = model.heatingSetPointMax;
                shotParams.foldingTime = model.foldingTime;
                shotParams.foldingSetPointMax = model.foldingSetPointMax;
                shotParams.cycleTime = model.cycleTime;
                shotParams.shotDateTime = model.shotDateTime;
                shotParams.mouldNumber = model.mouldNumber;
                shotParams.recipe = model.recipe;
                shotParams.pyroIndicatorOnOff = model.pyroIndicatorOnOff;

                udtValues.Add(shotParams);
                Console.WriteLine(udtValues);
            }

            return udtValues;
        }
    }
}
