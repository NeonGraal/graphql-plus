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
       Object(name) with {
         Alternates = new[] { Reference(other) },
       });

  public void WithTypeParameters(string name, string other, string parameter)
    => TrueExpected(
      name + "<$" + parameter + " >=" + other,
       Object(name) with {
         Alternates = new[] { Reference(other) },
         Parameters = parameter.TypeParameters(),
       });

  public void WithAliases(string name, string other, string alias1, string alias2)
    => TrueExpected(
      name + "[" + alias1 + " " + alias2 + " ]=" + other,
       Object(name) with {
         Alternates = new[] { Reference(other) },
         Aliases = new[] { alias1, alias2 },
       });

  public void WithField(string name, string field, string fieldType)
    => TrueExpected(
      name + "={" + field + ":" + fieldType + "}",
       Object(name) with {
         Fields = new[] { Field(field, fieldType) },
       });

  public void WithFieldAlias(string name, string field, string alias, string fieldType)
    => TrueExpected(
      name + "={" + field + "[" + alias + "]:" + fieldType + "}",
       Object(name) with {
         Fields = new[] { Field(field, fieldType) with {
           Aliases = new[] { alias }
         } },
       });

  public void WithFieldGeneric(string name, string field, string fieldType, string subType)
    => TrueExpected(
      name + "={" + field + ":" + fieldType + "<" + subType + ">}",
       Object(name) with {
         Fields = new[] { Field(field, Reference(fieldType, subType)) },
       });

  public void WithFieldModified(string name, string field, string fieldType)
    => TrueExpected(
      name + "={" + field + ":" + fieldType + "[]?}",
       Object(name) with {
         Fields = new[] { Field(field, fieldType) with {
           Modifiers = TestMods()
         } },
       });

  public void WithExtendsField(string name, string extends, string field, string fieldType)
    => TrueExpected(
      name + "=" + extends + "{" + field + ":" + fieldType + "}",
       Object(name) with {
         Fields = new[] { Field(field, fieldType) },
         Extends = Reference(extends),
       });

  public void WithExtendsGenericField(string name, string extends, string subType, string field, string fieldType)
    => TrueExpected(
      name + "=" + extends + "<" + subType + ">{" + field + ":" + fieldType + "}",
       Object(name) with {
         Fields = new[] { Field(field, fieldType) },
         Extends = Reference(extends, subType),
       });

  public O Object(string name)
    => _factories.Object(AstNulls.At, name, "");

  public F Field(string field, string fieldType)
    => _factories.Field(AstNulls.At, field, "", Reference(fieldType));

  public F Field(string field, R fieldType)
    => _factories.Field(AstNulls.At, field, "", fieldType);

  public R Reference(string type)
    => _factories.Reference(AstNulls.At, type);

  public R Reference(string type, string subType)
    => Reference(type) with { Arguments = new[] { Reference(subType) } };
}
