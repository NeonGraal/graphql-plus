﻿using GqlPlus.Verifier.Ast;
using NSubstitute;

namespace GqlPlus.Verifier.Merging;

[TracePerTest]

public abstract class TestAbbreviated<TAst>
  where TAst : AstAbbreviated
{
  [Fact]
  public void CanMerge_NoAsts_ReturnsFalse()
   => CanMerge_False([]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_OneAst_ReturnsTrue(string name)
    => CanMerge_True([MakeDistinct(name)]);

  [Fact]
  public void Merge_NullAsts_ReturnsEmpty()
  {
    var result = MergerBase.Merge(null!);

    result.Should().BeEmpty();
  }

  [Fact]
  public void Merge_NoAsts_ReturnsEmpty()
  {
    var result = MergerBase.Merge([]);

    result.Should().BeEmpty();
  }

  [Theory, RepeatData(Repeats)]
  public void Merge_OneAst_ReturnsAst(string name)
  {
    var ast = MakeDistinct(name);

    Merge_Expected([ast], ast);
  }

  protected abstract IMerge<TAst> MergerBase { get; }

  protected abstract TAst MakeDistinct(string name);

  protected void CanMerge_False(TAst[] asts, bool skipIf = false)
  {
    if (skipIf) {
      return;
    }

    var result = MergerBase.CanMerge(asts);

    result.Should().BeFalse();
  }

  protected void CanMerge_True(TAst[] asts)
  {
    var result = MergerBase.CanMerge(asts);

    result.Should().BeTrue();
  }

  protected void Merge_Expected(TAst[] asts, bool skipIf, params TAst[] expected)
  {
    if (skipIf) {
      return;
    }

    Merge_Expected(asts, expected);
  }

  protected void Merge_Expected(TAst[] asts, params TAst[] expected)
  {

    var result = MergerBase.Merge(asts);

    using var scope = new AssertionScope();

    result.Should().BeAssignableTo<IEnumerable<TAst>>();
    result.Should().BeEquivalentTo(expected);
  }

  protected IMerge<TResult> Merger<TResult>()
  {
    var result = Substitute.For<IMerge<TResult>>();
    result.CanMerge([]).ReturnsForAnyArgs(true);
    result.Merge([]).ReturnsForAnyArgs(c => c.Arg<IEnumerable<TResult>>());
    return result;
  }
}