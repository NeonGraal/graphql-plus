//HintName: test_generic-alt-arg-descr+Input_Model.gen.cs
// Generated from {CurrentDirectory}generic-alt-arg-descr+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_descr_Input;

public class testGnrcAltArgDescrInp<TType>
  : GqlpModelBase
  , ItestGnrcAltArgDescrInp<TType>
{
  public ItestRefGnrcAltArgDescrInp<TType>? AsRefGnrcAltArgDescrInp { get; set; }
  public ItestGnrcAltArgDescrInpObject<TType>? As_GnrcAltArgDescrInp { get; set; }
}

public class testGnrcAltArgDescrInpObject<TType>
  : GqlpModelBase
  , ItestGnrcAltArgDescrInpObject<TType>
{

  public testGnrcAltArgDescrInpObject
    ()
  {
  }
}

public class testRefGnrcAltArgDescrInp<TRef>
  : GqlpModelBase
  , ItestRefGnrcAltArgDescrInp<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcAltArgDescrInpObject<TRef>? As_RefGnrcAltArgDescrInp { get; set; }
}

public class testRefGnrcAltArgDescrInpObject<TRef>
  : GqlpModelBase
  , ItestRefGnrcAltArgDescrInpObject<TRef>
{

  public testRefGnrcAltArgDescrInpObject
    ()
  {
  }
}
