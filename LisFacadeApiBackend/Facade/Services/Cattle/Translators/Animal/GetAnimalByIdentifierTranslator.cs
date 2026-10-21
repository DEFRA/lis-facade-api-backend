using LisFacadeApiBackend.Facade.Cattle.Response.Cattle;
using LisFacadeApiBackend.Facade.LIS.Animal;

namespace LisFacadeApiBackend.Facade.Services.Cattle.Translators;

public class GetAnimalByIdentifierTranslator
    : ITranslator<string, string, CattleDetailsResponse, AnimalRecordDetails>
{
    public string ToCattleApi(string identifier) => throw new NotImplementedException();

    public AnimalRecordDetails ToLisApi(CattleDetailsResponse cattle) => throw new NotImplementedException();
}
