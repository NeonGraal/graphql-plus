//HintName: Gqlp_generic-parent-dual-parent+Input_Impl.gen.cs
// Generated from generic-parent-dual-parent+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_parent_dual_parent_Input;
public class InputGnrcPrntDualPrntInp
  : InputRefGnrcPrntDualPrntInp
  , IGnrcPrntDualPrntInp
{
}
public class InputRefGnrcPrntDualPrntInp<Tref>
  : Inputref
  , IRefGnrcPrntDualPrntInp<Tref>
{
}
public class DualAltGnrcPrntDualPrntInp
  : IAltGnrcPrntDualPrntInp
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
