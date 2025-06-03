//HintName: Model_generic-parent-enum-dom+Output.gen.cs
// Generated from generic-parent-enum-dom+Output.graphql+

/*
*/

namespace GqlTest.Model_generic_parent_enum_dom_Output;

public interface IGnrcPrntEnumDomOutp
  : IFieldGnrcPrntEnumDomOutp
{
}
public class OutputGnrcPrntEnumDomOutp
  : OutputFieldGnrcPrntEnumDomOutp
  , IGnrcPrntEnumDomOutp
{
}

public interface IFieldGnrcPrntEnumDomOutp<Tref>
{
  Tref field { get; }
}
public class OutputFieldGnrcPrntEnumDomOutp<Tref>
  : IFieldGnrcPrntEnumDomOutp<Tref>
{
  public Tref field { get; set; }
}

public enum EnumGnrcPrntEnumDomOutp
{
  gnrcPrntEnumDomOutpLabel,
  gnrcPrntEnumDomOutpOther,
}

public interface IDomGnrcPrntEnumDomOutp
{
}
public class DomainDomGnrcPrntEnumDomOutp
  : IDomGnrcPrntEnumDomOutp
{
}
