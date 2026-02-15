//HintName: test_constraint-dom-enum+Output_Impl.gen.cs
// Generated from constraint-dom-enum+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_dom_enum_Output;

public class testCnstDomEnumOutp
  : ItestCnstDomEnumOutp
{
}

public class testRefCnstDomEnumOutp<TType>
  : ItestRefCnstDomEnumOutp<TType>
{
  public TType Field { get; set; }
}

public class testJustCnstDomEnumOutp
  : GqlpDomainEnum
  , ItestJustCnstDomEnumOutp
{
}
