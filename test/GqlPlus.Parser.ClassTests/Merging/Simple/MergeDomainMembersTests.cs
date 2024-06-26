﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Simple;

using Xunit.Abstractions;

namespace GqlPlus.Merging.Simple;

public class MergeDomainMembersTests(
  ITestOutputHelper outputHelper
) : TestDomainItems<IGqlpDomainMember, string>
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsDifferentExcludes_ReturnsErrors(string name)
    => CanMerge_Errors([MakeItem(name, true), MakeAst(name)]);

  private readonly MergeDomainMembers _merger = new(outputHelper.ToLoggerFactory());

  internal override GroupsMerger<IGqlpDomainMember> MergerGroups => _merger;

  protected override IGqlpDomainMember MakeItem(string input, bool excludes)
    => new DomainMemberAst(AstNulls.At, excludes, input);
}
