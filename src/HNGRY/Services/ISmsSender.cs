namespace HNGRY.Services
{
	public interface ISmsSender
    {
        void SendSms(string number, string message);
    }
}
