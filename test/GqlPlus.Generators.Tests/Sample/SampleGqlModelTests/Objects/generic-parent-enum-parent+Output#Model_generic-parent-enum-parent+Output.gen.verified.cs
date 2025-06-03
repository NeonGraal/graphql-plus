//HintName: Model_generic-parent-enum-parent+Output.gen.cs
// Generated from generic-parent-enum-parent+Output.graphql+

/*
*/

namespace GqlTest.Model_generic_parent_enum_parent_Output;

public interface IGnrcPrntEnumPrntOutp
  : IFieldGnrcPrntEnumPrntOutp
{
}
public class OutputGnrcPrntEnumPrntOutp
  : OutputFieldGnrcPrntEnumPrntOutp
  , IGnrcPrntEnumPrntOutp
{
}

public interface IFieldGnrcPrntEnumPrntOutp<Tref>
{
  Tref field { get; }
}
public class OutputFieldGnrcPrntEnumPrntOutp<Tref>
  : IFieldGnrcPrntEnumPrntOutp<Tref>
{
  public Tref field { get; set; }
}

public enum EnumGnrcPrntEnumPrntOutp
{
  gnrcPrntEnumPrntOutpParent = ParentGnrcPrntEnumPrntOutp.gnrcPrntEnumPrntOutpParent,,
  gnrcPrntEnumPrntOutpLabel,
}

public enum ParentGnrcPrntEnumPrntOutp
{
  gnrcPrntEnumPrntOutpParent,
}
