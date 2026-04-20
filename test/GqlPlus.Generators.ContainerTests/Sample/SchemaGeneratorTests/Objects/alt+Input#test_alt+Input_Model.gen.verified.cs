//HintName: test_alt+Input_Model.gen.cs
// Generated from {CurrentDirectory}alt+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_Input;

public class testAltInp
  : GqlpModelBase
  , ItestAltInp
{
  public ItestAltAltInp? AsAltAltInp { get; set; }
  public ItestAltInpObject? As_AltInp { get; set; }
}

public class testAltInpObject
  : GqlpModelBase
  , ItestAltInpObject
{

  public testAltInpObject
    ()
  {
  }
}

public class testAltAltInp
  : GqlpModelBase
  , ItestAltAltInp
{
  public string? AsString { get; set; }
  public ItestAltAltInpObject? As_AltAltInp { get; set; }
}

public class testAltAltInpObject
  : GqlpModelBase
  , ItestAltAltInpObject
{
  public decimal Alt { get; set; }

  public testAltAltInpObject
    ( decimal palt
    )
  {
    Alt = palt;
  }
}
