using AutoMapper;
using System;
using System.Runtime.CompilerServices;

namespace ContactApp.Models
{
    public class ContactModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneType { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedDate { get; set; }

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