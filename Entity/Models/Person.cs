namespace Entity.Models
{
    public class Person : BaseModel
    {
        /// <summary>
        /// Person's document type
        /// </summary>
        public int DocumentType { get; set; }

        /// <summary>
        /// Unique code identifier for the person
        /// </summary>
        public string IdentificationNumber { get; set; } = string.Empty;

        /// <summary>
        /// Person's first name
        /// </summary>
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Person's middle name
        /// </summary>
        public string? MiddleName { get; set; } = string.Empty;

        /// <summary>
        /// Person's first last name
        /// </summary>
        public string FirstLastName { get; set; } = string.Empty;

        /// <summary>
        /// Person's secon last name
        /// </summary>
        public string? SecondLastName { get; set; } = string.Empty;

        /// <summary>
        /// Person's Gender
        /// </summary>
     //   public int Gender { get; set; }

        /// <summary>
        /// Person's Email
        /// </summary>
        public string Email { get; set; } = string.Empty;

        public string CodeDane { get; set; } = string.Empty;  //DANE code, used in Colombia for educational institutions    

        public string EmailInstitutional { get; set; } = string.Empty; //Institutional email, used in Colombia for educational institutions

        /// <summary>
        /// Person's Phone
        /// </summary>
        public uint Phone { get; set; } //I thing this should be string

        /// <summary>
        /// Collection of roles assigned to this person
        /// </summary>
        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}