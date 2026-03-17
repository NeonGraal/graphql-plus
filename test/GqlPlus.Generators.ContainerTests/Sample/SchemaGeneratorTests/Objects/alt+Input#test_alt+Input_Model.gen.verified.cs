//HintName: test_alt+Input_Model.gen.cs
// Generated from {CurrentDirectory}alt+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_Input;

public class testAltInp
  : GqlpModelImplementationBase
  , ItestAltInp
{
  public ItestAltAltInp? AsAltAltInp { get; set; }
  public ItestAltInpObject? As_AltInp { get; set; }
}

public class testAltInpObject
  : GqlpModelImplementationBase
  , ItestAltInpObject
{
}

public class testAltAltInp
  : GqlpModelImplementationBase
  , ItestAltAltInp
{
  public string? AsString { get; set; }
  public ItestAltAltInpObject? As_AltAltInp { get; set; }
}

public class testAltAltInpObject
  : GqlpModelImplementationBase
  , ItestAltAltInpObject
{
  public decimal Alt { get; set; }

  public testAltAltInpObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
