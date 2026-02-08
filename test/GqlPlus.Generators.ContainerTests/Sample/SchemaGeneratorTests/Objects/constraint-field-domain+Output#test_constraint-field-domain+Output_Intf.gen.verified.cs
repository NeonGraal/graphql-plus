//HintName: test_constraint-field-domain+Output_Intf.gen.cs
// Generated from constraint-field-domain+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_domain_Output;

public interface ItestCnstFieldDmnOutp
  : ItestRefCnstFieldDmnOutp
{
  public ItestCnstFieldDmnOutpObject AsCnstFieldDmnOutp { get; set; }
}

public interface ItestCnstFieldDmnOutpObject
  : ItestRefCnstFieldDmnOutpObject
{
}

public interface ItestRefCnstFieldDmnOutp<Tref>
{
  public ItestRefCnstFieldDmnOutpObject AsRefCnstFieldDmnOutp { get; set; }
}

public interface ItestRefCnstFieldDmnOutpObject<Tref>
{
  public Tref Field { get; set; }
}

public interface ItestDomCnstFieldDmnOutp
  : IDomainString
{
}
