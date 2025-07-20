//HintName: Model_parent-alt+Dual.gen.cs
// Generated from parent-alt+Dual.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_parent_alt_Dual;

public interface IPrntAltDual
  : IRefPrntAltDual
{
  Number AsNumber { get; }
}
public class DualPrntAltDual
  : DualRefPrntAltDual
  , IPrntAltDual
{
  public Number AsNumber { get; set; }
}

public interface IRefPrntAltDual
{
  Number parent { get; }
  String AsString { get; }
}
public class DualRefPrntAltDual
  : IRefPrntAltDual
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
