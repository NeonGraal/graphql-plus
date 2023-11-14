namespace GqlPlus.Verifier.Parse.Schema;

public abstract class BaseObjectTests
  : BaseAliasedTests<ObjectInput>
{
  [Theory, RepeatData(Repeats)]
  public void WithNameBad_ReturnsFalse(decimal id, string[] others)
    => Checks.WithNameBad(id, others);

  [Theory, RepeatData(Repeats)]
  public void WithAlternates_ReturnsCorrectAst(string name, string[] others)
    => Checks.WithAlternates(name, others);

  [Theory, RepeatData(Repeats)]
  public void WithAlternateComments_ReturnsCorrectAst(string name, AlternateComment[] others)
    => Checks.WithAlternateComments(name, others);

  [Theory, RepeatData(Repeats)]
  public void WithAlternateModifiers_ReturnsCorrectAst(string name, string[] others)
    => Checks.WithAlternateModifiers(name, others);

  [Theory, RepeatData(Repeats)]
  public void WithTypeParameters_ReturnsCorrectAst(string name, string other, string parameter)
    => Checks.WithTypeParameters(name, other, parameter);

  [Theory, RepeatData(Repeats)]
  public void WithTypeParameterBad_ReturnsFalse(string name, string other)
    => Checks.WithTypeParameterBad(name, other);

  [Theory, RepeatData(Repeats)]
  public void WithTypeParametersBad_ReturnsFalse(string name, string other, string parameter)
    => Checks.WithTypeParametersBad(name, other, parameter);

  [Theory, RepeatData(Repeats)]
  public void WithTypeParametersNone_ReturnsFalse(string name, string other)
    => Checks.WithTypeParametersNone(name, other);

  [Theory, RepeatData(Repeats)]
  public void WithFields_ReturnsCorrectAst(string name, FieldInput[] fields)
    => Checks.WithFields(name, fields);

  [Theory, RepeatData(Repeats)]
  public void WithFieldsBad_ReturnsFalse(string name, FieldInput[] fields)
    => Checks.WithFieldsBad(name, fields);

  [Theory, RepeatData(Repeats)]
  public void WithExtendsField_ReturnsCorrectAst(string name, string extends, string field, string fieldType)
    => Checks.WithExtendsField(name, extends, field, fieldType);

  [Theory, RepeatData(Repeats)]
  public void WithExtendsFieldBad_ReturnsFalse(string name, string extends, string field, string fieldType)
    => Checks.WithExtendsFieldBad(name, extends, field, fieldType);

  [Theory, RepeatData(Repeats)]
  public void WithExtendsGenericFieldBad_ReturnsFalse(string name, string extends, string subType, string field, string fieldType)
    => Checks.WithExtendsGenericFieldBad(name, extends, subType, field, fieldType);

  [Theory, RepeatData(Repeats)]
  public void WithFieldsAndAlternates_ReturnsCorrectAst(string name, FieldInput[] fields, string[] others)
    => Checks.WithFieldsAndAlternates(name, fields, others);

  [Theory, RepeatData(Repeats)]
  public void WithFieldsBadAndAlternates_ReturnsFalse(string name, FieldInput[] fields, string[] others)
    => Checks.WithFieldsBadAndAlternates(name, fields, others);

  [Theory, RepeatData(Repeats)]
  public void WithFieldsAndAlternatesBad_ReturnsFalse(string name, FieldInput[] fields, string[] others)
    => Checks.WithFieldsAndAlternatesBad(name, fields, others);

  internal abstract IBaseObjectChecks Checks { get; }

  internal override IBaseAliasedChecks<ObjectInput> AliasChecks => Checks;
}

public record struct ObjectInput(string Name, string Other);
