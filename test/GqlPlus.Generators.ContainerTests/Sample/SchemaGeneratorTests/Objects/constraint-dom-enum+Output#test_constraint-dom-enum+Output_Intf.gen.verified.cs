//HintName: test_constraint-dom-enum+Output_Intf.gen.cs
// Generated from constraint-dom-enum+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_dom_enum_Output;

public interface ItestCnstDomEnumOutp
{
  public ItestRefCnstDomEnumOutp<ItestEnumCnstDomEnumOutp> AsRefCnstDomEnumOutp { get; set; }
  public ItestCnstDomEnumOutpObject AsCnstDomEnumOutp { get; set; }
}

public interface ItestCnstDomEnumOutpObject
{
}

public interface ItestRefCnstDomEnumOutp<Ttype>
{
  public ItestRefCnstDomEnumOutpObject AsRefCnstDomEnumOutp { get; set; }
}

public interface ItestRefCnstDomEnumOutpObject<Ttype>
{
  public Ttype Field { get; set; }
}

public interface ItestJustCnstDomEnumOutp
  : IDomainEnum
{
}
