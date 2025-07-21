//HintName: Gqlp_generic-parent-dual+Input_Impl.gen.cs
// Generated from generic-parent-dual+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_parent_dual_Input;
public class InputGnrcPrntDualInp
  : InputRefGnrcPrntDualInp
  , IGnrcPrntDualInp
{
}
public class InputRefGnrcPrntDualInp<Tref>
  : IRefGnrcPrntDualInp<Tref>
{
  public Tref Asref { get; set; }
}
public class DualAltGnrcPrntDualInp
  : IAltGnrcPrntDualInp
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
