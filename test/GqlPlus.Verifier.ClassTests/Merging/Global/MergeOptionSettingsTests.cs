﻿using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using NSubstitute;

namespace GqlPlus.Verifier.Merging.Global;

public class MergeOptionSettingsTests
  : TestGroups<OptionSettingAst>
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsValuesCantMerge_ReturnsErrors(string name)
  {
    _values.CanMerge([]).ReturnsForAnyArgs(ErrorMessages);

    CanMerge_Errors([MakeAst(name), MakeAst(name)]);
  }

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoAsts_CallsValuesMerge(string name)
  {
    Merge_Expected([MakeAst(name), MakeAst(name)], MakeAst(name));

    _values.ReceivedWithAnyArgs().Merge([]);
  }

  private readonly MergeOptionSettings _merger;
  private readonly IMerge<ConstantAst> _values;

  public MergeOptionSettingsTests()
  {
    _values = Merger<ConstantAst>();
    _merger = new(_values);
  }

  internal override GroupsMerger<OptionSettingAst> MergerGroups => _merger;

  protected override OptionSettingAst MakeAst(string input)
    => new(AstNulls.At, input, new FieldKeyAst(AstNulls.At, input));
}
