using MudBlazor;

namespace SStore.Services
{
    public interface IAppSnackbarService
    {
        void SuccessMessageCenterButton(string message);
        void ErrorMessageCenterButton(string message);
        void WarningMessageCenterButton(string message);
        void InfoWarningMessageCenterButton(string message);
    }
    public class AppSnackbarService : IAppSnackbarService
    {
        private readonly ISnackbar _snackbar;

        public AppSnackbarService(ISnackbar snackbar)
        {
            this._snackbar = snackbar;
        }
        public void SuccessMessageCenterButton(string message)
        {
            _snackbar.Configuration.PositionClass = Defaults.Classes.Position.BottomCenter;
            _snackbar.Add(message,Severity.Success);
        }
        public void ErrorMessageCenterButton(string message)
        {
            _snackbar.Configuration.PositionClass = Defaults.Classes.Position.BottomCenter;
            _snackbar.Add(message, Severity.Error);
        }
        public void WarningMessageCenterButton(string message)
        {
            _snackbar.Configuration.PositionClass = Defaults.Classes.Position.BottomCenter;
            _snackbar.Add(message, Severity.Warning);
        }
        public void InfoWarningMessageCenterButton(string message)
        {
            _snackbar.Configuration.PositionClass = Defaults.Classes.Position.BottomCenter;
            _snackbar.Add(message, Severity.Info);
        }
    }
}
