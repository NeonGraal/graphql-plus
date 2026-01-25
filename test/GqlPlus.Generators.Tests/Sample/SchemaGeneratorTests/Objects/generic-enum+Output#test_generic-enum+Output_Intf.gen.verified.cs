//HintName: test_generic-enum+Output_Intf.gen.cs
// Generated from generic-enum+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_enum_Output;

public interface ItestGnrcEnumOutp
{
  public testRefGnrcEnumOutp<testEnumGnrcEnumOutp> AsRefGnrcEnumOutp { get; set; }
  public testGnrcEnumOutp GnrcEnumOutp { get; set; }
}

public interface ItestGnrcEnumOutpObject
{
}

public interface ItestRefGnrcEnumOutp<Ttype>
{
  public testRefGnrcEnumOutp RefGnrcEnumOutp { get; set; }
}

public interface ItestRefGnrcEnumOutpObject<Ttype>
{
  public Ttype field { get; set; }
}
