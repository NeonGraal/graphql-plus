//HintName: test_constraint-field-domain+Output_Intf.gen.cs
// Generated from constraint-field-domain+Output.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_domain_Output;

public interface ItestCnstFieldDmnOutp
  : ItestRefCnstFieldDmnOutp
{
  public testCnstFieldDmnOutp CnstFieldDmnOutp { get; set; }
}

public interface ItestCnstFieldDmnOutpField
  : ItestRefCnstFieldDmnOutpField
{
}

public interface ItestRefCnstFieldDmnOutp<Tref>
{
  public testRefCnstFieldDmnOutp RefCnstFieldDmnOutp { get; set; }
}

public interface ItestRefCnstFieldDmnOutpField<Tref>
{
  public Tref field { get; set; }
}

public interface ItestDomCnstFieldDmnOutp
{
}
