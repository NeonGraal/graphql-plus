//HintName: Model_generic-parent-simple-enum+Output.gen.cs
// Generated from generic-parent-simple-enum+Output.graphql+

/*
*/

namespace GqlTest.Model_generic_parent_simple_enum_Output;

public interface IGnrcPrntSmplEnumOutp
  : IFieldGnrcPrntSmplEnumOutp
{
}
public class OutputGnrcPrntSmplEnumOutp
  : OutputFieldGnrcPrntSmplEnumOutp
  , IGnrcPrntSmplEnumOutp
{
}

public interface IFieldGnrcPrntSmplEnumOutp<Tref>
{
  Tref field { get; }
}
public class OutputFieldGnrcPrntSmplEnumOutp<Tref>
  : IFieldGnrcPrntSmplEnumOutp<Tref>
{
  public Tref field { get; set; }
}

public enum EnumGnrcPrntSmplEnumOutp
{
  gnrcPrntSmplEnumOutp,
}
