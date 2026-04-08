//HintName: test_field+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}field+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_Dual;

public class testFieldDual
  : GqlpEncoderBase
  , ItestFieldDual
{
  public ItestFieldDualObject? As_FieldDual { get; set; }
}

public class testFieldDualObject
  : GqlpEncoderBase
  , ItestFieldDualObject
{
  public string Field { get; set; }

  public testFieldDualObject
    ( string field
    )
  {
    Field = field;
  }
}
