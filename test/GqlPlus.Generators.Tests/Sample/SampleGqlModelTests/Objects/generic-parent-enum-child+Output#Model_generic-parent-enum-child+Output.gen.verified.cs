//HintName: Model_generic-parent-enum-child+Output.gen.cs
// Generated from generic-parent-enum-child+Output.graphql+

/*
*/

namespace GqlTest.Model_generic_parent_enum_child_Output;

public interface IGnrcPrntEnumChildOutp
  : IFieldGnrcPrntEnumChildOutp
{
}
public class OutputGnrcPrntEnumChildOutp
  : OutputFieldGnrcPrntEnumChildOutp
  , IGnrcPrntEnumChildOutp
{
}

public interface IFieldGnrcPrntEnumChildOutp<Tref>
{
  Tref field { get; }
}
public class OutputFieldGnrcPrntEnumChildOutp<Tref>
  : IFieldGnrcPrntEnumChildOutp<Tref>
{
  public Tref field { get; set; }
}

public enum EnumGnrcPrntEnumChildOutp
{
  gnrcPrntEnumChildOutpParent = ParentGnrcPrntEnumChildOutp.gnrcPrntEnumChildOutpParent,,
  gnrcPrntEnumChildOutpLabel,
}

public enum ParentGnrcPrntEnumChildOutp
{
  gnrcPrntEnumChildOutpParent,
}
