//HintName: test_generic-alt-arg+Output_Model.gen.cs
// Generated from {CurrentDirectory}generic-alt-arg+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_Output;

public class testGnrcAltArgOutp<TType>
  : GqlpModelBase
  , ItestGnrcAltArgOutp<TType>
{
  public ItestRefGnrcAltArgOutp<TType>? AsRefGnrcAltArgOutp { get; set; }
  public ItestGnrcAltArgOutpObject<TType>? As_GnrcAltArgOutp { get; set; }
}

public class testGnrcAltArgOutpObject<TType>
  : GqlpModelBase
  , ItestGnrcAltArgOutpObject<TType>
{

  public testGnrcAltArgOutpObject
    ()
  {
  }
}

public class testRefGnrcAltArgOutp<TRef>
  : GqlpModelBase
  , ItestRefGnrcAltArgOutp<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcAltArgOutpObject<TRef>? As_RefGnrcAltArgOutp { get; set; }
}

public class testRefGnrcAltArgOutpObject<TRef>
  : GqlpModelBase
  , ItestRefGnrcAltArgOutpObject<TRef>
{

  public testRefGnrcAltArgOutpObject
    ()
  {
  }
}
