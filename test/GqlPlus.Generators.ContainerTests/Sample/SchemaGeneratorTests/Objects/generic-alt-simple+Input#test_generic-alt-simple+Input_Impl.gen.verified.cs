//HintName: test_generic-alt-simple+Input_Impl.gen.cs
// Generated from {CurrentDirectory}generic-alt-simple+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_simple_Input;

public class testGnrcAltSmplInp
  : GqlpModelImplementationBase
  , ItestGnrcAltSmplInp
{
  public ItestRefGnrcAltSmplInp<string>? AsRefGnrcAltSmplInp { get; set; }
  public ItestGnrcAltSmplInpObject? As_GnrcAltSmplInp { get; set; }
}

public class testGnrcAltSmplInpObject
  : GqlpModelImplementationBase
  , ItestGnrcAltSmplInpObject
{

  public testGnrcAltSmplInpObject
    ()
  {
  }
}

public class testRefGnrcAltSmplInp<TRef>
  : GqlpModelImplementationBase
  , ItestRefGnrcAltSmplInp<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcAltSmplInpObject<TRef>? As_RefGnrcAltSmplInp { get; set; }
}

public class testRefGnrcAltSmplInpObject<TRef>
  : GqlpModelImplementationBase
  , ItestRefGnrcAltSmplInpObject<TRef>
{

  public testRefGnrcAltSmplInpObject
    ()
  {
  }
}
