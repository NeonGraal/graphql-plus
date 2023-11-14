using System.Runtime.CompilerServices;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

internal sealed class BaseObjectChecks<O, F, R>
  : BaseAliasedChecks<ObjectInput, O>, IBaseObjectChecks
  where O : AstObject<F, R> where F : AstField<R> where R : AstReference<R>
{
  private readonly IObjectFactories<O, F, R> _factories;

  internal BaseObjectChecks(IObjectFactories<O, F, R> factories,
    OneResult one, [CallerArgumentExpression(nameof(one))] string oneExpression = "")
    : base(one, oneExpression)
    => _factories = factories;

  public void WithNameBad(decimal id, string[] others)
      => False($"{id}{{" + others.Joined("|") + "}");

  public void WithAlternates(string name, string[] others)
    => TrueExpected(
      name + "{" + others.Joined("|") + "}",
       Object(name) with {
         Alternates = others.Select(Alternate).ToArray(),
       });

  public void WithFieldsAndAlternates(string name, FieldInput[] fields, string[] others)
    => TrueExpected(
      name + "{" + fields.Select(f => f.Name + ":" + f.Type).Joined() + others.Joined("|") + "}",
       Object(name) with {
         Fields = fields.Select(f => Field(f.Name, f.Type)).ToArray(),
         Alternates = others.Select(Alternate).ToArray(),
       });

  public void WithFieldsBadAndAlternates(string name, FieldInput[] fields, string[] others)
    => False(name + "{" + fields.Select(f => f.Name + " " + f.Type).Joined() + others.Joined("|") + "}");

  public void WithFieldsAndAlternatesBad(string name, FieldInput[] fields, string[] others)
    => False(name + "{" + fields.Select(f => f.Name + ":" + f.Type).Joined() + "||" + others.Joined("|") + "}");

  public void WithAlternateComments(string name, AlternateComment[] others)
    => TrueExpected(
      name + "{" + others.Select(o => $"|'{o.Content}'{o.Alternate}").Joined() + "}",
       Object(name) with {
         Alternates = others.Select(o => Alternate(o.Alternate, o.Content)).ToArray(),
       });

  public void WithAlternateModifiers(string name, string[] others)
    => TrueExpected(
      name + "{" + others.Joined(a => $"|{a}[]?") + "}",
       Object(name) with {
         Alternates = others.Select(a => Alternate(a) with { Modifiers = TestMods() }).ToArray(),
       });

  public void WithTypeParameters(string name, string other, string parameter)
    => TrueExpected(
      name + "<$" + parameter + ">{|" + other + "}",
       Object(name) with {
         Alternates = new[] { Alternate(other) },
         Parameters = parameter.TypeParameters(),
       });

  public void WithTypeParameterBad(string name, string other)
    => False(name + "<$>{|" + other);

  public void WithTypeParametersBad(string name, string other, string parameter)
    => False(name + "<$" + parameter + "{|" + other);

  public void WithTypeParametersNone(string name, string other)
    => False(name + "<>{|" + other);

  public void WithFields(string name, FieldInput[] fields)
    => TrueExpected(
      name + "{" + fields.Select(f => f.Name + ":" + f.Type).Joined() + "}",
       Object(name) with {
         Fields = fields.Select(f => Field(f.Name, f.Type)).ToArray(),
       });

  public void WithFieldsBad(string name, FieldInput[] fields)
    => False(name + "{" + fields.Select(f => f.Name + ":" + f.Type).Joined());

  public void WithExtendsField(string name, string extends, string field, string fieldType)
    => TrueExpected(
      name + "{:" + extends + " " + field + ":" + fieldType + "}",
       Object(name) with {
         Fields = new[] { Field(field, fieldType) },
         Extends = Reference(extends),
       });

  public void WithExtendsFieldBad(string name, string extends, string field, string fieldType)
    => False(name + "{:" + extends + " " + field + ":" + fieldType);

  public void WithExtendsGenericField(string name, string extends, string subType, string field, string fieldType)
    => TrueExpected(
      name + "{:" + extends + "<" + subType + ">" + field + ":" + fieldType + "}",
       Object(name) with {
         Fields = new[] { Field(field, fieldType) },
         Extends = Reference(extends, subType),
       });

  public void WithExtendsGenericFieldBad(string name, string extends, string subType, string field, string fieldType)
    => False(name + "{:" + extends + "<" + subType + " " + field + ":" + fieldType + "}");

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

  public AstAlternate<R> Alternate(string type)
    => new(Reference(type));

  public AstAlternate<R> Alternate(string type, string description)
    => new(Reference(type) with { Description = description });

  protected internal override string AliasesString(ObjectInput input, string aliases)
    => input.Name + aliases + "{|" + input.Other + "}";
  protected internal override O AliasedFactory(ObjectInput input)
    => Object(input.Name) with { Alternates = new[] { Alternate(input.Other, "") } };
}

public record struct AlternateComment(string Content, string Alternate);
