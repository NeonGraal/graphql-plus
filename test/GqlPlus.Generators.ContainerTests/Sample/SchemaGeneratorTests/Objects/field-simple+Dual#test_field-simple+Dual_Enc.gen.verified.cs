//HintName: test_field-simple+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}field-simple+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_simple_Dual;

public class testFieldSmplDual
  : GqlpEncoderBase
  , ItestFieldSmplDual
{
  public ItestFieldSmplDualObject? As_FieldSmplDual { get; set; }
}

public class testFieldSmplDualObject
  : GqlpEncoderBase
  , ItestFieldSmplDualObject
{
  public decimal Field { get; set; }

  public testFieldSmplDualObject
    ( decimal field
    )
  {
    Field = field;
  }
}
