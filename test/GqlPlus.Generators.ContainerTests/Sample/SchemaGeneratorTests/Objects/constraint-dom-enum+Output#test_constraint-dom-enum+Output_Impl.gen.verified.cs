//HintName: test_constraint-dom-enum+Output_Impl.gen.cs
// Generated from constraint-dom-enum+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_dom_enum_Output;

public class testCnstDomEnumOutp
  : ItestCnstDomEnumOutp
{
  public ItestRefCnstDomEnumOutp<testEnumCnstDomEnumOutp> AsEnumCnstDomEnumOutpcnstDomEnumOutp { get; set; }
  public ItestCnstDomEnumOutpObject AsCnstDomEnumOutp { get; set; }
}

public class testRefCnstDomEnumOutp<TType>
  : ItestRefCnstDomEnumOutp<TType>
{
  public TType Field { get; set; }
  public ItestRefCnstDomEnumOutpObject AsRefCnstDomEnumOutp { get; set; }
}

public class testJustCnstDomEnumOutp
  : DomainEnum
  , ItestJustCnstDomEnumOutp
{
}
