using System.Runtime.CompilerServices;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

internal sealed class BaseObjectChecks<O, F, R>
  : BaseAliasedChecks<ObjectInput, O>, IBaseObjectChecks
  where O : AstObject<F, R> where F : AstField<R> where R : AstReference<R>
{
  private readonly IObjectFactories<O, F, R> _factories;

  internal BaseObjectChecks(IObjectFactories<O, F, R> factories,
    One one, [CallerArgumentExpression(nameof(one))] string oneExpression = "")
    : base(one, oneExpression)
    => _factories = factories;

  public void WithAlternates(string name, string[] others)
    => TrueExpected(
      name + "=" + string.Join("|", others),
       Object(name) with {
         Alternates = others.Select(Reference).ToArray(),
       });

  public void WithFieldsAndAlternates(string name, FieldInput[] fields, string[] others)
    => TrueExpected(
      name + "={" + fields.Select(f => f.Name + ":" + f.Type).Joined() + "}|" + string.Join("|", others),
       Object(name) with {
         Fields = fields.Select(f => Field(f.Name, f.Type)).ToArray(),
         Alternates = others.Select(Reference).ToArray(),
       });

  public void WithFieldsBadAndAlternates(string name, FieldInput[] fields, string[] others)
    => False(name + "={" + fields.Select(f => f.Name + ":" + f.Type).Joined() + "|" + string.Join("|", others));

  public void WithFieldsAndAlternatesBad(string name, FieldInput[] fields, string[] others)
    => False(name + "={" + fields.Select(f => f.Name + ":" + f.Type).Joined() + "}||" + string.Join("|", others));

  public void WithAlternateComments(string name, AlternateComment[] others)
    => TrueExpected(
      name + "=" + string.Join("|", others.Select(o => $"'{o.Content}'{o.Alternate}")),
       Object(name) with {
         Alternates = others.Select(o => Reference(o.Alternate) with { Description = o.Content }).ToArray(),
       });

  public void WithTypeParameters(string name, string other, string parameter)
    => TrueExpected(
      name + "<$" + parameter + ">=" + other,
       Object(name) with {
         Alternates = new[] { Reference(other) },
         Parameters = parameter.TypeParameters(),
       });

  public void WithTypeParametersBad(string name, string other, string parameter)
    => False(name + "<$" + parameter + "=" + other);

  public void WithFields(string name, FieldInput[] fields)
    => TrueExpected(
      name + "={" + fields.Select(f => f.Name + ":" + f.Type).Joined() + "}",
       Object(name) with {
         Fields = fields.Select(f => Field(f.Name, f.Type)).ToArray(),
       });

  public void WithFieldsBad(string name, FieldInput[] fields)
    => False(name + "={" + fields.Select(f => f.Name + ":" + f.Type).Joined());

  public void WithExtendsField(string name, string extends, string field, string fieldType)
    => TrueExpected(
      name + "=" + extends + "{" + field + ":" + fieldType + "}",
       Object(name) with {
         Fields = new[] { Field(field, fieldType) },
         Extends = Reference(extends),
       });

  public void WithExtendsFieldBad(string name, string extends, string field, string fieldType)
    => False(name + "=" + extends + "{" + field + ":" + fieldType);

  public void WithExtendsGenericField(string name, string extends, string subType, string field, string fieldType)
    => TrueExpected(
      name + "=" + extends + "<" + subType + ">{" + field + ":" + fieldType + "}",
       Object(name) with {
         Fields = new[] { Field(field, fieldType) },
         Extends = Reference(extends, subType),
       });

  public void WithExtendsGenericFieldBad(string name, string extends, string subType, string field, string fieldType)
    => False(name + "=" + extends + "<" + subType + "{" + field + ":" + fieldType + "}");

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

  protected internal override string AliasesString(ObjectInput input, string aliases)
    => input.Name + aliases + "=" + input.Other;
  protected internal override O AliasedFactory(ObjectInput input)
    => Object(input.Name) with { Alternates = new[] { Reference(input.Other) } };
}

public record struct AlternateComment(string Content, string Alternate);
