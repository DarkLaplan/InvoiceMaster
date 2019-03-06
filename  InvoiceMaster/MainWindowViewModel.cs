using System.Windows.Input;

namespace InvoiceMaster
{
    /// <summary>
    /// Main viewmodel class contains logic for <see cref="MainWindowView"/>
    /// </summary>
    public class MainWindowViewModel : BaseViewModel
    {
        private string name;
        private string ico;
        private string dic;
        private string psc;
        private string city;
        private string address;
        private string bank;
        private string accountNumber;
        private string payDayDate;
        private string paymentMethod;
        private string exposureDate;
        private string mainText;
        private string realizationDate;
        private string prize;

        /// <summary>
        /// Base constructor.
        /// </summary>
        public MainWindowViewModel()
        {
            InitializeCommands();
        }

        #region Properties

        /// <summary>
        /// Gets or sets state of application.
        /// </summary>
        public ApplicationState AppState { get; set; }

        /// <summary>
        /// Gets or sets whatever is automatic compile allowed.
        /// </summary>
        public bool IsAutoCompileAllowed { get; set; }

        /// <summary>
        /// Gets or sets name of customer.
        /// </summary>
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        /// <summary>
        /// Gets or sets address.
        /// </summary>
        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                OnPropertyChanged(nameof(Address));
            }
        }

        /// <summary>
        /// Gets or sets city name.
        /// </summary>
        public string City
        {
            get { return city; }
            set
            {
                city = value;
                OnPropertyChanged(nameof(City));
            }
        }

        /// <summary>
        /// Gets or sets postal code.
        /// </summary>
        public string PSC
        {
            get { return psc; }
            set
            {
                psc = value;
                OnPropertyChanged(nameof(PSC));
            }
        }

        /// <summary>
        /// Gets or sets IČO.
        /// </summary>
        public string ICO
        {
            get { return ico; }
            set
            {
                ico = value;
                OnPropertyChanged(nameof(ICO));
            }
        }

        /// <summary>
        /// Gets or sets DIC.
        /// </summary>
        public string DIC
        {
            get { return dic; }
            set
            {
                dic = value;
                OnPropertyChanged(nameof(DIC));
            }
        }

        /// <summary>
        /// Gets or sets bank name.
        /// </summary>
        public string Bank
        {
            get { return bank; }
            set
            {
                bank = value;
                OnPropertyChanged(nameof(Bank));
            }
        }

        /// <summary>
        /// Gets or sets bank account number.
        /// </summary>
        public string AccountNumber
        {
            get { return accountNumber; }
            set
            {
                accountNumber = value;
                OnPropertyChanged(nameof(AccountNumber));
            }
        }

        /// <summary>
        /// Gets or sets payday date.
        /// </summary>
        public string PayDayDate
        {
            get { return payDayDate; }
            set
            {
                payDayDate = value;
                OnPropertyChanged(nameof(PayDayDate));
            }
        }

        /// <summary>
        /// Gets or sets payment method.
        /// </summary>
        public string PaymentMethod
        {
            get { return paymentMethod; }
            set
            {
                paymentMethod = value;
                OnPropertyChanged(nameof(PaymentMethod));
            }
        }

        /// <summary>
        /// Gets or sets exposure date.
        /// </summary>
        public string ExposureDate
        {
            get { return exposureDate; }
            set
            {
                exposureDate = value;
                OnPropertyChanged(nameof(ExposureDate));
            }
        }

        /// <summary>
        /// Gets or sets realization date.
        /// </summary>
        public string RealizationDate
        {
            get { return realizationDate; }
            set
            {
                realizationDate = value;
                OnPropertyChanged(nameof(RealizationDate));
            }
        }

        /// <summary>
        /// Gets or sets main text.
        /// </summary>
        public string MainText
        {
            get { return mainText; }
            set
            {
                mainText = value;
                OnPropertyChanged(nameof(MainText));
            }
        }

        /// <summary>
        /// Gets or sets prize.
        /// </summary>
        public string Prize
        {
            get { return prize; }
            set
            {
                prize = value;
                OnPropertyChanged(nameof(prize));
            }
        }

        /// <summary>
        /// Command which creates new invoice.
        /// </summary>
        public ICommand CreateNewInvoiceCommand { get; set; }

        /// <summary>
        /// Command which loades new invoice.
        /// </summary>
        public ICommand LoadOldInvoiceCommand { get; set; }

        /// <summary>
        /// Command which compile current data into pdf file.
        /// </summary>
        public ICommand CompileCommand { get; set; }
        #endregion

        #region Methods

        private void InitializeCommands()
        {
            CreateNewInvoiceCommand = new RelayCommand(ClearProperties);
            LoadOldInvoiceCommand = new RelayCommand(LoadPdfFile);
            CompileCommand = new RelayCommand(CompilePdf);
        }

        private void CompilePdf(object unused)
        {

        }

        private void LoadPdfFile(object unused)
        {

        }

        private void ClearProperties(object unused)
        {

        }

        #endregion
    }
}
