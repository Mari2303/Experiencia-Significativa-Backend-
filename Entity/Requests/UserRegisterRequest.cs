using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Entity.Requests
{
    public class UserRegisterRequest 
    {
        // datos de persona 

        /// <summary>
        /// Person's document type
        /// </summary>
        public string DocumentType { get; set; } = string.Empty;

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
        /// Person's secon last name
        /// </summary>
        public string? FullName { get; set; } = string.Empty;

        public string CodeDane { get; set; } = string.Empty;

        public string EmailInstitutional { get; set; } = string.Empty;

        /// <summary>
        /// Person's Email
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Person's Phone
        /// </summary>
        public uint Phone { get; set; }



        // datos de usuario 

        /// <summary>
        /// Unique code identifier for the user 
        /// </summary>
        public string Code { get; set; } = string.Empty;
        /// <summary>
        /// The unique username for authentication
        /// </summary>
        public string Username { get; set; } = string.Empty;
        /// <summary>
        /// Hashed password for user authentication
        /// </summary>
        public string Password { get; set; } = string.Empty;
        /// <summary>
        /// /// Foreign key referencing the associated person
        /// </summary>
      




    }
}
