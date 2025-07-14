using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Globals;
using GqlPlus.Modelling;

namespace GqlPlus.Schema.Globals;

public class OperationModelTests(
  IOperationModelChecks checks
) : TestAliasedModel<OperationInput, OperationModel>(checks)
{

  [Theory, RepeatData(Repeats)]
  public void Model_All(
    OperationInput input,
    string contents,
    string[] aliases
  ) => checks.OperationExpected(
      new OperationDeclAst(AstNulls.At, input.Name, contents, input.Category) {
        Aliases = aliases,
      },
      new(input, aliases, contents));
}

internal sealed class OperationModelChecks(
  IModeller<IGqlpSchemaOperation, OperationModel> modeller,
  IEncoder<OperationModel> encoding
) : CheckAliasedModel<OperationInput, IGqlpSchemaOperation, OperationDeclAst, OperationModel>(modeller, encoding)
  , IOperationModelChecks
{
  protected override string[] ExpectedDescriptionAliases(ExpectedDescriptionAliasesInput<OperationInput> input)
    => ExpectedOperation(new(input));

  protected override OperationDeclAst NewAliasedAst(OperationInput input, string? description = null, string[]? aliases = null)
    => new(AstNulls.At, input.Name, description ?? "", input.Category) { Aliases = aliases ?? [], };

  internal string[] ExpectedOperation(ExpectedOperationInput input)
    => ["!_Operation",
      .. input.ExpectedAliases,
      "category: " + input.Name.Category,
      .. input.ExpectedDescription,
      "name: " + input.Name.Name,
      "operation: TBC"];

  public string[] ExpectedParams(string[] parameters)
    => [.. ItemsExpected(
       "parameters:",
        parameters,
        p => ["- !_InputParam", "  input: " + p])];

  public void OperationExpected(IGqlpSchemaOperation ast, ExpectedOperationInput input)
    => AstExpected((OperationDeclAst)ast, ExpectedOperation(input));
}

public sealed class ExpectedOperationInput(
  OperationInput input,
  IEnumerable<string>? aliases = null,
  string? description = null
) : ExpectedDescriptionAliasesInput<OperationInput>(input, aliases, description)
{
  internal ExpectedOperationInput(ExpectedDescriptionAliasesInput<OperationInput> input)
    : this(input.Name)
  {
    Aliases = input.Aliases;
    ExpectedAliases = input.ExpectedAliases;
    Description = input.Description;
    ExpectedDescription = input.ExpectedDescription;
  }
}

public interface IOperationModelChecks
  : ICheckAliasedModel<OperationInput, OperationModel>
{
  void OperationExpected(IGqlpSchemaOperation ast, ExpectedOperationInput input);
  string[] ExpectedParams(string[] parameters);
}
