//HintName: test_generic-alt-simple+Input_Model.gen.cs
// Generated from {CurrentDirectory}generic-alt-simple+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_simple_Input;

public class testGnrcAltSmplInp
  : GqlpModelBase
  , ItestGnrcAltSmplInp
{
  public ItestRefGnrcAltSmplInp<string>? AsRefGnrcAltSmplInp { get; set; }
  public ItestGnrcAltSmplInpObject? As_GnrcAltSmplInp { get; set; }
}

public class testGnrcAltSmplInpObject
  : GqlpModelBase
  , ItestGnrcAltSmplInpObject
{

  public testGnrcAltSmplInpObject
    ()
  {
  }
}

public class testRefGnrcAltSmplInp<TRef>
  : GqlpModelBase
  , ItestRefGnrcAltSmplInp<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcAltSmplInpObject<TRef>? As_RefGnrcAltSmplInp { get; set; }
}

public class testRefGnrcAltSmplInpObject<TRef>
  : GqlpModelBase
  , ItestRefGnrcAltSmplInpObject<TRef>
{

  public testRefGnrcAltSmplInpObject
    ()
  {
  }
}
