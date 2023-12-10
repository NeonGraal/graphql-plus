﻿using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public class AlternatesMerger<TAlternate, TReference>
  : DescribedMerger<TAlternate>
  where TAlternate : AlternateAst<TReference>
  where TReference : AstReference<TReference>, IEquatable<TReference>
{
  protected override string ItemGroupKey(TAlternate item)
    => item.Modifiers.AsString().Joined();
}

internal class AlternatesMerger<TReference>
  : AlternatesMerger<AlternateAst<TReference>, TReference>
  where TReference : AstReference<TReference>, IEquatable<TReference>
{ }
