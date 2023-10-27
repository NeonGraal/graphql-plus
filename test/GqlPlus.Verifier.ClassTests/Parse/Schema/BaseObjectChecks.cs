using System.Runtime.CompilerServices;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

internal sealed class BaseObjectChecks<O, F, R>
  : OneChecks<SchemaParser, O>, IBaseObjectChecks
  where O : AstObject<F, R> where F : AstField<R> where R : AstReference<R>
{
  private readonly IObjectFactories<O, F, R> _factories;

  internal BaseObjectChecks(IObjectFactories<O, F, R> factories,
    One one, [CallerArgumentExpression(nameof(one))] string oneExpression = "")
    : base(tokens => new SchemaParser(tokens), one, oneExpression)
    => _factories = factories;

  public void WithMinimum(string name, string other)
    => TrueExpected(
      name + "=" + other,
       _factories.Object(AstNulls.At, name, "") with {
         Alternates = new[] { _factories.Reference(AstNulls.At, other) },
       });

  public void WithTypeParameters(string name, string other, string parameter)
    => TrueExpected(
      name + "<$" + parameter + " >=" + other,
       _factories.Object(AstNulls.At, name, "") with {
         Alternates = new[] { _factories.Reference(AstNulls.At, other) },
         Parameters = parameter.TypeParameters(),
       });

  public void WithAliases(string name, string other, string alias1, string alias2)
    => TrueExpected(
      name + "[" + alias1 + " " + alias2 + " ]=" + other,
       _factories.Object(AstNulls.At, name, "") with {
         Alternates = new[] { _factories.Reference(AstNulls.At, other) },
         Aliases = new[] { alias1, alias2 },
       });

  public void WithField(string name, string field, string fieldType)
    => TrueExpected(
      name + "={" + field + ":" + fieldType + "}",
       _factories.Object(AstNulls.At, name, "") with {
         Fields = new[] { Field(field, fieldType) },
       });

  public void WithFieldAlias(string name, string field, string alias, string fieldType)
    => TrueExpected(
      name + "={" + field + "[" + alias + "]:" + fieldType + "}",
       _factories.Object(AstNulls.At, name, "") with {
         Fields = new[] { Field(field, fieldType) with {
           Aliases = new[] { alias }
         } },
       });

  public void WithFieldGeneric(string name, string field, string fieldType, string subType)
    => TrueExpected(
      name + "={" + field + ":" + fieldType + "<" + subType + ">}",
       _factories.Object(AstNulls.At, name, "") with {
         Fields = new[] { Field(field, fieldType, subType) },
       });

  public void WithFieldModified(string name, string field, string fieldType)
    => TrueExpected(
      name + "={" + field + ":" + fieldType + "[]?}",
       _factories.Object(AstNulls.At, name, "") with {
         Fields = new[] { Field(field, fieldType) with {
           Modifiers = TestMods()
         } },
       });

  public void WithExtendsField(string name, string extends, string field, string fieldType)
    => TrueExpected(
      name + "=" + extends + "{" + field + ":" + fieldType + "}",
       _factories.Object(AstNulls.At, name, "") with {
         Fields = new[] { Field(field, fieldType) },
         Extends = _factories.Reference(AstNulls.At, extends),
       });

  public F Field(string field, string fieldType)
    => _factories.Field(AstNulls.At, field, "", _factories.Reference(AstNulls.At, fieldType));

  public F Field(string field, string fieldType, string subType)
    => _factories.Field(AstNulls.At, field, "", _factories.Reference(AstNulls.At, fieldType) with {
      Arguments = new[] { _factories.Reference(AstNulls.At, subType) },
    });
}
