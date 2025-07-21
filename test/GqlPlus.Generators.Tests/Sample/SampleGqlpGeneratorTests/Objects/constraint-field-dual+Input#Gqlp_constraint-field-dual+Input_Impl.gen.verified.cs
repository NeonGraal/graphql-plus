//HintName: Gqlp_constraint-field-dual+Input_Impl.gen.cs
// Generated from constraint-field-dual+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_field_dual_Input;
public class InputCnstFieldDualInp
  : InputRefCnstFieldDualInp
  , ICnstFieldDualInp
{
}
public class InputRefCnstFieldDualInp<Tref>
  : IRefCnstFieldDualInp<Tref>
{
  public Tref field { get; set; }
}
public class DualPrntCnstFieldDualInp
  : IPrntCnstFieldDualInp
{
  public String AsString { get; set; }
}
public class InputAltCnstFieldDualInp
  : InputPrntCnstFieldDualInp
  , IAltCnstFieldDualInp
{
  public Number alt { get; set; }
}
