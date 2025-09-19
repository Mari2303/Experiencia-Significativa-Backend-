using System.ComponentModel.DataAnnotations;

public class InstitutionCreateDTO
{
    [Required(ErrorMessage = "El nombre de la institución es obligatorio")]
   
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "La dirección es obligatoria")]
    [StringLength(50, ErrorMessage = "La dirección no debe superar los 50 caracteres")]
    public string Address { get; set; } = string.Empty;

    [Required(ErrorMessage = "El teléfono es obligatorio")]
   
    public uint Phone { get; set; }

    [Required(ErrorMessage = "El código DANE es obligatorio")]
    
    public string CodeDane { get; set; } = string.Empty;

    [Required(ErrorMessage = "El correo institucional es obligatorio")]
    [EmailAddress(ErrorMessage = "El correo institucional no tiene un formato válido")]
    public string EmailInstitucional { get; set; } = string.Empty;

    [Required(ErrorMessage = "El departamento es obligatorio")]
    [StringLength(100, ErrorMessage = "El departamento no debe superar los 100 caracteres")]
    public string Departament { get; set; } = string.Empty;

    [Required(ErrorMessage = "El municipio es obligatorio")]
    [StringLength(100, ErrorMessage = "El municipio no debe superar los 100 caracteres")]
    public string Municipality { get; set; } = string.Empty;

    [StringLength(100, ErrorMessage = "La comuna no debe superar los 100 caracteres")]
    public string Commune { get; set; } = string.Empty;

    [Required(ErrorMessage = "El nombre del rector es obligatorio")]
    [StringLength(150, ErrorMessage = "El nombre del rector no debe superar los 150 caracteres")]
    public string NameRector { get; set; } = string.Empty;

    [StringLength(100, ErrorMessage = "La zona educativa no debe superar los 50 caracteres")]
    public string EZone { get; set; } = string.Empty;

    [StringLength(100, ErrorMessage = "Las características no deben superar los 100 caracteres")]
    public string Caracteristic { get; set; } = string.Empty;

    [StringLength(100, ErrorMessage = "La entidad territorial no debe superar los 100 caracteres")]
    public string TerritorialEntity { get; set; } = string.Empty;

    [StringLength(100, ErrorMessage = "Las pruebas de conocimiento no deben superar los 100 caracteres")]
    public string TestsKnow { get; set; } = string.Empty;
}
