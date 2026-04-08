//HintName: test_generic-alt-mod-String+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}generic-alt-mod-String+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_mod_String_Dual;

public class testRefGnrcAltModStrDual<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcAltModStrDual<TRef>
{
  public IDictionary<string, TRef>? Asref { get; set; }
  public ItestRefGnrcAltModStrDualObject<TRef>? As_RefGnrcAltModStrDual { get; set; }
}

public class testRefGnrcAltModStrDualObject<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcAltModStrDualObject<TRef>
{

  public testRefGnrcAltModStrDualObject
    ()
  {
  }
}
