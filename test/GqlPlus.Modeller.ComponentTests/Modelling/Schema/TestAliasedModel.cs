﻿using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Modelling.Schema;

public abstract class TestAliasedModel<TInput, TModel>(
  ICheckAliasedModel<TInput, TModel> aliasedChecks
) : TestDescribedModel<TInput, TModel>(aliasedChecks)
  where TModel : IModelBase
{
  [Theory, RepeatData]
  public void Model_Aliases(TInput input, string[] aliases)
  {
    Assert.SkipWhen(SkipIf(input), SkipReason);

    aliasedChecks.Model_Expected(
        aliasedChecks.ToModel(aliasedChecks.AliasedAst(input, aliases)),
        aliasedChecks.ExpectedDescriptionAliases(new(input, aliases)));
  }
}

internal abstract class CheckAliasedModel<TName, TAst, TModel>(
  IModeller<TAst, TModel> modeller,
  IEncoder<TModel> encoding
) : CheckAliasedModel<TName, TAst, TAst, TModel>(modeller, encoding)
  where TAst : IGqlpAliased
  where TModel : IModelBase
{ }

internal abstract class CheckAliasedModel<TName, TSrc, TAst, TModel>(
  IModeller<TSrc, TModel> modeller,
  IEncoder<TModel> encoding
) : CheckDescribedModel<TName, TSrc, TAst, TModel>(modeller, encoding)
  , ICheckAliasedModel<TName, TModel>
  where TSrc : IGqlpError, IGqlpDescribed
  where TAst : IGqlpAliased, TSrc
  where TModel : IModelBase
{
  protected abstract string[] ExpectedDescriptionAliases(ExpectedDescriptionAliasesInput<TName> input);

  protected override string[] ExpectedDescription(ExpectedDescriptionInput<TName> input)
    => ExpectedDescriptionAliases(new(input));

  IGqlpAliased ICheckAliasedModel<TName, TModel>.AliasedAst(TName name, string[]? aliases)
    => NewAliasedAst(name, aliases: aliases);
  string[] ICheckAliasedModel<TName, TModel>.ExpectedDescriptionAliases(ExpectedDescriptionAliasesInput<TName> input) => ExpectedDescriptionAliases(input);
  IModelBase ICheckAliasedModel<TName, TModel>.ToModel(IGqlpAliased aliased) => AstToModel((TAst)aliased);

  protected override TAst NewDescribedAst(TName name, string description)
    => NewAliasedAst(name, description);

  protected abstract TAst NewAliasedAst(TName name, string? description = null, string[]? aliases = null);
}

public interface ICheckAliasedModel<TName, TModel>
  : ICheckDescribedModel<TName, TModel>
  where TModel : IModelBase
{
  IGqlpAliased AliasedAst(TName name, string[]? aliases = null);
  IModelBase ToModel(IGqlpAliased aliased);
  string[] ExpectedDescriptionAliases(ExpectedDescriptionAliasesInput<TName> input);
}

public class ExpectedDescriptionAliasesInput<TName>(
  TName name,
  IEnumerable<string>? aliases = null,
  string? description = null
) : ExpectedDescriptionInput<TName>(name, description)
{
#pragma warning disable CA1819 // Properties should not return arrays
  public string[] Aliases { get; protected set; } = aliases is null ? [] : [.. aliases];
  public string[] ExpectedAliases { get; protected set; }
    = aliases is null ? [] : [aliases.Surround("aliases: [", "]", ",")];
#pragma warning restore CA1819 // Properties should not return arrays

  internal ExpectedDescriptionAliasesInput(ExpectedDescriptionInput<TName> input)
    : this(input.Name)
    => ExpectedDescription = input.ExpectedDescription;
}
