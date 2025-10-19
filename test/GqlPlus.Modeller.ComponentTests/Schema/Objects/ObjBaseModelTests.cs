using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Modelling;

namespace GqlPlus.Schema.Objects;

public class ObjBaseModelTests(
  IObjBaseModelChecks objBaseChecks
) : TestModelBase<string, ObjBaseModel>(objBaseChecks)
{
  [Theory, RepeatData]
  public void Model_Args(string name, string[] arguments)
    => objBaseChecks.ObjBase_Expected(
      objBaseChecks.ObjBaseAst(name, false, [.. arguments.Select(a => objBaseChecks.TypeArgAst(a, false))]),
      objBaseChecks.ExpectedObjBase(name, false, objBaseChecks.ExpectedArgs(arguments))
      );

  [Theory, RepeatData]
  public void Model_TypeParam(string name)
    => objBaseChecks.ObjBase_Expected(
      objBaseChecks.ObjBaseAst(name, true, []),
      objBaseChecks.ExpectedObjBase(name, true, [])
      );
}

internal sealed class ObjBaseModelChecks(
  IModeller<IGqlpObjBase, ObjBaseModel> objBase,
  IEncoder<ObjBaseModel> encoding
) : CheckModelBase<string, IGqlpObjBase, ObjBaseModel>(objBase, encoding),
    IObjBaseModelChecks
{
  protected override ObjBaseAst NewBaseAst(string input)
    => NewObjBaseAst(input, false, []);
  protected override string[] ExpectedBase(string input)
    => ExpectedObjBase(input, false, []);

  private string[] ExpectedObjBase(string input, bool isTypeParam, string[] args)
    => ["!_ObjBase", (isTypeParam ? "typeParam" : "name") + ": " + input, .. args];
  private string[] ExpectedDual(string input)
    => ["!_ObjBase", "name: " + input];

  private ObjBaseAst NewObjBaseAst(string input, bool isTypeParam, IGqlpTypeArg[] args)
    => new(AstNulls.At, input, "") {
      IsTypeParam = isTypeParam,
      Args = args,
    };

  private TypeArgAst NewTypeArgAst(string input, bool isTypeParam)
    => new(AstNulls.At, input, "") {
      IsTypeParam = isTypeParam,
    };

  void IObjBaseModelChecks.ObjBase_Expected(IGqlpObjBase ast, string[] expected)
    => Model_Expected(AstToModel(ast), expected);
  IGqlpObjBase IObjBaseModelChecks.ObjBaseAst(string input, bool isTypeParam, IGqlpTypeArg[] args)
    => NewObjBaseAst(input, isTypeParam, args);
  string[] IObjBaseModelChecks.ExpectedObjBase(string input, bool isTypeParam, string[] args)
    => ExpectedObjBase(input, isTypeParam, args);
  string[] IObjBaseModelChecks.ExpectedDual(string input)
    => ExpectedDual(input);
  string[] IObjBaseModelChecks.ExpectedArgs(string[] args)
    => [.. ItemsExpected("typeArgs:", args, a => [$"  - !_TypeArg", $"    name: {a}"])];
  IGqlpTypeArg IObjBaseModelChecks.TypeArgAst(string input, bool isTypeParam) => NewTypeArgAst(input, isTypeParam);
}

public interface IObjBaseModelChecks
  : ICheckModelBase<string, ObjBaseModel>
{
  string[] ExpectedObjBase(string input, bool isTypeParam, string[] args);
  string[] ExpectedDual(string input);
  string[] ExpectedArgs(string[] args);
  void ObjBase_Expected(IGqlpObjBase ast, string[] expected);
  IGqlpObjBase ObjBaseAst(string input, bool isTypeParam, IGqlpTypeArg[] args);
  IGqlpTypeArg TypeArgAst(string input, bool isTypeParam);
}
