//HintName: test_constraint-dom-enum+Output_Intf.gen.cs
// Generated from constraint-dom-enum+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_dom_enum_Output;

public interface ItestCnstDomEnumOutp
{
  public testRefCnstDomEnumOutp<testEnumCnstDomEnumOutp> AsRefCnstDomEnumOutp { get; set; }
  public testCnstDomEnumOutp CnstDomEnumOutp { get; set; }
}

public interface ItestCnstDomEnumOutpObject
{
}

public interface ItestRefCnstDomEnumOutp<Ttype>
{
  public testRefCnstDomEnumOutp RefCnstDomEnumOutp { get; set; }
}

public interface ItestRefCnstDomEnumOutpObject<Ttype>
{
  public Ttype field { get; set; }
}

public interface ItestJustCnstDomEnumOutp
  : IDomainEnum
{
}
