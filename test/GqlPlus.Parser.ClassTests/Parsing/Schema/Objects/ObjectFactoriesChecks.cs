using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parsing.Schema.Objects;

internal sealed class ObjectFactoriesChecks<TObjField, TObjFieldAst>(
  IObjectFactories<TObjField, TObjFieldAst> sut
) : SubstituteBase
  , IObjectFactoriesChecks
  where TObjField : class, IGqlpObjField
  where TObjFieldAst : AstObjField, TObjField
{
  private readonly IObjectFactories<TObjField, TObjFieldAst> _sut = sut;

  public void ObjectField_Can_Be_Created(string name, string type, string description)
  {
    IGqlpObjBase objType = A.ObjBase(type).AsObjBase;
    TObjFieldAst result = _sut.ObjField(AstNulls.At, name, objType, description);

    result.ShouldSatisfyAllConditions(
      r => r.ShouldBeOfType<TObjFieldAst>(),
      r => r.Name.ShouldBe(name),
      r => r.Type.Name.ShouldBe(type),
      r => r.Description.ShouldBe(description)
      );

  }

  public void Object_Can_Be_Created(string name, string description)
  {
    AstObject<TObjField> result = _sut.Object(AstNulls.At, name, description);

    result.ShouldSatisfyAllConditions(
      r => r.ShouldBeOfType<AstObject<TObjField>>(),
      r => r.Name.ShouldBe(name),
      r => r.Description.ShouldBe(description)
      );
  }
}

public interface IObjectFactoriesChecks
{
  void ObjectField_Can_Be_Created(string name, string type, string description);
  void Object_Can_Be_Created(string name, string description);
}
