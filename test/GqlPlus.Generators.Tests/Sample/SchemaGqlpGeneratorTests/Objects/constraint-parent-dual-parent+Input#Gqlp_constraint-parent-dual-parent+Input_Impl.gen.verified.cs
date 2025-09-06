//HintName: Gqlp_constraint-parent-dual-parent+Input_Impl.gen.cs
// Generated from constraint-parent-dual-parent+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_parent_dual_parent_Input;

public class InputCnstPrntDualPrntInp
  : InputRefCnstPrntDualPrntInp
  , ICnstPrntDualPrntInp
{
}

public class InputRefCnstPrntDualPrntInp<Tref>
  : Inputref
  , IRefCnstPrntDualPrntInp<Tref>
{
}

public class DualPrntCnstPrntDualPrntInp
  : IPrntCnstPrntDualPrntInp
{
  public String AsString { get; set; }
}

public class InputAltCnstPrntDualPrntInp
  : InputPrntCnstPrntDualPrntInp
  , IAltCnstPrntDualPrntInp
{
  public Number alt { get; set; }
}
