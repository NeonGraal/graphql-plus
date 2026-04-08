//HintName: test_generic-field-arg+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-field-arg+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_arg_Input;

public class testGnrcFieldArgInp<TType>
  : GqlpEncoderBase
  , ItestGnrcFieldArgInp<TType>
{
  public ItestGnrcFieldArgInpObject<TType>? As_GnrcFieldArgInp { get; set; }
}

public class testGnrcFieldArgInpObject<TType>
  : GqlpEncoderBase
  , ItestGnrcFieldArgInpObject<TType>
{
  public ItestRefGnrcFieldArgInp<TType> Field { get; set; }

  public testGnrcFieldArgInpObject
    ( ItestRefGnrcFieldArgInp<TType> field
    )
  {
    Field = field;
  }
}

public class testRefGnrcFieldArgInp<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcFieldArgInp<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcFieldArgInpObject<TRef>? As_RefGnrcFieldArgInp { get; set; }
}

public class testRefGnrcFieldArgInpObject<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcFieldArgInpObject<TRef>
{

  public testRefGnrcFieldArgInpObject
    ()
  {
  }
}
