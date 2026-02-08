//HintName: test_constraint-dom-enum+Output_Impl.gen.cs
// Generated from constraint-dom-enum+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_dom_enum_Output;

public class testCnstDomEnumOutp
  : ItestCnstDomEnumOutp
{
  public ItestRefCnstDomEnumOutp<ItestEnumCnstDomEnumOutp> AsRefCnstDomEnumOutp { get; set; }
}

public class testRefCnstDomEnumOutp<Ttype>
  : ItestRefCnstDomEnumOutp<Ttype>
{
  public Ttype Field { get; set; }
}

public class testJustCnstDomEnumOutp
  : DomainEnum
  , ItestJustCnstDomEnumOutp
{
}
