using travellingyuan.Models;
using Syncfusion.XForms.ComboBox;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace travellingyuan.Controls
{
    [Preserve(AllMembers = true)]
    public class CountryComboBox : SfComboBox, INotifyPropertyChanged
    {
        #region Fields

        private object country;

        private string phoneNumberPlaceHolder = "Phone Number";

        private string phoneNumber;

        private string city;

        private object state;

        private string[] states;

        private string countryCode;

        #endregion

        #region Constructor
        public CountryComboBox()
        {
            BindingContext = this;

            Countries = new List<CountryModel>();
            Countries.Add(new CountryModel()
            {
                Country = "Andorra",
                States = new string[] { }
            });
            Countries.Add(new CountryModel()
            {
                Country = "Austria",
                States = new string[] { }
            });
            Countries.Add(new CountryModel()
            {
                Country = "Belgium",
                States = new string[] { }
            });
            Countries.Add(new CountryModel()
            {
                Country = "Cyprus",
                States = new string[] { }
            });
            Countries.Add(new CountryModel()
            {
                Country = "Estonia",
                States = new string[] { }
            });
            Countries.Add(new CountryModel()
            {
                Country = "Finland",
                States = new string[] { }
            });
            Countries.Add(new CountryModel()
            {
                Country = "France",
                States = new string[] { }
            });
            Countries.Add(new CountryModel()
            {
                Country = "Germany",
                States = new string[] { }
            });
            Countries.Add(new CountryModel()
            {
                Country = "Greece",
                States = new string[] { "Tasmania", "Victoria", "Queensland", "Northen Territory" }
            });
            Countries.Add(new CountryModel()
            {
                Country = "Ireland",
                States = new string[] { }
            });
            Countries.Add(new CountryModel()
            {
                Country = "Italy",
                States = new string[] { }
            });
            Countries.Add(new CountryModel()
            {
                Country = "Kosovo",
                States = new string[] { }
            });
            Countries.Add(new CountryModel()
            {
                Country = "Latvia",
                States = new string[] { }
            });
            Countries.Add(new CountryModel()
            {
                Country = "Lithuania",
                States = new string[] { }
            });
            Countries.Add(new CountryModel()
            {
                Country = "Luxembourg",
                States = new string[] { }
            });
            Countries.Add(new CountryModel()
            {
                Country = "Malta",
                States = new string[] { }
            });
            Countries.Add(new CountryModel()
            {
                Country = "Monaco",
                States = new string[] { }
            });
            Countries.Add(new CountryModel()
            {
                Country = "Montenegro",
                States = new string[] { }
            });
            Countries.Add(new CountryModel()
            {
                Country = "Netherlands",
                States = new string[] { }
            });
            Countries.Add(new CountryModel()
            {
                Country = "Portugal",
                States = new string[] { }
            });
            Countries.Add(new CountryModel()
            {
                Country = "Saint Barthelemy",
                States = new string[] { }
            });
            Countries.Add(new CountryModel()
            {
                Country = "Saint Pierre and Miquelon",
                States = new string[] { }
            });
            Countries.Add(new CountryModel()
            {
                Country = "San Marino",
                States = new string[] { }
            });
            Countries.Add(new CountryModel()
            {
                Country = "Slovakia",
                States = new string[] { }
            });
            Countries.Add(new CountryModel()
            {
                Country = "Slovenia",
                States = new string[] { }
            });
            Countries.Add(new CountryModel()
            {
                Country = "Spain",
                States = new string[] { }
            });
            Countries.Add(new CountryModel()
            {
                Country = "Vatican City",
                States = new string[] { "Tasmania", "Victoria", "Queensland", "Northen Territory" }
            });

            DataSource = Countries;
            this.SetBinding(SfComboBox.SelectedItemProperty, "Country", BindingMode.TwoWay);
            DisplayMemberPath = "Country";
            Watermark = "Select Country";
            this.VerticalOptions = LayoutOptions.CenterAndExpand;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the property that bounds with a ComboBox that gets the Country from user.
        /// </summary>
        public object Country
        {
            get { return country; }
            set
            {
                country = value;
                UpdateStateAndPhoneNumberFormat();
            }
        }

        /// <summary>
        /// Gets or set the string property, that represents the phone number format based on country. 
        /// </summary>
        public string PhoneNumberPlaceHolder
        {
            get { return phoneNumberPlaceHolder; }
            set
            {
                phoneNumberPlaceHolder = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or set the string property, that represents the phone number based on country. 
        /// </summary>
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                phoneNumber = value;
                NotifyPropertyChanged();
            }
        }


        /// <summary>
        /// Gets or sets the string property, which holds the contry code based on user input. 
        /// </summary>
        public string CountryCode
        {
            get { return countryCode; }
            set
            {
                countryCode = value;
                NotifyPropertyChanged();
            }
        }


        /// <summary>
        /// Gets or set the string property, that represents the user given city. 
        /// </summary>
        public string City
        {
            get { return city; }
            set
            {
                city = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the property that bounds with a ComboBox that gets the State from user.
        /// </summary>
        public object State
        {
            get { return state; }
            set
            {
                state = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets array collection that contains states based on country selection. 
        /// </summary>
        public string[] States
        {
            get { return states; }
            set
            {
                states = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets string property that represents mask format for phone number. 
        /// </summary>
        private string _mask = "";
        public string Mask
        {
            get => _mask;
            set
            {
                _mask = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the collection property, which contains the countries data. 
        /// </summary>
        public List<CountryModel> Countries { get; set; }

        #endregion

        #region Event handler

        /// <summary>
        /// Occurs when the property is changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Methods

        /// <summary>
        /// Method used to rest State and City and update PhoneNumber format. 
        /// </summary>
        private void UpdateStateAndPhoneNumberFormat()
        {
            State = null;
            PhoneNumber = string.Empty;
            City = string.Empty;
            CountryModel countryModel = Country as CountryModel;
            States = countryModel.States;

            switch (countryModel.Country)
            {
                case "Andorra":
                    PhoneNumberPlaceHolder = "e.g. X XXXX XXXX";
                    Mask = "+376X XXXX XXXX";
                    CountryCode = "+376";
                    break;
                case "Austria":
                    PhoneNumberPlaceHolder = "e.g. X XXXX XXXX";
                    Mask = "+43XXXXXXXXX";
                    CountryCode = "+43";
                    break;
                case "Belgium":
                    PhoneNumberPlaceHolder = "e.g. X XXXX XXXX";
                    Mask = "+32X XXXX XXXX";
                    CountryCode = "+32";
                    break;
                case "Cyprus":
                    PhoneNumberPlaceHolder = "e.g. X XXXX XXXX";
                    Mask = "+357X XXXX XXXX";
                    CountryCode = "+357";
                    break;
                case "Estonia":
                    PhoneNumberPlaceHolder = "e.g. X XXXX XXXX";
                    Mask = "+372X XXXX XXXX";
                    CountryCode = "+372";
                    break;
                case "Finland":
                    PhoneNumberPlaceHolder = "e.g. X XXXX XXXX";
                    Mask = "+358X XXXX XXXX";
                    CountryCode = "+358";
                    break;
                case "France":
                    PhoneNumberPlaceHolder = "e.g. X XXXX XXXX";
                    Mask = "+33X XXXX XXXX";
                    CountryCode = "+33";
                    break;
                case "Germany":
                    PhoneNumberPlaceHolder = "e.g. X XXXX XXXX";
                    Mask = "+49X XXXX XXXX";
                    CountryCode = "+49";
                    break;
                case "Greece":
                    PhoneNumberPlaceHolder = "e.g. X XXXX XXXX";
                    Mask = "+30X XXXX XXXX";
                    CountryCode = "+30";
                    break;
                case "Ireland":
                    PhoneNumberPlaceHolder = "e.g. X XXXX XXXX";
                    Mask = "+353X XXXX XXXX";
                    CountryCode = "+353";
                    break;
                case "Italy":
                    PhoneNumberPlaceHolder = "e.g. X XXXX XXXX";
                    Mask = "+39X XXXX XXXX";
                    CountryCode = "+39";
                    break;
                case "Kosovo":
                    PhoneNumberPlaceHolder = "e.g. X XXXX XXXX";
                    Mask = "+383X XXXX XXXX";
                    CountryCode = "+383";
                    break;
                case "Latvia":
                    PhoneNumberPlaceHolder = "e.g. X XXXX XXXX";
                    Mask = "+371X XXXX XXXX";
                    CountryCode = "+371";
                    break;
                case "Lithuania":
                    PhoneNumberPlaceHolder = "e.g. X XXXX XXXX";
                    Mask = "+370X XXXX XXXX";
                    CountryCode = "+370";
                    break;
                case "Luxembourg":
                    PhoneNumberPlaceHolder = "e.g. X XXXX XXXX";
                    Mask = "+352X XXXX XXXX";
                    CountryCode = "+352";
                    break;
                case "Malta":
                    PhoneNumberPlaceHolder = "e.g. X XXXX XXXX";
                    Mask = "+356X XXXX XXXX";
                    CountryCode = "+356";
                    break;
                case "Monaco":
                    PhoneNumberPlaceHolder = "e.g. X XXXX XXXX";
                    Mask = "+377X XXXX XXXX";
                    CountryCode = "+377";
                    break;
                case "Montenegro":
                    PhoneNumberPlaceHolder = "e.g. X XXXX XXXX";
                    Mask = "+382X XXXX XXXX";
                    CountryCode = "+382";
                    break;
                case "Netherlands":
                    PhoneNumberPlaceHolder = "e.g. X XXXX XXXX";
                    Mask = "+31X XXXX XXXX";
                    CountryCode = "+31";
                    break;
                case "Portugal":
                    PhoneNumberPlaceHolder = "e.g. X XXXX XXXX";
                    Mask = "+351X XXXX XXXX";
                    CountryCode = "+351";
                    break;
                case "Saint Barthelemy":
                    PhoneNumberPlaceHolder = "e.g. X XXXX XXXX";
                    Mask = "+590X XXXX XXXX";
                    CountryCode = "+590";
                    break;
                case "Saint Pierre and Miquelon":
                    PhoneNumberPlaceHolder = "e.g. X XXXX XXXX";
                    Mask = "+508X XXXX XXXX";
                    CountryCode = "+508";
                    break;
                case "San Marino":
                    PhoneNumberPlaceHolder = "e.g. X XXXX XXXX";
                    Mask = "+378X XXXX XXXX";
                    CountryCode = "+378";
                    break;
                case "Slovakia":
                    PhoneNumberPlaceHolder = "e.g. X XXXX XXXX";
                    Mask = "+421X XXXX XXXX";
                    CountryCode = "+421";
                    break;
                case "Slovenia":
                    PhoneNumberPlaceHolder = "e.g. X XXXX XXXX";
                    Mask = "+386X XXXX XXXX";
                    CountryCode = "+386";
                    break;
                case "Spain":
                    PhoneNumberPlaceHolder = "e.g. X XXXX XXXX";
                    Mask = "+34X XXXX XXXX";
                    CountryCode = "+34";
                    break;
                case "Vatican City":
                    PhoneNumberPlaceHolder = "e.g. X XXXX XXXX";
                    Mask = "+379X XXXX XXXX";
                    CountryCode = "+379";
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// The PropertyChanged event occurs when changing the value of property.
        /// </summary>
        /// <param name="propertyName">The PropertyName</param>
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
