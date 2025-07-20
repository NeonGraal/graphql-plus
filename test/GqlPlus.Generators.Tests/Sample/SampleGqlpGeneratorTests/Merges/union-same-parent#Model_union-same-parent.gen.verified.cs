//HintName: Model_union-same-parent.gen.cs
// Generated from union-same-parent.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_union_same_parent;

public interface IUnionSamePrnt
  : IPrntUnionSamePrnt
{
  Boolean AsBoolean { get; }
}
public class UnionUnionSamePrnt
  : UnionPrntUnionSamePrnt
  , IUnionSamePrnt
{
  public Boolean AsBoolean { get; set; }
}

public interface IPrntUnionSamePrnt
{
  String AsString { get; }
}
public class UnionPrntUnionSamePrnt
  : IPrntUnionSamePrnt
{
  public String AsString { get; set; }
}
