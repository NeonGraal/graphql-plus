using System.Diagnostics.CodeAnalysis;
using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema;

public abstract class VerifierTypeBase
  : VerifierBase
{
  protected IMap<string> EnumValues { get; } = new Map<string>();
  protected IMap<IGqlpDescribed> Types { get; } = new Map<IGqlpDescribed>();

  protected IGqlpEnum Enum(string name, [NotNull] params string[] labels)
  {
    IGqlpEnum result = NFor<IGqlpEnum>(name);
    IGqlpEnumLabel[] items = NForA<IGqlpEnumLabel>(labels);
    result.Items.Returns(items);
    foreach (string label in labels) {
      result.HasValue(label).Returns(true);
      EnumValues[label] = name;
    }

    Types[name] = result;
    return result;
  }
}
