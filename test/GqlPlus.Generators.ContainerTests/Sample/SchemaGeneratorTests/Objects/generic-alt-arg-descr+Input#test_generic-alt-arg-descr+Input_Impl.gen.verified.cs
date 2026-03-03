//HintName: test_generic-alt-arg-descr+Input_Impl.gen.cs
// Generated from {CurrentDirectory}generic-alt-arg-descr+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_descr_Input;

public class testGnrcAltArgDescrInp<TType>
  : GqlpModelImplementationBase
  , ItestGnrcAltArgDescrInp<TType>
{
  public ItestRefGnrcAltArgDescrInp<TType>? AsRefGnrcAltArgDescrInp { get; set; }
  public ItestGnrcAltArgDescrInpObject<TType>? As_GnrcAltArgDescrInp { get; set; }
}

public class testGnrcAltArgDescrInpObject<TType>
  : GqlpModelImplementationBase
  , ItestGnrcAltArgDescrInpObject<TType>
{

  public testGnrcAltArgDescrInpObject
    ()
  {
  }
}

public class testRefGnrcAltArgDescrInp<TRef>
  : GqlpModelImplementationBase
  , ItestRefGnrcAltArgDescrInp<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcAltArgDescrInpObject<TRef>? As_RefGnrcAltArgDescrInp { get; set; }
}

public class testRefGnrcAltArgDescrInpObject<TRef>
  : GqlpModelImplementationBase
  , ItestRefGnrcAltArgDescrInpObject<TRef>
{

  public testRefGnrcAltArgDescrInpObject
    ()
  {
  }
}
