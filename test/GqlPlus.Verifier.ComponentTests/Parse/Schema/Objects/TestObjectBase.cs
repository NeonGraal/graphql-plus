﻿using GqlPlus.Verifier.Ast.Schema.Objects;

namespace GqlPlus.Verifier.Parse.Schema.Objects;

public abstract class TestObjectBase
{
  [Theory, RepeatData(Repeats)]
  public void WithMinimum_ReturnsCorrectAst(string name)
  => ObjectBaseChecks.WithMinimum(name);

  [Theory, RepeatData(Repeats)]
  public void WithTypeParameter_ReturnsCorrectAst(string name)
  => ObjectBaseChecks.WithTypeParameter(name);

  [Fact]
  public void WithTypeParameterBad_ReturnsFalse()
  => ObjectBaseChecks.WithTypeParameterBad();

  [Theory, RepeatData(Repeats)]
  public void WithTypeArguments_ReturnsCorrectAst(string name, string[] objBases)
  => ObjectBaseChecks.WithTypeArguments(name, objBases);

  [Theory, RepeatData(Repeats)]
  public void WithTypeArgumentsBad_ReturnsCorrectAst(string name, string[] objBases)
  => ObjectBaseChecks.WithTypeArgumentsBad(name, objBases);

  [Theory, RepeatData(Repeats)]
  public void WithTypeArgumentsNone_ReturnsFalse(string name)
  => ObjectBaseChecks.WithTypeArgumentsNone(name);

  internal abstract ICheckObjectBase ObjectBaseChecks { get; }
}

internal sealed class CheckObjectBase<TObjBase>(
  IObjectBaseFactories<TObjBase> factories, Parser<TObjBase>.D parser
) : CheckOne<TObjBase>(parser), ICheckObjectBase
  where TObjBase : AstObjectBase<TObjBase>
{
  private readonly IObjectBaseFactories<TObjBase> _factories = factories;

  public void WithMinimum(string name)
    => TrueExpected(name, ObjBase(name));

  public void WithTypeParameter(string name)
    => TrueExpected("$" + name, ObjBase(name) with { IsTypeParameter = true });

  public void WithTypeParameterBad()
    => False("$");

  public void WithTypeArguments(string name, string[] objBases)
    => TrueExpected(
      name + "<" + objBases.Joined() + ">",
      ObjBase(name) with {
        Arguments = [.. objBases.Select(ObjBase)]
      });

  public void WithTypeArgumentsBad(string name, string[] objBases)
    => False(name + "<" + objBases.Joined());

  public void WithTypeArgumentsNone(string name)
    => False(name + "<>");

  public TObjBase ObjBase(string type)
    => _factories.ObjBase(AstNulls.At, type);
}

public interface ICheckObjectBase
{
  void WithMinimum(string name);
  void WithTypeParameter(string name);
  void WithTypeParameterBad();
  void WithTypeArguments(string name, string[] objBases);
  void WithTypeArgumentsBad(string name, string[] objBases);
  void WithTypeArgumentsNone(string name);
}
