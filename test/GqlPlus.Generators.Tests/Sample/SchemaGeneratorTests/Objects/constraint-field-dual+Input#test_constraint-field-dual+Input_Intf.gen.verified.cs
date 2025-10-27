//HintName: test_constraint-field-dual+Input_Intf.gen.cs
// Generated from constraint-field-dual+Input.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_dual_Input;

public interface ItestCnstFieldDualInp
  : ItestRefCnstFieldDualInp
{
}

public interface ItestRefCnstFieldDualInp<Tref>
{
  Tref field { get; }
}

public interface ItestPrntCnstFieldDualInp
{
  String AsString { get; }
}

public interface ItestAltCnstFieldDualInp
  : ItestPrntCnstFieldDualInp
{
  Number alt { get; }
}
