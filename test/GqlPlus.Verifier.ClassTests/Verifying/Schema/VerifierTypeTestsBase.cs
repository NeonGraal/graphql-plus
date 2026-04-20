using System.Diagnostics.CodeAnalysis;
using GqlPlus.Ast.Schema;

namespace GqlPlus.Verifying.Schema;

public abstract class VerifierTypeTestsBase
  : VerifierTestsBase
{
  protected IMap<string> EnumValues { get; } = new Map<string>();
  protected IMap<IAstDescribed> Types { get; } = new Map<IAstDescribed>();

  protected void AddTypes([NotNull] params IAstNamed[] types)
  {
    foreach (IAstNamed type in types) {
      Types[type.Name] = type;
    }
  }
}
