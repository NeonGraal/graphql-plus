//HintName: Model_parent+Dual.gen.cs
// Generated from parent+Dual.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_parent_Dual;

public interface IPrntDual
  : IRefPrntDual
{
}
public class DualPrntDual
  : DualRefPrntDual
  , IPrntDual
{
}

public interface IRefPrntDual
{
  Number parent { get; }
  String AsString { get; }
}
public class DualRefPrntDual
  : IRefPrntDual
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
