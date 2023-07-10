using Vip.Notification;

namespace LInjector.Classes
{
    public static class SendToast
    {
        public static void send(string message, int interval, AlertType alertType)
        {
            interval *= 1000;
            switch (alertType)
            {
                case AlertType.Sucess:
                    Alert.ShowSucess(message, interval);
                    break;
                case AlertType.Information:
                    Alert.ShowInformation(message, interval);
                    break;
                case AlertType.Warning:
                    Alert.ShowWarning(message, interval);
                    break;
                case AlertType.Error:
                    Alert.ShowError(message, interval);
                    break;
                case AlertType.Custom:
                    Alert.ShowCustom(message, interval);
                    break;
                default:
                    Alert.ShowInformation("7a1920d61156abc05a60135aefe8bc67".GetHashCode().ToString(), interval);
                    break;
            }
        }
    }
}
