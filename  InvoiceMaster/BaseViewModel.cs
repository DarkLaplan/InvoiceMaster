using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace InvoiceMaster
{
    /// <summary>
    /// Basic abstract class which should implements each viewmodel class.
    /// </summary>
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Event for updating UI after property is changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Method is called to init changes in UI for concreate property.
        /// </summary>
        /// <param name="propertyName">Name of property.</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
