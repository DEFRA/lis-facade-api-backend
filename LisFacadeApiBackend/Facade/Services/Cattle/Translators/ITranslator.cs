namespace LisFacadeApiBackend.Facade.Services.Cattle.Translators;

public interface ITranslator<in TLisRequest, out TCattleApiRequest, in TCattleApiResponse, out TLisResponse>
{
    TCattleApiRequest ToCattleApi(TLisRequest lisRequest);

    TLisResponse ToLisApi(TCattleApiResponse cattleApiResponse);
}
