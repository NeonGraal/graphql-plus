//HintName: test_generic-alt-simple+Output_Model.gen.cs
// Generated from {CurrentDirectory}generic-alt-simple+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_simple_Output;

public class testGnrcAltSmplOutp
  : GqlpModelBase
  , ItestGnrcAltSmplOutp
{
  public ItestRefGnrcAltSmplOutp<string>? AsRefGnrcAltSmplOutp { get; set; }
  public ItestGnrcAltSmplOutpObject? As_GnrcAltSmplOutp { get; set; }
}

public class testGnrcAltSmplOutpObject
  : GqlpModelBase
  , ItestGnrcAltSmplOutpObject
{

  public testGnrcAltSmplOutpObject
    ()
  {
  }
}

public class testRefGnrcAltSmplOutp<TRef>
  : GqlpModelBase
  , ItestRefGnrcAltSmplOutp<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcAltSmplOutpObject<TRef>? As_RefGnrcAltSmplOutp { get; set; }
}

public class testRefGnrcAltSmplOutpObject<TRef>
  : GqlpModelBase
  , ItestRefGnrcAltSmplOutpObject<TRef>
{

  public testRefGnrcAltSmplOutpObject
    ()
  {
  }
}
