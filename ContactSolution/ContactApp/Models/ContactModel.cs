﻿using AutoMapper;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ContactApp.Models
{
    public class ContactModel : IDataErrorInfo, INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneType { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedDate { get; set; }
        private string nameError { get; set; }

        // INotifyPropertyChanged interface
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // IDataErrorInfo interface
        public string Error => "Never Used";
        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "Name":
                        {
                            NameError = "";

                            if (Name == null || string.IsNullOrEmpty(Name))
                            {
                                NameError = "Name cannot be empty.";
                            }
                            else if (Name.Length > 12)
                            {
                                NameError = "Name cannot be longer than 12 characters.";
                            }

                            return NameError;
                        }
                }

                return null;
            }
        }
        public string NameError
        {
            get
            {
                return nameError;
            }
            set
            {
                if (nameError != value)
                {
                    nameError = value;
                    OnPropertyChanged("NameError");
                }
            }
        }
        private static MapperConfiguration config = new MapperConfiguration(cfg => cfg.CreateMap<ContactApp.Models.ContactModel, ContactRepository.ContactModel>().ReverseMap());
        private static IMapper mapper = config.CreateMapper();

        public ContactRepository.ContactModel ToRepositoryModel()
        {
            return mapper.Map<ContactRepository.ContactModel>(this);
        }

        public static ContactModel ToModel(ContactRepository.ContactModel respositoryModel)
        {
            return mapper.Map<ContactApp.Models.ContactModel>(respositoryModel);
        }
    }
}