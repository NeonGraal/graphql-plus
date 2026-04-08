//HintName: test_generic-alt-mod-String+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-alt-mod-String+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_mod_String_Input;

public class testRefGnrcAltModStrInp<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcAltModStrInp<TRef>
{
  public IDictionary<string, TRef>? Asref { get; set; }
  public ItestRefGnrcAltModStrInpObject<TRef>? As_RefGnrcAltModStrInp { get; set; }
}

public class testRefGnrcAltModStrInpObject<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcAltModStrInpObject<TRef>
{

  public testRefGnrcAltModStrInpObject
    ()
  {
  }
}
