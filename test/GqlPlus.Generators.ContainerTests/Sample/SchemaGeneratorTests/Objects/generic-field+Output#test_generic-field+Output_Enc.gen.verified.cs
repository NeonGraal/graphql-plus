//HintName: test_generic-field+Output_Enc.gen.cs
// Generated from {CurrentDirectory}generic-field+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_Output;

public class testGnrcFieldOutp<TType>
  : GqlpEncoderBase
  , ItestGnrcFieldOutp<TType>
{
  public ItestGnrcFieldOutpObject<TType>? As_GnrcFieldOutp { get; set; }
}

public class testGnrcFieldOutpObject<TType>
  : GqlpEncoderBase
  , ItestGnrcFieldOutpObject<TType>
{
  public TType Field { get; set; }

  public testGnrcFieldOutpObject
    ( TType field
    )
  {
    Field = field;
  }
}
