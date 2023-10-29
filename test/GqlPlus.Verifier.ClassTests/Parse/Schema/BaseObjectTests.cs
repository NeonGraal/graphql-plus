﻿namespace GqlPlus.Verifier.Parse.Schema;

public abstract class BaseObjectTests
{
  [Theory, RepeatData(Repeats)]
  public void WithMinimum_ReturnsCorrectAst(string name, string other)
    => Checks.WithMinimum(name, other);

  [Theory, RepeatData(Repeats)]
  public void WithAlternates_ReturnsCorrectAst(string name, string[] others)
    => Checks.WithAlternates(name, others);

  [Theory, RepeatData(Repeats)]
  public void WithTypeParameters_ReturnsCorrectAst(string name, string other, string parameter)
    => Checks.WithTypeParameters(name, other, parameter);

  [Theory, RepeatData(Repeats)]
  public void WithAliases_ReturnsCorrectAst(string name, string other, string[] aliases)
    => Checks.WithAliases(name, other, aliases);

  [Theory, RepeatData(Repeats)]
  public void WithField_ReturnsCorrectAst(string name, string field, string fieldType)
    => Checks.WithField(name, field, fieldType);

  [Theory, RepeatData(Repeats)]
  public void WithFields_ReturnsCorrectAst(string name, FieldInput[] fields)
    => Checks.WithFields(name, fields);

  [Theory, RepeatData(Repeats)]
  public void WithFieldAlias_ReturnsCorrectAst(string name, string field, string alias, string fieldType)
    => Checks.WithFieldAlias(name, field, alias, fieldType);

  [Theory, RepeatData(Repeats)]
  public void WithFieldGeneric_ReturnsCorrectAst(string name, string field, string fieldType, string subType)
    => Checks.WithFieldGeneric(name, field, fieldType, subType);

  [Theory, RepeatData(Repeats)]
  public void WithFieldModified_ReturnsCorrectAst(string name, string field, string fieldType)
    => Checks.WithFieldModified(name, field, fieldType);

  [Theory, RepeatData(Repeats)]
  public void WithExtendsField_ReturnsCorrectAst(string name, string extends, string field, string fieldType)
    => Checks.WithExtendsField(name, extends, field, fieldType);

  [Theory, RepeatData(Repeats)]
  public void WithExtendsGenericField_ReturnsCorrectAst(string name, string extends, string subType, string field, string fieldType)
    => Checks.WithExtendsGenericField(name, extends, subType, field, fieldType);

  internal abstract IBaseObjectChecks Checks { get; }
}
