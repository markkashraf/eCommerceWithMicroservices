namespace eCommerce.Core.DTO;

public record AuthenticationResponse(
  Guid UserID,
  string? Email,
  string? PersonName,
  string? Gender,
  string? Token,
  bool Success
  )
{
    public AuthenticationResponse() : this
    (Guid.NewGuid(), string.Empty, string.Empty, string.Empty, string.Empty, false) { }

};
