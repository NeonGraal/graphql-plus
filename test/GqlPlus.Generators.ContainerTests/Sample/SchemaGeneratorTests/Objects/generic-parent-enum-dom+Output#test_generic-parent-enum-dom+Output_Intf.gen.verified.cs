//HintName: test_generic-parent-enum-dom+Output_Intf.gen.cs
// Generated from generic-parent-enum-dom+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_dom_Output;

public interface ItestGnrcPrntEnumDomOutp
  : ItestFieldGnrcPrntEnumDomOutp
{
  public ItestGnrcPrntEnumDomOutpObject AsGnrcPrntEnumDomOutp { get; set; }
}

public interface ItestGnrcPrntEnumDomOutpObject
  : ItestFieldGnrcPrntEnumDomOutpObject
{
}

public interface ItestFieldGnrcPrntEnumDomOutp<Tref>
{
  public ItestFieldGnrcPrntEnumDomOutpObject AsFieldGnrcPrntEnumDomOutp { get; set; }
}

public interface ItestFieldGnrcPrntEnumDomOutpObject<Tref>
{
  public Tref Field { get; set; }
}

public interface ItestDomGnrcPrntEnumDomOutp
  : IDomainEnum
{
}
