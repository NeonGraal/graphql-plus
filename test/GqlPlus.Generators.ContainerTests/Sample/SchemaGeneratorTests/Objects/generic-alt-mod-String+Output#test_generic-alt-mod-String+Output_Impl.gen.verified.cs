//HintName: test_generic-alt-mod-String+Output_Impl.gen.cs
// Generated from {CurrentDirectory}generic-alt-mod-String+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_mod_String_Output;

public class testRefGnrcAltModStrOutp<TRef>
  : GqlpModelImplementationBase
  , ItestRefGnrcAltModStrOutp<TRef>
{
  public IDictionary<string, TRef>? Asref { get; set; }
  public ItestRefGnrcAltModStrOutpObject<TRef>? As_RefGnrcAltModStrOutp { get; set; }
}

public class testRefGnrcAltModStrOutpObject<TRef>
  : GqlpModelImplementationBase
  , ItestRefGnrcAltModStrOutpObject<TRef>
{

  public testRefGnrcAltModStrOutpObject
    ()
  {
  }
}
