//HintName: Gqlp_constraint-parent-dual-grandparent+Input_Impl.gen.cs
// Generated from constraint-parent-dual-grandparent+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_parent_dual_grandparent_Input;
public class InputCnstPrntDualGrndInp
  : InputRefCnstPrntDualGrndInp
  , ICnstPrntDualGrndInp
{
}
public class InputRefCnstPrntDualGrndInp<Tref>
  : Inputref
  , IRefCnstPrntDualGrndInp<Tref>
{
}
public class DualGrndCnstPrntDualGrndInp
  : IGrndCnstPrntDualGrndInp
{
  public String AsString { get; set; }
}
public class DualPrntCnstPrntDualGrndInp
  : DualGrndCnstPrntDualGrndInp
  , IPrntCnstPrntDualGrndInp
{
}
public class InputAltCnstPrntDualGrndInp
  : InputPrntCnstPrntDualGrndInp
  , IAltCnstPrntDualGrndInp
{
  public Number alt { get; set; }
}
