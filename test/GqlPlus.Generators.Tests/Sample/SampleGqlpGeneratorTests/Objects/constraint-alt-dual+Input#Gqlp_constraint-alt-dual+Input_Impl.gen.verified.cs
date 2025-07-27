//HintName: Gqlp_constraint-alt-dual+Input_Impl.gen.cs
// Generated from constraint-alt-dual+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_alt_dual_Input;

public class InputCnstAltDualInp
  : ICnstAltDualInp
{
  public RefCnstAltDualInp<AltCnstAltDualInp> AsRefCnstAltDualInp { get; set; }
}

public class InputRefCnstAltDualInp<Tref>
  : IRefCnstAltDualInp<Tref>
{
  public Tref Asref { get; set; }
}

public class DualPrntCnstAltDualInp
  : IPrntCnstAltDualInp
{
  public String AsString { get; set; }
}

public class InputAltCnstAltDualInp
  : InputPrntCnstAltDualInp
  , IAltCnstAltDualInp
{
  public Number alt { get; set; }
}
