//HintName: test_generic-descr+Output_Enc.gen.cs
// Generated from {CurrentDirectory}generic-descr+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_descr_Output;

public class testGnrcDescrOutp<TType>
  : GqlpEncoderBase
  , ItestGnrcDescrOutp<TType>
{
  public ItestGnrcDescrOutpObject<TType>? As_GnrcDescrOutp { get; set; }
}

public class testGnrcDescrOutpObject<TType>
  : GqlpEncoderBase
  , ItestGnrcDescrOutpObject<TType>
{
  public TType Field { get; set; }

  public testGnrcDescrOutpObject
    ( TType field
    )
  {
    Field = field;
  }
}
