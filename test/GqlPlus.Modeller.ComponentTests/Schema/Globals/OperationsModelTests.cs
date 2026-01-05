using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Globals;
using GqlPlus.Modelling;

namespace GqlPlus.Schema.Globals;

public class OperationsModelTests(
  IOperationsModelChecks checks
) : TestModelBase<OperationInput, OperationsModel>(checks)
{
  [Theory, RepeatData(Repeats)]
  public void Model_Type(string input)
    => checks
    .Model_Expected(
      checks.ToModel(null, input),
      ["!_TypeInput",
        "name: " + input,
        "typeKind: !_TypeKind Input"]);

  [Theory, RepeatData(Repeats)]
  public void Model_Both(
    string type,
    OperationInput input
  ) => checks
    .Model_Expected(
      checks.ToModel(new OperationDeclAst(AstNulls.At, input.Name, input.Category), type),
      ["!_Operations",
        "operation: !_Operation",
        "  category: " + input.Category,
        "  name: " + input.Name,
        "  operation: TBC",
        "type: !_TypeInput",
        "  name: " + type,
        "  typeKind: !_TypeKind Input"]);
}

internal sealed class OperationsModelChecks(
  IModeller<IGqlpSchemaOperation, OperationModel> modeller,
  IEncoder<OperationsModel> encoding
) : CheckModelBase<OperationInput, IGqlpSchemaOperation, OperationDeclAst, OperationModel, OperationsModel>(modeller, encoding)
  , IOperationsModelChecks
{
  protected override string[] ExpectedBase(OperationInput input)
  => ["!_Operation",
    "category: " + input.Category,
    "name: " + input.Name,
    "operation: TBC",];

  protected override OperationDeclAst NewBaseAst(OperationInput input)
    => new(AstNulls.At, input.Name, input.Category);

  IModelBase ICheckModelBase.ToModel(IGqlpError ast)
    => new OperationsModel() { And = _modeller.ToModel((OperationDeclAst)ast, TypeKinds) };

  public OperationsModel ToModel(IGqlpSchemaOperation? ast, string input)
    => new() {
      And = _modeller.TryModel((OperationDeclAst?)ast, TypeKinds),
      Type = new TypeInputModel(input, ""),
    };
}

public interface IOperationsModelChecks
  : ICheckModelBase<OperationInput, OperationsModel>
{
  OperationsModel ToModel(IGqlpSchemaOperation? ast, string input);
}
