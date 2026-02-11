//HintName: test_constraint-alt-domain+Output_Intf.gen.cs
// Generated from constraint-alt-domain+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_domain_Output;

public interface ItestCnstAltDmnOutp
{
  ItestRefCnstAltDmnOutp<ItestDomCnstAltDmnOutp> AsRefCnstAltDmnOutp { get; }
  ItestCnstAltDmnOutpObject AsCnstAltDmnOutp { get; }
}

public interface ItestCnstAltDmnOutpObject
{
}

public interface ItestRefCnstAltDmnOutp<Tref>
{
  Tref Asref { get; }
  ItestRefCnstAltDmnOutpObject AsRefCnstAltDmnOutp { get; }
}

public interface ItestRefCnstAltDmnOutpObject<Tref>
{
}

public interface ItestDomCnstAltDmnOutp
  : IDomainString
{
}
