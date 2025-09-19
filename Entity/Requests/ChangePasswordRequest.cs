using System.ComponentModel.DataAnnotations;

namespace Entity.Requests
{
    /// <summary>
    /// Request for changing a user's password
    /// </summary>
    public class ChangePasswordRequest
    {
        /// <summary>
        /// The unique identifier for the user
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// User's current password for verification        
        /// </summary>
        //   public string CurrentPassword { get; set; } = string.Empty;

        /// <summary>
        /// User's new password
        /// </summary>

        [Required(ErrorMessage = "La nueva contrase�a es obligatoria")]
        [MinLength(8, ErrorMessage = "La contrase�a debe tener al menos 8 caracteres")]
        public string NewPassword { get; set; } = string.Empty;

        /// <summary>
        /// Confirmation of the new password
        /// </summary>
        /// 
        [Required(ErrorMessage = "Debe confirmar la contrase�a")]
        [Compare("NewPassword", ErrorMessage = "Las contrase�as no coinciden")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
