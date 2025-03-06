﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Merging;
using GqlPlus.Merging.Simple;
using Xunit.Abstractions;

namespace GqlPlus.Schema.Simple;

public class MergeDomainAstStringsTests
  : TestDomainAsts<IGqlpDomainRegex, string>
{
  internal override IDomainMerger<IGqlpDomainRegex> Merger { get; }
  internal override AstTypeMerger<IGqlpDomain, IGqlpDomain<IGqlpDomainRegex>, string, IGqlpDomainRegex> MergerTyped { get; }

  public MergeDomainAstStringsTests(ITestOutputHelper outputHelper)
  {
    MergeDomains<DomainRegexAst, IGqlpDomainRegex> merger = new(outputHelper.ToLoggerFactory(), MergeItems);
    MergerTyped = merger;
    Merger = merger;
  }

  protected override IGqlpDomain<IGqlpDomainRegex> MakeDomain(string name, string[]? aliases = null, string description = "", string? parent = null, DomainKind? kind = null, IEnumerable<IGqlpDomainRegex>? items = null)
    => new AstDomain<DomainRegexAst, IGqlpDomainRegex>(AstNulls.At, name, description, kind ?? DomainKind.String) {
      Aliases = aliases ?? [],
      Parent = parent,
      Members = items?.ArrayOf<DomainRegexAst>() ?? [],
    };

  protected override IGqlpDomainRegex[] MakeItems(string input)
    => new[] { input }.DomainRegexes();
}
