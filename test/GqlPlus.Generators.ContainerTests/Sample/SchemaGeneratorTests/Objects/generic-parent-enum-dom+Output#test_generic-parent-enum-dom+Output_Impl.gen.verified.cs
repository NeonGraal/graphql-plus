//HintName: test_generic-parent-enum-dom+Output_Impl.gen.cs
// Generated from generic-parent-enum-dom+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_dom_Output;

public class testGnrcPrntEnumDomOutp
  : testFieldGnrcPrntEnumDomOutp
  , ItestGnrcPrntEnumDomOutp
{
  public ItestGnrcPrntEnumDomOutpObject AsGnrcPrntEnumDomOutp { get; set; }
}

public class testFieldGnrcPrntEnumDomOutp<Tref>
  : ItestFieldGnrcPrntEnumDomOutp<Tref>
{
  public Tref Field { get; set; }
  public ItestFieldGnrcPrntEnumDomOutpObject AsFieldGnrcPrntEnumDomOutp { get; set; }
}

public class testDomGnrcPrntEnumDomOutp
  : DomainEnum
  , ItestDomGnrcPrntEnumDomOutp
{
}
