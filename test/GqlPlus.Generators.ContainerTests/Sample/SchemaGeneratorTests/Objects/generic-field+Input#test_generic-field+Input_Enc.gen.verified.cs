//HintName: test_generic-field+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-field+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_Input;

public class testGnrcFieldInp<TType>
  : GqlpEncoderBase
  , ItestGnrcFieldInp<TType>
{
  public ItestGnrcFieldInpObject<TType>? As_GnrcFieldInp { get; set; }
}

public class testGnrcFieldInpObject<TType>
  : GqlpEncoderBase
  , ItestGnrcFieldInpObject<TType>
{
  public TType Field { get; set; }

  public testGnrcFieldInpObject
    ( TType field
    )
  {
    Field = field;
  }
}
