//HintName: Model_generic-parent-dual-parent+Input.gen.cs
// Generated from generic-parent-dual-parent+Input.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_generic_parent_dual_parent_Input;

public interface IGnrcPrntDualPrntInp
  : IRefGnrcPrntDualPrntInp
{
}
public class InputGnrcPrntDualPrntInp
  : InputRefGnrcPrntDualPrntInp
  , IGnrcPrntDualPrntInp
{
}

public interface IRefGnrcPrntDualPrntInp<Tref>
  : Iref
{
}
public class InputRefGnrcPrntDualPrntInp<Tref>
  : Inputref
  , IRefGnrcPrntDualPrntInp<Tref>
{
}

public interface IAltGnrcPrntDualPrntInp
{
  Number alt { get; }
  String AsString { get; }
}
public class DualAltGnrcPrntDualPrntInp
  : IAltGnrcPrntDualPrntInp
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
