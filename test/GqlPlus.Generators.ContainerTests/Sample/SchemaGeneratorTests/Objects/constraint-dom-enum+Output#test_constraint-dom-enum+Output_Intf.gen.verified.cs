//HintName: test_constraint-dom-enum+Output_Intf.gen.cs
// Generated from constraint-dom-enum+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_dom_enum_Output;

public interface ItestCnstDomEnumOutp
{
  ItestRefCnstDomEnumOutp<testEnumCnstDomEnumOutp> AsEnumCnstDomEnumOutpcnstDomEnumOutp { get; }
  ItestCnstDomEnumOutpObject AsCnstDomEnumOutp { get; }
}

public interface ItestCnstDomEnumOutpObject
{
}

public interface ItestRefCnstDomEnumOutp<TType>
{
  ItestRefCnstDomEnumOutpObject AsRefCnstDomEnumOutp { get; }
}

public interface ItestRefCnstDomEnumOutpObject<TType>
{
  TType Field { get; }
}

public interface ItestJustCnstDomEnumOutp
  : IDomainEnum
{
}
