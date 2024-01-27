using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public abstract class BaseObjectTests
  : BaseAliasedTests<ObjectInput>
{
  [Theory, RepeatData(Repeats)]
  public void WithAlternates_ReturnsCorrectAst(string name, string[] others)
    => ObjectChecks.WithAlternates(name, others);

  [Theory, RepeatData(Repeats)]
  public void WithAlternateComments_ReturnsCorrectAst(string name, AlternateComment[] others)
    => ObjectChecks.WithAlternateComments(name, others);

  [Theory, RepeatData(Repeats)]
  public void WithAlternateModifiers_ReturnsCorrectAst(string name, string[] others)
    => ObjectChecks.WithAlternateModifiers(name, others);

  [Theory, RepeatData(Repeats)]
  public void WithAlternateModifiersBad_ReturnsFalse(string name, string[] others)
    => ObjectChecks.WithAlternateModifiersBad(name, others);

  [Theory, RepeatData(Repeats)]
  public void WithTypeParameters_ReturnsCorrectAst(string name, string other, string[] parameters)
    => ObjectChecks.WithTypeParameters(name, other, parameters);

  [Theory, RepeatData(Repeats)]
  public void WithTypeParameterBad_ReturnsFalse(string name, string other)
    => ObjectChecks.WithTypeParameterBad(name, other);

  [Theory, RepeatData(Repeats)]
  public void WithTypeParametersBad_ReturnsFalse(string name, string other, string[] parameters)
    => ObjectChecks.WithTypeParametersBad(name, other, parameters);

  [Theory, RepeatData(Repeats)]
  public void WithTypeParametersNone_ReturnsFalse(string name, string other)
    => ObjectChecks.WithTypeParametersNone(name, other);

  [Theory, RepeatData(Repeats)]
  public void WithFieldBad_ReturnsFalse(string name, FieldInput[] fields, string fieldName)
    => ObjectChecks.WithFieldBad(name, fields, fieldName);

  [Theory, RepeatData(Repeats)]
  public void WithFields_ReturnsCorrectAst(string name, FieldInput[] fields)
    => ObjectChecks.WithFields(name, fields);

  [Theory, RepeatData(Repeats)]
  public void WithFieldsBad_ReturnsFalse(string name, FieldInput[] fields)
    => ObjectChecks.WithFieldsBad(name, fields);

  [Theory, RepeatData(Repeats)]
  public void WithExtendsField_ReturnsCorrectAst(string name, string extends, string field, string fieldType)
    => ObjectChecks.WithExtendsField(name, extends, field, fieldType);

  [Theory, RepeatData(Repeats)]
  public void WithExtendsFieldBad_ReturnsFalse(string name, string extends, string field, string fieldType)
    => ObjectChecks.WithExtendsFieldBad(name, extends, field, fieldType);

  [Theory, RepeatData(Repeats)]
  public void WithExtendsGenericFieldBad_ReturnsFalse(string name, string extends, string subType, string field, string fieldType)
    => ObjectChecks.WithExtendsGenericFieldBad(name, extends, subType, field, fieldType);

  [Theory, RepeatData(Repeats)]
  public void WithFieldsAndAlternates_ReturnsCorrectAst(string name, FieldInput[] fields, string[] others)
    => ObjectChecks.WithFieldsAndAlternates(name, fields, others);

  [Theory, RepeatData(Repeats)]
  public void WithFieldsBadAndAlternates_ReturnsFalse(string name, FieldInput[] fields, string[] others)
    => ObjectChecks.WithFieldsBadAndAlternates(name, fields, others);

  [Theory, RepeatData(Repeats)]
  public void WithFieldsAndAlternatesBad_ReturnsFalse(string name, FieldInput[] fields, string[] others)
    => ObjectChecks.WithFieldsAndAlternatesBad(name, fields, others);

  internal abstract IBaseObjectChecks ObjectChecks { get; }

  internal sealed override IBaseAliasedChecks<ObjectInput> AliasChecks => ObjectChecks;
}

public record struct ObjectInput(string Name, string Other);

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

  protected internal sealed override string AliasesString(ObjectInput input, string aliases)
    => input.Name + aliases + "{|" + input.Other + "}";
  protected internal sealed override O AliasedFactory(ObjectInput input)
    => Object(input.Name) with { Alternates = [Alternate(input.Other)] };
}

public record struct AlternateComment(string Content, string Alternate);

internal interface IBaseObjectChecks
  : IBaseAliasedChecks<ObjectInput>
{
  void WithNameBad(decimal id, string[] others);
  void WithTypeParameters(string name, string other, string[] typeParameters);
  void WithTypeParameterBad(string name, string other);
  void WithTypeParametersBad(string name, string other, string[] typeParameters);
  void WithTypeParametersNone(string name, string other);
  void WithExtendsField(string name, string extends, string field, string fieldType);
  void WithExtendsFieldBad(string name, string extends, string field, string fieldType);
  void WithExtendsGenericField(string name, string extends, string subType, string field, string fieldType);
  void WithExtendsGenericFieldBad(string name, string extends, string subType, string field, string fieldType);
  void WithAlternates(string name, string[] others);
  void WithAlternateComments(string name, AlternateComment[] others);
  void WithAlternateModifiers(string name, string[] others);
  void WithAlternateModifiersBad(string name, string[] others);
  void WithFieldBad(string name, FieldInput[] fields, string fieldName);
  void WithFields(string name, FieldInput[] fields);
  void WithFieldsBad(string name, FieldInput[] fields);
  void WithFieldsAndAlternates(string name, FieldInput[] fields, string[] others);
  void WithFieldsBadAndAlternates(string name, FieldInput[] fields, string[] others);
  void WithFieldsAndAlternatesBad(string name, FieldInput[] fields, string[] others);
}
