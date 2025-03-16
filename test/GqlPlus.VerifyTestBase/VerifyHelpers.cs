namespace GqlPlus;

public static class VerifyHelpers
{
  public static VerifySettings CheckAutoVerify(this VerifySettings settings)
  {
    ArgumentNullException.ThrowIfNull(settings);

    if (!string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("GQLPLUS_AUTOVERIFY"))) {
      settings.AutoVerify();
    }

    return settings;
  }
}
