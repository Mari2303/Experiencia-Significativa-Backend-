using System.ComponentModel.DataAnnotations;

namespace Entity.Requests
{
    public class PersonUserRegisterRequest
    {
        [Required]
        public PersonRegisterRequest Person { get; set; }
        [Required]
        public UserRegisterRequest User { get; set; }
    }

    public class PersonRegisterRequest
    {
        [Required]
        public string DocumentType { get; set; }
        [Required]
        public string IdentificationNumber { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string FirstLastName { get; set; }
        public string SecondLastName { get; set; }
        public string FullName { get; set; }
        public string CodeDane { get; set; }
        public string EmailInstitutional { get; set; }
        [Required]
        public string Email { get; set; }
        public long Phone { get; set; }
    }

}