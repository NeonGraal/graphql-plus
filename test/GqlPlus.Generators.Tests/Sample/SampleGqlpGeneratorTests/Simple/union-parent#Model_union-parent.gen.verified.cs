﻿//HintName: Model_union-parent.gen.cs
// Generated from union-parent.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_union_parent;

public interface IUnionPrnt
  : IPrntUnionPrnt
{
  String AsString { get; }
}
public class UnionUnionPrnt
  : UnionPrntUnionPrnt
  , IUnionPrnt
{
  public String AsString { get; set; }
}

public interface IPrntUnionPrnt
{
  Number AsNumber { get; }
}
public class UnionPrntUnionPrnt
  : IPrntUnionPrnt
{
  public Number AsNumber { get; set; }
}
