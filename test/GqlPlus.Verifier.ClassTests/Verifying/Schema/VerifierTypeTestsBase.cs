using System.Diagnostics.CodeAnalysis;

namespace GqlPlus.Verifying.Schema;

public abstract class VerifierTypeTestsBase
  : VerifierTestsBase
{
  protected IMap<string> EnumValues { get; } = new Map<string>();
  protected IMap<IGqlpDescribed> Types { get; } = new Map<IGqlpDescribed>();

  protected TResult AddType<TResult>(string name)
    where TResult : class, IGqlpNamed
  {
    TResult result = NFor<TResult>(name);
    Types[name] = result;
    return result;
  }

  protected IGqlpEnum Enum(string name, [NotNull] params string[] labels)
  {
    IGqlpEnum result = AddType<IGqlpEnum>(name);
    IGqlpEnumLabel[] items = NForA<IGqlpEnumLabel>(labels);
    result.Items.Returns(items);
    foreach (string label in labels) {
      result.HasValue(label).Returns(true);
      EnumValues[label] = name;
    }

    return result;
  }
}
