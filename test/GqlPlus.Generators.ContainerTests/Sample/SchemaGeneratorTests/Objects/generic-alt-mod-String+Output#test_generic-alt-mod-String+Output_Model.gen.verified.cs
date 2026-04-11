//HintName: test_generic-alt-mod-String+Output_Model.gen.cs
// Generated from {CurrentDirectory}generic-alt-mod-String+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_mod_String_Output;

public class testRefGnrcAltModStrOutp<TRef>
  : GqlpModelBase
  , ItestRefGnrcAltModStrOutp<TRef>
{
  public IDictionary<string, TRef>? Asref { get; set; }
  public ItestRefGnrcAltModStrOutpObject<TRef>? As_RefGnrcAltModStrOutp { get; set; }
}

public class testRefGnrcAltModStrOutpObject<TRef>
  : GqlpModelBase
  , ItestRefGnrcAltModStrOutpObject<TRef>
{

  public testRefGnrcAltModStrOutpObject
    ()
  {
  }
}
