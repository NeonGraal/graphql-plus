using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public abstract class AstObjectTests
  : AstTypeTests
{
  [Theory, RepeatData]
  public void HashCode_WithAlternates(string name, TypeInput[] alternates)
    => ObjectChecks.HashCode_WithAlternates(name, alternates);
  [Theory, RepeatData]
  public void Text_WithAlternates(string name, TypeInput[] alternates)
    => ObjectChecks.Text_WithAlternates(name, alternates);
  [Theory, RepeatData]
  public void Equality_WithAlternates(string name, TypeInput[] alternates)
    => ObjectChecks.Equality_WithAlternates(name, alternates);
  [Theory, RepeatData]
  public void Inequality_BetweenAlternates(string name, TypeInput[] alternates1, TypeInput[] alternates2)
    => ObjectChecks.Inequality_BetweenAlternates(name, alternates1, alternates2);

  [Theory, RepeatData]
  public void HashCode_WithFields(string name, FieldInput[] fields)
      => ObjectChecks.HashCode_WithFields(name, fields);
  [Theory, RepeatData]
  public void Text_WithFields(string name, FieldInput[] fields)
    => ObjectChecks.Text_WithFields(name, fields);
  [Theory, RepeatData]
  public void Equality_WithFields(string name, FieldInput[] fields)
    => ObjectChecks.Equality_WithFields(name, fields);
  [Theory, RepeatData]
  public void Inequality_BetweenFields(string name, FieldInput[] fields1, FieldInput[] fields2)
    => ObjectChecks.Inequality_BetweenFields(name, fields1, fields2);

  [Theory, RepeatData]
  public void HashCode_WithTypeParams(string name, string[] typeParams)
      => ObjectChecks.HashCode_WithTypeParams(name, typeParams);
  [Theory, RepeatData]
  public void Text_WithTypeParams(string name, string[] typeParams)
    => ObjectChecks.Text_WithTypeParams(name, typeParams);
  [Theory, RepeatData]
  public void Equality_WithTypeParams(string name, string[] typeParams)
    => ObjectChecks.Equality_WithTypeParams(name, typeParams);
  [Theory, RepeatData]
  public void Inequality_BetweenTypeParams(string name, string[] typeParams1, string[] typeParams2)
    => ObjectChecks.Inequality_BetweenTypeParams(name, typeParams1, typeParams2);

  internal override IAstTypeChecks TypeChecks => ObjectChecks;

  internal abstract IAstObjectChecks ObjectChecks { get; }
}

internal abstract class AstObjectChecks<TObjField>(
  TypeKind kind,
  AstTypeChecks<AstObject<TObjField>, IGqlpObjBase>.ParentCreator createParent
) : AstTypeChecks<AstObject<TObjField>, IGqlpObjBase>(CreateObject(kind), CloneObject, createParent)
  , IAstObjectChecks
  where TObjField : IGqlpObjField
{
  public void Equality_WithAlternates(string name, TypeInput[] alternates)
    => Equality(() => CreateInput(name) with { Alternates = AstObjectChecks<TObjField>.CreateAlternates(alternates) });
  public void HashCode_WithAlternates(string name, TypeInput[] alternates)
    => HashCode(() => CreateInput(name) with { Alternates = AstObjectChecks<TObjField>.CreateAlternates(alternates) });
  public void Inequality_BetweenAlternates(string name, TypeInput[] alternates1, TypeInput[] alternates2)
    => InequalityBetween(alternates1, alternates2,
      alternates => CreateInput(name) with { Alternates = AstObjectChecks<TObjField>.CreateAlternates(alternates) },
      alternates1.OrderedEqual(alternates2));
  public void Text_WithAlternates(string name, TypeInput[] alternates)
    => Text(
      () => CreateInput(name) with { Alternates = AstObjectChecks<TObjField>.CreateAlternates(alternates) },
      $"( !{Abbr} {name} | {alternates.Joined(AlternateString)} )");

  public void HashCode_WithFields(string name, FieldInput[] fields)
      => HashCode(() => CreateInput(name) with { ObjFields = CreateFields(fields) });
  public void Text_WithFields(string name, FieldInput[] fields)
    => Text(
      () => CreateInput(name) with { ObjFields = CreateFields(fields) },
      $"( !{Abbr} {name} {{ {fields.Joined(FieldString)} }} )");
  public void Equality_WithFields(string name, FieldInput[] fields)
    => Equality(() => CreateInput(name) with { ObjFields = CreateFields(fields) });
  public void Inequality_BetweenFields(string name, FieldInput[] fields1, FieldInput[] fields2)
    => InequalityBetween(fields1, fields2,
      fields => CreateInput(name) with { ObjFields = CreateFields(fields) },
      fields1.OrderedEqual(fields2));

  public void HashCode_WithTypeParams(string name, string[] typeParams)
      => HashCode(
        () => CreateInput(name) with { TypeParams = typeParams.TypeParams() });
  public void Text_WithTypeParams(string name, string[] typeParams)
    => Text(
      () => CreateInput(name) with { TypeParams = typeParams.TypeParams() },
      $"( !{Abbr} {name} < {typeParams.Joined(s => "$" + s + " :_Any")} > )");
  public void Equality_WithTypeParams(string name, string[] typeParams)
    => Equality(
      () => CreateInput(name) with { TypeParams = typeParams.TypeParams() });
  public void Inequality_BetweenTypeParams(string name, string[] typeParams1, string[] typeParams2)
    => InequalityBetween(typeParams1, typeParams2,
      parameters => CreateInput(name) with { TypeParams = parameters.TypeParams() },
      typeParams1.SequenceEqual(typeParams2));

  protected static IGqlpAlternate[] CreateAlternates(IEnumerable<TypeInput> alternates)
    => alternates.Alternates();
  protected string AlternateString(TypeInput input)
    => $"{input.Type} [] ?";

  protected override string ParentString(string name, string parent)
    => $"( !{Abbr} {name} : {parent} )";

  protected abstract TObjField[] CreateFields(IEnumerable<FieldInput> fields);
  protected abstract string FieldString(FieldInput input);

  private static CreateBy<string> CreateObject(TypeKind kind)
    => input => new(kind, AstNulls.At, input, "");
  private static AstObject<TObjField> CloneObject(AstObject<TObjField> original, string input)
    => original with { Name = input };
}

internal interface IAstObjectChecks
  : IAstTypeChecks
{
  void HashCode_WithAlternates(string name, TypeInput[] alternates);
  void Text_WithAlternates(string name, TypeInput[] alternates);
  void Equality_WithAlternates(string name, TypeInput[] alternates);
  void Inequality_BetweenAlternates(string name, TypeInput[] alternates1, TypeInput[] alternates2);

  void HashCode_WithFields(string name, FieldInput[] fields);
  void Text_WithFields(string name, FieldInput[] fields);
  void Equality_WithFields(string name, FieldInput[] fields);
  void Inequality_BetweenFields(string name, FieldInput[] fields1, FieldInput[] fields2);

  void HashCode_WithTypeParams(string name, string[] typeParams);
  void Text_WithTypeParams(string name, string[] typeParams);
  void Equality_WithTypeParams(string name, string[] typeParams);
  void Inequality_BetweenTypeParams(string name, string[] typeParams1, string[] typeParams2);
}
