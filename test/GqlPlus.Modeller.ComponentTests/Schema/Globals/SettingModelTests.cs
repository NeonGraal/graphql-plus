using System.Diagnostics.CodeAnalysis;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Globals;
using GqlPlus.Modelling;

namespace GqlPlus.Schema.Globals;

public class SettingModelTests(
  ICheckDescribedModel<SettingInput, SettingModel> checks
) : TestDescribedModel<SettingInput, SettingModel>(checks)
{ }

internal sealed class SettingModelChecks(
  IModeller<IGqlpSchemaSetting, SettingModel> modeller,
  IRenderer<SettingModel> rendering
) : CheckDescribedModel<SettingInput, IGqlpSchemaSetting, OptionSettingAst, SettingModel>(modeller, rendering)
{
  protected override string[] ExpectedDescription(ExpectedDescriptionInput<SettingInput> input)
    => input.Name.Expected(input.ExpectedDescription ?? []);

  protected override OptionSettingAst NewDescribedAst(SettingInput input, string description)
    => input.ToAst(description);
}

public record struct SettingInput(string Name, string Value)
{
  public static IEqualityComparer<SettingInput> CompareNames { get; } = new CompareByName();

  private sealed class CompareByName
    : IEqualityComparer<SettingInput>
  {
    public bool Equals(SettingInput x, SettingInput y)
      => string.Equals(x.Name, y.Name, StringComparison.Ordinal);
    public int GetHashCode([DisallowNull] SettingInput obj)
      => obj.Name.GetHashCode(StringComparison.Ordinal);
  }
  internal readonly OptionSettingAst ToAst(string description)
    => new(AstNulls.At, Name, description, new ConstantAst(new FieldKeyAst(AstNulls.At, Value)));

  internal readonly string[] Expected(string[] description, string prefix = "", string indent = "")
    => [prefix + "!_Setting",
      .. description.Select(d => indent + d),
      indent + "name: " + Name,
      indent + "value: " + Value.Quoted("'")];
}
