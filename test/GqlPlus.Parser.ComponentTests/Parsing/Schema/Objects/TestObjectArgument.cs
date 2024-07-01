﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parsing.Schema.Objects;

public abstract class TestObjectArgument
{
  [Theory, RepeatData(Repeats)]
  public void WithMinimum_ReturnsCorrectAst(string name)
  => ObjectArgumentChecks.WithMinimum(name);

  [Theory, RepeatData(Repeats)]
  public void WithTypeParameter_ReturnsCorrectAst(string name)
  => ObjectArgumentChecks.WithTypeParameter(name);

  [Fact]
  public void WithTypeParameterBad_ReturnsFalse()
  => ObjectArgumentChecks.WithTypeParameterBad();

  internal abstract ICheckObjectArgument ObjectArgumentChecks { get; }
}

internal sealed class CheckObjectArgument<TObjArg, TObjArgAst>(
  IObjectArgumentFactories<TObjArg, TObjArgAst> factories,
  Parser<TObjArg>.D parser
) : OneChecksParser<TObjArg>(parser), ICheckObjectArgument
  where TObjArg : IGqlpObjArgument
  where TObjArgAst : AstObjArgument, TObjArg
{
  private readonly IObjectArgumentFactories<TObjArg, TObjArgAst> _factories = factories;

  public void WithMinimum(string name)
    => TrueExpected(name, ObjArg(name));

  public void WithTypeParameter(string name)
    => TrueExpected("$" + name, ObjArg(name) with { IsTypeParameter = true });

  public void WithTypeParameterBad()
    => False("$");

  public TObjArgAst ObjArg(string type)
    => _factories.ObjArgument(AstNulls.At, type);
}

public interface ICheckObjectArgument
{
  void WithMinimum(string name);
  void WithTypeParameter(string name);
  void WithTypeParameterBad();
}
