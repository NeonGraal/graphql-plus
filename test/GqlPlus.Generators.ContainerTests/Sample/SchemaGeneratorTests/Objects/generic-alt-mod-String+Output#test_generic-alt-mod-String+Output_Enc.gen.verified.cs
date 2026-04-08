//HintName: test_generic-alt-mod-String+Output_Enc.gen.cs
// Generated from {CurrentDirectory}generic-alt-mod-String+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_mod_String_Output;

public class testRefGnrcAltModStrOutp<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcAltModStrOutp<TRef>
{
  public IDictionary<string, TRef>? Asref { get; set; }
  public ItestRefGnrcAltModStrOutpObject<TRef>? As_RefGnrcAltModStrOutp { get; set; }
}

public class testRefGnrcAltModStrOutpObject<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcAltModStrOutpObject<TRef>
{

  public testRefGnrcAltModStrOutpObject
    ()
  {
  }
}
