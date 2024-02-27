namespace Packt.Shared;

public class UserService
{
  private readonly IEmailSender _emailSender;

  public UserService(IEmailSender emailSender)
  {
    _emailSender = emailSender;
  }

  public bool CreateUser(string email, string password)
  {
    // Create user.
    bool successfulUserCreation = true;

    // Send email to user.
    bool successfulEmailSend = _emailSender.SendEmail(
      to: email,
      subject: "Welcome!",
      body: "Your account is created.");

    return successfulEmailSend && successfulUserCreation;
  }
}
