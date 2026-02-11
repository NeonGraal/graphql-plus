//HintName: test_constraint-field-domain+Output_Intf.gen.cs
// Generated from constraint-field-domain+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_domain_Output;

public interface ItestCnstFieldDmnOutp
  : ItestRefCnstFieldDmnOutp
{
  ItestCnstFieldDmnOutpObject AsCnstFieldDmnOutp { get; }
}

public interface ItestCnstFieldDmnOutpObject
  : ItestRefCnstFieldDmnOutpObject
{
}

public interface ItestRefCnstFieldDmnOutp<Tref>
{
  ItestRefCnstFieldDmnOutpObject AsRefCnstFieldDmnOutp { get; }
}

public interface ItestRefCnstFieldDmnOutpObject<Tref>
{
  Tref Field { get; }
}

public interface ItestDomCnstFieldDmnOutp
  : IDomainString
{
}
