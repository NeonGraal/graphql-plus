//HintName: test_generic-alt-mod-String+Input_Impl.gen.cs
// Generated from {CurrentDirectory}generic-alt-mod-String+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_mod_String_Input;

public class testRefGnrcAltModStrInp<TRef>
  : GqlpModelImplementationBase
  , ItestRefGnrcAltModStrInp<TRef>
{
  public IDictionary<string, TRef>? Asref { get; set; }
  public ItestRefGnrcAltModStrInpObject<TRef>? As_RefGnrcAltModStrInp { get; set; }
}

public class testRefGnrcAltModStrInpObject<TRef>
  : GqlpModelImplementationBase
  , ItestRefGnrcAltModStrInpObject<TRef>
{

  public testRefGnrcAltModStrInpObject()
  {
  }
}
