namespace Entity.Requests
{
    public class PersonRequest : BaseRequest
    {
        
        public string DocumentType { get; set; } = string.Empty;

       
        public string IdentificationNumber { get; set; } = string.Empty;

       
        public string FirstName { get; set; } = string.Empty;

       
        public string? MiddleName { get; set; } = string.Empty;

       
        public string FirstLastName { get; set; } = string.Empty;

        public string? SecondLastName { get; set; } = string.Empty;

        public string? FullName { get; set; } = string.Empty;

       public string CodeDane { get; set; } = string.Empty;

        public string EmailInstitutional { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

    
        public uint Phone { get; set; }

    }
}