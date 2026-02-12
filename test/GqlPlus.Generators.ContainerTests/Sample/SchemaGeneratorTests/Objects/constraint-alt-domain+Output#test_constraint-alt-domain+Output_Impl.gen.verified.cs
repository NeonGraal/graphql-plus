//HintName: test_constraint-alt-domain+Output_Impl.gen.cs
// Generated from constraint-alt-domain+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_domain_Output;

public class testCnstAltDmnOutp
  : ItestCnstAltDmnOutp
{
  public ItestRefCnstAltDmnOutp<ItestDomCnstAltDmnOutp> AsRefCnstAltDmnOutp { get; set; }
  public ItestCnstAltDmnOutpObject AsCnstAltDmnOutp { get; set; }
}

public class testRefCnstAltDmnOutp<TRef>
  : ItestRefCnstAltDmnOutp<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefCnstAltDmnOutpObject<TRef> AsRefCnstAltDmnOutp { get; set; }
}

public class testDomCnstAltDmnOutp
  : GqlpDomainString
  , ItestDomCnstAltDmnOutp
{
}
