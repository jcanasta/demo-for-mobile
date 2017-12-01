using OrderingApp.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingApp.Models.Core.Common
{
    public class Person : ModelBase
    {
        private string _fullName;
        public string FullName
        {
            get { return _fullName; }
            set
            {
                _fullName = value;
                OnPropertyChanged();
            }
        }

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }

        private string _middleName;
        public string MiddleName
        {
            get { return _middleName; }
            set
            {
                _middleName = value;
                OnPropertyChanged();
            }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }

        private DateTime? _birthDate;
        public DateTime? BirthDate
        {
            get { return _birthDate; }
            set
            {
                _birthDate = value;
                OnPropertyChanged();
            }
        }

        private string _occupation;
        public string Occupation
        {
            get { return _occupation; }
            set
            {
                _occupation = value;
                OnPropertyChanged();
            }
        }

        private string _gender;
        public string Gender
        {
            get { return _gender; }
            set
            {
                _gender = value;
                OnPropertyChanged();
            }
        }

        private string _contactNumber;
        public string ContactNumber
        {
            get { return _contactNumber; }
            set
            {
                _contactNumber = value;
                OnPropertyChanged();
            }
        }

        private string _emailAddress;
        public string EmailAddress
        {
            get { return _emailAddress; }
            set
            {
                _emailAddress = value;
                OnPropertyChanged();
            }
        }


        private string _address;
        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                OnPropertyChanged();
            }
        }

        private string _zipCode;
        public string ZipCode
        {
            get { return _zipCode; }
            set
            {
                _zipCode = value;
                OnPropertyChanged();
            }
        }

        private string _birthPlace;
        public string BirthPlace
        {
            get { return _birthPlace; }
            set
            {
                _birthPlace = value;
                OnPropertyChanged();
            }
        }

        private string _civilStatus;
        public string CivilStatus
        {
            get { return _civilStatus; }
            set
            {
                _civilStatus = value;
                OnPropertyChanged();
            }
        }

        private string _nationality;
        public string Nationality
        {
            get { return _nationality; }
            set
            {
                _nationality = value;
                OnPropertyChanged();
            }
        }

        private string _religion;
        public string Religion
        {
            get { return _religion; }
            set
            {
                _religion = value;
                OnPropertyChanged();
            }
        }

        private string _fatherName;
        public string FatherName
        {
            get { return _fatherName; }
            set
            {
                _fatherName = value;
                OnPropertyChanged();
            }
        }

        private string _motherName;
        public string MotherName
        {
            get { return _motherName; }
            set
            {
                _motherName = value;
                OnPropertyChanged();
            }
        }

        private string _spouseName;
        public string SpouseName
        {
            get { return _spouseName; }
            set
            {
                _spouseName = value;
                OnPropertyChanged();
            }
        }

        public string _mobileNo;
        public string MobileNo
        {
            get { return _mobileNo; }
            set
            {
                _mobileNo = value;
                OnPropertyChanged();
            }
        }

        public string _homePhoneNo;
        public string HomePhoneNo
        {
            get { return _homePhoneNo; }
            set
            {
                _homePhoneNo = value;
                OnPropertyChanged();
            }
        }

        public string _faxNo;
        public string FaxNo
        {
            get { return _faxNo; }
            set
            {
                _faxNo = value;
                OnPropertyChanged();
            }
        }

        public string _contactPerson;
        public string ContactPerson
        {
            get { return _contactPerson; }
            set
            {
                _contactPerson = value;
                OnPropertyChanged();
            }
        }

        public int? Age
        {
            get
            {
                if (BirthDate != null && BirthDate.HasValue)
                {
                    int age = DateTime.Now.Year - BirthDate.Value.Year;
                    if (DateTime.Now < BirthDate.Value.AddYears(age)) age--;
                    return age;
                }
                return null;
            }
        }

    }
}
