using System.Diagnostics.CodeAnalysis;

namespace GqlPlus.Verifying.Schema;

public abstract class VerifierTypeTestsBase
  : VerifierTestsBase
{
  protected IMap<string> EnumValues { get; } = new Map<string>();
  protected IMap<IGqlpDescribed> Types { get; } = new Map<IGqlpDescribed>();

  protected void AddTypes([NotNull] params IGqlpNamed[] types)
  {
    foreach (IGqlpNamed type in types) {
      Types[type.Name] = type;
    }
  }
}
