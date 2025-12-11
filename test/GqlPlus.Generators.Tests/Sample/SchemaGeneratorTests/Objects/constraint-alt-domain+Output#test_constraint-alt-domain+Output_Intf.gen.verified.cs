//HintName: test_constraint-alt-domain+Output_Intf.gen.cs
// Generated from constraint-alt-domain+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_domain_Output;

public interface ItestCnstAltDmnOutp
{
  public testRefCnstAltDmnOutp<testDomCnstAltDmnOutp> AsRefCnstAltDmnOutp { get; set; }
  public testCnstAltDmnOutp CnstAltDmnOutp { get; set; }
}

public interface ItestCnstAltDmnOutpField
{
}

public interface ItestRefCnstAltDmnOutp<Tref>
{
  public Tref Asref { get; set; }
  public testRefCnstAltDmnOutp RefCnstAltDmnOutp { get; set; }
}

public interface ItestRefCnstAltDmnOutpField<Tref>
{
}

public interface ItestDomCnstAltDmnOutp
  : IDomainString
{
}
