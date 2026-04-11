//HintName: test_generic-alt-arg-descr+Output_Model.gen.cs
// Generated from {CurrentDirectory}generic-alt-arg-descr+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_descr_Output;

public class testGnrcAltArgDescrOutp<TType>
  : GqlpModelBase
  , ItestGnrcAltArgDescrOutp<TType>
{
  public ItestRefGnrcAltArgDescrOutp<TType>? AsRefGnrcAltArgDescrOutp { get; set; }
  public ItestGnrcAltArgDescrOutpObject<TType>? As_GnrcAltArgDescrOutp { get; set; }
}

public class testGnrcAltArgDescrOutpObject<TType>
  : GqlpModelBase
  , ItestGnrcAltArgDescrOutpObject<TType>
{

  public testGnrcAltArgDescrOutpObject
    ()
  {
  }
}

public class testRefGnrcAltArgDescrOutp<TRef>
  : GqlpModelBase
  , ItestRefGnrcAltArgDescrOutp<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcAltArgDescrOutpObject<TRef>? As_RefGnrcAltArgDescrOutp { get; set; }
}

public class testRefGnrcAltArgDescrOutpObject<TRef>
  : GqlpModelBase
  , ItestRefGnrcAltArgDescrOutpObject<TRef>
{

  public testRefGnrcAltArgDescrOutpObject
    ()
  {
  }
}
