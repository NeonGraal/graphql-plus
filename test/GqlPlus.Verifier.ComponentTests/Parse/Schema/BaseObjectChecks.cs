using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

internal sealed class BaseObjectChecks<O, F, R>
  : BaseAliasedChecks<ObjectInput, O>, IBaseObjectChecks
  where O : AstObject<F, R> where F : AstField<R> where R : AstReference<R>
{
  private readonly IObjectFactories<O, F, R> _factories;

  internal BaseObjectChecks(IObjectFactories<O, F, R> factories, Parser<O>.D parser)
    : base(parser)
    => _factories = factories;

  public void WithNameBad(decimal id, string[] others)
      => False($"{id}{{" + others.Joined("|") + "}");

  public void WithAlternates(string name, string[] others)
    => TrueExpected(
      name + "{" + others.Joined("|") + "}",
       Object(name) with {
         Alternates = [.. others.Select(Alternate)],
       });

  public void WithFieldsAndAlternates(string name, FieldInput[] fields, string[] others)
    => TrueExpected(
      name + "{" + fields.Select(f => f.Name + ":" + f.Type).Joined() + others.Joined("|") + "}",
       Object(name) with {
         Fields = [.. fields.Select(f => Field(f.Name, f.Type))],
         Alternates = [.. others.Select(Alternate)],
       });

  public void WithFieldsBadAndAlternates(string name, FieldInput[] fields, string[] others)
    => False(name + "{" + fields.Select(f => f.Name + " " + f.Type).Joined() + others.Joined("|") + "}");

  public void WithFieldsAndAlternatesBad(string name, FieldInput[] fields, string[] others)
    => False(name + "{" + fields.Select(f => f.Name + ":" + f.Type).Joined() + "||" + others.Joined("|") + "}");

  public void WithAlternateComments(string name, AlternateComment[] others)
    => TrueExpected(
      name + "{" + others.Select(o => $"|'{o.Content}'{o.Alternate}").Joined() + "}",
       Object(name) with {
         Alternates = [.. others.Select(o => Alternate(o.Alternate, o.Content))],
       });

  public void WithAlternateModifiers(string name, string[] others)
    => TrueExpected(
      name + "{" + others.Joined(a => $"|{a}[][String]") + "}",
       Object(name) with {
         Alternates = [.. others.Select(a => Alternate(a) with { Modifiers = TestCollections() })],
       });

  public void WithAlternateModifiersBad(string name, string[] others)
    => False(name + "{" + others.Joined(a => $"|{a}[?]") + "}");

  public void WithTypeParameters(string name, string other, string[] parameters)
    => TrueExpected(
      name + "<" + parameters.Joined("$") + ">{|" + other + "}",
       Object(name) with {
         Alternates = [Alternate(other)],
         TypeParameters = parameters.TypeParameters(),
       });

  public void WithTypeParameterBad(string name, string other)
    => False(name + "<$>{|" + other);

  public void WithTypeParametersBad(string name, string other, string[] parameters)
    => False(name + "<" + parameters.Joined("$") + "{|" + other);

  public void WithTypeParametersNone(string name, string other)
    => False(name + "<>{|" + other);

  public void WithFieldBad(string name, FieldInput[] fields, string fieldName)
    => False(name + "{" + fields.Select(f => f.Name + ":" + f.Type).Joined() + " " + fieldName + ":}");

  public void WithFields(string name, FieldInput[] fields)
    => TrueExpected(
      name + "{" + fields.Select(f => f.Name + ":" + f.Type).Joined() + "}",
       Object(name) with {
         Fields = [.. fields.Select(f => Field(f.Name, f.Type))],
       });

  public void WithFieldsBad(string name, FieldInput[] fields)
    => False(name + "{" + fields.Select(f => f.Name + ":" + f.Type).Joined());

  public void WithExtendsField(string name, string extends, string field, string fieldType)
    => TrueExpected(
      name + "{:" + extends + " " + field + ":" + fieldType + "}",
       Object(name) with {
         Fields = [Field(field, fieldType)],
         Extends = Reference(extends),
       });

  public void WithExtendsFieldBad(string name, string extends, string field, string fieldType)
    => False(name + "{:" + extends + " " + field + ":" + fieldType);

  public void WithExtendsGenericField(string name, string extends, string subType, string field, string fieldType)
    => TrueExpected(
      name + "{:" + extends + "<" + subType + ">" + field + ":" + fieldType + "}",
       Object(name) with {
         Fields = [Field(field, fieldType)],
         Extends = ReferenceWithArgs(extends, subType),
       });

  public void WithExtendsGenericFieldBad(string name, string extends, string subType, string field, string fieldType)
    => False(name + "{:" + extends + "<" + subType + " " + field + ":" + fieldType + "}");

  public O Object(string name)
    => _factories.Object(AstNulls.At, name);

  public F Field(string field, string fieldType)
    => _factories.Field(AstNulls.At, field, Reference(fieldType));

  public F Field(string field, R fieldType)
    => _factories.Field(AstNulls.At, field, fieldType);

  public R Reference(string type, string description = "")
    => _factories.Reference(AstNulls.At, type, description);

  public R ReferenceWithArgs(string type, string subType)
    => Reference(type) with { Arguments = [Reference(subType)] };

  public AlternateAst<R> Alternate(string type)
    => new(Reference(type));

  public AlternateAst<R> Alternate(string type, string description)
    => new(Reference(type, description));

  protected internal override string AliasesString(ObjectInput input, string aliases)
    => input.Name + aliases + "{|" + input.Other + "}";
  protected internal override O AliasedFactory(ObjectInput input)
    => Object(input.Name) with { Alternates = [Alternate(input.Other)] };
}

public record struct AlternateComment(string Content, string Alternate);
