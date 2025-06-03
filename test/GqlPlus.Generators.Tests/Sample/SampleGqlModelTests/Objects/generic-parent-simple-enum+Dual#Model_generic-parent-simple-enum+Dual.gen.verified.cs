//HintName: Model_generic-parent-simple-enum+Dual.gen.cs
// Generated from generic-parent-simple-enum+Dual.graphql+

/*
*/

namespace GqlTest.Model_generic_parent_simple_enum_Dual;

public interface IGnrcPrntSmplEnumDual
  : IFieldGnrcPrntSmplEnumDual
{
}
public class DualGnrcPrntSmplEnumDual
  : DualFieldGnrcPrntSmplEnumDual
  , IGnrcPrntSmplEnumDual
{
}

public interface IFieldGnrcPrntSmplEnumDual<Tref>
{
  Tref field { get; }
}
public class DualFieldGnrcPrntSmplEnumDual<Tref>
  : IFieldGnrcPrntSmplEnumDual<Tref>
{
  public Tref field { get; set; }
}

public enum EnumGnrcPrntSmplEnumDual
{
  gnrcPrntSmplEnumDual,
}
